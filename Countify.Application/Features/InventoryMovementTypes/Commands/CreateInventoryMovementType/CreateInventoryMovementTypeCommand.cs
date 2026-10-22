using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Countify.Application.Features.InventoryMovementTypes.Commands.CreateInventoryMovementType;

public class CreateInventoryMovementTypeCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    /// <summary>0 = Sin inventario, 1 = Entrada, 2 = Salida.</summary>
    public int Direction { get; set; } = 1;

    public bool ChecksStock { get; set; }
    public bool GeneratesPosting { get; set; }
    public bool CountsForStock { get; set; } = true;
    public bool IsInactive { get; set; }
}

public class CreateInventoryMovementTypeCommandValidator
    : AbstractValidator<CreateInventoryMovementTypeCommand>
{
    public CreateInventoryMovementTypeCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(10)
            .Matches("^[A-Za-z0-9+-]+$").WithMessage("El código solo admite letras, números, + y −.");
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Direction)
            .Must(v => System.Enum.IsDefined(typeof(Countify.Domain.Entities.Inventory.InventoryMovementDirection), v))
            .WithMessage("La dirección debe ser 0 (sin inventario), 1 (entrada) o 2 (salida).");
    }
}

public class CreateInventoryMovementTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateInventoryMovementTypeCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateInventoryMovementTypeCommand request, CancellationToken cancellationToken)
    {
        var code = request.Code.Trim();
        var name = request.Name.Trim();

        if (await unitOfWork.InventoryMovementTypes.ExistsAsync(t => t.Code == code, cancellationToken))
            return Response<Guid>.Failure($"Ya existe un tipo de movimiento con el código '{code}'.");

        if (await unitOfWork.InventoryMovementTypes.ExistsAsync(t => t.Name == name, cancellationToken))
            return Response<Guid>.Failure($"Ya existe un tipo de movimiento llamado '{name}'.");

        var type = mapper.Map<InventoryMovementType>(request);
        type.Code = code;
        type.Name = name;
        type.IsSystem = false;

        await unitOfWork.InventoryMovementTypes.AddAsync(type, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(type.Id, 201);
    }
}
