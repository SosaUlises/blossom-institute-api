using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Curso.Queries.GetCursoById
{
    public interface IGetCursoByIdQuery
    {
        Task<BaseResponseModel> Execute(int cursoId);
    }
}
