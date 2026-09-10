using Countify.Application.Features.Roles.DTOs;

namespace Countify.Application.Features.Users.DTOs;

public class UserDto
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public IList<RoleDto> Roles { get; set; } = [];
}