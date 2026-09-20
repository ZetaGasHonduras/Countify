using Countify.Application.Wrappers;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.JournalEntries.Commands.DeleteJournalEntry;

public class DeleteJournalEntryCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteJournalEntryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteJournalEntryCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteJournalEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await unitOfWork.JournalEntries.GetByIdAsync(request.Id, cancellationToken);
        if (entry is null)
            return Response<bool>.NotFound($"Partida {request.Id} no encontrada.");

        if (entry.Status == JournalEntryStatus.Voided)
            return Response<bool>.Failure("No se pueden eliminar partidas anuladas.");

        if (entry.PeriodId is not null)
        {
            var period = await unitOfWork.AccountingPeriods.GetByIdAsync(
                entry.PeriodId.Value, cancellationToken);

            if (period?.IsClosed == true)
                return Response<bool>.Failure("El período de la partida está cerrado; no se puede eliminar.");
        }

        await unitOfWork.JournalEntries.DeleteAsync(entry, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
