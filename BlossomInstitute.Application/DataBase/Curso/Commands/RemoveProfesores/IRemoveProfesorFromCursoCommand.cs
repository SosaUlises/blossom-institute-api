using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Curso.Commands.RemoveProfesores
{
    public interface IRemoveProfesorFromCursoCommand
    {
        Task<BaseResponseModel> Execute(int cursoId, int profesorId, CancellationToken ct = default);
    }
}
