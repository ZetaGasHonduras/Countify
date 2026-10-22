using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Warehouses.Commands.CreateWarehouse;

public class CreateWarehouseCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
    public bool IsInactive { get; set; }
}

public class CreateWarehouseCommandValidator : AbstractValidator<CreateWarehouseCommand>
{
    public CreateWarehouseCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}

public class CreateWarehouseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateWarehouseCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var code = request.Code.Trim();
        var name = request.Name.Trim();

        if (await unitOfWork.Warehouses.ExistsAsync(w => w.Code == code, cancellationToken))
            return Response<Guid>.Failure($"Ya existe un almacén con el código '{code}'.");

        if (await unitOfWork.Warehouses.ExistsAsync(w => w.Name == name, cancellationToken))
            return Response<Guid>.Failure($"Ya existe un almacén llamado '{name}'.");

        if (request.IsDefault)
        {
            var defaults = await unitOfWork.Warehouses.Query()
                .Where(w => w.IsDefault).ToListAsync(cancellationToken);
            foreach (var current in defaults)
                current.IsDefault = false;
        }

        var warehouse = mapper.Map<Warehouse>(request);
        warehouse.Code = code;
        warehouse.Name = name;

        await unitOfWork.Warehouses.AddAsync(warehouse, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(warehouse.Id, 201);
    }
}
