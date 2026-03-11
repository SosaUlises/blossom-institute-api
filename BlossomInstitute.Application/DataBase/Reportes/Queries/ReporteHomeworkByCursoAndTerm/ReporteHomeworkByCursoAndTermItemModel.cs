namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteHomeworkByCursoAndTerm
{
    public class ReporteHomeworkByCursoAndTermItemModel
    {
        public int AlumnoId { get; set; }
        public string AlumnoNombre { get; set; } = default!;
        public string AlumnoApellido { get; set; } = default!;
        public long AlumnoDni { get; set; }
        public string? AlumnoEmail { get; set; }

        public int HomeworkTotal { get; set; }
        public int HomeworkEntregadas { get; set; }
        public int HomeworkSinEntregar { get; set; }
        public int HomeworkPendientesCorreccion { get; set; }
        public int HomeworkRehacer { get; set; }
        public int HomeworkAprobadas { get; set; }
        public decimal? HomeworkPromedio { get; set; }
    }
}
