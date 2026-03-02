using BlossomInstitute.Common.Features;
using BlossomInstitute.Domain.Entidades.Tarea;
using BlossomInstitute.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlossomInstitute.Application.DataBase.Tarea.Queries.GetTareasByCurso
{
    public class GetTareasByCursoQuery : IGetTareasByCursoQuery
    {
        private readonly IDataBaseService _db;
        public GetTareasByCursoQuery(IDataBaseService db) => _db = db;

        public async Task<BaseResponseModel> Execute(int cursoId, EstadoTarea? estado, int pageNumber, int pageSize, CancellationToken ct = default)
        {
            if (cursoId <= 0) return ResponseApiService.Response(400, "CursoId inválido");
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;
            if (pageSize > 200) pageSize = 200;

            var q = _db.Tareas.AsNoTracking()
                .Where(t => t.CursoId == cursoId);

            if (estado.HasValue)
                q = q.Where(t => t.Estado == estado.Value);

            var total = await q.CountAsync(ct);

            var items = await q
                .OrderByDescending(t => t.CreatedAtUtc)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(t => new
                {
                    t.Id,
                    t.CursoId,
                    t.ProfesorId,
                    t.Titulo,
                    t.Estado,
                    t.FechaEntregaUtc,
                    t.CreatedAtUtc
                })
                .ToListAsync(ct);

            return ResponseApiService.Response(StatusCodes.Status200OK, new { total, pageNumber, pageSize, items });
        }
    }
}

