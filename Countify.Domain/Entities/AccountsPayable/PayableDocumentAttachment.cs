using Countify.Domain.Common;

namespace Countify.Domain.Entities.AccountsPayable;

/// <summary>
/// Archivo adjunto de un documento por pagar.
/// Corresponde al campo <c>Adjunto</c> (FileData) de <c>CXPDocumentos</c> en el legacy.
/// </summary>
public class PayableDocumentAttachment : BaseEntity
{
    public Guid DocumentId { get; set; }
    public PayableDocument? Document { get; set; }

    public string FileName { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public long Size { get; set; }

    /// <summary>Ruta relativa dentro del almacenamiento de adjuntos configurado.</summary>
    public string StoragePath { get; set; } = string.Empty;

    public DateTime UploadedOn { get; set; }
    public string? UploadedBy { get; set; }
}
