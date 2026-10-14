using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.CustomerTypes.Commands.CreateCustomerType;

public class CreateCustomerTypeCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? AccountingAccountId { get; set; }
}

public class CreateCustomerTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateCustomerTypeCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.CustomerTypes.ExistsAsync(
            t => t.Code == request.Code, cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"El tipo de cliente '{request.Code}' ya existe.");

        var customerType = mapper.Map<CustomerType>(request);
        await unitOfWork.CustomerTypes.AddAsync(customerType, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(customerType.Id, 201);
    }
}