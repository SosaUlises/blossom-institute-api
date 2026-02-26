using BlossomInstitute.Domain.Entidades.Clase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlossomInstitute.Infraestructure.Configuration
{
    public class ClaseConfiguration
    {
        public ClaseConfiguration(EntityTypeBuilder<ClaseEntity> entity)
        {
            entity.ToTable("Clases");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Fecha)
                .HasConversion(
                    v => v.ToDateTime(TimeOnly.MinValue),
                    v => DateOnly.FromDateTime(v))
                .HasColumnType("date");

            entity.Property(x => x.Estado)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(x => x.Descripcion)
                .HasMaxLength(1000);

            entity.HasIndex(x => new { x.CursoId, x.Fecha })
                .IsUnique();

            entity.HasOne(x => x.Curso)
                .WithMany(c => c.Clases) 
                .HasForeignKey(x => x.CursoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
