namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteAttendanceByCursoAndTerm
{
    public class ReporteAttendanceByCursoAndTermResumenModel
    {
        public int CursoId { get; set; }
        public string CursoNombre { get; set; } = default!;

        public int Year { get; set; }
        public int Term { get; set; }
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }

        public int TotalAlumnos { get; set; }
        public int TotalClases { get; set; }
        public int TotalPresentes { get; set; }
        public int TotalAusentes { get; set; }
        public decimal? PorcentajeAsistenciaCurso { get; set; }
    }
}
