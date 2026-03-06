using BlossomInstitute.Application.DataBase.Calificacion.Queries.Model;
using BlossomInstitute.Common.Features;
using BlossomInstitute.Domain.Entidades.Calificacion;
using BlossomInstitute.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlossomInstitute.Application.DataBase.Calificacion.Queries.GetCalificacionesByCurso
{
    public class GetCalificacionesByCursoQuery : IGetCalificacionesByCursoQuery
    {
        private readonly IDataBaseService _db;

        public GetCalificacionesByCursoQuery(IDataBaseService db)
        {
            _db = db;
        }

        public async Task<BaseResponseModel> Execute(
            int cursoId,
            int profesorUserId,
            bool isAdmin,
            int pageNumber,
            int pageSize,
            string? search,
            int? alumnoId,
            int? tipo,
            CancellationToken ct)
        {
            if (cursoId <= 0)
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, "CursoId inválido");

            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;
            if (pageSize > 100) pageSize = 100;

            var cursoExiste = await _db.Cursos.AsNoTracking()
                .AnyAsync(x => x.Id == cursoId, ct);

            if (!cursoExiste)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Curso no encontrado");

            if (!isAdmin)
            {
                var profesorAsignado = await _db.CursoProfesores.AsNoTracking()
                    .AnyAsync(x => x.CursoId == cursoId && x.ProfesorId == profesorUserId, ct);

                if (!profesorAsignado)
                    return ResponseApiService.Response(StatusCodes.Status403Forbidden, "Profesor no asignado a este curso");
            }

            var q = _db.Calificaciones.AsNoTracking()
                .Where(x => x.CursoId == cursoId && !x.Archivado);

            if (alumnoId.HasValue)
                q = q.Where(x => x.AlumnoId == alumnoId.Value);

            if (tipo.HasValue)
            {
                var tipoEnum = (TipoCalificacion)tipo.Value;
                q = q.Where(x => x.Tipo == tipoEnum);
            }

            var projected = q.Select(x => new
            {
                x.Id,
                x.CursoId,
                x.AlumnoId,
                AlumnoNombre = x.Alumno.Usuario.Nombre,
                AlumnoApellido = x.Alumno.Usuario.Apellido,
                AlumnoDni = x.Alumno.Usuario.Dni,
                x.Tipo,
                x.Titulo,
                x.Descripcion,
                x.Nota,
                x.Fecha,
                x.TareaId,
                x.EntregaId
            });

            if (!string.IsNullOrWhiteSpace(search))
            {
                var s = search.Trim().ToLowerInvariant();
                projected = projected.Where(x =>
                    (x.AlumnoApellido ?? "").ToLower().Contains(s) ||
                    (x.AlumnoNombre ?? "").ToLower().Contains(s) ||
                    x.AlumnoDni.ToString().Contains(s) ||
                    (x.Titulo ?? "").ToLower().Contains(s));
            }

            var total = await projected.CountAsync(ct);

            var items = await projected
                .OrderByDescending(x => x.Fecha)
                .ThenBy(x => x.AlumnoApellido)
                .ThenBy(x => x.AlumnoNombre)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new CalificacionListItemModel
                {
                    Id = x.Id,
                    CursoId = x.CursoId,
                    AlumnoId = x.AlumnoId,
                    AlumnoNombre = x.AlumnoNombre ?? "",
                    AlumnoApellido = x.AlumnoApellido ?? "",
                    AlumnoDni = x.AlumnoDni,
                    Tipo = x.Tipo,
                    Titulo = x.Titulo,
                    Descripcion = x.Descripcion,
                    Nota = x.Nota,
                    Fecha = x.Fecha,
                    TareaId = x.TareaId,
                    EntregaId = x.EntregaId
                })
                .ToListAsync(ct);

            return ResponseApiService.Response(StatusCodes.Status200OK, new
            {
                pageNumber,
                pageSize,
                total,
                items
            });
        }
    }
}
