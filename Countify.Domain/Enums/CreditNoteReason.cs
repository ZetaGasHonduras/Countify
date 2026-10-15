namespace Countify.Domain.Enums;

/// <summary>
/// Motivo de una nota de crédito.
/// Corresponde al enum legacy <c>PublicEnums.MotivoNotaDeCredito</c> (mismos valores).
/// </summary>
public enum CreditNoteReason
{
    Annulment = 0,
    Return = 1,
    Discounts = 2,
    Other = 3
}
