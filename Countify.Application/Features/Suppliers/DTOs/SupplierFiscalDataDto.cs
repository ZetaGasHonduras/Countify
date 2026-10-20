namespace Countify.Application.Features.Suppliers.DTOs;

/// <summary>
/// Datos fiscales del proveedor (CAI, rangos, correlativo). También se usa como
/// entrada en los comandos de creación/actualización: un <see cref="Id"/> vacío
/// indica una fila nueva.
/// </summary>
public class SupplierFiscalDataDto
{
    public Guid Id { get; set; }
    public string? Branch { get; set; }
    public string? CAI { get; set; }
    public string? RangeFrom { get; set; }
    public string? RangeTo { get; set; }
    public string? Correlative { get; set; }
    public DateTime? EmissionLimitDate { get; set; }
    public bool IsActive { get; set; } = true;
}
