using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Curso.Commands.AsignarProfesor.Command
{
    public interface IAssignProfesoresCommand
    {
        Task<BaseResponseModel> Execute(int cursoId, AssignProfesoresModel model, CancellationToken ct = default);
    }
}
