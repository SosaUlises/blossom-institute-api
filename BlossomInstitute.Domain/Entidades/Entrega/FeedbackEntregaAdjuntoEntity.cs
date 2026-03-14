using BlossomInstitute.Domain.Entidades.Common;

namespace BlossomInstitute.Domain.Entidades.Entrega
{
    public class FeedbackEntregaAdjuntoEntity
    {
        public int Id { get; set; }

        public int FeedbackEntregaId { get; set; }
        public FeedbackEntregaEntity FeedbackEntrega { get; set; } = default!;

        public TipoAdjunto Tipo { get; set; }

        public string Url { get; set; } = default!;
        public string? Nombre { get; set; }

        public StorageProviderType? StorageProvider { get; set; }
        public string? StorageKey { get; set; }
        public string? ContentType { get; set; }
        public long? SizeBytes { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
