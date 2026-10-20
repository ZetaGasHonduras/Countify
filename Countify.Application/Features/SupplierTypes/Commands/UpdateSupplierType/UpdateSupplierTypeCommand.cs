using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.SupplierTypes.Commands.UpdateSupplierType;

public class UpdateSupplierTypeCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? AccountingAccountId { get; set; }
}

public class UpdateSupplierTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateSupplierTypeCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateSupplierTypeCommand request, CancellationToken cancellationToken)
    {
        var supplierType = await unitOfWork.SupplierTypes.GetByIdAsync(request.Id, cancellationToken);
        if (supplierType is null)
            return Response<bool>.NotFound($"Tipo de proveedor {request.Id} no encontrado.");

        var exists = await unitOfWork.SupplierTypes.ExistsAsync(
            t => t.Code == request.Code && t.Id != request.Id, cancellationToken);

        if (exists)
            return Response<bool>.Failure($"El tipo de proveedor '{request.Code}' ya existe.");

        mapper.Map(request, supplierType);
        await unitOfWork.SupplierTypes.UpdateAsync(supplierType, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
