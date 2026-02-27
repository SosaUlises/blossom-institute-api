using BlossomInstitute.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Asistencia.Queries.GetAsistenciasByAlumno
{
    public interface IGetAsistenciasByAlumnoQuery
    {
        Task<BaseResponseModel> Execute(int alumnoId, int cursoId, DateOnly? from, DateOnly? to, CancellationToken ct = default);
    }
}
