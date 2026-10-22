using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Warehouses.Commands.UpdateWarehouse;

public class UpdateWarehouseCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
    public bool IsInactive { get; set; }
}

public class UpdateWarehouseCommandValidator : AbstractValidator<UpdateWarehouseCommand>
{
    public UpdateWarehouseCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}

public class UpdateWarehouseCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateWarehouseCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = await unitOfWork.Warehouses.GetByIdAsync(request.Id, cancellationToken);
        if (warehouse is null)
            return Response<bool>.NotFound($"Almacén {request.Id} no encontrado.");

        var code = request.Code.Trim();
        var name = request.Name.Trim();

        if (await unitOfWork.Warehouses.ExistsAsync(
                w => w.Id != warehouse.Id && (w.Code == code || w.Name == name), cancellationToken))
            return Response<bool>.Failure("Otro almacén ya usa ese código o nombre.");

        if (request.IsDefault && !warehouse.IsDefault)
        {
            var defaults = await unitOfWork.Warehouses.Query()
                .Where(w => w.IsDefault && w.Id != warehouse.Id).ToListAsync(cancellationToken);
            foreach (var current in defaults)
                current.IsDefault = false;
        }

        if (!request.IsDefault && warehouse.IsDefault && !request.IsInactive)
            return Response<bool>.Failure("El almacén predeterminado no se puede desmarcar; marque otro como predeterminado.");

        warehouse.Code = code;
        warehouse.Name = name;
        warehouse.IsDefault = request.IsDefault;
        warehouse.IsInactive = request.IsInactive;

        await unitOfWork.Warehouses.UpdateAsync(warehouse, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
