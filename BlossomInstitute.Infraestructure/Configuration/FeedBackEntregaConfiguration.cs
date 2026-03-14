using BlossomInstitute.Domain.Entidades.Entrega;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlossomInstitute.Infraestructure.Configuration
{
    public class FeedbackEntregaConfiguration
    {
        public FeedbackEntregaConfiguration(EntityTypeBuilder<FeedbackEntregaEntity> b)
        {
            b.ToTable("EntregaFeedbacks");

            b.HasKey(x => x.Id);

            b.Property(x => x.EsVigente)
                .IsRequired();

            b.Property(x => x.Estado)
                .HasConversion<int>()
                .IsRequired();

            b.Property(x => x.Nota)
                .HasPrecision(5, 2);

            b.Property(x => x.FechaCorreccionUtc)
                .IsRequired();

            b.Property(x => x.Comentario)
                .HasMaxLength(8000);

            b.HasOne(x => x.Entrega)
                .WithMany(e => e.Feedbacks)
                .HasForeignKey(x => x.EntregaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Búsqueda general por entrega
            b.HasIndex(x => x.EntregaId);

            // Garantiza un solo feedback vigente por entrega
            b.HasIndex(x => x.EntregaId)
                .IsUnique()
                .HasFilter("\"EsVigente\" = true");
        }
    }
}