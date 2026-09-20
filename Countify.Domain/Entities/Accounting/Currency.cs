using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class Currency : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal ExchangeRate { get; set; } = 1;
    public bool IsActive { get; set; } = true;
}
