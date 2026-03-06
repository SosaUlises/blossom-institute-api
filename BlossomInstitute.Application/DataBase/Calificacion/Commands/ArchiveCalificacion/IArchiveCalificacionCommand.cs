using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Calificacion.Commands.ArchiveCalificacion
{
    public interface IArchiveCalificacionCommand
    {
        Task<BaseResponseModel> Execute(
            int cursoId,
            int alumnoId,
            int calificacionId,
            int profesorUserId,
            CancellationToken ct);
    }
}
