namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteAttendanceByCursoAndTerm
{
    public class ReporteAttendanceByCursoAndTermItemModel
    {
        public int AlumnoId { get; set; }
        public string AlumnoNombre { get; set; } = default!;
        public string AlumnoApellido { get; set; } = default!;
        public long AlumnoDni { get; set; }
        public string? AlumnoEmail { get; set; }

        public int ClasesTotales { get; set; }
        public int Presentes { get; set; }
        public int Ausentes { get; set; }
        public decimal PorcentajeAsistencia { get; set; }
    }
}
