using BlossomInstitute.Domain.Entidades.Clase;

namespace BlossomInstitute.Application.DataBase.Asistencia.Queries.GetAsistenciasByClase
{
    public class ClaseAsistenciasModel
    {
        public int ClaseId { get; set; }
        public int CursoId { get; set; }
        public string Fecha { get; set; } = default!;
        public EstadoClase EstadoClase { get; set; }
        public string? Descripcion { get; set; }
        public List<AsistenciaAlumnoModel> Alumnos { get; set; } = new();
    }
}
