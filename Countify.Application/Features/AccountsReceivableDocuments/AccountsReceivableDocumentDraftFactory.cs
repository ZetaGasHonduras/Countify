using Countify.Application.Features.AccountsReceivableDocuments.DTOs;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Interfaces;

namespace Countify.Application.Features.AccountsReceivableDocuments;

internal static class AccountsReceivableDocumentDraftFactory
{
    public static async Task<DraftCreationResult> CreateAsync(
        IUnitOfWork unitOfWork,
        AccountsReceivableDocumentDraftRequest draft,
        CancellationToken cancellationToken)
    {
        var customer = await unitOfWork.Customers.GetByIdAsync(draft.CustomerId, cancellationToken);
        if (customer is null)
            return DraftCreationResult.Failure("El cliente del documento por cobrar no existe.");

        var concept = await unitOfWork.AccountsReceivableConcepts.FirstOrDefaultAsync(
            unitOfWork.AccountsReceivableConcepts.Query().Where(c => c.Id == draft.ConceptId), cancellationToken);
        if (concept is null)
            return DraftCreationResult.Failure("El concepto del documento por cobrar no existe.");

        var currencyExists = await unitOfWork.Currencies.ExistsAsync(c => c.Id == draft.CurrencyId, cancellationToken);
        if (!currencyExists)
            return DraftCreationResult.Failure("La moneda del documento por cobrar no existe.");

        var document = new AccountsReceivableDocument
        {
            CustomerId = draft.CustomerId,
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
            Notes = draft.Notes,
        };

        if (concept.IsReceipt)
            document.ReceiptNumber = await NextReceiptNumber(unitOfWork, cancellationToken);

        await unitOfWork.AccountsReceivableDocuments.AddAsync(document, cancellationToken);

        return DraftCreationResult.Success(document, customer.Code, customer.Name);
    }

    private static async Task<int> NextReceiptNumber(IUnitOfWork unitOfWork, CancellationToken cancellationToken)
    {
        var last = await unitOfWork.AccountsReceivableDocuments.FirstOrDefaultAsync(
            unitOfWork.AccountsReceivableDocuments.Query()
                .Where(d => d.ReceiptNumber != null)
                .OrderByDescending(d => d.ReceiptNumber),
            cancellationToken);

        return (last?.ReceiptNumber ?? 0) + 1;
    }
}

internal readonly record struct DraftCreationResult(AccountsReceivableDocument? Document, string? CustomerCode, string? CustomerName, string? Error)
{
    public static DraftCreationResult Success(AccountsReceivableDocument document, string customerCode, string customerName)
        => new(document, customerCode, customerName, null);

    public static DraftCreationResult Failure(string error)
        => new(null, null, null, error);
}