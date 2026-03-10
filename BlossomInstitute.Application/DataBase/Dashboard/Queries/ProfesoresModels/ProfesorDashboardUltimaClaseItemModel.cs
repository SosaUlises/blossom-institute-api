using BlossomInstitute.Domain.Entidades.Clase;

namespace BlossomInstitute.Application.DataBase.Dashboard.Queries.ProfesoresModels
{
    public class ProfesorDashboardUltimaClaseItemModel
    {
        public int ClaseId { get; set; }
        public int CursoId { get; set; }
        public string CursoNombre { get; set; } = default!;
        public DateOnly Fecha { get; set; }
        public EstadoClase EstadoClase { get; set; }
        public string? Descripcion { get; set; }
    }
}
