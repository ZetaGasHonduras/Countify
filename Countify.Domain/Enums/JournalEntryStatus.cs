namespace Countify.Domain.Enums;

public enum JournalEntryStatus
{
    Draft = 0,
    // Kept only to read legacy records; new entries never transition through approval.
    Approved = 1,
    Posted = 2,
    Voided = 3
}
