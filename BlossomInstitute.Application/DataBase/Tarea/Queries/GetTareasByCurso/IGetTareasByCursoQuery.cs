using BlossomInstitute.Domain.Entidades.Tarea;
using BlossomInstitute.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Tarea.Queries.GetTareasByCurso
{
    public interface IGetTareasByCursoQuery
    {
        Task<BaseResponseModel> Execute(int cursoId, EstadoTarea? estado, int pageNumber, int pageSize, CancellationToken ct = default);
    }
}
