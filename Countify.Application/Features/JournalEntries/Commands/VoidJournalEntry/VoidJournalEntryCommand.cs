using Countify.Application.Wrappers;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.JournalEntries.Commands.VoidJournalEntry;

public class VoidJournalEntryCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class VoidJournalEntryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<VoidJournalEntryCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        VoidJournalEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await unitOfWork.JournalEntries.GetByIdAsync(request.Id, cancellationToken);
        if (entry is null)
            return Response<bool>.NotFound($"Partida {request.Id} no encontrada.");

        if (entry.Status == JournalEntryStatus.Voided)
            return Response<bool>.Success(true, 204);

        if (entry.Status is not JournalEntryStatus.Posted)
            return Response<bool>.Failure($"No se puede anular una partida en estado {entry.Status}.");

        if (entry.PeriodId is not null)
        {
            var period = await unitOfWork.AccountingPeriods.GetByIdAsync(
                entry.PeriodId.Value, cancellationToken);

            if (period?.IsClosed == true)
                return Response<bool>.Failure("El período de la partida está cerrado; no se puede anular.");
        }

        entry.Status = JournalEntryStatus.Voided;
        await unitOfWork.JournalEntries.UpdateAsync(entry, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
