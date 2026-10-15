using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountsReceivableDocuments.Commands.UpdateAccountsReceivableDocument;

public class UpdateAccountsReceivableDocumentCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
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
    public string? Notes { get; set; }

    // Solo para notas fiscales (crédito/débito)
    public CreditNoteReason? CreditNoteReason { get; set; }
    public string? FiscalConcept { get; set; }
}

public class UpdateAccountsReceivableDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateAccountsReceivableDocumentCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateAccountsReceivableDocumentCommand request, CancellationToken cancellationToken)
    {
        var document = await unitOfWork.AccountsReceivableDocuments.GetByIdAsync(request.Id, cancellationToken);
        if (document is null)
            return Response<bool>.NotFound($"Documento por cobrar {request.Id} no encontrado.");

        if (document.IsVoided)
            return Response<bool>.Failure("El documento está anulado y no puede modificarse.");

        var customerExists = await unitOfWork.Customers.ExistsAsync(c => c.Id == request.CustomerId, cancellationToken);
        if (!customerExists)
            return Response<bool>.Failure($"El cliente {request.CustomerId} no existe.");

        var concept = await unitOfWork.AccountsReceivableConcepts.FirstOrDefaultAsync(
            unitOfWork.AccountsReceivableConcepts.Query().Where(c => c.Id == request.ConceptId), cancellationToken);
        if (concept is null)
            return Response<bool>.Failure($"El concepto {request.ConceptId} no existe.");

        var currencyExists = await unitOfWork.Currencies.ExistsAsync(c => c.Id == request.CurrencyId, cancellationToken);
        if (!currencyExists)
            return Response<bool>.Failure($"La moneda {request.CurrencyId} no existe.");

        var customer = await unitOfWork.Customers.FirstOrDefaultAsync(
            unitOfWork.Customers.Query().Where(c => c.Id == request.CustomerId), cancellationToken);

        mapper.Map(request, document);

        if (concept.IsReceipt && document.ReceiptNumber is null)
        {
            document.ReceiptNumber = await FiscalNoteNumberingFactory.NextReceiptNumberAsync(unitOfWork, cancellationToken);
            document.ReceiptNumberAssigned = true;
        }

        var fiscalError = await FiscalNoteNumberingFactory.AssignAsync(unitOfWork, document, concept, cancellationToken);
        if (fiscalError is not null)
            return Response<bool>.Failure(fiscalError);

        await unitOfWork.AccountsReceivableDocuments.UpdateAsync(document, cancellationToken);

        if (concept.GeneratePosting || document.JournalEntryId is not null)
        {
            var postingError = await AccountsReceivablePostingFactory.CreateOrUpdatePostingAsync(
                unitOfWork, document, customer, concept, cancellationToken);
            if (postingError is not null)
                return Response<bool>.Failure(postingError);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
