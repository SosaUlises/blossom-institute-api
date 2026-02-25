namespace BlossomInstitute.Application.DataBase.Curso.Queries.GetCursoById
{
    public class GetCursoHorarioModel
    {
        public int Dia { get; set; } // 0-6
        public string HoraInicio { get; set; } = default!; // "HH:mm"
        public string HoraFin { get; set; } = default!;
    }
}
