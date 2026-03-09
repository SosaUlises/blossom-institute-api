using BlossomInstitute.Domain.Entidades.Calificacion;

namespace BlossomInstitute.Application.DataBase.Calificacion.Commands.UpdateCalificacion
{
    public class UpdateCalificacionDetalleModel
    {
        public SkillEvaluada Skill { get; set; }
        public decimal PuntajeObtenido { get; set; }
        public decimal PuntajeMaximo { get; set; }
    }
}
