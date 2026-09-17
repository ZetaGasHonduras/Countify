using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountingPeriods.Commands.DeleteAccountingPeriod;

public class DeleteAccountingPeriodCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteAccountingPeriodCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteAccountingPeriodCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteAccountingPeriodCommand request, CancellationToken cancellationToken)
    {
        var period = await unitOfWork.AccountingPeriods.GetByIdAsync(request.Id, cancellationToken);
        if (period is null)
            return Response<bool>.NotFound($"Período {request.Id} no encontrado.");

        if (period.IsClosed)
            return Response<bool>.Failure("No se puede eliminar un período cerrado.");

        var hasEntries = await unitOfWork.JournalEntries.ExistsAsync(
            e => e.PeriodId == request.Id, cancellationToken);

        if (hasEntries)
            return Response<bool>.Failure("No se puede eliminar: el período contiene partidas contables.");

        await unitOfWork.AccountingPeriods.DeleteAsync(period, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}