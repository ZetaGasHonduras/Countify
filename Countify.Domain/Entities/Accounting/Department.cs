using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class Department : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}