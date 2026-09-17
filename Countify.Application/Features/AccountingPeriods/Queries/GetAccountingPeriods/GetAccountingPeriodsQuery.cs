using AutoMapper;
using Countify.Application.Features.AccountingPeriods.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.AccountingPeriods.Queries.GetAccountingPeriods;

public class GetAccountingPeriodsQuery : IRequest<Response<List<AccountingPeriodDto>>>;

public class GetAccountingPeriodsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAccountingPeriodsQuery, Response<List<AccountingPeriodDto>>>
{
    public async Task<Response<List<AccountingPeriodDto>>> Handle(
        GetAccountingPeriodsQuery request, CancellationToken cancellationToken)
    {
        var periods = await unitOfWork.AccountingPeriods.ToListAsync(
            unitOfWork.AccountingPeriods.Query().OrderByDescending(p => p.Month),
            cancellationToken);

        return Response<List<AccountingPeriodDto>>.Success(
            mapper.Map<List<AccountingPeriodDto>>(periods));
    }
}