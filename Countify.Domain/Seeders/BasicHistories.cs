using Countify.Domain.Entities.Audit;

namespace Countify.Domain.Seeders;

public static class BasicHistories
{
    public static History[] Items { get; } =
    [
        new History
        {
            Id = Guid.Parse("81000000-0000-0000-0000-000000000001"),
            Entity = "JournalEntry",
            Property = "Status",
            EntityId = BasicJournalEntries.OpeningEntry.Id,
            Date = DateTime.UtcNow,
            UserId = Guid.Parse(BasicUsers.SuperAdmin.Id),
            UserName = BasicUsers.SuperAdmin.UserName ?? "",
            OldValue = "Draft",
            NewValue = "Posted"
        }
    ];
}