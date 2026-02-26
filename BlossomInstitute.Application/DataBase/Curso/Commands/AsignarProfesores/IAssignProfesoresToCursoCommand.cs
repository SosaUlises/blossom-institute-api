using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Curso.Commands.AsignarProfesores
{
    public interface IAssignProfesoresToCursoCommand
    {
        Task<BaseResponseModel> Execute(int cursoId, AssignProfesoresToCursoModel model, CancellationToken ct = default);
    }
}
