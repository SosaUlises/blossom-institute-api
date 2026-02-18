using BlossomInstitute.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.External
{
    public interface IGetTokenJWTService
    {
        string Execute(string userId, IEnumerable<string> roles, UsuarioEntity usuario);
    }
}
