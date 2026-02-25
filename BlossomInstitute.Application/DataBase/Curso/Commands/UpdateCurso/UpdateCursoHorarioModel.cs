using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Curso.Commands.UpdateCurso
{
    public class UpdateCursoHorarioModel
    {
        public int Dia { get; set; } // 0-6
        public string HoraInicio { get; set; } = default!; // "HH:mm"
        public string HoraFin { get; set; } = default!;    // "HH:mm"
    }
}
