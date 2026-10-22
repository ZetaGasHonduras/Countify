using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Locations.Commands.CreateLocation;

public class CreateLocationCommand : IRequest<Response<Guid>>
{
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

public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.WarehouseId).NotEmpty();
        RuleFor(x => x.Observations).MaximumLength(500);
    }
}

public class CreateLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateLocationCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var code = request.Code.Trim();
        var name = request.Name.Trim();

        var warehouse = await unitOfWork.Warehouses.GetByIdAsync(request.WarehouseId, cancellationToken);
        if (warehouse is null || warehouse.IsInactive)
            return Response<Guid>.Failure("El almacén indicado no existe o está inactivo.");

        if (await unitOfWork.Locations.ExistsAsync(
                l => l.WarehouseId == warehouse.Id && l.Code == code, cancellationToken))
            return Response<Guid>.Failure($"Ya existe una ubicación con el código '{code}' en el almacén {warehouse.Name}.");

        if (await unitOfWork.Locations.ExistsAsync(l => l.Name == name, cancellationToken))
            return Response<Guid>.Failure($"Ya existe una ubicación llamada '{name}'.");

        if (request.AccountId is Guid accountId &&
            !await unitOfWork.Accounts.ExistsAsync(a => a.Id == accountId, cancellationToken))
            return Response<Guid>.Failure("La cuenta contable indicada no existe.");

        if (request.ProjectId is Guid projectId &&
            !await unitOfWork.Projects.ExistsAsync(p => p.Id == projectId, cancellationToken))
            return Response<Guid>.Failure("El proyecto indicado no existe.");

        if (request.IsDefault)
        {
            var defaults = await unitOfWork.Locations.Query()
                .Where(l => l.IsDefault).ToListAsync(cancellationToken);
            foreach (var current in defaults)
                current.IsDefault = false;
        }

        var location = mapper.Map<Location>(request);
        location.Code = code;
        location.Name = name;

        await unitOfWork.Locations.AddAsync(location, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(location.Id, 201);
    }
}
