using Countify.Application.Features.PayableDocuments.DTOs;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PayableDocuments;

/// <summary>
/// Crea un documento de CxP desde otro módulo (movimiento bancario o partida contable).
/// Espejo de <c>AccountsReceivableDocumentDraftFactory</c>: no genera partida propia —
/// el asiento lo produce el módulo de origen, y la línea enlaza vía AppliesToPayableId.
/// Equivalente legacy: <c>BanDetCrearCXP_Execute</c> / <c>CntDocDetCrearCXP_Execute</c>.
/// </summary>
internal static class PayableDocumentDraftFactory
{
    public static async Task<PayableDraftCreationResult> CreateAsync(
        IUnitOfWork unitOfWork,
        PayableDocumentDraftRequest draft,
        CancellationToken cancellationToken)
    {
        var supplier = await unitOfWork.Suppliers.GetByIdAsync(draft.SupplierId, cancellationToken);
        if (supplier is null)
            return PayableDraftCreationResult.Failure("El proveedor del documento por pagar no existe.");

        var concept = await unitOfWork.PayableConcepts.FirstOrDefaultAsync(
            unitOfWork.PayableConcepts.Query().Where(c => c.Id == draft.ConceptId), cancellationToken);
        if (concept is null)
            return PayableDraftCreationResult.Failure("El concepto del documento por pagar no existe.");

        var currencyExists = await unitOfWork.Currencies.ExistsAsync(c => c.Id == draft.CurrencyId, cancellationToken);
        if (!currencyExists)
            return PayableDraftCreationResult.Failure("La moneda del documento por pagar no existe.");

        var document = new PayableDocument
        {
            SupplierId = draft.SupplierId,
            ConceptId = draft.ConceptId,
            Date = draft.Date,
            DueDate = draft.DueDate,
            Reference = draft.Reference,
            AppliesTo = draft.AppliesTo,
            DepartmentId = draft.DepartmentId,
            ProjectId = draft.ProjectId,
            CurrencyId = draft.CurrencyId,
            ExchangeRate = draft.ExchangeRate <= 0 ? 1 : draft.ExchangeRate,
            Amount = draft.Amount,
            Tax = draft.Tax,
            TaxLocal = Math.Round(draft.Tax * (draft.ExchangeRate <= 0 ? 1 : draft.ExchangeRate), 2),
            Notes = draft.Notes,
            SupplierRegistration = supplier.Registration,
            SupplierAddress = supplier.Address,
        };

        // Compras (Debit=1) heredan el dato fiscal activo del proveedor (legacy: CXPDocumentos copia CAI/rangos).
        if (concept.Type == PayableConceptType.Debit)
        {
            var fiscal = await unitOfWork.SupplierFiscalData.Query()
                .FirstOrDefaultAsync(f => f.SupplierId == supplier.Id && f.IsActive, cancellationToken);

            document.CAI = fiscal?.CAI;
            document.RangeFrom = fiscal?.RangeFrom;
            document.RangeTo = fiscal?.RangeTo;
            document.Correlative = fiscal?.Correlative;
            document.EmissionLimitDate = fiscal?.EmissionLimitDate;
        }

        await unitOfWork.PayableDocuments.AddAsync(document, cancellationToken);

        return PayableDraftCreationResult.Success(document, supplier.Code, supplier.Name);
    }
}

internal readonly record struct PayableDraftCreationResult(PayableDocument? Document, string? SupplierCode, string? SupplierName, string? Error)
{
    public static PayableDraftCreationResult Success(PayableDocument document, string supplierCode, string supplierName)
        => new(document, supplierCode, supplierName, null);

    public static PayableDraftCreationResult Failure(string error)
        => new(null, null, null, error);
}
