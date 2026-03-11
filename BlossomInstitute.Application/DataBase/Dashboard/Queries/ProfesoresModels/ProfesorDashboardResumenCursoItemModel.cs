namespace BlossomInstitute.Application.DataBase.Dashboard.Queries.ProfesoresModels
{
    public class ProfesorDashboardResumenCursoItemModel
    {
        public int CursoId { get; set; }
        public string CursoNombre { get; set; } = default!;
        public int CantidadAlumnos { get; set; }
        public int TareasPublicadas { get; set; }
        public int EntregasPendientesCorreccion { get; set; }
        public decimal? PromedioCurso { get; set; }
    }
}
