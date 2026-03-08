using BlossomInstitute.Common.Features;
using BlossomInstitute.Domain.Entidades.Tarea;
using BlossomInstitute.Domain.Entidades.Usuario;
using BlossomInstitute.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlossomInstitute.Application.DataBase.Tarea.Commands.UpdateTarea
{
    public class UpdateTareaCommand : IUpdateTareaCommand
    {
        private readonly IDataBaseService _db;
        private readonly UserManager<UsuarioEntity> _userManager;

        public UpdateTareaCommand(IDataBaseService db, UserManager<UsuarioEntity> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<BaseResponseModel> Execute(
            int cursoId,
            int tareaId,
            int profesorUserId,
            UpdateTareaModel model,
            CancellationToken ct = default)
        {
            if (cursoId <= 0)
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, "CursoId inválido");

            if (tareaId <= 0)
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, "TareaId inválido");

            if (profesorUserId <= 0)
                return ResponseApiService.Response(StatusCodes.Status401Unauthorized, "No autenticado");

            var user = await _userManager.FindByIdAsync(profesorUserId.ToString());
            if (user == null || !user.Activo)
                return ResponseApiService.Response(StatusCodes.Status403Forbidden, "Usuario inválido o inactivo");

            if (!await _userManager.IsInRoleAsync(user, "Profesor"))
                return ResponseApiService.Response(StatusCodes.Status403Forbidden, "Acceso denegado");

            var profesorAsignado = await _db.CursoProfesores.AsNoTracking()
                .AnyAsync(x => x.CursoId == cursoId && x.ProfesorId == profesorUserId, ct);

            if (!profesorAsignado)
                return ResponseApiService.Response(StatusCodes.Status403Forbidden, "No estás asignado a este curso");

            var tarea = await _db.Tareas
                .Include(t => t.Recursos)
                .FirstOrDefaultAsync(t => t.Id == tareaId && t.CursoId == cursoId, ct);

            if (tarea == null)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Tarea no encontrada");

            var estadoAnterior = tarea.Estado;
            var estadoNuevo = model.Estado;
            var nowUtc = DateTime.UtcNow;

            await using var tx = await _db.BeginTransactionAsync(ct);

            try
            {
                tarea.Titulo = model.Titulo.Trim();
                tarea.Consigna = model.Consigna?.Trim();
                tarea.FechaEntregaUtc = model.FechaEntregaUtc;
                tarea.Estado = estadoNuevo;
                tarea.UpdatedAtUtc = nowUtc;

                // Reemplazar recursos
                tarea.Recursos.Clear();
                if (model.Recursos != null && model.Recursos.Count > 0)
                {
                    foreach (var r in model.Recursos)
                    {
                        tarea.Recursos.Add(new TareaRecursoEntity
                        {
                            Tipo = r.Tipo,
                            Url = r.Url.Trim(),
                            Nombre = r.Nombre?.Trim()
                        });
                    }
                }

                // Si pasa a Archivada => archivar calificaciones asociadas por tarea
                if (estadoAnterior != EstadoTarea.Archivada && estadoNuevo == EstadoTarea.Archivada)
                {
                    await _db.Calificaciones
                        .Where(c => c.TareaId == tareaId && !c.Archivado)
                        .ExecuteUpdateAsync(s => s
                            .SetProperty(x => x.Archivado, true)
                            .SetProperty(x => x.ArchivadoPorTarea, true)
                            .SetProperty(x => x.UpdatedAtUtc, nowUtc), ct);
                }

                // Si sale de Archivada => desarchivar SOLO las archivadas por tarea
                if (estadoAnterior == EstadoTarea.Archivada && estadoNuevo != EstadoTarea.Archivada)
                {
                    await _db.Calificaciones
                        .Where(c => c.TareaId == tareaId && c.Archivado && c.ArchivadoPorTarea)
                        .ExecuteUpdateAsync(s => s
                            .SetProperty(x => x.Archivado, false)
                            .SetProperty(x => x.ArchivadoPorTarea, false)
                            .SetProperty(x => x.UpdatedAtUtc, nowUtc), ct);
                }

                var ok = await _db.SaveAsync(ct);
                if (!ok)
                {
                    await tx.RollbackAsync(ct);
                    return ResponseApiService.Response(StatusCodes.Status500InternalServerError, "No se pudo actualizar la tarea");
                }

                await tx.CommitAsync(ct);

                return ResponseApiService.Response(StatusCodes.Status200OK, new
                {
                    tarea.Id,
                    tarea.CursoId,
                    tarea.Titulo,
                    tarea.Estado,
                    tarea.FechaEntregaUtc
                }, "Tarea actualizada correctamente");
            }
            catch
            {
                await tx.RollbackAsync(ct);
                throw;
            }
        }
    }
}
