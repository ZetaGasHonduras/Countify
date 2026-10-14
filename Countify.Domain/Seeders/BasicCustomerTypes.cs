using Countify.Domain.Entities.AccountsReceivable;

namespace Countify.Domain.Seeders;

public static class BasicCustomerTypes
{
    public static readonly CustomerType Cash = new()
    {
        Id = Guid.Parse("0b000000-0000-0000-0000-000000000001"),
        Code = "CONTADO",
        Name = "Contado"
    };

    public static readonly CustomerType Credit = new()
    {
        Id = Guid.Parse("0b000000-0000-0000-0000-000000000002"),
        Code = "CREDITO",
        Name = "Crédito"
    };

    public static CustomerType[] Items { get; } = [Cash, Credit];
}