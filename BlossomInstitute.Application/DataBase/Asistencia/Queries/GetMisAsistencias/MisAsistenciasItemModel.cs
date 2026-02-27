using BlossomInstitute.Domain.Entidades.Clase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Asistencia.Queries.GetMisAsistencias
{
    public class MisAsistenciasItemModel
    {
        public int CursoId { get; set; }
        public string CursoNombre { get; set; } = default!;
        public int ClaseId { get; set; }
        public string Fecha { get; set; } = default!;
        public EstadoClase EstadoClase { get; set; }
        public EstadoAsistencia? Estado { get; set; } // null = sin registro
        public string? DescripcionClase { get; set; }
    }
}
