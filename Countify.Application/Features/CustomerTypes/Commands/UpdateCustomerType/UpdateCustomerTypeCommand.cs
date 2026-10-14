using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.CustomerTypes.Commands.UpdateCustomerType;

public class UpdateCustomerTypeCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? AccountingAccountId { get; set; }
}

public class UpdateCustomerTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateCustomerTypeCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        var customerType = await unitOfWork.CustomerTypes.GetByIdAsync(request.Id, cancellationToken);
        if (customerType is null)
            return Response<bool>.NotFound($"Tipo de cliente {request.Id} no encontrado.");

        var exists = await unitOfWork.CustomerTypes.ExistsAsync(
            t => t.Code == request.Code && t.Id != request.Id, cancellationToken);

        if (exists)
            return Response<bool>.Failure($"El tipo de cliente '{request.Code}' ya existe.");

        mapper.Map(request, customerType);
        await unitOfWork.CustomerTypes.UpdateAsync(customerType, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}