namespace Countify.Application.Features.PayableDocuments.DTOs;

/// <summary>
/// Solicitud para crear un documento de CxP desde otro módulo (banco/partida),
/// espejo de <c>AccountsReceivableDocumentDraftRequest</c>. Equivalente legacy:
/// <c>BanDetCrearCXP_Execute</c> / <c>CntDocDetCrearCXP_Execute</c>.
/// </summary>
public class PayableDocumentDraftRequest
{
    public Guid SupplierId { get; set; }
    public Guid ConceptId { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public string? Reference { get; set; }
    public string? AppliesTo { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? ProjectId { get; set; }
    public Guid CurrencyId { get; set; }
    public decimal ExchangeRate { get; set; } = 1;
    public decimal Amount { get; set; }
    public decimal Tax { get; set; }
    public string? Notes { get; set; }
}
