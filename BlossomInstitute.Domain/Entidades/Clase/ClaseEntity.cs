using BlossomInstitute.Domain.Entidades.Curso;

namespace BlossomInstitute.Domain.Entidades.Clase
{
    public class ClaseEntity
    {
        public int Id { get; set; }

        public int CursoId { get; set; }
        public CursoEntity Curso { get; set; } = default!;

        public DateOnly Fecha { get; set; }

        public EstadoClase Estado { get; set; } = EstadoClase.Programada;

        public string? Descripcion { get; set; }

        public ICollection<AsistenciaEntity> Asistencias { get; set; } = new List<AsistenciaEntity>();
    }
}
