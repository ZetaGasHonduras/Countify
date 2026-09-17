namespace Countify.Application.Features.JournalEntries.DTOs;

public class AccountMovementsResponse
{
    public Guid AccountId { get; set; }
    public string AccountCode { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public decimal DebitTotal { get; set; }
    public decimal CreditTotal { get; set; }
    public decimal Balance { get; set; }
    public List<AccountMovementDto> Movements { get; set; } = [];
}