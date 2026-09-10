namespace Countify.Application.Features.Users.DTOs;

public class UserDetailDto : UserDto
{
    public DateTime? LastActivity { get; set; }
    public string? CreatedBy { get; set; }
}