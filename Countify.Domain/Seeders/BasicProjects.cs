using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicProjects
{
    public static readonly Project Central = new()
    {
        Id = Guid.Parse("40000000-0000-0000-0000-000000000002"),
        Code = "PRY-001",
        Name = "Proyecto Central",
        GroupId = BasicProjectGroups.MainId
    };

    public static readonly Project WithoutGroup = new()
    {
        Id = Guid.Parse("40000000-0000-0000-0000-000000000003"),
        Code = "PRY-002",
        Name = "Proyecto sin grupo"
    };

    public static Project[] Items { get; } = [Central, WithoutGroup];
}