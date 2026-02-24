using BlossomInstitute.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Alumno.Queries.GetAll
{
    public interface IGetAllAlumnosQuery
    {
        Task<BaseResponseModel> Execute(int pageNumber, int pageSize, string? search);
    }
}
