using Countify.Application.Features.Reports.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Reports.Queries.GetTrialBalance;

public class GetTrialBalanceQuery : IRequest<Response<TrialBalanceDto>>
{
    public Guid? PeriodId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? ProjectId { get; set; }
}

public class GetTrialBalanceQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetTrialBalanceQuery, Response<TrialBalanceDto>>
{
    public async Task<Response<TrialBalanceDto>> Handle(
        GetTrialBalanceQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.JournalEntryLines.Query()
            .AsNoTracking()
            .Where(line => line.JournalEntry != null &&
                           line.JournalEntry.Status == JournalEntryStatus.Posted);

        if (request.PeriodId.HasValue)
            query = query.Where(line => line.JournalEntry!.PeriodId == request.PeriodId);

        if (request.DepartmentId.HasValue)
            query = query.Where(line => line.DepartmentId == request.DepartmentId);

        if (request.ProjectId.HasValue)
            query = query.Where(line => line.ProjectId == request.ProjectId);

        var lines = await query
            .GroupBy(line => new
            {
                line.AccountId,
                Code = line.Account!.Code,
                Name = line.Account!.Name
            })
            .Select(group => new TrialBalanceLineDto
            {
                AccountId = group.Key.AccountId,
                AccountCode = group.Key.Code,
                AccountName = group.Key.Name,
                Debit = group.Sum(line => line.Debit),
                Credit = group.Sum(line => line.Credit),
                Balance = group.Sum(line => line.Debit - line.Credit)
            })
            .OrderBy(line => line.AccountCode)
            .ToListAsync(cancellationToken);

        var result = new TrialBalanceDto
        {
            Lines = lines,
            DebitTotal = lines.Sum(line => line.Debit),
            CreditTotal = lines.Sum(line => line.Credit),
            Difference = lines.Sum(line => line.Debit) - lines.Sum(line => line.Credit)
        };

        return Response<TrialBalanceDto>.Success(result);
    }
}
