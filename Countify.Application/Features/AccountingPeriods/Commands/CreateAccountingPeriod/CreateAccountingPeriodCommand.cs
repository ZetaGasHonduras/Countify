using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountingPeriods.Commands.CreateAccountingPeriod;

public class CreateAccountingPeriodCommand : IRequest<Response<Guid>>
{
    public DateTime Month { get; set; }
}

public class CreateAccountingPeriodCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateAccountingPeriodCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateAccountingPeriodCommand request, CancellationToken cancellationToken)
    {
        var firstDay = new DateTime(request.Month.Year, request.Month.Month, 1);
        var lastDay = firstDay.AddMonths(1).AddDays(-1);
        var end = lastDay.Date.AddDays(1).AddSeconds(-1);

        var sameMonth = await unitOfWork.AccountingPeriods.ExistsAsync(
            p => p.Month.Year == request.Month.Year && p.Month.Month == request.Month.Month,
            cancellationToken);

        if (sameMonth)
            return Response<Guid>.Failure($"El período {firstDay:yyyy-MM} ya existe.");

        var period = new AccountingPeriod
        {
            Month = new DateTime(request.Month.Year, request.Month.Month, 1),
            StartDate = firstDay,
            EndDate = end,
            IsClosed = false
        };

        await unitOfWork.AccountingPeriods.AddAsync(period, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(period.Id, 201);
    }
}