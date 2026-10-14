namespace Countify.Application.Features.Auth.DTOs;

public class UserInfoResponse
{
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = string.Empty;
    public IList<string> Roles { get; set; } = [];
    public IList<string> Permissions { get; set; } = [];
}