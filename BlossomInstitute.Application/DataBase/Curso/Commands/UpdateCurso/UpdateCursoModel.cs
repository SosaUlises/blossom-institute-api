using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Curso.Commands.UpdateCurso
{
    public class UpdateCursoModel
    {
        public string Nombre { get; set; } = default!;
        public int Anio { get; set; }
        public string? Descripcion { get; set; }
        public int Estado { get; set; } = 1; // 1-3

        public List<UpdateCursoHorarioModel> Horarios { get; set; } = new();
    }
}
