using AutoMapper;
using Countify.Application.Features.InventoryMovements;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

    // --- Ingreso de Compras (FASE 6 Etapa 5) ---

    /// <summary>El documento de compra ingresa mercancía: genera su movimiento 'COM'.</summary>
    public bool IsPurchaseEntry { get; set; }

    public Guid? WarehouseId { get; set; }

    /// <summary>Líneas del ingreso (producto, ubicación destino, cantidad, costo unitario, %ISV).</summary>
    public List<PurchaseEntryLineInput> InventoryLines { get; set; } = [];

    public class PurchaseEntryLineInput
    {
        public Guid ProductId { get; set; }
        public string? Description { get; set; }
        public string? Unit { get; set; }
        public Guid LocationId { get; set; }
        public decimal Quantity { get; set; } = 1;
        public decimal UnitCost { get; set; }
        public decimal TaxRate { get; set; } = 15;
    }
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

        InventoryMovement? movement = null;

        if (request.IsPurchaseEntry)
        {
            var (m, error, amount, tax) = await BuildMovementAsync(request, supplier.Name, cancellationToken);
            if (error is not null)
                return Response<Guid>.Failure(error);

            movement = m!;
            request.Amount = amount;
            request.Tax = tax;
        }

        var document = mapper.Map<PayableDocument>(request);
        document.TaxLocal = Math.Round(request.Tax * request.ExchangeRate, 2);

        if (movement is not null)
        {
            document.IsPurchaseEntry = true;
            document.WarehouseId = request.WarehouseId;
            document.InventoryMovement = movement;
        }

        // Snapshot del proveedor + datos fiscales de su SupplierFiscalData activo (3.3/3.6 del roadmap).
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

        if (request.IsPurchaseEntry)
        {
            // La partida del ingreso va a cuentas de inventario por producto (no al concepto).
            var postingError = await PayablePostingFactory.CreateOrUpdatePurchaseEntryAsync(
                unitOfWork, document, supplier, movement!, cancellationToken);
            if (postingError is not null)
                return Response<Guid>.Failure(postingError);
        }
        else if (concept.GeneratePosting)
        {
            var postingError = await PayablePostingFactory.CreateOrUpdatePostingAsync(
                unitOfWork, document, supplier, concept, cancellationToken);
            if (postingError is not null)
                return Response<Guid>.Failure(postingError);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(document.Id, 201);
    }

    /// <summary>Valida y construye el movimiento 'COM' (código, líneas, totales como legacy).</summary>
    private async Task<(InventoryMovement? Movement, string? Error, decimal Amount, decimal Tax)> BuildMovementAsync(
        CreatePayableDocumentCommand request, string supplierName, CancellationToken cancellationToken)
    {
        if (request.ConceptId == Guid.Empty)
            return (null, "Seleccione un concepto de compra.", 0, 0);

        var concept = await unitOfWork.PayableConcepts.GetByIdAsync(request.ConceptId, cancellationToken);
        if (concept is not null && concept.Type != PayableConceptType.Debit)
            return (null, "El ingreso de compras debe usar un concepto de tipo compra (débito).", 0, 0);

        if (request.WarehouseId is not Guid warehouseId)
            return (null, "El ingreso de compras debe indicar el almacén destino.", 0, 0);

        var warehouse = await unitOfWork.Warehouses.GetByIdAsync(warehouseId, cancellationToken);
        if (warehouse is null || warehouse.IsInactive)
            return (null, "El almacén indicado no existe o está inactivo.", 0, 0);

        if (request.InventoryLines.Count == 0)
            return (null, "Agregue al menos una línea de productos al ingreso.", 0, 0);

        if (request.InventoryLines.Count > 999)
            return (null, "El ingreso no puede tener más de 999 líneas.", 0, 0);

        var comType = await unitOfWork.InventoryMovementTypes.Query()
            .FirstOrDefaultAsync(t => t.Code == "COM", cancellationToken);
        if (comType is null)
            return (null, "No existe el tipo de movimiento 'COM' (simbre el catálogo de inventario).", 0, 0);

        var productIds = request.InventoryLines.Select(l => l.ProductId).Distinct().ToList();
        var products = await unitOfWork.Products.Query()
            .Where(p => productIds.Contains(p.Id)).ToListAsync(cancellationToken);
        if (products.Count != productIds.Count)
            return (null, "Uno o más productos del ingreso no existen.", 0, 0);

        var locationIds = request.InventoryLines.Select(l => l.LocationId).Distinct().ToList();
        var locations = await unitOfWork.Locations.Query()
            .Where(l => locationIds.Contains(l.Id)).ToListAsync(cancellationToken);

        var lines = new List<InventoryMovementLine>();
        var order = 1;
        foreach (var input in request.InventoryLines)
        {
            var location = locations.FirstOrDefault(l => l.Id == input.LocationId);
            if (location is null || location.IsInactive)
                return (null, "Una de las ubicaciones no existe o está inactiva.", 0, 0);

            if (location.WarehouseId != warehouseId)
                return (null, $"La ubicación {location.Code} no pertenece al almacén {warehouse.Name}.", 0, 0);

            var product = products.First(p => p.Id == input.ProductId);

            lines.Add(new InventoryMovementLine
            {
                Order = order++,
                ProductId = input.ProductId,
                Description = string.IsNullOrWhiteSpace(input.Description) ? product.Name : input.Description.Trim(),
                Unit = input.Unit?.Trim(),
                LocationId = input.LocationId,
                Quantity = input.Quantity,
                UnitCost = input.UnitCost,
                TaxRate = input.TaxRate,
            });
        }

        var maxCorrelativo = await unitOfWork.InventoryMovements.Query()
            .Where(m => m.TypeId == comType.Id)
            .Select(m => (int?)m.Correlativo).MaxAsync(cancellationToken);
        var correlativo = (maxCorrelativo ?? 0) + 1;

        var movement = new InventoryMovement
        {
            TypeId = comType.Id,
            Correlativo = correlativo,
            Code = $"{comType.Code}{correlativo:D10}",
            Date = request.Date,
            Reference = request.Reference?.Trim(),
            Concept = $"Ingreso de compras {supplierName}",
            WarehouseId = warehouseId,
            IsTaxExempt = false,
        };
        movement.Lines = lines;

        InventoryMovementTotals.Apply(movement);

        return (movement, null, movement.SubTotal, movement.TaxAmount);
    }
}
