using Countify.Application.Wrappers;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Countify.Application.Features.InventoryMovementTypes.Commands.UpdateInventoryMovementType;

public class UpdateInventoryMovementTypeCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Direction { get; set; } = 1;
    public bool ChecksStock { get; set; }
    public bool GeneratesPosting { get; set; }
    public bool CountsForStock { get; set; } = true;
    public bool IsInactive { get; set; }
}

public class UpdateInventoryMovementTypeCommandValidator
    : AbstractValidator<UpdateInventoryMovementTypeCommand>
{
    public UpdateInventoryMovementTypeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Code).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Direction)
            .Must(v => System.Enum.IsDefined(typeof(Countify.Domain.Entities.Inventory.InventoryMovementDirection), v))
            .WithMessage("La dirección debe ser 0 (sin inventario), 1 (entrada) o 2 (salida).");
    }
}

public class UpdateInventoryMovementTypeCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateInventoryMovementTypeCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateInventoryMovementTypeCommand request, CancellationToken cancellationToken)
    {
        var type = await unitOfWork.InventoryMovementTypes.GetByIdAsync(request.Id, cancellationToken);
        if (type is null)
            return Response<bool>.NotFound($"Tipo de movimiento {request.Id} no encontrado.");

        var code = request.Code.Trim();
        var name = request.Name.Trim();

        if (await unitOfWork.InventoryMovementTypes.ExistsAsync(
                t => t.Id != type.Id && (t.Code == code || t.Name == name), cancellationToken))
            return Response<bool>.Failure("Otro tipo ya usa ese código o nombre.");

        // El código de un tipo de sistema es prefijo de correlativo y referencia de flujo: inmutable.
        if (type.IsSystem && code != type.Code)
            return Response<bool>.Failure(
                $"El código del tipo de sistema '{type.Code}' no se puede modificar.");

        type.Code = code;
        type.Name = name;
        type.Direction = (InventoryMovementDirection)request.Direction;
        type.ChecksStock = request.ChecksStock;
        type.GeneratesPosting = request.GeneratesPosting;
        type.CountsForStock = request.CountsForStock;
        type.IsInactive = request.IsInactive;

        await unitOfWork.InventoryMovementTypes.UpdateAsync(type, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
