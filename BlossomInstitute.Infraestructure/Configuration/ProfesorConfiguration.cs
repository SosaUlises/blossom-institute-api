using BlossomInstitute.Domain.Entidades.Profesor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlossomInstitute.Infraestructure.Configuration
{
    public class ProfesorConfiguration
    {
        public ProfesorConfiguration(EntityTypeBuilder<ProfesorEntity> entityBuilder)
        {
            entityBuilder.ToTable("Profesores");
            entityBuilder.HasKey(p => p.Id);

            entityBuilder.Property(p => p.Id).ValueGeneratedNever();

            entityBuilder.HasOne(p => p.Usuario)
                .WithOne(u => u.Profesor)
                .HasForeignKey<ProfesorEntity>(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
