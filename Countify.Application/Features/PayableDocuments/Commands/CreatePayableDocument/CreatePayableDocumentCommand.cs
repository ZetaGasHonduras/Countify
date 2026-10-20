using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.PayableDocuments.Commands.CreatePayableDocument;

public class CreatePayableDocumentCommand : IRequest<Response<Guid>>
{
    public Guid SupplierId { get; set; }
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
    public decimal Tax { get; set; }
    public string? Notes { get; set; }
}

public class CreatePayableDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreatePayableDocumentCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreatePayableDocumentCommand request, CancellationToken cancellationToken)
    {
        var supplier = await unitOfWork.Suppliers.FirstOrDefaultAsync(
            unitOfWork.Suppliers.Query().Where(s => s.Id == request.SupplierId), cancellationToken);
        if (supplier is null)
            return Response<Guid>.Failure($"El proveedor {request.SupplierId} no existe.");

        var concept = await unitOfWork.PayableConcepts.FirstOrDefaultAsync(
            unitOfWork.PayableConcepts.Query().Where(c => c.Id == request.ConceptId), cancellationToken);
        if (concept is null)
            return Response<Guid>.Failure($"El concepto {request.ConceptId} no existe.");

        var currencyExists = await unitOfWork.Currencies.ExistsAsync(c => c.Id == request.CurrencyId, cancellationToken);
        if (!currencyExists)
            return Response<Guid>.Failure($"La moneda {request.CurrencyId} no existe.");

        var document = mapper.Map<PayableDocument>(request);
        document.TaxLocal = Math.Round(request.Tax * request.ExchangeRate, 2);

        // Snapshot del proveedor + datos fiscales de su SupplierFiscalData activo (§3.3/§3.6 del roadmap).
        document.SupplierRegistration = supplier.Registration;
        document.SupplierAddress = supplier.Address;

        if (concept.Type == PayableConceptType.Debit)
        {
            var fiscal = await unitOfWork.SupplierFiscalData.FirstOrDefaultAsync(
                unitOfWork.SupplierFiscalData.Query()
                    .Where(f => f.SupplierId == supplier.Id && f.IsActive),
                cancellationToken);

            document.CAI = fiscal?.CAI;
            document.RangeFrom = fiscal?.RangeFrom;
            document.RangeTo = fiscal?.RangeTo;
            document.Correlative = fiscal?.Correlative;
            document.EmissionLimitDate = fiscal?.EmissionLimitDate;
        }

        await unitOfWork.PayableDocuments.AddAsync(document, cancellationToken);

        if (concept.GeneratePosting)
        {
            var postingError = await PayablePostingFactory.CreateOrUpdatePostingAsync(
                unitOfWork, document, supplier, concept, cancellationToken);
            if (postingError is not null)
                return Response<Guid>.Failure(postingError);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(document.Id, 201);
    }
}
