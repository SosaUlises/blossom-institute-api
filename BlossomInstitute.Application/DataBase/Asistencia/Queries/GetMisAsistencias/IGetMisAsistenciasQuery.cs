using BlossomInstitute.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Asistencia.Queries.GetMisAsistencias
{
    public interface IGetMisAsistenciasQuery
    {
        Task<BaseResponseModel> Execute(
            int userId,
            int? cursoId,
            DateOnly? from,
            DateOnly? to,
            int pageNumber,
            int pageSize,
            CancellationToken ct = default);
    }
}
