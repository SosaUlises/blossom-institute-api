using BlossomInstitute.Domain.Entidades.Alumno;

namespace BlossomInstitute.Domain.Entidades.Curso
{
    public class MatriculaEntity
    {
        public int CursoId { get; set; }
        public CursoEntity Curso { get; set; } = default!;

        public int AlumnoId { get; set; } 
        public AlumnoEntity Alumno { get; set; } = default!;
    }
}
