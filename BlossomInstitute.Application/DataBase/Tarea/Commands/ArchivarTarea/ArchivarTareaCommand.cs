using BlossomInstitute.Common.Features;
using BlossomInstitute.Domain.Entidades.Tarea;
using BlossomInstitute.Domain.Entidades.Usuario;
using BlossomInstitute.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlossomInstitute.Application.DataBase.Tarea.Commands.ArchivarTarea
{
    public class ArchivarTareaCommand : IArchivarTareaCommand
    {
        private readonly IDataBaseService _db;
        private readonly UserManager<UsuarioEntity> _userManager;

        public ArchivarTareaCommand(IDataBaseService db, UserManager<UsuarioEntity> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<BaseResponseModel> Execute(int cursoId, int tareaId, int profesorUserId, CancellationToken ct = default)
        {
            if (cursoId <= 0) return ResponseApiService.Response(400, "CursoId inválido");
            if (tareaId <= 0) return ResponseApiService.Response(400, "TareaId inválido");

            var user = await _userManager.FindByIdAsync(profesorUserId.ToString());
            if (user == null || !user.Activo) return ResponseApiService.Response(403, "Usuario inválido o inactivo");
            if (!await _userManager.IsInRoleAsync(user, "Profesor")) return ResponseApiService.Response(403, "Acceso denegado");

            var profesorAsignado = await _db.CursoProfesores.AsNoTracking()
                .AnyAsync(x => x.CursoId == cursoId && x.ProfesorId == profesorUserId, ct);
            if (!profesorAsignado)
                return ResponseApiService.Response(403, "No estás asignado a este curso");

            var tarea = await _db.Tareas.FirstOrDefaultAsync(t => t.Id == tareaId && t.CursoId == cursoId, ct);
            if (tarea == null) return ResponseApiService.Response(404, "Tarea no encontrada");

            if (tarea.Estado == EstadoTarea.Archivada)
                return ResponseApiService.Response(400, "La tarea ya está archivada");

            tarea.Estado = EstadoTarea.Archivada;
            tarea.UpdatedAtUtc = DateTime.UtcNow;

            await _db.SaveAsync(ct);
            return ResponseApiService.Response(200, "Tarea archivada correctamente");
        }
    }
}
