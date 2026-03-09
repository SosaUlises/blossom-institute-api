using BlossomInstitute.Domain.Entidades.Calificacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlossomInstitute.Infraestructure.Configuration
{
    public class CalificacionDetalleConfiguration
    {
        public CalificacionDetalleConfiguration(EntityTypeBuilder<CalificacionDetalleEntity> entity)
        {
            entity.ToTable("CalificacionDetalles");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Skill)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(x => x.PuntajeObtenido)
                .HasPrecision(5, 2)
                .IsRequired();

            entity.Property(x => x.PuntajeMaximo)
                .HasPrecision(5, 2)
                .IsRequired();

            entity.HasIndex(x => new { x.CalificacionId, x.Skill })
                .IsUnique();
        }
    }
}
