using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Tarea.Commands.ArchivarTarea
{
    public interface IArchivarTareaCommand
    {
        Task<BaseResponseModel> Execute(int cursoId, int tareaId, int profesorUserId, CancellationToken ct = default);
    }
}
