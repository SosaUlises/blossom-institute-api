using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Curso.Commands.UpdateCurso
{
    public interface IUpdateCursoCommand
    {
        Task<BaseResponseModel> Execute(int cursoId, UpdateCursoModel model);
    }
}
