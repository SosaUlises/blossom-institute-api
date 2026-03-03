namespace BlossomInstitute.Domain.Entidades.Entrega
{
    public class FeedbackEntregaEntity
    {
        public int Id { get; set; }

        public int EntregaId { get; set; }
        public EntregaEntity Entrega { get; set; } = default!;

        public string? Comentario { get; set; }

        public EstadoCorreccion Estado { get; set; }

        public decimal? Nota { get; set; }

        public DateTime FechaCorreccionUtc { get; set; } = DateTime.UtcNow;

        // adjunto corregido 
        public string? ArchivoCorregidoUrl { get; set; }
        public string? ArchivoCorregidoNombre { get; set; }
    }
}
