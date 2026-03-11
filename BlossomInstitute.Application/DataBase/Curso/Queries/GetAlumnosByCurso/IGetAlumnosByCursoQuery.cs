using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Curso.Queries.GetAlumnosByCurso
{
    public interface IGetAlumnosByCursoQuery
    {
        Task<BaseResponseModel> Execute(
            int cursoId,
            int userId,
            bool isAdmin,
            int pageNumber,
            int pageSize,
            string? search,
            CancellationToken ct);
    }
}
