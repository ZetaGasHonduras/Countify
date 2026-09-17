using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class DocumentType : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
}