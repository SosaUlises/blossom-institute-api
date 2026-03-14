namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteMarksByCursoAndTerm
{
    public class ReporteMarksByCursoAndTermResumenModel
    {
        public int CursoId { get; set; }
        public string CursoNombre { get; set; } = default!;

        public int Year { get; set; }
        public int Term { get; set; }
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }

        public int TotalAlumnos { get; set; }
        public int AlumnosConNotas { get; set; }

        public int TotalQuizzes { get; set; }
        public decimal? PromedioQuizzesCurso { get; set; }

        public int TotalTests { get; set; }
        public decimal? PromedioTestsCurso { get; set; }

        public int TotalMarks { get; set; }
        public decimal? PromedioGeneralCurso { get; set; }
    }
}
