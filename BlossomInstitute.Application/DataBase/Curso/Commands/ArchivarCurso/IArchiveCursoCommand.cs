using BlossomInstitute.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Curso.Commands.ArchivarCurso
{
    public interface IArchiveCursoCommand
    {
        Task<BaseResponseModel> Execute(int cursoId);
    }
}
