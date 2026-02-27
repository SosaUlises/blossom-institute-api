using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Clase.Command
{
    public interface ICancelarClaseCommand
    {
        Task<BaseResponseModel> Execute(int cursoId, DateOnly fecha, CancellationToken ct = default);
    }
}
