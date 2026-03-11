namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteMarksByCursoAndTerm
{
    public class ReporteMarksByCursoAndTermItemModel
    {
        public int AlumnoId { get; set; }
        public string AlumnoNombre { get; set; } = default!;
        public string AlumnoApellido { get; set; } = default!;
        public long AlumnoDni { get; set; }
        public string? AlumnoEmail { get; set; }

        public int QuizCount { get; set; }
        public decimal? QuizPromedio { get; set; }

        public int TestCount { get; set; }
        public decimal? TestPromedio { get; set; }

        public int MarksCount { get; set; }
        public decimal? PromedioGeneral { get; set; }
    }
}
