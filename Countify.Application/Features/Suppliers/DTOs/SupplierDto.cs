namespace Countify.Application.Features.Suppliers.DTOs;

public class SupplierDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? SupplierTypeId { get; set; }
    public string? SupplierTypeCode { get; set; }
    public string? SupplierTypeName { get; set; }
    public string? TaxId { get; set; }
    public string? IdentityDocument { get; set; }
    public string? Registration { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPosition { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public int CreditDays { get; set; }
    public decimal CreditLimit { get; set; }
    public Guid? AccountingAccountId { get; set; }
    public string? AccountingAccountCode { get; set; }
    public string? AccountingAccountName { get; set; }
    public bool IsInactive { get; set; }
    public List<SupplierFiscalDataDto> FiscalData { get; set; } = [];
}
