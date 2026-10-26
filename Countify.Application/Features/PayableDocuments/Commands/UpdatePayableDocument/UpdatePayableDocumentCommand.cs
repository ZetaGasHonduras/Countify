using AutoMapper;
using Countify.Application.Features.InventoryMovements;
using Countify.Application.Features.PayableDocuments.Commands.CreatePayableDocument;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

    // --- Ingreso de Compras (inmutable tras la creación; las líneas sí se editan) ---
    public bool IsPurchaseEntry { get; set; }
    public Guid? WarehouseId { get; set; }
    public List<CreatePayableDocumentCommand.PurchaseEntryLineInput> InventoryLines { get; set; } = [];
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

        if (request.IsPurchaseEntry != document.IsPurchaseEntry)
            return Response<bool>.Failure("Un ingreso de compras no puede convertirse en documento común (ni al revés); anule y cree otro.");

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

        InventoryMovement? movement = null;

        if (document.IsPurchaseEntry)
        {
            var error = await PurchaseEntryHelper.ValidateWarehouseAsync(
                unitOfWork, request.WarehouseId, cancellationToken);
            if (error is not null)
                return Response<bool>.Failure(error);

            var (builtLines, linesError) = await PurchaseEntryHelper.BuildLinesAsync(
                unitOfWork, request.WarehouseId!.Value, request.InventoryLines, cancellationToken);
            if (linesError is not null)
                return Response<bool>.Failure(linesError);

            movement = await unitOfWork.InventoryMovements.Query()
                .Include(m => m.Lines)
                .FirstOrDefaultAsync(m => m.Id == document.InventoryMovementId, cancellationToken);

            if (movement is null)
                return Response<bool>.Failure("El movimiento 'COM' del ingreso no se encontró.");

            if (movement.IsVoided)
                return Response<bool>.Failure("El movimiento de inventario del ingreso está anulado.");

            // Reemplazo de líneas del movimiento (el código correlativo no cambia).
            foreach (var oldLine in movement.Lines.ToList())
                await unitOfWork.InventoryMovementLines.DeleteAsync(oldLine, cancellationToken);

            movement.Date = request.Date;
            movement.Reference = request.Reference?.Trim();
            movement.WarehouseId = request.WarehouseId!.Value;
            movement.Lines = builtLines;

            InventoryMovementTotals.Apply(movement);

            request.Amount = movement.SubTotal;
            request.Tax = movement.TaxAmount;
            document.WarehouseId = request.WarehouseId;
        }

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

        if (document.IsPurchaseEntry)
        {
            var postingError = await PayablePostingFactory.CreateOrUpdatePostingAsync(
                unitOfWork, document, supplier, concept, cancellationToken, movement);
            if (postingError is not null)
                return Response<bool>.Failure(postingError);
        }
        else if (concept.GeneratePosting || document.JournalEntryId is not null)
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
