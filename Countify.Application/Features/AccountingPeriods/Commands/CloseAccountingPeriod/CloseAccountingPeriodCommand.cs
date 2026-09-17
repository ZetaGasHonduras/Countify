using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountingPeriods.Commands.CloseAccountingPeriod;

public class CloseAccountingPeriodCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class CloseAccountingPeriodCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CloseAccountingPeriodCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        CloseAccountingPeriodCommand request, CancellationToken cancellationToken)
    {
        var period = await unitOfWork.AccountingPeriods.GetByIdAsync(request.Id, cancellationToken);
        if (period is null)
            return Response<bool>.NotFound($"Período {request.Id} no encontrado.");

        period.IsClosed = true;
        await unitOfWork.AccountingPeriods.UpdateAsync(period, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}