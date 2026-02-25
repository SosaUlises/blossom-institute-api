using BlossomInstitute.Domain.Entidades.Curso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlossomInstitute.Infraestructure.Configuration
{
    public class MatriculaConfiguration
    {
        public MatriculaConfiguration(EntityTypeBuilder<MatriculaEntity> b)
        {
            b.ToTable("Matriculas");
            b.HasKey(x => new { x.CursoId, x.AlumnoId });

            b.HasOne(x => x.Curso)
                .WithMany(c => c.Matriculas)
                .HasForeignKey(x => x.CursoId);

            b.HasOne(x => x.Alumno)
                .WithMany()
                .HasForeignKey(x => x.AlumnoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
