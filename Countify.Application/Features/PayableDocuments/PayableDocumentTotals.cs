using Countify.Domain.Entities.AccountsPayable;

namespace Countify.Application.Features.PayableDocuments;

internal static class PayableDocumentTotals
{
    /// <summary>Total del documento = Amount + Tax (decisión §6.2 del roadmap).</summary>
    public static decimal Total(this PayableDocument document)
        => Math.Round(document.Amount + document.Tax, 2);
}
