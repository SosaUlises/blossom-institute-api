using BlossomInstitute.Domain.Entidades.Alumno;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlossomInstitute.Infraestructure.Configuration
{
    public class AlumnoConfiguration
    {
        public AlumnoConfiguration(EntityTypeBuilder<AlumnoEntity> entityBuilder)
        {
            entityBuilder.ToTable("Alumnos");
            entityBuilder.HasKey(p => p.Id);

            entityBuilder.Property(p => p.Id).ValueGeneratedNever();

            entityBuilder.HasOne(p => p.Usuario)
                .WithOne(u => u.Alumno)
                .HasForeignKey<AlumnoEntity>(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
