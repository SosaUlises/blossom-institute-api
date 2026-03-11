using BlossomInstitute.Domain.Entidades.Calificacion;

namespace BlossomInstitute.Application.DataBase.Calificacion.Commands.CreateCalificacion
{
    public class CreateCalificacionDetalleModel
    {
        public SkillEvaluada Skill { get; set; }
        public decimal PuntajeObtenido { get; set; }
        public decimal PuntajeMaximo { get; set; }
    }
}
