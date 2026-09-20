using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class Quality : BaseEntity
{
    public string? Code { get; set; }
    public string Name { get; set; } = string.Empty;
}