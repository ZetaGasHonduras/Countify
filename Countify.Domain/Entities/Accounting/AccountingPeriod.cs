using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class AccountingPeriod : BaseEntity
{
    public DateTime Month { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsClosed { get; set; }
}