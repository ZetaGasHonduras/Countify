namespace Countify.Application.Features.Invoices.DTOs;

public class InvoicePaymentDto
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public string PaymentMethodName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
