using Countify.Domain.Common;
using Countify.Domain.Enums;

namespace Countify.Domain.Entities.Accounting;

/// <summary>
/// Control fiscal por tipo de documento (CAI, rangos y correlativos).
/// Corresponde a <c>ControlesFiscales</c> del sistema legacy.
/// </summary>
public class FiscalControl : BaseEntity
{
    public FiscalDocumentType DocumentType { get; set; }

    public string? Branch { get; set; }
    public string? EmissionPoint { get; set; }

    /// <summary>Segmento numérico del correlativo (legacy usaba "06" para nota de crédito).</summary>
    public string? DocumentCode { get; set; }

    public string? CAI { get; set; }
    public string? RangeFrom { get; set; }
    public string? RangeTo { get; set; }

    public DateTime? EmissionDate { get; set; }
    public DateTime? EmissionLimitDate { get; set; }

    public bool IsActive { get; set; } = true;

    /// <summary>Último correlativo asignado para este tipo de documento.</summary>
    public int LastNumber { get; set; }

    /// <summary>Correlativo a partir del cual se muestra el aviso de rango por agotarse.</summary>
    public int WarningNumber { get; set; }

    public string? Observations { get; set; }

    /// <summary>Correlativo que se asignará en el próximo documento de este tipo.</summary>
    public int NextNumber => LastNumber + 1;
}
