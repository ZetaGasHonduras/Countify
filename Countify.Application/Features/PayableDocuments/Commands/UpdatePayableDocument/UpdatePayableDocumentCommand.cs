using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.PayableDocuments.Commands.UpdatePayableDocument;

public class UpdatePayableDocumentCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
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

public class UpdatePayableDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdatePayableDocumentCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdatePayableDocumentCommand request, CancellationToken cancellationToken)
    {
        var document = await unitOfWork.PayableDocuments.GetByIdAsync(request.Id, cancellationToken);
        if (document is null)
            return Response<bool>.NotFound($"Documento por pagar {request.Id} no encontrado.");

        if (document.IsVoided)
            return Response<bool>.Failure("El documento está anulado y no puede modificarse.");

        var supplier = await unitOfWork.Suppliers.FirstOrDefaultAsync(
            unitOfWork.Suppliers.Query().Where(s => s.Id == request.SupplierId), cancellationToken);
        if (supplier is null)
            return Response<bool>.Failure($"El proveedor {request.SupplierId} no existe.");

        var concept = await unitOfWork.PayableConcepts.FirstOrDefaultAsync(
            unitOfWork.PayableConcepts.Query().Where(c => c.Id == request.ConceptId), cancellationToken);
        if (concept is null)
            return Response<bool>.Failure($"El concepto {request.ConceptId} no existe.");

        var currencyExists = await unitOfWork.Currencies.ExistsAsync(c => c.Id == request.CurrencyId, cancellationToken);
        if (!currencyExists)
            return Response<bool>.Failure($"La moneda {request.CurrencyId} no existe.");

        mapper.Map(request, document);
        document.TaxLocal = Math.Round(request.Tax * request.ExchangeRate, 2);

        // Recalcular snapshot y datos fiscales contra el proveedor/concepto actuales.
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
        else
        {
            document.CAI = null;
            document.RangeFrom = null;
            document.RangeTo = null;
            document.Correlative = null;
            document.EmissionLimitDate = null;
        }

        await unitOfWork.PayableDocuments.UpdateAsync(document, cancellationToken);

        if (concept.GeneratePosting || document.JournalEntryId is not null)
        {
            var postingError = await PayablePostingFactory.CreateOrUpdatePostingAsync(
                unitOfWork, document, supplier, concept, cancellationToken);
            if (postingError is not null)
                return Response<bool>.Failure(postingError);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
