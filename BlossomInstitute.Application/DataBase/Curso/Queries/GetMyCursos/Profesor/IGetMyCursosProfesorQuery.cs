using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Curso.Queries.GetMyCursos.Profesor
{
    public interface IGetMyCursosProfesorQuery
    {
        Task<BaseResponseModel> Execute(int userId, int pageNumber, int pageSize, string? search, int? anio, int? estado);
    }
}
