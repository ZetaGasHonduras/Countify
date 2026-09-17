using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicProjectGroups
{
    public static readonly Guid MainId = Guid.Parse("40000000-0000-0000-0000-000000000001");

    public static readonly ProjectGroup Main = new()
    {
        Id = MainId,
        Code = "PRY",
        Name = "Proyectos"
    };

    public static ProjectGroup[] Items { get; } = [Main];
}