using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.SupplierTypes.Commands.CreateSupplierType;

public class CreateSupplierTypeCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? AccountingAccountId { get; set; }
}

public class CreateSupplierTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateSupplierTypeCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateSupplierTypeCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.SupplierTypes.ExistsAsync(
            t => t.Code == request.Code, cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"El tipo de proveedor '{request.Code}' ya existe.");

        var supplierType = mapper.Map<SupplierType>(request);
        await unitOfWork.SupplierTypes.AddAsync(supplierType, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(supplierType.Id, 201);
    }
}
