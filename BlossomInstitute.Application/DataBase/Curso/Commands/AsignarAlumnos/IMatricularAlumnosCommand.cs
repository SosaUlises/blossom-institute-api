using BlossomInstitute.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Curso.Commands.AsignarAlumnos
{
    public interface IMatricularAlumnosCommand
    {
        Task<BaseResponseModel> Execute(int cursoId, MatricularAlumnosModel model, CancellationToken ct = default);
    }
}
