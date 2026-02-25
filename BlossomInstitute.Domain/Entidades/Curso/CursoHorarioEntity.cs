namespace BlossomInstitute.Domain.Entidades.Curso
{
    public class CursoHorarioEntity
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public CursoEntity Curso { get; set; } = default!;

        public DayOfWeek Dia { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
    }
}
