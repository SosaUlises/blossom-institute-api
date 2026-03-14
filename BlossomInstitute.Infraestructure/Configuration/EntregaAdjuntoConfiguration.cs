using BlossomInstitute.Domain.Entidades.Entrega;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlossomInstitute.Infraestructure.Configuration
{
    public class EntregaAdjuntoConfiguration
    {
        public EntregaAdjuntoConfiguration(EntityTypeBuilder<EntregaAdjuntoEntity> b)
        {
            b.ToTable("EntregaAdjuntos");

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

            b.HasOne(x => x.Entrega)
                .WithMany(e => e.Adjuntos)
                .HasForeignKey(x => x.EntregaId)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasIndex(x => new { x.EntregaId, x.Tipo });

            b.HasIndex(x => new { x.EntregaId, x.StorageKey });

            b.HasIndex(x => x.StorageKey);
        }
    }
}
