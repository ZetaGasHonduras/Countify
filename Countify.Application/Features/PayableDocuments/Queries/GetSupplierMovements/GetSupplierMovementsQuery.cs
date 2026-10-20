using Countify.Application.Features.PayableDocuments.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PayableDocuments.Queries.GetSupplierMovements;

public class GetSupplierMovementsQuery : IRequest<Response<SupplierMovementsDto>>
{
    public Guid SupplierId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}

public class GetSupplierMovementsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetSupplierMovementsQuery, Response<SupplierMovementsDto>>
{
    private static readonly (string Key, string Label)[] AgingBuckets =
    [
        ("current", "Corriente"),
        ("d1_30", "1-30"),
        ("d31_60", "31-60"),
        ("d61_90", "61-90"),
        ("d91_120", "91-120"),
        ("d121_plus", "121+"),
    ];

    public async Task<Response<SupplierMovementsDto>> Handle(
        GetSupplierMovementsQuery request, CancellationToken cancellationToken)
    {
        if (request.FromDate > request.ToDate)
            return Response<SupplierMovementsDto>.Failure("El rango de fechas no es válido.");

        var supplier = await unitOfWork.Suppliers.GetByIdAsync(request.SupplierId, cancellationToken);
        if (supplier is null)
            return Response<SupplierMovementsDto>.NotFound("Proveedor no encontrado.");

        var end = request.ToDate.Date.AddDays(1);
        var asOf = request.ToDate.Date;

        var documents = await unitOfWork.PayableDocuments.ToListAsync(
            unitOfWork.PayableDocuments.Query()
                .Include(d => d.Supplier)
                .Include(d => d.Concept)
                .Include(d => d.Currency)
                .Where(d => d.SupplierId == request.SupplierId && d.Date >= request.FromDate && d.Date < end)
                .OrderBy(d => d.Date)
                .ThenBy(d => d.DocumentNo),
            cancellationToken);

        var ids = documents.Select(d => d.Id).ToList();

        var lines = ids.Count > 0
            ? await unitOfWork.PayableDocumentLines.ToListAsync(
                unitOfWork.PayableDocumentLines.Query()
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
        var movements = new List<SupplierMovementDto>();

        foreach (var document in documents)
        {
            var isPayment = IsPayment(document);
            var total = Math.Round(document.Amount + document.Tax, 2);
            var totalLocal = Math.Round(total * document.ExchangeRate, 2);
            var debit = document.IsVoided ? 0 : isPayment ? 0 : totalLocal;
            var credit = document.IsVoided ? 0 : isPayment ? totalLocal : 0;

            if (!document.IsVoided)
            {
                if (isPayment) totalAbonos += totalLocal;
                else totalCargos += totalLocal;
                runningBalance += debit - credit;
            }

            decimal appliedAmount = 0;
            var applications = new List<SupplierMovementApplicationDto>();

            if (isPayment)
            {
                foreach (var line in appliedAsSource.GetValueOrDefault(document.Id, []))
                {
                    if (line.AppliedDocument is null) continue;
                    appliedAmount += line.Amount;
                    applications.Add(new SupplierMovementApplicationDto
                    {
                        Id = line.Id,
                        RelatedDocumentId = line.AppliedDocumentId,
                        RelatedDocumentNo = line.AppliedDocument.DocumentNo,
                        RelatedDate = line.AppliedDocument.Date,
                        RelatedReference = line.AppliedDocument.Reference,
                        RelatedConcept = line.AppliedDocument.Concept?.Description ?? string.Empty,
                        RelatedIsPayment = IsPayment(line.AppliedDocument),
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
                    applications.Add(new SupplierMovementApplicationDto
                    {
                        Id = line.Id,
                        RelatedDocumentId = line.DocumentId,
                        RelatedDocumentNo = line.Document.DocumentNo,
                        RelatedDate = line.Document.Date,
                        RelatedReference = line.Document.Reference,
                        RelatedConcept = line.Document.Concept?.Description ?? string.Empty,
                        RelatedIsPayment = IsPayment(line.Document),
                        Amount = line.Amount,
                    });
                }
            }

            var outstanding = document.IsVoided || isPayment
                ? 0m
                : Math.Round(totalLocal - appliedAmount, 2);

            int? daysOverdue = null;
            string? agingBucket = null;
            if (!document.IsVoided && !isPayment && outstanding > 0)
            {
                daysOverdue = (asOf - document.DueDate.Date).Days;
                agingBucket = BucketKeyFor(daysOverdue.Value);
            }

            movements.Add(new SupplierMovementDto
            {
                DocumentId = document.Id,
                DocumentNo = document.DocumentNo,
                IsPayment = isPayment,
                Date = document.Date,
                DueDate = document.DueDate,
                Reference = document.Reference,
                ConceptDescription = document.Concept?.Description ?? string.Empty,
                CurrencyCode = document.Currency?.Code ?? string.Empty,
                Amount = document.Amount,
                Tax = document.Tax,
                Total = total,
                TotalLocal = totalLocal,
                Debit = debit,
                Credit = credit,
                RunningBalance = Math.Round(runningBalance, 2),
                AppliedAmount = Math.Round(appliedAmount, 2),
                OutstandingAmount = outstanding,
                DaysOverdue = daysOverdue,
                AgingBucket = agingBucket,
                IsVoided = document.IsVoided,
                Applications = applications,
            });
        }

        var aging = await BuildAgingAsync(request.SupplierId, asOf, end, cancellationToken);

        var dto = new SupplierMovementsDto
        {
            SupplierId = supplier.Id,
            SupplierCode = supplier.Code,
            SupplierName = supplier.Name,
            FromDate = request.FromDate,
            ToDate = request.ToDate,
            TotalCargos = Math.Round(totalCargos, 2),
            TotalAbonos = Math.Round(totalAbonos, 2),
            Saldo = Math.Round(totalCargos - totalAbonos, 2),
            Aging = aging,
            Movements = movements,
        };

        return Response<SupplierMovementsDto>.Success(dto);
    }

    /// <summary>
    /// Antigüedad de saldos pendientes al corte: considera todas las compras no anuladas con
    /// fecha anterior o igual al corte (no solo las del período consultado), igual que en CxC.
    /// </summary>
    private async Task<SupplierAgingDto> BuildAgingAsync(
        Guid supplierId, DateTime asOf, DateTime end, CancellationToken cancellationToken)
    {
        var aging = new SupplierAgingDto
        {
            AsOfDate = asOf,
            Buckets = AgingBuckets.Select(b => new SupplierAgingBucketDto { Key = b.Key, Label = b.Label }).ToList(),
        };

        var chargeDocuments = await unitOfWork.PayableDocuments.ToListAsync(
            unitOfWork.PayableDocuments.Query()
                .Include(d => d.Concept)
                .Include(d => d.Currency)
                .Where(d => d.SupplierId == supplierId && !d.IsVoided && d.Date < end)
                .OrderBy(d => d.DueDate)
                .ThenBy(d => d.DocumentNo),
            cancellationToken);

        // Solo compras (los pagos no generan saldo por pagar).
        chargeDocuments = chargeDocuments.Where(d => !IsPayment(d)).ToList();
        var chargeIds = chargeDocuments.Select(d => d.Id).ToList();

        var appliedByDocument = new Dictionary<Guid, decimal>();
        if (chargeIds.Count > 0)
        {
            var agingLines = await unitOfWork.PayableDocumentLines.ToListAsync(
                unitOfWork.PayableDocumentLines.Query()
                    .Where(l => chargeIds.Contains(l.AppliedDocumentId)),
                cancellationToken);

            appliedByDocument = agingLines
                .GroupBy(l => l.AppliedDocumentId)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Amount));
        }

        var bucketTotals = AgingBuckets.ToDictionary(b => b.Key, _ => 0m);

        foreach (var document in chargeDocuments)
        {
            var totalLocal = Math.Round(
                Math.Round(document.Amount + document.Tax, 2) * document.ExchangeRate, 2);
            var applied = Math.Round(appliedByDocument.GetValueOrDefault(document.Id, 0m), 2);
            var outstanding = Math.Round(totalLocal - applied, 2);
            if (outstanding <= 0) continue;

            var daysOverdue = (asOf - document.DueDate.Date).Days;
            var bucketKey = BucketKeyFor(daysOverdue);

            bucketTotals[bucketKey] += outstanding;
            aging.TotalOutstanding += outstanding;

            aging.Details.Add(new SupplierAgingDetailDto
            {
                DocumentId = document.Id,
                DocumentNo = document.DocumentNo,
                Date = document.Date,
                DueDate = document.DueDate,
                Reference = document.Reference,
                ConceptDescription = document.Concept?.Description ?? string.Empty,
                CurrencyCode = document.Currency?.Code ?? string.Empty,
                AmountLocal = totalLocal,
                AppliedAmount = applied,
                OutstandingAmount = outstanding,
                DaysOverdue = daysOverdue,
                BucketKey = bucketKey,
            });
        }

        foreach (var bucket in aging.Buckets)
            bucket.Amount = Math.Round(bucketTotals.GetValueOrDefault(bucket.Key, 0m), 2);

        aging.TotalOutstanding = Math.Round(aging.TotalOutstanding, 2);

        return aging;
    }

    private static string BucketKeyFor(int daysOverdue)
    {
        if (daysOverdue <= 0) return "current";
        if (daysOverdue <= 30) return "d1_30";
        if (daysOverdue <= 60) return "d31_60";
        if (daysOverdue <= 90) return "d61_90";
        if (daysOverdue <= 120) return "d91_120";
        return "d121_plus";
    }

    private static bool IsPayment(PayableDocument document)
        => document.Concept != null && document.Concept.Type == PayableConceptType.Credit;
}
