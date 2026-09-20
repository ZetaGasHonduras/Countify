using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class Budget : BaseEntity
{
    public int FiscalYear { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<BudgetLine> Lines { get; set; } = [];
}
