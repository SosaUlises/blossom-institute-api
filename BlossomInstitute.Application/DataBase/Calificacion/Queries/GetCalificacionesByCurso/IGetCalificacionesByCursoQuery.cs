using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Calificacion.Queries.GetCalificacionesByCurso
{
    public interface IGetCalificacionesByCursoQuery
    {
        Task<BaseResponseModel> Execute(
            int cursoId,
            int profesorUserId,
            bool isAdmin,
            int pageNumber,
            int pageSize,
            string? search,
            int? alumnoId,
            int? tipo,
            DateOnly? from,
            DateOnly? to,
            int? year,
            int? term,
            CancellationToken ct);
    }
}
