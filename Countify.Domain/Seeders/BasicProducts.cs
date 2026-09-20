using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicProducts
{
    public static readonly Product Services = new()
    {
        Id = Guid.Parse("70000000-0000-0000-0000-000000000001"),
        Code = "SERV-001",
        Name = "Servicios generales"
    };

    public static readonly Product OfficeSupplies = new()
    {
        Id = Guid.Parse("70000000-0000-0000-0000-000000000002"),
        Code = "MAT-001",
        Name = "Materiales de oficina"
    };

    public static readonly Product Equipment = new()
    {
        Id = Guid.Parse("70000000-0000-0000-0000-000000000003"),
        Code = "EQU-001",
        Name = "Equipo y mobiliario"
    };

    public static readonly Product[] Items = [Services, OfficeSupplies, Equipment];
}
