namespace Countify.Domain.Enums;

/// <summary>
/// Tipo de documento fiscal controlado por CAI.
/// Corresponde al enum legacy <c>PublicEnums.TipoFiscal</c>.
/// </summary>
public enum FiscalDocumentType
{
    Invoicing = 0,
    DebitNote = 1,
    CreditNote = 2,
    DispatchGuide = 3,
    Retention = 4
}
