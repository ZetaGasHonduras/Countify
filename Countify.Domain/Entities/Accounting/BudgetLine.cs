using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class BudgetLine : BaseEntity
{
    public Guid BudgetId { get; set; }
    public Budget? Budget { get; set; }

    public Guid AccountId { get; set; }
    public Account? Account { get; set; }

    public Guid DepartmentId { get; set; }
    public Department? Department { get; set; }

    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }

    public decimal January { get; set; }
    public decimal February { get; set; }
    public decimal March { get; set; }
    public decimal April { get; set; }
    public decimal May { get; set; }
    public decimal June { get; set; }
    public decimal July { get; set; }
    public decimal August { get; set; }
    public decimal September { get; set; }
    public decimal October { get; set; }
    public decimal November { get; set; }
    public decimal December { get; set; }

    public decimal Total => January + February + March + April + May + June +
        July + August + September + October + November + December;
}
