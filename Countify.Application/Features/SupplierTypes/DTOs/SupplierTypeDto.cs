namespace Countify.Application.Features.SupplierTypes.DTOs;

public class SupplierTypeDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? AccountingAccountId { get; set; }
    public string? AccountingAccountCode { get; set; }
    public string? AccountingAccountName { get; set; }
}
