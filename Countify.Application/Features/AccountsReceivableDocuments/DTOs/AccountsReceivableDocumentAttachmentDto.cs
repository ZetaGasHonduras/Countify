namespace Countify.Application.Features.AccountsReceivableDocuments.DTOs;

public class AccountsReceivableDocumentAttachmentDto
{
    public Guid Id { get; set; }
    public Guid DocumentId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public long Size { get; set; }
    public DateTime UploadedOn { get; set; }
    public string? UploadedBy { get; set; }
}
