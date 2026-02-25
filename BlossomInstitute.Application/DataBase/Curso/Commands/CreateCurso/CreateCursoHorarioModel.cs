namespace BlossomInstitute.Application.DataBase.Curso.Commands.CreateCurso
{
    public class CreateCursoHorarioModel
    {
        public int Dia { get; set; } // 0-6 (DayOfWeek)
        public string HoraInicio { get; set; } = default!; // "HH:mm"
        public string HoraFin { get; set; } = default!;    // "HH:mm"
    }
}
