namespace Countify.Application.Features.AccountsReceivableDocuments.DTOs;

public class AccountsReceivableDocumentAttachmentContentDto
{
    public string FileName { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public Stream Content { get; set; } = Stream.Null;
}
