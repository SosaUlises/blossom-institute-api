using BlossomInstitute.Domain.Entidades.Curso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlossomInstitute.Infraestructure.Configuration
{
    public class CursoProfesorConfiguration
    {
        public CursoProfesorConfiguration(EntityTypeBuilder<CursoProfesorEntity> b)
        {
            b.ToTable("CursoProfesores");
            b.HasKey(x => new { x.CursoId, x.ProfesorId });

            b.HasOne(x => x.Curso)
                .WithMany(c => c.Profesores)
                .HasForeignKey(x => x.CursoId);

            b.HasOne(x => x.Profesor)
                .WithMany() 
                .HasForeignKey(x => x.ProfesorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
