namespace Countify.Application.Features.Auth.DTOs;

public class AuthResponse
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public IList<string> Roles { get; set; } = [];
    public IList<string> Permissions { get; set; } = [];
}