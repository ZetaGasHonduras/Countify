using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.CustomerTypes.Commands.DeleteCustomerType;

public class DeleteCustomerTypeCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteCustomerTypeCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteCustomerTypeCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        var customerType = await unitOfWork.CustomerTypes.GetByIdAsync(request.Id, cancellationToken);
        if (customerType is null)
            return Response<bool>.NotFound($"Tipo de cliente {request.Id} no encontrado.");

        var hasAssignments = await unitOfWork.Customers.ExistsAsync(
            c => c.CustomerTypeId == request.Id, cancellationToken);

        if (hasAssignments)
            return Response<bool>.Failure("No se puede eliminar: el tipo de cliente está asignado a clientes.");

        await unitOfWork.CustomerTypes.DeleteAsync(customerType, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}