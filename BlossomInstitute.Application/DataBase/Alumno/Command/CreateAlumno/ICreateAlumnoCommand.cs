using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Alumno.Command.CreateAlumno
{
    public interface ICreateAlumnoCommand
    {
        Task<BaseResponseModel> Execute(CreateAlumnoModel model);
    }
}
