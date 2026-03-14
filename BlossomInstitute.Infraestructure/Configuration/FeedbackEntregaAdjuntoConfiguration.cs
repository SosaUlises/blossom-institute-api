using BlossomInstitute.Domain.Entidades.Entrega;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlossomInstitute.Infraestructure.Configuration
{
    public class FeedbackEntregaAdjuntoConfiguration
    {
        public FeedbackEntregaAdjuntoConfiguration(EntityTypeBuilder<FeedbackEntregaAdjuntoEntity> b)
        {
            b.ToTable("FeedbackEntregaAdjuntos");

            b.HasKey(x => x.Id);

            b.Property(x => x.Tipo)
                .HasConversion<int>()
                .IsRequired();

            b.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(2000);

            b.Property(x => x.Nombre)
                .HasMaxLength(200);

            b.Property(x => x.StorageProvider)
                .HasConversion<int>();

            b.Property(x => x.StorageKey)
                .HasMaxLength(500);

            b.Property(x => x.ContentType)
                .HasMaxLength(200);

            b.Property(x => x.SizeBytes);

            b.Property(x => x.CreatedAtUtc)
                .IsRequired();

            b.HasOne(x => x.FeedbackEntrega)
                .WithMany(f => f.Adjuntos)
                .HasForeignKey(x => x.FeedbackEntregaId)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasIndex(x => new { x.FeedbackEntregaId, x.Tipo });

            b.HasIndex(x => new { x.FeedbackEntregaId, x.StorageKey });

            b.HasIndex(x => x.StorageKey);
        }
    }
}