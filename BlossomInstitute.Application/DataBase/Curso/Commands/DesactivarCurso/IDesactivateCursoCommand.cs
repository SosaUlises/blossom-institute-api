using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Curso.Commands.DesactivarCurso
{
    public interface IDesactivateCursoCommand
    {
        Task<BaseResponseModel> Execute(int cursoId);
    }
}
