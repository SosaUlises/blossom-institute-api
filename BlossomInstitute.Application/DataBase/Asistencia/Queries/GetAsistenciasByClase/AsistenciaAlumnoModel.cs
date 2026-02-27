using BlossomInstitute.Domain.Entidades.Clase;

namespace BlossomInstitute.Application.DataBase.Asistencia.Queries.GetAsistenciasByClase
{
    public class AsistenciaAlumnoModel
    {
        public int AlumnoId { get; set; }
        public string NombreCompleto { get; set; } = default!;
        public EstadoAsistencia? Estado { get; set; } // null = sin registro
    }
}
