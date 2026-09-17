namespace Countify.Application.Features.JournalEntries.DTOs;

public class AccountMovementDto
{
    public Guid JournalEntryId { get; set; }
    public int EntryNumber { get; set; }
    public DateTime ReferenceDate { get; set; }
    public string Concept { get; set; } = string.Empty;
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public decimal Balance { get; set; }
}