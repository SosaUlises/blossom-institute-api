using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Curso.Queries.GetAllCursos
{
    public interface IGetAllCursosQuery
    {
        Task<BaseResponseModel> Execute(
            int pageNumber,
            int pageSize,
            string? search,
            int? anio,
            int? estado);
    }
}
