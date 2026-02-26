using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Alumno.Command.ActivarAlumno
{
    public interface IActivarAlumnoCommand
    {
        Task<BaseResponseModel> Execute(int userId);
    }
}
