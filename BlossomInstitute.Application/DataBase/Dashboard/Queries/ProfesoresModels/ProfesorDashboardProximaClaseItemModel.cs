namespace BlossomInstitute.Application.DataBase.Dashboard.Queries.ProfesoresModels
{
    public class ProfesorDashboardProximaClaseItemModel
    {
        public int CursoId { get; set; }
        public string CursoNombre { get; set; } = default!;
        public DayOfWeek Dia { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
    }
}
