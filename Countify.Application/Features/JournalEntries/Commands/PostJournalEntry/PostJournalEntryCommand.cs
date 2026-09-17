using Countify.Application.Wrappers;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.JournalEntries.Commands.PostJournalEntry;

public class PostJournalEntryCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class PostJournalEntryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<PostJournalEntryCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        PostJournalEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await unitOfWork.JournalEntries.Query()
            .Include(e => e.Lines)
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (entry is null)
            return Response<bool>.NotFound($"Partida {request.Id} no encontrada.");

        if (entry.Status != JournalEntryStatus.Approved)
            return Response<bool>.Failure("Solo se pueden contabilizar partidas aprobadas.");

        if (entry.PeriodId is null)
            return Response<bool>.Failure("La partida no tiene período asignado.");

        var period = await unitOfWork.AccountingPeriods.GetByIdAsync(
            entry.PeriodId.Value, cancellationToken);

        if (period is null)
            return Response<bool>.NotFound($"Período {entry.PeriodId} no encontrado.");

        if (period.IsClosed)
            return Response<bool>.Failure("El período de la partida está cerrado.");

        var settings = await unitOfWork.CompanySettings.Query()
            .FirstOrDefaultAsync(cancellationToken);

        if (settings is null)
            return Response<bool>.Failure("No hay configuración de la empresa.");

        var ruleError = JournalEntryRules.Validate(false, entry.Lines, settings);
        if (ruleError is not null)
            return Response<bool>.Failure(ruleError);

        entry.Status = JournalEntryStatus.Posted;
        await unitOfWork.JournalEntries.UpdateAsync(entry, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}