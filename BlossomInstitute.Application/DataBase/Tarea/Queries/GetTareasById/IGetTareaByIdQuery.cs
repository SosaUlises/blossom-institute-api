using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Tarea.Queries.GetTareasById
{
    public interface IGetTareaByIdQuery
    {
        Task<BaseResponseModel> Execute(int cursoId, int tareaId, CancellationToken ct = default);
    }
}
