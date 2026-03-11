using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteAttendanceByCursoAndTerm
{
    public interface IGetReporteAttendanceByCursoAndTermQuery
    {
        Task<BaseResponseModel> Execute(
            int cursoId,
            int year,
            int term,
            int userId,
            bool isAdmin,
            int pageNumber,
            int pageSize,
            string? search,
            CancellationToken ct);
    }
}
