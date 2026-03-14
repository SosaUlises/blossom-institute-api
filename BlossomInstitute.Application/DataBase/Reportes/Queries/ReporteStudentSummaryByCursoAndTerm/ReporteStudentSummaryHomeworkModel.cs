namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteStudentSummaryByCursoAndTerm
{
    public class ReporteStudentSummaryHomeworkModel
    {
        public int HomeworkTotal { get; set; }
        public int HomeworkEntregadas { get; set; }
        public int HomeworkSinEntregar { get; set; }
        public int HomeworkPendientesCorreccion { get; set; }
        public int HomeworkRehacer { get; set; }
        public int HomeworkAprobadas { get; set; }
        public decimal? HomeworkPromedio { get; set; }
    }
}
