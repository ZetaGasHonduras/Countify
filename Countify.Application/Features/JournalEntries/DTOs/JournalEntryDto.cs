using Countify.Domain.Enums;

namespace Countify.Application.Features.JournalEntries.DTOs;

public class JournalEntryDto
{
    public Guid Id { get; set; }
    public Guid Gid { get; set; }
    public int EntryNumber { get; set; }
    public string? Code { get; set; }
    public Guid TypeId { get; set; }
    public string TypeName { get; set; } = null!;
    public Guid? PeriodId { get; set; }
    public DateTime ReferenceDate { get; set; }
    public string Reference { get; set; } = null!;
    public string Concept { get; set; } = null!;
    public string? Observations { get; set; }
    public decimal DebitTotal { get; set; }
    public decimal CreditTotal { get; set; }
    public decimal DifferenceAmount { get; set; }
    public JournalEntryStatus Status { get; set; }
    public SourceModule SourceModule { get; set; }
    public List<JournalEntryLineDto> Lines { get; set; } = [];
}