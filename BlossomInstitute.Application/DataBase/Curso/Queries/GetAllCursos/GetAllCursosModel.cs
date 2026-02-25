using BlossomInstitute.Domain.Entidades.Curso;

namespace BlossomInstitute.Application.DataBase.Curso.Queries.GetAllCursos
{
    public class GetAllCursosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public int Anio { get; set; }
        public EstadoCurso Estado { get; set; }

        public int CantidadHorarios { get; set; }
        public int CantidadProfesores { get; set; }
        public int CantidadAlumnos { get; set; }
    }
}
