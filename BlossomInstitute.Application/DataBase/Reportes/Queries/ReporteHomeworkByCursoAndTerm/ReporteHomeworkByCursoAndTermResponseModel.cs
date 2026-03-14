namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteHomeworkByCursoAndTerm
{
    public class ReporteHomeworkByCursoAndTermResponseModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }

        public ReporteHomeworkByCursoAndTermResumenModel Resumen { get; set; } = new();

        public List<ReporteHomeworkByCursoAndTermItemModel> Items { get; set; } = new();
    }
}
