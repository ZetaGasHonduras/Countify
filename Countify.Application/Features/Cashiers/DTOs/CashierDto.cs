namespace Countify.Application.Features.Cashiers.DTOs;

public class CashierDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public bool IsInactive { get; set; }
}
