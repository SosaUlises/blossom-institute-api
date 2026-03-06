using BlossomInstitute.Domain.Entidades.Calificacion;

namespace BlossomInstitute.Application.DataBase.Calificacion.Queries.Model
{
    public class CalificacionListItemModel
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int AlumnoId { get; set; }

        public string AlumnoNombre { get; set; } = "";
        public string AlumnoApellido { get; set; } = "";
        public long AlumnoDni { get; set; }

        public TipoCalificacion Tipo { get; set; }
        public string Titulo { get; set; } = "";
        public string? Descripcion { get; set; }

        public decimal Nota { get; set; }
        public DateOnly Fecha { get; set; }

        public int? TareaId { get; set; }
        public int? EntregaId { get; set; }
    }
}
