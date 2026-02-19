using BlossomInstitute.Domain.Entidades.Profesor;
using Microsoft.EntityFrameworkCore;

namespace BlossomInstitute.Application.DataBase
{
    public interface IDataBaseService
    {

        DbSet<ProfesorEntity> Profesores { get; set; }
        Task<bool> SaveAsync(CancellationToken ct = default);
    }
}

