using BlossomInstitute.Common.Features;
using BlossomInstitute.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlossomInstitute.Application.DataBase.Curso.Queries.GetCursoById
{
    public class GetCursoByIdQuery : IGetCursoByIdQuery
    {
        private readonly IDataBaseService _db;

        public GetCursoByIdQuery(IDataBaseService db)
        {
            _db = db;
        }

        public async Task<BaseResponseModel> Execute(int cursoId)
        {
            if (cursoId <= 0)
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, "Id inválido");

            var curso = await _db.Cursos
                .AsNoTracking()
                .Include(c => c.Horarios)
                .FirstOrDefaultAsync(c => c.Id == cursoId);

            if (curso == null)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Curso no encontrado");

            var dto = new GetCursoByIdModel
            {
                Id = curso.Id,
                Nombre = curso.Nombre,
                Anio = curso.Anio,
                Descripcion = curso.Descripcion,
                Estado = curso.Estado,
                CantidadProfesores = curso.Profesores.Count,
                CantidadAlumnos = curso.Matriculas.Count,
                Horarios = curso.Horarios
                    .OrderBy(h => h.Dia)
                    .ThenBy(h => h.HoraInicio)
                    .Select(h => new GetCursoHorarioModel
                    {
                        Dia = (int)h.Dia,
                        HoraInicio = h.HoraInicio.ToString("HH:mm"),
                        HoraFin = h.HoraFin.ToString("HH:mm"),
                    })
                    .ToList()
            };

            return ResponseApiService.Response(StatusCodes.Status200OK, dto);
        }
    }
}
