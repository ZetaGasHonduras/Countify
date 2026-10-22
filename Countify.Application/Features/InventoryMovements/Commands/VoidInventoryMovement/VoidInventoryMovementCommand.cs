using Countify.Application.Wrappers;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryMovements.Commands.VoidInventoryMovement;

public class VoidInventoryMovementCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public class VoidInventoryMovementCommandValidator : AbstractValidator<VoidInventoryMovementCommand>
{
    public VoidInventoryMovementCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Reason).NotEmpty().MaximumLength(500)
            .WithMessage("El motivo de anulación es obligatorio.");
    }
}

public class VoidInventoryMovementCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<VoidInventoryMovementCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        VoidInventoryMovementCommand request, CancellationToken cancellationToken)
    {
        var movement = await unitOfWork.InventoryMovements.Query()
            .Include(m => m.JournalEntry)
            .Include(m => m.Type)
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (movement is null)
            return Response<bool>.NotFound($"Movimiento de inventario {request.Id} no encontrado.");

        if (movement.IsVoided)
            return Response<bool>.Failure("El movimiento ya está anulado.");

        // Consumo de solicitud: solo se puede anular un AJ- para liberar la solicitud,
        // y una solicitud no puede anularse si ya fue consumida.
        if (movement.Type?.Code == "TP-" &&
            await unitOfWork.InventoryMovements.ExistsAsync(
                m => m.SourceRequestId == movement.Id && !m.IsVoided && m.Type!.Code == "AJ-",
                cancellationToken))
            return Response<bool>.Failure("La solicitud ya fue consumida por un ajuste negativo.");

        if (movement.JournalEntry?.PeriodId is Guid periodId &&
            await unitOfWork.AccountingPeriods.ExistsAsync(
                p => p.Id == periodId && p.IsClosed, cancellationToken))
            return Response<bool>.Failure("El período de la partida generada está cerrado y no puede anularse.");

        movement.IsVoided = true;
        movement.VoidedAt = DateTime.UtcNow;
        movement.VoidReason = request.Reason.Trim();

        if (movement.JournalEntry is not null)
            movement.JournalEntry.Status = JournalEntryStatus.Voided;

        await unitOfWork.InventoryMovements.UpdateAsync(movement, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
