using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Clase.Queries.GetClasesByCurso
{
    public interface IGetClasesByCursoQuery
    {
        Task<BaseResponseModel> Execute(
            int cursoId,
            DateOnly? from,
            DateOnly? to,
            int pageNumber,
            int pageSize,
            CancellationToken ct = default);
    }
}
