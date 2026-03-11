namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteStudentSummaryByCursoAndTerm
{
    public class ReporteStudentSummaryMarksModel
    {
        public int QuizCount { get; set; }
        public decimal? QuizPromedio { get; set; }

        public int TestCount { get; set; }
        public decimal? TestPromedio { get; set; }

        public int MarksCount { get; set; }
        public decimal? PromedioGeneral { get; set; }
    }
}
