using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Cashiers.Commands.DeleteCashier;

public class DeleteCashierCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteCashierCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteCashierCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteCashierCommand request, CancellationToken cancellationToken)
    {
        var cashier = await unitOfWork.Cashiers.GetByIdAsync(request.Id, cancellationToken);
        if (cashier is null)
            return Response<bool>.NotFound($"Cajero {request.Id} no encontrado.");

        await unitOfWork.Cashiers.DeleteAsync(cashier, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
