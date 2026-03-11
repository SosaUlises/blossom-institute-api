using BlossomInstitute.Domain.Entidades.Calificaciones;

namespace BlossomInstitute.Domain.Entidades.Calificacion
{
    public class CalificacionDetalleEntity
    {
        public int Id { get; set; }

        public int CalificacionId { get; set; }
        public CalificacionEntity Calificacion { get; set; } = default!;

        public SkillEvaluada Skill { get; set; }

        public decimal PuntajeObtenido { get; set; }
        public decimal PuntajeMaximo { get; set; }

    }
}
