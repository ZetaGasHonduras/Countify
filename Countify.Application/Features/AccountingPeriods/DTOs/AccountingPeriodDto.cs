namespace Countify.Application.Features.AccountingPeriods.DTOs;

public class AccountingPeriodDto
{
    public Guid Id { get; set; }
    public DateTime Month { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsClosed { get; set; }
}