using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Countify.Application.Features.InventoryPeriods.Commands.ReopenInventoryPeriod;

/// <summary>Legay <c>ActAbrirPeriodo</c>: reabre para permitir otro cierre/recálculo.</summary>
public class ReopenInventoryPeriodCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class ReopenInventoryPeriodCommandValidator : AbstractValidator<ReopenInventoryPeriodCommand>
{
    public ReopenInventoryPeriodCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

public class ReopenInventoryPeriodCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<ReopenInventoryPeriodCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        ReopenInventoryPeriodCommand request, CancellationToken cancellationToken)
    {
        var period = await unitOfWork.InventoryPeriods.GetByIdAsync(request.Id, cancellationToken);
        if (period is null)
            return Response<bool>.NotFound($"Período de inventario {request.Id} no encontrado.");

        if (!period.IsClosed)
            return Response<bool>.Failure("El período ya está abierto.");

        period.IsClosed = false;
        period.ClosedAt = null;

        await unitOfWork.InventoryPeriods.UpdateAsync(period, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
