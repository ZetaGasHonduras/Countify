namespace Countify.Application.Features.Customers.DTOs;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? CustomerTypeId { get; set; }
    public string? CustomerTypeCode { get; set; }
    public string? CustomerTypeName { get; set; }
    public string? TaxId { get; set; }
    public string? IdentityDocument { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public int CreditDays { get; set; }
    public decimal CreditLimit { get; set; }
    public Guid? AccountingAccountId { get; set; }
    public string? AccountingAccountCode { get; set; }
    public string? AccountingAccountName { get; set; }
    public bool IsInactive { get; set; }
}