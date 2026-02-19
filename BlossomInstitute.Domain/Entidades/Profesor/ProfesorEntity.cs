using BlossomInstitute.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Domain.Entidades.Profesor
{
    public class ProfesorEntity
    {
        public int Id { get; set; }
        public UsuarioEntity Usuario { get; set; } = default!;
    }
}
