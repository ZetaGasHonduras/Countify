using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
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

public class UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateCustomerCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await unitOfWork.Customers.GetByIdAsync(request.Id, cancellationToken);
        if (customer is null)
            return Response<bool>.NotFound($"Cliente {request.Id} no encontrado.");

        var exists = await unitOfWork.Customers.ExistsAsync(
            c => c.Code == request.Code && c.Id != request.Id, cancellationToken);

        if (exists)
            return Response<bool>.Failure($"El cliente '{request.Code}' ya existe.");

        mapper.Map(request, customer);
        await unitOfWork.Customers.UpdateAsync(customer, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}