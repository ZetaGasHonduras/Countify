namespace Countify.Application.Features.PaymentMethods.DTOs;

public class PaymentMethodDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsInactive { get; set; }
    public bool IsDefault { get; set; }
}
