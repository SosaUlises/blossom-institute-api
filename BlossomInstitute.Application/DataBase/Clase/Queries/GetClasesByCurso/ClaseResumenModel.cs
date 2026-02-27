using BlossomInstitute.Domain.Entidades.Clase;

namespace BlossomInstitute.Application.DataBase.Clase.Queries.GetClasesByCurso
{
    public class ClaseResumenModel
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public string Fecha { get; set; } = default!;
        public EstadoClase Estado { get; set; }
        public string? Descripcion { get; set; }
        public int CantAsistencias { get; set; }
        public int CantPresentes { get; set; }
        public int CantAusentes { get; set; }
    }
}
