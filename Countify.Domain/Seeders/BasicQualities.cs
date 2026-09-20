using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicQualities
{
    public static readonly Quality Standard = new()
    {
        Id = Guid.Parse("80000000-0000-0000-0000-000000000001"),
        Code = "STD",
        Name = "Estandar"
    };

    public static readonly Quality Premium = new()
    {
        Id = Guid.Parse("80000000-0000-0000-0000-000000000002"),
        Code = "PREM",
        Name = "Premium"
    };

    public static readonly Quality[] Items = [Standard, Premium];
}
