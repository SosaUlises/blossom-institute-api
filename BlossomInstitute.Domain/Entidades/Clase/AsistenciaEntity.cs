using BlossomInstitute.Domain.Entidades.Alumno;

namespace BlossomInstitute.Domain.Entidades.Clase
{
    public class AsistenciaEntity
    {
        public int Id { get; set; }
        public int ClaseId { get; set; }
        public ClaseEntity Clase { get; set; } = default!;

        public int AlumnoId { get; set; }
        public AlumnoEntity Alumno { get; set; } = default!;

        public EstadoAsistencia Estado { get; set; }
    }
}
