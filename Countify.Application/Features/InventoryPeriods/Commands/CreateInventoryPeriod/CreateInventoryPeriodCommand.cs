using Countify.Application.Wrappers;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryPeriods.Commands.CreateInventoryPeriod;

public class CreateInventoryPeriodCommand : IRequest<Response<Guid>>
{
    /// <summary>Cualquier día del mes; se normaliza al primero.</summary>
    public DateTime Month { get; set; }
    public string? Notes { get; set; }
}

public class CreateInventoryPeriodCommandValidator : AbstractValidator<CreateInventoryPeriodCommand>
{
    public CreateInventoryPeriodCommandValidator()
    {
        RuleFor(x => x.Month).NotEmpty();
        RuleFor(x => x.Notes).MaximumLength(500);
    }
}

public class CreateInventoryPeriodCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateInventoryPeriodCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateInventoryPeriodCommand request, CancellationToken cancellationToken)
    {
        var month = new DateTime(request.Month.Year, request.Month.Month, 1);
        var from = month;
        var to = month.AddMonths(1).AddTicks(-1);

        if (await unitOfWork.InventoryPeriods.ExistsAsync(p => p.Month == month, cancellationToken))
            return Response<Guid>.Failure($"Ya existe un período para {month:MM/yyyy}.");

        var period = new InventoryPeriod
        {
            Month = month,
            PeriodFrom = from,
            PeriodTo = to,
            Notes = request.Notes?.Trim(),
        };

        await unitOfWork.InventoryPeriods.AddAsync(period, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(period.Id, 201);
    }
}
