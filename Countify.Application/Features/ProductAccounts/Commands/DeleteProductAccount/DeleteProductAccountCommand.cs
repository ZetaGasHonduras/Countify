using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.ProductAccounts.Commands.DeleteProductAccount;

public class DeleteProductAccountCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteProductAccountCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProductAccountCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteProductAccountCommand request, CancellationToken cancellationToken)
    {
        var productAccount = await unitOfWork.ProductAccounts.GetByIdAsync(request.Id, cancellationToken);
        if (productAccount is null)
            return Response<bool>.NotFound($"Configuración {request.Id} no encontrada.");

        await unitOfWork.ProductAccounts.DeleteAsync(productAccount, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}