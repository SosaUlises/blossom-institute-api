using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Curso.Commands.ActivarCurso
{
    public interface IActivateCursoCommand
    {
        Task<BaseResponseModel> Execute(int cursoId);
    }
}
