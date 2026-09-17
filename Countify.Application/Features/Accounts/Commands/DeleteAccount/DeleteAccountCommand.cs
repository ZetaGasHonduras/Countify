using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Accounts.Commands.DeleteAccount;

public class DeleteAccountCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteAccountCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteAccountCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await unitOfWork.Accounts.GetByIdAsync(request.Id, cancellationToken);
        if (account is null)
            return Response<bool>.NotFound($"Cuenta {request.Id} no encontrada.");

        var hasMovements = await unitOfWork.JournalEntryLines.ExistsAsync(
            l => l.AccountId == request.Id, cancellationToken);

        if (hasMovements)
            return Response<bool>.Failure("No se puede eliminar: la cuenta tiene movimientos en partidas contables.");

        await unitOfWork.Accounts.DeleteAsync(account, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}