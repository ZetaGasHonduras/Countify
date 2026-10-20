namespace Countify.Application.Features.PayableDocuments.DTOs;

public class PayableDocumentAttachmentContentDto
{
    public string FileName { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public Stream Content { get; set; } = Stream.Null;
}
