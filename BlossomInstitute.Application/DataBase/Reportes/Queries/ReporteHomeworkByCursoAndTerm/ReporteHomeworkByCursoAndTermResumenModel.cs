namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteHomeworkByCursoAndTerm
{
    public class ReporteHomeworkByCursoAndTermResumenModel
    {
        public int CursoId { get; set; }
        public string CursoNombre { get; set; } = default!;

        public int Year { get; set; }
        public int Term { get; set; }
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }

        public int TotalAlumnos { get; set; }
        public int TotalHomework { get; set; }
        public int TotalEntregas { get; set; }
        public int TotalSinEntregar { get; set; }
        public int TotalPendientesCorreccion { get; set; }
        public int TotalRehacer { get; set; }
        public int TotalAprobadas { get; set; }
        public decimal? PromedioHomeworkCurso { get; set; }
    }
}
