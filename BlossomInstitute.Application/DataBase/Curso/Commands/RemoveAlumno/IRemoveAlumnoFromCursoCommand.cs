using BlossomInstitute.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Curso.Commands.RemoveAlumno
{
    public interface IRemoveAlumnoFromCursoCommand
    {
        Task<BaseResponseModel> Execute(int cursoId, int alumnoId, CancellationToken ct = default);
    }
}
