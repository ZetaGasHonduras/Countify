using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Locations.Commands.UpdateLocation;

public class UpdateLocationCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid WarehouseId { get; set; }
    public Guid? AccountId { get; set; }
    public Guid? ProjectId { get; set; }
    public bool ManageNegativeStock { get; set; }
    public bool IsDefault { get; set; }
    public bool IsInactive { get; set; }
    public string? Observations { get; set; }
}

public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.WarehouseId).NotEmpty();
        RuleFor(x => x.Observations).MaximumLength(500);
    }
}

public class UpdateLocationCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateLocationCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await unitOfWork.Locations.GetByIdAsync(request.Id, cancellationToken);
        if (location is null)
            return Response<bool>.NotFound($"Ubicación {request.Id} no encontrada.");

        var code = request.Code.Trim();
        var name = request.Name.Trim();

        if (!await unitOfWork.Warehouses.ExistsAsync(w => w.Id == request.WarehouseId, cancellationToken))
            return Response<bool>.Failure("El almacén indicado no existe.");

        if (await unitOfWork.Locations.ExistsAsync(
                l => l.Id != location.Id && l.WarehouseId == request.WarehouseId && l.Code == code,
                cancellationToken))
            return Response<bool>.Failure("Otra ubicación del mismo almacén ya usa ese código.");

        if (await unitOfWork.Locations.ExistsAsync(
                l => l.Id != location.Id && l.Name == name, cancellationToken))
            return Response<bool>.Failure("Otra ubicación ya usa ese nombre.");

        if (request.AccountId is Guid accountId &&
            !await unitOfWork.Accounts.ExistsAsync(a => a.Id == accountId, cancellationToken))
            return Response<bool>.Failure("La cuenta contable indicada no existe.");

        if (request.ProjectId is Guid projectId &&
            !await unitOfWork.Projects.ExistsAsync(p => p.Id == projectId, cancellationToken))
            return Response<bool>.Failure("El proyecto indicado no existe.");

        if (request.IsDefault && !location.IsDefault)
        {
            var defaults = await unitOfWork.Locations.Query()
                .Where(l => l.IsDefault && l.Id != location.Id).ToListAsync(cancellationToken);
            foreach (var current in defaults)
                current.IsDefault = false;
        }

        if (!request.IsDefault && location.IsDefault && !request.IsInactive)
            return Response<bool>.Failure("La ubicación predeterminada no se puede desmarcar; marque otra como predeterminada.");

        location.Code = code;
        location.Name = name;
        location.WarehouseId = request.WarehouseId;
        location.AccountId = request.AccountId;
        location.ProjectId = request.ProjectId;
        location.ManageNegativeStock = request.ManageNegativeStock;
        location.IsDefault = request.IsDefault;
        location.IsInactive = request.IsInactive;
        location.Observations = string.IsNullOrWhiteSpace(request.Observations)
            ? null
            : request.Observations.Trim();

        await unitOfWork.Locations.UpdateAsync(location, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
