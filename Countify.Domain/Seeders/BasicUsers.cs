using Countify.Domain.Entities.Auth;

namespace Countify.Domain.Seeders;

public static class BasicUsers
{
    public static readonly ApplicationUser SuperAdmin = new()
    {
        Id = "a1b2c3d4-0000-0000-0000-000000000001",
        UserName = "superadmin",
        NormalizedUserName = "SUPERADMIN",
        Email = "superadmin@nexum.com",
        NormalizedEmail = "SUPERADMIN@NEXUM.COM",
        EmailConfirmed = true,
        FirstName = "Super",
        LastName = "Admin",
        IsActive = true,
        CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
        SecurityStamp = "a1b2c3d4-0000-0000-0000-000000000001",
        ConcurrencyStamp = "a1b2c3d4-0000-0000-0000-000000000001",
        PasswordHash = "AQAAAAIAAYagAAAAEK8bEtGtCb/UDoybN4kOqOuD3301RFO4res70fBHqEQHqTue2QGGOoUlkc+4MI/2ag==" //SuperAdmin123!
    };
    
    public static ApplicationUser[] Items { get; } = [SuperAdmin];
}