using BlossomInstitute.Domain.Entidades.Curso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlossomInstitute.Infraestructure.Configuration
{
    public class CursoHorarioConfiguration
    {
        public CursoHorarioConfiguration(EntityTypeBuilder<CursoHorarioEntity> b)
        {
            b.ToTable("CursoHorarios");
            b.HasKey(x => x.Id);

            b.Property(x => x.Dia).IsRequired();
            b.Property(x => x.HoraInicio).IsRequired();
            b.Property(x => x.HoraFin).IsRequired();

            b.HasOne(x => x.Curso)
                .WithMany(c => c.Horarios)
                .HasForeignKey(x => x.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasIndex(x => new { x.CursoId, x.Dia, x.HoraInicio }).IsUnique();
        }
    }
}
