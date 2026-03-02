using BlossomInstitute.Common.Features;
using BlossomInstitute.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BlossomInstitute.Application.DataBase.Tarea.Queries.GetTareasById
{
    public class GetTareaByIdQuery : IGetTareaByIdQuery
    {
        private readonly IDataBaseService _db;
        public GetTareaByIdQuery(IDataBaseService db) => _db = db;

        public async Task<BaseResponseModel> Execute(int cursoId, int tareaId, CancellationToken ct = default)
        {
            if (cursoId <= 0) return ResponseApiService.Response(400, "CursoId inválido");
            if (tareaId <= 0) return ResponseApiService.Response(400, "TareaId inválido");

            var tarea = await _db.Tareas.AsNoTracking()
                .Where(t => t.CursoId == cursoId && t.Id == tareaId)
                .Select(t => new
                {
                    t.Id,
                    t.CursoId,
                    t.ProfesorId,
                    t.Titulo,
                    t.Consigna,
                    t.Estado,
                    t.FechaEntregaUtc,
                    t.CreatedAtUtc,
                    t.UpdatedAtUtc,
                    Recursos = t.Recursos.Select(r => new { r.Id, r.Tipo, r.Url, r.Nombre }).ToList()
                })
                .FirstOrDefaultAsync(ct);

            if (tarea == null) return ResponseApiService.Response(404, "Tarea no encontrada");

            return ResponseApiService.Response(200, tarea);
        }
    }
}
