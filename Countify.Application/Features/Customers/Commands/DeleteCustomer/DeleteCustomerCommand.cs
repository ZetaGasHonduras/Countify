using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteCustomerCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await unitOfWork.Customers.GetByIdAsync(request.Id, cancellationToken);
        if (customer is null)
            return Response<bool>.NotFound($"Cliente {request.Id} no encontrado.");

        await unitOfWork.Customers.DeleteAsync(customer, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}