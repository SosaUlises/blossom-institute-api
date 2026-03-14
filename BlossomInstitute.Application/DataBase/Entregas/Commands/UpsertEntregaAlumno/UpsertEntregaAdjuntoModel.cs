using BlossomInstitute.Domain.Entidades.Common;
using BlossomInstitute.Domain.Entidades.Entrega;

namespace BlossomInstitute.Application.DataBase.Entregas.Commands.UpsertEntregaAlumno
{
    public class UpsertEntregaAdjuntoModel
    {
        public TipoAdjunto Tipo { get; set; }
        public string? Url { get; set; }
        public string? Nombre { get; set; }
        public StorageProviderType? StorageProvider { get; set; }
        public string? StorageKey { get; set; }
        public string? ContentType { get; set; }
        public long? SizeBytes { get; set; }
    }
}
