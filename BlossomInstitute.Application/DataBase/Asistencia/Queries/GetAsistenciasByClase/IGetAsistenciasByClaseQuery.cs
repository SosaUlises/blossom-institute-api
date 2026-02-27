using BlossomInstitute.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Asistencia.Queries.GetAsistenciasByClase
{
    public interface IGetAsistenciasByClaseQuery
    {
        Task<BaseResponseModel> Execute(int cursoId, DateOnly fecha, CancellationToken ct = default);
    }
}
