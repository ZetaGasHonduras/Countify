using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? CustomerTypeId { get; set; }
    public string? TaxId { get; set; }
    public string? IdentityDocument { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public int CreditDays { get; set; }
    public decimal CreditLimit { get; set; }
    public Guid? AccountingAccountId { get; set; }
    public bool IsInactive { get; set; }
}

public class CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateCustomerCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.Customers.ExistsAsync(
            c => c.Code == request.Code, cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"El cliente '{request.Code}' ya existe.");

        var customer = mapper.Map<Customer>(request);
        await unitOfWork.Customers.AddAsync(customer, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(customer.Id, 201);
    }
}