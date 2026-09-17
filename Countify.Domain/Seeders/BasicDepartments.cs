using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicDepartments
{
    public static readonly Department General = new()
    {
        Id = Guid.Parse("60000000-0000-0000-0000-000000000001"),
        Code = "GER",
        Name = "Gerencia"
    };

    public static readonly Department Administration = new()
    {
        Id = Guid.Parse("60000000-0000-0000-0000-000000000002"),
        Code = "ADM",
        Name = "Administración"
    };

    public static readonly Department Operations = new()
    {
        Id = Guid.Parse("60000000-0000-0000-0000-000000000003"),
        Code = "OPR",
        Name = "Operaciones"
    };

    public static readonly Department Sales = new()
    {
        Id = Guid.Parse("60000000-0000-0000-0000-000000000004"),
        Code = "VNT",
        Name = "Ventas"
    };

    public static Department[] Items { get; } = [General, Administration, Operations, Sales];
}