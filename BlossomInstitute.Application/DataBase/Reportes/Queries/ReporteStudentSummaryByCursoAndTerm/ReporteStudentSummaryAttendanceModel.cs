namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteStudentSummaryByCursoAndTerm
{
    public class ReporteStudentSummaryAttendanceModel
    {
        public int ClasesTotales { get; set; }
        public int Presentes { get; set; }
        public int Ausentes { get; set; }
        public decimal PorcentajeAsistencia { get; set; }
    }
}
