using BlossomInstitute.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteStudentSummaryByCursoAndTerm
{
    public interface IGetReporteStudentSummaryByCursoAndTermQuery
    {
        Task<BaseResponseModel> Execute(
            int cursoId,
            int alumnoId,
            int year,
            int term,
            int userId,
            bool isAdmin,
            CancellationToken ct);
    }
}
