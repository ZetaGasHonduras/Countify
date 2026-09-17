using AutoMapper;
using Countify.Application.Extensions;
using Countify.Application.Features.Accounts.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Accounts.Queries.GetAccounts;

public class GetAccountsQuery : RequestParameter, IRequest<PaginatedResponse<List<AccountDto>>>
{
    public string? Search { get; set; }
    public bool? IsOperable { get; set; }
}

public class GetAccountsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAccountsQuery, PaginatedResponse<List<AccountDto>>>
{
    public async Task<PaginatedResponse<List<AccountDto>>> Handle(
        GetAccountsQuery request, CancellationToken cancellationToken)
    {
        if (request.PageSize <= 0) request.PageSize = 10;
        if (request.PageNumber < 0) request.PageNumber = 0;

        var search = request.Search ?? request.Parameter;

        var query = unitOfWork.Accounts.Query()
            .ApplySearch(search, x => x.Code.Contains(search!) || x.Name.Contains(search!))
            .ApplyOrder(request.Column, request.Order == "desc", x => x.Code, new()
            {
                ["Code"] = x => x.Code,
                ["Name"] = x => x.Name
            });

        if (request.IsOperable == true)
        {
            query = query.Where(x => x.IsOperable);
        }

        var totalCount = await unitOfWork.Accounts.CountAsync(query, cancellationToken);

        if (request.All)
        {
            request.PageNumber = 0;
            request.PageSize = totalCount == 0 ? 1 : totalCount;
        }

        var accounts = await unitOfWork.Accounts.ToListAsync(
            query
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize),
            cancellationToken);

        var dtos = mapper.Map<List<AccountDto>>(accounts);

        if (dtos.Count > 0)
        {
            await ApplyConsolidatedBalances(dtos, cancellationToken);
        }

        return new PaginatedResponse<List<AccountDto>>(
            dtos, request.PageNumber, request.PageSize, totalCount);
    }

    private async Task ApplyConsolidatedBalances(
        List<AccountDto> dtos, CancellationToken cancellationToken)
    {
        var catalog = await unitOfWork.Accounts.Query()
            .Select(x => new { x.Id, x.Code, x.ParentCode })
            .ToListAsync(cancellationToken);

        var codeById = catalog.ToDictionary(x => x.Id, x => x.Code);
        var childrenByParentCode = catalog
            .Where(x => x.ParentCode != null)
            .GroupBy(x => x.ParentCode!)
            .ToDictionary(g => g.Key, g => g.Select(x => x.Id).ToList());

        var directTotals = await unitOfWork.JournalEntryLines.Query()
            .Include(l => l.JournalEntry)
            .Where(l => l.JournalEntry != null
                && l.JournalEntry.Status != JournalEntryStatus.Voided)
            .GroupBy(l => l.AccountId)
            .Select(g => new
            {
                AccountId = g.Key,
                Debit = g.Sum(x => x.Debit),
                Credit = g.Sum(x => x.Credit),
            })
            .ToListAsync(cancellationToken);

        var directByAccountId = directTotals.ToDictionary(t => t.AccountId);

        var memo = new Dictionary<Guid, decimal>();

        decimal NetFor(Guid accountId, HashSet<Guid> visiting)
        {
            if (memo.TryGetValue(accountId, out var cached)) return cached;
            if (!visiting.Add(accountId)) return 0;

            decimal net = 0;
            if (directByAccountId.TryGetValue(accountId, out var direct))
                net = direct.Debit - direct.Credit;

            if (childrenByParentCode.TryGetValue(codeById[accountId], out var children))
            {
                foreach (var childId in children)
                    net += NetFor(childId, visiting);
            }

            visiting.Remove(accountId);
            memo[accountId] = net;
            return net;
        }

        foreach (var dto in dtos)
        {
            var direct = directByAccountId.GetValueOrDefault(dto.Id);
            dto.TotalDebit = direct?.Debit ?? 0;
            dto.TotalCredit = direct?.Credit ?? 0;
            dto.Balance = NetFor(dto.Id, []);
        }
    }
}