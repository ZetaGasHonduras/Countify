using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountsReceivableDocuments.Commands.CreateAccountsReceivableDocument;

public class CreateAccountsReceivableDocumentCommand : IRequest<Response<Guid>>
{
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
}

public class CreateAccountsReceivableDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateAccountsReceivableDocumentCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateAccountsReceivableDocumentCommand request, CancellationToken cancellationToken)
    {
        var customerExists = await unitOfWork.Customers.ExistsAsync(c => c.Id == request.CustomerId, cancellationToken);
        if (!customerExists)
            return Response<Guid>.Failure($"El cliente {request.CustomerId} no existe.");

        var concept = await unitOfWork.AccountsReceivableConcepts.FirstOrDefaultAsync(
            unitOfWork.AccountsReceivableConcepts.Query().Where(c => c.Id == request.ConceptId), cancellationToken);
        if (concept is null)
            return Response<Guid>.Failure($"El concepto {request.ConceptId} no existe.");

        var currencyExists = await unitOfWork.Currencies.ExistsAsync(c => c.Id == request.CurrencyId, cancellationToken);
        if (!currencyExists)
            return Response<Guid>.Failure($"La moneda {request.CurrencyId} no existe.");

        var customer = await unitOfWork.Customers.FirstOrDefaultAsync(
            unitOfWork.Customers.Query().Where(c => c.Id == request.CustomerId), cancellationToken);

        var document = mapper.Map<AccountsReceivableDocument>(request);

        if (concept.IsReceipt)
            document.ReceiptNumber = await NextReceiptNumber(unitOfWork, cancellationToken);

        await unitOfWork.AccountsReceivableDocuments.AddAsync(document, cancellationToken);

        if (concept.GeneratePosting)
        {
            var postingError = await AccountsReceivablePostingFactory.CreateOrUpdatePostingAsync(
                unitOfWork, document, customer, concept, cancellationToken);
            if (postingError is not null)
                return Response<Guid>.Failure(postingError);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(document.Id, 201);
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