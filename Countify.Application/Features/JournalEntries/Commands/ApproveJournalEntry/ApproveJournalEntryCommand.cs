using Countify.Application.Wrappers;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.JournalEntries.Commands.ApproveJournalEntry;

public class ApproveJournalEntryCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class ApproveJournalEntryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<ApproveJournalEntryCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        ApproveJournalEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await unitOfWork.JournalEntries.Query()
            .Include(e => e.Lines)
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (entry is null)
            return Response<bool>.NotFound($"Partida {request.Id} no encontrada.");

        if (entry.Status != JournalEntryStatus.Draft)
            return Response<bool>.Failure("Solo se pueden aprobar partidas en borrador.");

        var settings = await unitOfWork.CompanySettings.Query()
            .FirstOrDefaultAsync(cancellationToken);

        if (settings is null)
            return Response<bool>.Failure("No hay configuración de la empresa.");

        var ruleError = JournalEntryRules.Validate(false, entry.Lines, settings);
        if (ruleError is not null)
            return Response<bool>.Failure(ruleError);

        entry.Status = JournalEntryStatus.Approved;
        await unitOfWork.JournalEntries.UpdateAsync(entry, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}