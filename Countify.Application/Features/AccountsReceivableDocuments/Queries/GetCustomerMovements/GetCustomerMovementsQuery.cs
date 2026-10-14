using Countify.Application.Features.AccountsReceivableDocuments.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.AccountsReceivableDocuments.Queries.GetCustomerMovements;

public class GetCustomerMovementsQuery : IRequest<Response<CustomerMovementsDto>>
{
    public Guid CustomerId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}

public class GetCustomerMovementsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetCustomerMovementsQuery, Response<CustomerMovementsDto>>
{
    public async Task<Response<CustomerMovementsDto>> Handle(
        GetCustomerMovementsQuery request, CancellationToken cancellationToken)
    {
        if (request.FromDate > request.ToDate)
            return Response<CustomerMovementsDto>.Failure("El rango de fechas no es válido.");

        var customer = await unitOfWork.Customers.GetByIdAsync(request.CustomerId, cancellationToken);
        if (customer is null)
            return Response<CustomerMovementsDto>.NotFound("Cliente no encontrado.");

        var end = request.ToDate.Date.AddDays(1);

        var documents = await unitOfWork.AccountsReceivableDocuments.ToListAsync(
            unitOfWork.AccountsReceivableDocuments.Query()
                .Include(d => d.Customer)
                .Include(d => d.Concept)
                .Include(d => d.Currency)
                .Where(d => d.CustomerId == request.CustomerId && d.Date >= request.FromDate && d.Date < end)
                .OrderBy(d => d.Date)
                .ThenBy(d => d.DocumentNo),
            cancellationToken);

        var ids = documents.Select(d => d.Id).ToList();

        var lines = ids.Count > 0
            ? await unitOfWork.AccountsReceivableDocumentLines.ToListAsync(
                unitOfWork.AccountsReceivableDocumentLines.Query()
                    .Include(l => l.Document)
                    .Include(l => l.AppliedDocument)
                    .Where(l => ids.Contains(l.DocumentId) || ids.Contains(l.AppliedDocumentId)),
                cancellationToken)
            : [];

        var appliedAsTarget = lines
            .Where(l => l.AppliedDocumentId != Guid.Empty)
            .GroupBy(l => l.AppliedDocumentId)
            .ToDictionary(g => g.Key, g => g.ToList());

        var appliedAsSource = lines
            .Where(l => l.DocumentId != Guid.Empty)
            .GroupBy(l => l.DocumentId)
            .ToDictionary(g => g.Key, g => g.ToList());

        decimal totalCargos = 0, totalAbonos = 0, runningBalance = 0;
        var movements = new List<CustomerMovementDto>();

        foreach (var document in documents)
        {
            var isCredit = IsCredit(document);
            var amountLocal = Math.Round(document.Amount * document.ExchangeRate, 2);
            var debit = document.IsVoided ? 0 : isCredit ? 0 : amountLocal;
            var credit = document.IsVoided ? 0 : isCredit ? amountLocal : 0;

            if (!document.IsVoided)
            {
                if (isCredit) totalAbonos += amountLocal;
                else totalCargos += amountLocal;
                runningBalance += debit - credit;
            }

            decimal appliedAmount = 0;
            var applications = new List<CustomerMovementApplicationDto>();

            if (isCredit)
            {
                foreach (var line in appliedAsSource.GetValueOrDefault(document.Id, []))
                {
                    if (line.AppliedDocument is null) continue;
                    appliedAmount += line.Amount;
                    applications.Add(new CustomerMovementApplicationDto
                    {
                        Id = line.Id,
                        RelatedDocumentId = line.AppliedDocumentId,
                        RelatedDocumentNo = line.AppliedDocument.DocumentNo,
                        RelatedReceiptNumber = line.AppliedDocument.ReceiptNumber,
                        RelatedDate = line.AppliedDocument.Date,
                        RelatedReference = line.AppliedDocument.Reference,
                        RelatedConcept = line.AppliedDocument.Concept?.Description ?? string.Empty,
                        RelatedIsCredit = IsCredit(line.AppliedDocument),
                        Amount = line.Amount,
                    });
                }
            }
            else
            {
                foreach (var line in appliedAsTarget.GetValueOrDefault(document.Id, []))
                {
                    if (line.Document is null) continue;
                    appliedAmount += line.Amount;
                    applications.Add(new CustomerMovementApplicationDto
                    {
                        Id = line.Id,
                        RelatedDocumentId = line.DocumentId,
                        RelatedDocumentNo = line.Document.DocumentNo,
                        RelatedReceiptNumber = line.Document.ReceiptNumber,
                        RelatedDate = line.Document.Date,
                        RelatedReference = line.Document.Reference,
                        RelatedConcept = line.Document.Concept?.Description ?? string.Empty,
                        RelatedIsCredit = IsCredit(line.Document),
                        Amount = line.Amount,
                    });
                }
            }

            movements.Add(new CustomerMovementDto
            {
                DocumentId = document.Id,
                DocumentNo = document.DocumentNo,
                ReceiptNumber = document.ReceiptNumber,
                IsCredit = isCredit,
                Date = document.Date,
                DueDate = document.DueDate,
                Reference = document.Reference,
                ConceptDescription = document.Concept?.Description ?? string.Empty,
                CurrencyCode = document.Currency?.Code ?? string.Empty,
                Amount = document.Amount,
                AmountLocal = amountLocal,
                Debit = debit,
                Credit = credit,
                RunningBalance = Math.Round(runningBalance, 2),
                AppliedAmount = Math.Round(appliedAmount, 2),
                OutstandingAmount = document.IsVoided || isCredit
                    ? 0
                    : Math.Round(amountLocal - appliedAmount, 2),
                IsVoided = document.IsVoided,
                Applications = applications,
            });
        }

        var dto = new CustomerMovementsDto
        {
            CustomerId = customer.Id,
            CustomerCode = customer.Code,
            CustomerName = customer.Name,
            FromDate = request.FromDate,
            ToDate = request.ToDate,
            TotalCargos = Math.Round(totalCargos, 2),
            TotalAbonos = Math.Round(totalAbonos, 2),
            Saldo = Math.Round(totalCargos - totalAbonos, 2),
            Movements = movements,
        };

        return Response<CustomerMovementsDto>.Success(dto);
    }

    private static bool IsCredit(AccountsReceivableDocument document)
        => document.Concept != null && document.Concept.Type == AccountsReceivableConceptType.Credit;
}