using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.PaymentMethods.Commands.DeletePaymentMethod;

public class DeletePaymentMethodCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeletePaymentMethodCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeletePaymentMethodCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeletePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var method = await unitOfWork.PaymentMethods.GetByIdAsync(request.Id, cancellationToken);
        if (method is null)
            return Response<bool>.NotFound($"Método de pago {request.Id} no encontrado.");

        await unitOfWork.PaymentMethods.DeleteAsync(method, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
