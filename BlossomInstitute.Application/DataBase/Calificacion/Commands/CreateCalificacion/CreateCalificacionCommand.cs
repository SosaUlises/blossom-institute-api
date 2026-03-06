using BlossomInstitute.Common.Features;
using BlossomInstitute.Domain.Entidades.Calificaciones;
using BlossomInstitute.Domain.Entidades.Usuario;
using BlossomInstitute.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlossomInstitute.Application.DataBase.Calificacion.Commands.CreateCalificacion
{
    public class CreateCalificacionCommand : ICreateCalificacionCommand
    {
        private readonly IDataBaseService _db;
        private readonly UserManager<UsuarioEntity> _userManager;

        public CreateCalificacionCommand(IDataBaseService db, UserManager<UsuarioEntity> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<BaseResponseModel> Execute(
            int cursoId,
            int alumnoId,
            int profesorUserId,
            CreateCalificacionModel model,
            CancellationToken ct)
        {
            if (cursoId <= 0 || alumnoId <= 0)
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, "Parámetros inválidos");

            var profesor = await _userManager.FindByIdAsync(profesorUserId.ToString());
            if (profesor == null)
                return ResponseApiService.Response(StatusCodes.Status401Unauthorized, "No autenticado");

            if (!profesor.Activo)
                return ResponseApiService.Response(StatusCodes.Status403Forbidden, "Usuario inactivo");

            if (!await _userManager.IsInRoleAsync(profesor, "Profesor"))
                return ResponseApiService.Response(StatusCodes.Status403Forbidden, "No autorizado");

            var curso = await _db.Cursos.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == cursoId, ct);

            if (curso == null)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Curso no encontrado");

            var profesorAsignado = await _db.CursoProfesores.AsNoTracking()
                .AnyAsync(x => x.CursoId == cursoId && x.ProfesorId == profesorUserId, ct);

            if (!profesorAsignado)
                return ResponseApiService.Response(StatusCodes.Status403Forbidden, "Profesor no asignado a este curso");

            var matriculado = await _db.Matriculas.AsNoTracking()
                .AnyAsync(x => x.CursoId == cursoId && x.AlumnoId == alumnoId, ct);

            if (!matriculado)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Alumno no matriculado en el curso");

            if (model.TareaId.HasValue)
            {
                var tareaValida = await _db.Tareas.AsNoTracking()
                    .AnyAsync(t => t.Id == model.TareaId.Value && t.CursoId == cursoId, ct);

                if (!tareaValida)
                    return ResponseApiService.Response(StatusCodes.Status409Conflict, "La tarea no pertenece al curso");
            }

            if (model.EntregaId.HasValue)
            {
                var entregaValida = await _db.Entregas.AsNoTracking()
                    .AnyAsync(e => e.Id == model.EntregaId.Value && e.AlumnoId == alumnoId, ct);

                if (!entregaValida)
                    return ResponseApiService.Response(StatusCodes.Status409Conflict, "La entrega no corresponde al alumno");
            }

            var calificacion = new CalificacionEntity
            {
                CursoId = cursoId,
                AlumnoId = alumnoId,
                Tipo = model.Tipo,
                Titulo = model.Titulo.Trim(),
                Descripcion = string.IsNullOrWhiteSpace(model.Descripcion) ? null : model.Descripcion.Trim(),
                Nota = model.Nota,
                Fecha = model.Fecha,
                TareaId = model.TareaId,
                EntregaId = model.EntregaId,
                CreatedAtUtc = DateTime.UtcNow,
                Archivado = false
            };

            await using var tx = await _db.BeginTransactionAsync(ct);

            try
            {
                _db.Calificaciones.Add(calificacion);

                var ok = await _db.SaveAsync(ct);
                if (!ok)
                {
                    await tx.RollbackAsync(ct);
                    return ResponseApiService.Response(StatusCodes.Status500InternalServerError, "No se pudo guardar la calificación");
                }

                await tx.CommitAsync(ct);

                return ResponseApiService.Response(StatusCodes.Status201Created, new
                {
                    calificacion.Id,
                    calificacion.CursoId,
                    calificacion.AlumnoId,
                    calificacion.Titulo,
                    calificacion.Nota,
                    calificacion.Fecha
                }, "Calificación registrada correctamente");
            }
            catch
            {
                await tx.RollbackAsync(ct);
                throw;
            }
        }
    }
}
