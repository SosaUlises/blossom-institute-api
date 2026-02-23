using BlossomInstitute.Domain.Entidades.Usuario;

namespace BlossomInstitute.Domain.Entidades.Alumno
{
    public class AlumnoEntity
    {
        public int Id { get; set; }
        public UsuarioEntity Usuario { get; set; } = default!;
    }
}
