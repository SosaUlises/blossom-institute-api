using BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteAttendanceByCursoAndTerm;
using BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteMarksByCursoAndTerm;

namespace BlossomInstitute.Application.Services.Export
{
    public interface IReporteExportService
    {
        byte[] ExportMarksByCourseTermToExcel(
            ReporteMarksByCursoAndTermResumenModel resumen,
            List<ReporteMarksByCursoAndTermItemModel> items);

        byte[] ExportMarksByCourseTermToPdf(
            ReporteMarksByCursoAndTermResumenModel resumen,
            List<ReporteMarksByCursoAndTermItemModel> items);

        byte[] ExportAttendanceByCourseTermToExcel(
        ReporteAttendanceByCursoAndTermResumenModel resumen,
        List<ReporteAttendanceByCursoAndTermItemModel> items);

        byte[] ExportAttendanceByCourseTermToPdf(
            ReporteAttendanceByCursoAndTermResumenModel resumen,
            List<ReporteAttendanceByCursoAndTermItemModel> items);
    }
}
