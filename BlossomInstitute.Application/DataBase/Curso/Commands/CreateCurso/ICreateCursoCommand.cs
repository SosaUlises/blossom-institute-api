using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Curso.Commands.CreateCurso
{
    public interface ICreateCursoCommand
    {
        Task<BaseResponseModel> Execute(CreateCursoModel model);
    }
}
