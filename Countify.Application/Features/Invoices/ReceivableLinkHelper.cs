using Countify.Domain.Entities.Billing;
using Countify.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Invoices;

/// <summary>
/// Enlace factura ↔ documento de cuentas por cobrar.
/// Legacy: <c>CrearCXC.CrearCuentasPorCobrar</c> (al guardar) y
/// <c>AnularFacturas</c> (concepto ANULACION DE FACTURA al anular).
/// </summary>
internal static class ReceivableLinkHelper
{
    /// <summary>Crea el documento CxC de la factura (concepto FACTURA) y lo enlaza.</summary>
    public static async Task<string?> CreateForInvoiceAsync(
        IUnitOfWork unitOfWork, Invoice invoice, CancellationToken cancellationToken)
    {
        var concept = await FindConceptAsync(unitOfWork, "FACTURA", cancellationToken);
        if (concept is null)
            return "No existe el concepto FACTURA en cuentas por cobrar. Siémbrelo o cree uno.";

        var document = new Domain.Entities.AccountsReceivable.AccountsReceivableDocument
        {
            CustomerId = invoice.CustomerId,
            ConceptId = concept.Id,
            Date = invoice.Date,
            DueDate = invoice.DueDate,
            Reference = invoice.Number,
            AppliesTo = invoice.Number,
            DepartmentId = invoice.DepartmentId,
            ProjectId = invoice.ProjectId,
            CurrencyId = invoice.CurrencyId,
            ExchangeRate = invoice.ExchangeRate,
            Amount = invoice.Total,
            Notes = $"Generada desde la factura {invoice.Number}",
        };

        await unitOfWork.AccountsReceivableDocuments.AddAsync(document, cancellationToken);
        invoice.ReceivableDocumentId = document.Id;
        return null;
    }

    /// <summary>Actualiza el documento CxC enlazado (fechas, monto) al editar la factura.</summary>
    public static async Task<string?> SyncWithInvoiceAsync(
        IUnitOfWork unitOfWork, Invoice invoice, CancellationToken cancellationToken)
    {
        if (invoice.ReceivableDocumentId is not Guid docId)
            return await CreateForInvoiceAsync(unitOfWork, invoice, cancellationToken);

        var document = await unitOfWork.AccountsReceivableDocuments.GetByIdAsync(docId, cancellationToken);
        if (document is null)
        {
            invoice.ReceivableDocumentId = null;
            return await CreateForInvoiceAsync(unitOfWork, invoice, cancellationToken);
        }

        document.Date = invoice.Date;
        document.DueDate = invoice.DueDate;
        document.Amount = invoice.Total;
        document.ExchangeRate = invoice.ExchangeRate;
        document.CurrencyId = invoice.CurrencyId;
        await unitOfWork.AccountsReceivableDocuments.UpdateAsync(document, cancellationToken);
        return null;
    }

    /// <summary>
    /// Elimina el documento enlazado si la factura pasa de Crédito a Contado.
    /// Bloqueado si el documento ya tiene partida o aplicaciones.
    /// </summary>
    public static async Task<string?> RemoveForInvoiceAsync(
        IUnitOfWork unitOfWork, Invoice invoice, CancellationToken cancellationToken)
    {
        if (invoice.ReceivableDocumentId is not Guid docId)
            return null;

        var document = await unitOfWork.AccountsReceivableDocuments.GetByIdAsync(docId, cancellationToken);
        if (document is not null)
        {
            if (document.JournalEntryId is not null)
                return "El documento de cuentas por cobrar ya tiene partida generada; no se puede cambiar a contado.";

            var applied = await unitOfWork.AccountsReceivableDocumentLines.ExistsAsync(
                l => l.DocumentId == docId || l.AppliedDocumentId == docId, cancellationToken);
            if (applied)
                return "El documento de cuentas por cobrar ya tiene aplicaciones; no se puede cambiar a contado.";

            await unitOfWork.AccountsReceivableDocuments.DeleteAsync(document, cancellationToken);
        }

        invoice.ReceivableDocumentId = null;
        return null;
    }

    /// <summary>Crea el documento de anulación (concepto ANULACION DE FACTURA) al anular la factura.</summary>
    public static async Task<string?> CreateCancellationAsync(
        IUnitOfWork unitOfWork, Invoice invoice, string? reason, CancellationToken cancellationToken)
    {
        var concept = await FindConceptAsync(unitOfWork, "ANULACION DE FACTURA", cancellationToken);
        if (concept is null)
            return "No existe el concepto ANULACION DE FACTURA en cuentas por cobrar.";

        var today = DateTime.Today;
        var document = new Domain.Entities.AccountsReceivable.AccountsReceivableDocument
        {
            CustomerId = invoice.CustomerId,
            ConceptId = concept.Id,
            Date = today,
            DueDate = today,
            Reference = invoice.Number,
            AppliesTo = invoice.Number,
            DepartmentId = invoice.DepartmentId,
            ProjectId = invoice.ProjectId,
            CurrencyId = invoice.CurrencyId,
            ExchangeRate = invoice.ExchangeRate,
            Amount = invoice.Total,
            Notes = $"Anulación de la factura {invoice.Number}. Motivo: {reason}",
        };

        await unitOfWork.AccountsReceivableDocuments.AddAsync(document, cancellationToken);
        return null;
    }

    private static async Task<Domain.Entities.AccountsReceivable.AccountsReceivableConcept?> FindConceptAsync(
        IUnitOfWork unitOfWork, string description, CancellationToken cancellationToken)
        => await unitOfWork.AccountsReceivableConcepts.Query()
            .FirstOrDefaultAsync(c => c.Description == description, cancellationToken);
}
