namespace Countify.Application.Features.Configurations.DTOs;

public class CompanySettingsDto
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string TaxId { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int FiscalYear { get; set; }
    public Guid? DefaultProjectId { get; set; }
    public Guid? DefaultDepartmentId { get; set; }
    public bool UseDepartments { get; set; }
    public bool RequireDepartments { get; set; }
    public bool UseProjects { get; set; }
    public bool RequireProjects { get; set; }
    public bool UseSubProjects { get; set; }
    public bool RequireSubProjects { get; set; }
    public bool UseConceptTypes { get; set; }
    public bool RequireConceptTypes { get; set; }

    // Cuentas para la partida mensual de ventas (legacy: Controles).
    public Guid? SalesLocalAccountId { get; set; }
    public Guid? SalesForeignAccountId { get; set; }
    public Guid? ReceivableLocalAccountId { get; set; }
    public Guid? ReceivableForeignAccountId { get; set; }
    public Guid? CashAccountId { get; set; }
    public Guid? TaxPayableAccountId { get; set; }
    public Guid? InventoryAdjustmentAccountId { get; set; }
}
