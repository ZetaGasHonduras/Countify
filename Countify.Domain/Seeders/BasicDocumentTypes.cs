using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicDocumentTypes
{
    public static readonly DocumentType Partida = new()
    {
        Id = Guid.Parse("30000000-0000-0000-0000-000000000001"),
        Code = "PARTIDA",
        Name = "Partida",
        IsDefault = true
    };

    public static DocumentType[] Items { get; } = [Partida];
}