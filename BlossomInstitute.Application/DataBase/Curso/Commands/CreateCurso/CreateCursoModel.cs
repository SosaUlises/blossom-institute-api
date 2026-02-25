namespace BlossomInstitute.Application.DataBase.Curso.Commands.CreateCurso
{
    public class CreateCursoModel
    {
        public string Nombre { get; set; } = default!;
        public int Anio { get; set; }
        public string? Descripcion { get; set; }
        public int Estado { get; set; } = 1; // 1 = Activo por default
        public List<CreateCursoHorarioModel> Horarios { get; set; } = new();
    }
}
