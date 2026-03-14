using BlossomInstitute.Domain.Entidades.Common;

namespace BlossomInstitute.Domain.Entidades.Entrega
{
    public class EntregaAdjuntoEntity
    {
        public int Id { get; set; }

        public int EntregaId { get; set; }
        public EntregaEntity Entrega { get; set; } = default!;

        public TipoAdjunto Tipo { get; set; }

        // Link: URL externa
        // Archivo: URL del storage
        public string Url { get; set; } = default!;

        public string? Nombre { get; set; }

        // Solo aplica si Tipo = Archivo
        public StorageProviderType? StorageProvider { get; set; }
        public string? StorageKey { get; set; }
        public string? ContentType { get; set; }
        public long? SizeBytes { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
