using Microsoft.AspNetCore.Identity;

namespace Countify.Domain.Seeders;

public static class BasicRoles
{
    public static readonly IdentityRole SuperAdmin = new()
    {
        Id = "f3d1e2c4-0000-0000-0000-000000000001",
        Name = "SuperAdmin",
        NormalizedName = "SUPERADMIN",
        ConcurrencyStamp = "f3d1e2c4-0000-0000-0000-000000000001"
    };

    private static readonly IdentityRole Admin = new()
    {
        Id = "f3d1e2c4-0000-0000-0000-000000000002",
        Name = "Admin",
        NormalizedName = "ADMIN",
        ConcurrencyStamp = "f3d1e2c4-0000-0000-0000-000000000002"
    };

    public static IdentityRole[] Items { get; } = [SuperAdmin, Admin];
}