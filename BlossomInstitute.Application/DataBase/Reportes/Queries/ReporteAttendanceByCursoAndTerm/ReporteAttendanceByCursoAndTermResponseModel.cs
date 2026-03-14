namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteAttendanceByCursoAndTerm
{
    public class ReporteAttendanceByCursoAndTermResponseModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }

        public ReporteAttendanceByCursoAndTermResumenModel Resumen { get; set; } = new();

        public List<ReporteAttendanceByCursoAndTermItemModel> Items { get; set; } = new();
    }
}
