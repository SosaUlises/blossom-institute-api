using BlossomInstitute.Domain.Entidades.Clase;

namespace BlossomInstitute.Application.DataBase.Asistencia.Queries.GetAsistenciasByAlumno
{
    public class AsistenciaAlumnoHistorialItemModel
    {
        public int ClaseId { get; set; }
        public string Fecha { get; set; } = default!;
        public EstadoClase EstadoClase { get; set; }
        public EstadoAsistencia? Estado { get; set; }
        public string? Descripcion { get; set; }
    }
}
