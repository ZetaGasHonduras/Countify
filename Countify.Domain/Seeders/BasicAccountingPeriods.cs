using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicAccountingPeriods
{
    public static readonly AccountingPeriod TwoMonthsAgo = new()
    {
        Id = Guid.Parse("70000000-0000-0000-0000-000000000001"),
        Month = MonthOf(DateTime.UtcNow.AddMonths(-2)),
        StartDate = MonthOf(DateTime.UtcNow.AddMonths(-2)),
        EndDate = EndOf(DateTime.UtcNow.AddMonths(-2)),
        IsClosed = true
    };

    public static readonly AccountingPeriod LastMonth = new()
    {
        Id = Guid.Parse("70000000-0000-0000-0000-000000000002"),
        Month = MonthOf(DateTime.UtcNow.AddMonths(-1)),
        StartDate = MonthOf(DateTime.UtcNow.AddMonths(-1)),
        EndDate = EndOf(DateTime.UtcNow.AddMonths(-1)),
        IsClosed = true
    };

    public static readonly AccountingPeriod Current = new()
    {
        Id = Guid.Parse("70000000-0000-0000-0000-000000000003"),
        Month = MonthOf(DateTime.UtcNow),
        StartDate = MonthOf(DateTime.UtcNow),
        EndDate = EndOf(DateTime.UtcNow),
        IsClosed = false
    };

    public static AccountingPeriod[] Items { get; } = [TwoMonthsAgo, LastMonth, Current];

    private static DateTime MonthOf(DateTime value)
        => new(value.Year, value.Month, 1, 0, 0, 0, DateTimeKind.Utc);

    private static DateTime EndOf(DateTime value)
        => MonthOf(value).AddMonths(1).AddMilliseconds(-1);
}