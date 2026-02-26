using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Profesor.Command.ActivarProfesor
{
    public interface IActivarProfesorCommand
    {
        Task<BaseResponseModel> Execute(int userId);
    }
}
