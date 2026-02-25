using BlossomInstitute.Domain.Entidades.Profesor;

namespace BlossomInstitute.Domain.Entidades.Curso
{
    public class CursoProfesorEntity
    {
        public int CursoId { get; set; }
        public CursoEntity Curso { get; set; } = default!;

        public int ProfesorId { get; set; } 
        public ProfesorEntity Profesor { get; set; } = default!;
    }
}
