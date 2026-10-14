using Countify.Application.Features.Reports.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Reports.Queries.GetIncomeStatement;

public class GetIncomeStatementQuery : IRequest<Response<IncomeStatementDto>>
{
    public DateTime? Date { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? ProjectId { get; set; }
}

public class GetIncomeStatementQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetIncomeStatementQuery, Response<IncomeStatementDto>>
{
    public async Task<Response<IncomeStatementDto>> Handle(
        GetIncomeStatementQuery request, CancellationToken cancellationToken)
    {
        var (monthStart, monthEnd) = GetMonthRange(request.Date);

        var query = unitOfWork.JournalEntryLines.Query()
            .AsNoTracking()
            .Where(line => line.JournalEntry != null &&
                           line.JournalEntry.Status == JournalEntryStatus.Posted &&
                           line.JournalEntry.ReferenceDate >= monthStart &&
                           line.JournalEntry.ReferenceDate < monthEnd);

        if (request.DepartmentId.HasValue)
            query = query.Where(line => line.DepartmentId == request.DepartmentId);

        if (request.ProjectId.HasValue)
            query = query.Where(line => line.ProjectId == request.ProjectId);

        var balances = await query
            .GroupBy(line => new
            {
                line.AccountId,
                line.Account!.Code,
                line.Account.Name
            })
            .Select(group => new IncomeStatementLineDto
            {
                AccountId = group.Key.AccountId,
                AccountCode = group.Key.Code,
                AccountName = group.Key.Name,
                Balance = group.Sum(line => line.Debit - line.Credit)
            })
            .ToListAsync(cancellationToken);

        var balanceByCode = balances.ToDictionary(line => line.AccountCode, line => line.Balance);

        var catalogAccounts = await unitOfWork.Accounts.Query()
            .AsNoTracking()
            .Where(a => a.IsOperable)
            .Select(a => new { a.Id, a.Code, a.Name })
            .ToListAsync(cancellationToken);

        var accountGroups = catalogAccounts
            .GroupBy(a => a.Code)
            .ToDictionary(g => g.Key, g => (g.First().Id, g.First().Code, g.First().Name));

        var revenueLines = BuildSection(accountGroups, balanceByCode, "4");
        var costLines = BuildSection(accountGroups, balanceByCode, "5");
        var expenseLines = BuildSection(accountGroups, balanceByCode, "6");

        var sections = new List<IncomeStatementSectionDto>
        {
            new() { Code = "4", Name = "Ingresos", Lines = revenueLines, Total = revenueLines.Sum(l => l.Balance) },
            new() { Code = "5", Name = "Costos", Lines = costLines, Total = costLines.Sum(l => l.Balance) },
            new() { Code = "6", Name = "Gastos", Lines = expenseLines, Total = expenseLines.Sum(l => l.Balance) }
        };

        var totalRevenue = sections[0].Total;
        var totalCosts = sections[1].Total;
        var totalExpenses = sections[2].Total;

        var result = new IncomeStatementDto
        {
            EndDate = request.Date?.Date ?? DateTime.Today,
            Sections = sections,
            TotalRevenue = totalRevenue,
            TotalCostOfSales = totalCosts,
            GrossProfit = totalRevenue - totalCosts,
            TotalExpenses = totalExpenses,
            NetResult = totalRevenue - totalCosts - totalExpenses
        };

        return Response<IncomeStatementDto>.Success(result);
    }

    private static (DateTime Start, DateTime End) GetMonthRange(DateTime? date)
    {
        var reference = date?.Date ?? DateTime.Today;
        var start = new DateTime(reference.Year, reference.Month, 1);
        var end = start.AddMonths(1);
        return (start, end);
    }

    private static List<IncomeStatementLineDto> BuildSection(
        Dictionary<string, (Guid Id, string Code, string Name)> catalog,
        Dictionary<string, decimal> balanceByCode,
        string sectionPrefix)
    {
        return catalog
            .Where(entry => entry.Value.Code.Split('.')[0] == sectionPrefix)
            .OrderBy(entry => entry.Value.Code)
            .Select(entry =>
            {
                var hasBalance = balanceByCode.TryGetValue(entry.Value.Code, out var movement);
                var balance = sectionPrefix == "4" ? -movement : movement;
                return new IncomeStatementLineDto
                {
                    AccountId = entry.Value.Id,
                    AccountCode = entry.Value.Code,
                    AccountName = entry.Value.Name,
                    Balance = hasBalance ? balance : 0
                };
            })
            .ToList();
    }
}