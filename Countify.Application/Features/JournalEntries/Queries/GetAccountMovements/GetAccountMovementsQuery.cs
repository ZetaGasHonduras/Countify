using Countify.Application.Features.JournalEntries.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.JournalEntries.Queries.GetAccountMovements;

public class GetAccountMovementsQuery : IRequest<Response<AccountMovementsResponse>>
{
    public Guid? AccountId { get; set; }
}

public class GetAccountMovementsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAccountMovementsQuery, Response<AccountMovementsResponse>>
{
    public async Task<Response<AccountMovementsResponse>> Handle(
        GetAccountMovementsQuery request, CancellationToken cancellationToken)
    {
        if (!request.AccountId.HasValue)
            return Response<AccountMovementsResponse>.Failure("Debe indicar la cuenta.");

        var account = await unitOfWork.Accounts.GetByIdAsync(request.AccountId.Value, cancellationToken);
        if (account is null)
            return Response<AccountMovementsResponse>.NotFound($"Cuenta {request.AccountId} no encontrada.");

        var lines = await unitOfWork.JournalEntryLines.Query()
            .Include(l => l.JournalEntry)
            .Where(l => l.AccountId == request.AccountId.Value
                && l.JournalEntry != null
                && l.JournalEntry.Status != JournalEntryStatus.Voided)
            .OrderBy(l => l.JournalEntry!.ReferenceDate)
            .ThenBy(l => l.JournalEntry!.EntryNumber)
            .ToListAsync(cancellationToken);

        decimal debitTotal = 0;
        decimal creditTotal = 0;
        decimal runningBalance = 0;
        var movements = new List<AccountMovementDto>(lines.Count);

        foreach (var line in lines)
        {
            runningBalance += line.Debit - line.Credit;
            debitTotal += line.Debit;
            creditTotal += line.Credit;

            movements.Add(new AccountMovementDto
            {
                JournalEntryId = line.JournalEntryId,
                EntryNumber = line.JournalEntry!.EntryNumber,
                ReferenceDate = line.JournalEntry.ReferenceDate,
                Concept = line.JournalEntry.Concept,
                Debit = line.Debit,
                Credit = line.Credit,
                Balance = runningBalance,
            });
        }

        return Response<AccountMovementsResponse>.Success(new AccountMovementsResponse
        {
            AccountId = account.Id,
            AccountCode = account.Code,
            AccountName = account.Name,
            DebitTotal = debitTotal,
            CreditTotal = creditTotal,
            Balance = debitTotal - creditTotal,
            Movements = movements,
        });
    }
}