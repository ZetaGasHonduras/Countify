using Countify.Domain.Entities.AccountsPayable;

namespace Countify.Domain.Seeders;

/// <summary>
/// Conceptos de CxP iniciales. Espejo de <c>BasicAccountsReceivableConcepts</c>.
/// "COMPRAS GENERALES" conserva el nombre exacto del legacy: el sistema viejo la
/// buscaba por <c>Contains([Descripcion],'COMPRAS GENERALES')</c> para generar la
/// partida de compras (<c>CrearCXP.cs</c>).
/// </summary>
public static class BasicPayableConcepts
{
    public static readonly PayableConcept Purchase = NewConcept(
        1, "COMPRAS GENERALES", PayableConceptType.Debit, generatePosting: true);

    public static readonly PayableConcept Payment = NewConcept(
        2, "PAGO A PROVEEDORES", PayableConceptType.Credit, generatePosting: true, isPayment: true);

    public static PayableConcept[] Items { get; } = [Purchase, Payment];

    private static PayableConcept NewConcept(
        int id, string description, PayableConceptType type, bool generatePosting,
        bool isPayment = false)
        => new()
        {
            Id = Guid.Parse($"0c000000-0000-0000-0000-000000000{id:D3}"),
            Description = description,
            Type = type,
            GeneratePosting = generatePosting,
            IsPayment = isPayment
        };
}
