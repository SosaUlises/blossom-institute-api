using BlossomInstitute.Domain.Entidades.Calificacion;

namespace BlossomInstitute.Application.DataBase.Reportes.Queries.ReporteStudentSummaryByCursoAndTerm
{
    public class ReporteStudentSummarySkillItemModel
    {
        public SkillEvaluada Skill { get; set; }
        public int EvaluacionesCount { get; set; }
        public decimal TotalObtenido { get; set; }
        public decimal TotalMaximo { get; set; }
        public decimal? Porcentaje { get; set; }
    }
}
