using System.Globalization;
using AutoMapper;
using Countify.Application.Features.SalesJournalBatches.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.Billing;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using Countify.Domain.Seeders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.SalesJournalBatches.Commands.CreateSalesJournalBatch;

/// <summary>
/// Legacy <c>CntPartidaDeVentasVC</c> + sp <c>PRDCntCrearPartidaVentas</c>:
/// agrupa las facturas del rango (no anuladas y aún sin lote) en una única
/// partida de diario en moneda local. El rango debe caer dentro de un mismo
/// mes con período contable abierto.
/// </summary>
public class CreateSalesJournalBatchCommand : IRequest<Response<SalesJournalBatchDto>>
{
    public DateTime PeriodFrom { get; set; }
    public DateTime PeriodTo { get; set; }
    public string? Notes { get; set; }
}

public class CreateSalesJournalBatchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateSalesJournalBatchCommand, Response<SalesJournalBatchDto>>
{
    public async Task<Response<SalesJournalBatchDto>> Handle(
        CreateSalesJournalBatchCommand request, CancellationToken cancellationToken)
    {
        var from = request.PeriodFrom.Date;
        var to = request.PeriodTo.Date;

        if (to < from)
            return Response<SalesJournalBatchDto>.Failure("La fecha hasta no puede ser anterior a la fecha desde.");

        if (from.Year != to.Year || from.Month != to.Month)
            return Response<SalesJournalBatchDto>.Failure("La partida de ventas se genera por mes: el rango debe estar dentro del mismo mes.");

        var overlap = await unitOfWork.SalesJournalBatches.ExistsAsync(
            b => b.PeriodFrom <= to && b.PeriodTo >= from, cancellationToken);
        if (overlap)
            return Response<SalesJournalBatchDto>.Failure("Ya existe una partida de ventas que cubre parte de ese rango.");

        var settings = await unitOfWork.CompanySettings.Query().FirstOrDefaultAsync(cancellationToken);
        if (settings is null)
            return Response<SalesJournalBatchDto>.Failure("Configure la información de la empresa primero.");

        var missing = new (Guid? Id, string Name)[]
        {
            (settings.SalesLocalAccountId, "Ventas Local"),
            (settings.SalesForeignAccountId, "Ventas Extranjero"),
            (settings.ReceivableLocalAccountId, "Cuentas por Cobrar Local"),
            (settings.ReceivableForeignAccountId, "Cuentas por Cobrar Extranjero"),
            (settings.CashAccountId, "Caja"),
            (settings.TaxPayableAccountId, "ISV Por Pagar"),
        }.Where(x => x.Id is null).Select(x => x.Name).ToList();

        if (missing.Count > 0)
            return Response<SalesJournalBatchDto>.Failure(
                $"Faltan cuentas de ventas por configurar: {string.Join(", ", missing)} (Configuración Contable).");

        var period = await unitOfWork.AccountingPeriods.Query()
            .FirstOrDefaultAsync(p => p.Month.Month == to.Month && p.Month.Year == to.Year, cancellationToken);
        if (period is null || period.IsClosed)
            return Response<SalesJournalBatchDto>.Failure($"No existe un período contable abierto para {to:MM/yyyy}.");

        var invoices = await unitOfWork.Invoices.Query()
            .Include(i => i.Currency)
            .Where(i => !i.IsVoided && i.SalesBatchId == null && i.Date >= from && i.Date <= to)
            .ToListAsync(cancellationToken);

        if (invoices.Count == 0)
            return Response<SalesJournalBatchDto>.Failure("No hay facturas por contabilizar en ese rango.");

        // ---- Agregación estilo PRDCntCrearPartidaVentas (montos en moneda local) ----
        // Clave: (cuenta, departamento, proyecto). Caja/CXC debitan; Ventas/ISV acreeditan.
        var lines = new Dictionary<(Guid AccountId, Guid? Dept, Guid? Proj), (decimal Debit, decimal Credit)>();

        void Add(Guid accountId, Guid? dept, Guid? proj, decimal debit, decimal credit)
        {
            var key = (accountId, dept, proj);
            var (d, c) = lines.TryGetValue(key, out var v) ? v : (0m, 0m);
            lines[key] = (d + debit, c + credit);
        }

        foreach (var invoice in invoices)
        {
            var rate = invoice.ExchangeRate <= 0 ? 1m : invoice.ExchangeRate;
            var subLocal = Math.Round(invoice.SubTotal * rate, 2, MidpointRounding.AwayFromZero);
            var taxLocal = Math.Round(invoice.TaxAmount * rate, 2, MidpointRounding.AwayFromZero);
            var netLocal = subLocal + taxLocal;

            // Local vs extranjero por factor de la moneda (legacy: TotalLocal se movía solo con Factor > 1).
            var isForeign = rate > 1;

            var salesAccount = isForeign ? settings.SalesForeignAccountId!.Value : settings.SalesLocalAccountId!.Value;
            var payableAccount = invoice.PaymentTerms == InvoicePaymentTerms.Credito
                ? (isForeign ? settings.ReceivableForeignAccountId!.Value : settings.ReceivableLocalAccountId!.Value)
                : settings.CashAccountId!.Value;

            Add(payableAccount, invoice.DepartmentId, invoice.ProjectId, netLocal, 0);
            Add(salesAccount, invoice.DepartmentId, invoice.ProjectId, 0, subLocal);
            if (taxLocal > 0)
                Add(settings.TaxPayableAccountId!.Value, invoice.DepartmentId, invoice.ProjectId, 0, taxLocal);
        }

        var maxEntry = await unitOfWork.JournalEntries.Query()
            .Select(e => (int?)e.EntryNumber).MaxAsync(cancellationToken);

        var monthName = to.ToString("MMMM", new CultureInfo("es-HN"));
        var journal = new JournalEntry
        {
            TypeId = BasicDocumentTypes.Partida.Id,
            PeriodId = period.Id,
            EntryNumber = (maxEntry ?? 0) + 1,
            Code = $"PARTIDADEVENTAS{to:MMyyyy}",
            ReferenceDate = to,
            Reference = $"PARTIDA DE VENTAS {monthName.ToUpperInvariant()} {to:yyyy}",
            Concept = $"Partida de Ventas de {monthName} {to:yyyy}",
            Observations = string.IsNullOrWhiteSpace(request.Notes)
                ? $"Generada automáticamente desde Facturación ({invoices.Count} facturas)."
                : $"Generada desde Facturación ({invoices.Count} facturas). {request.Notes!.Trim()}",
            Status = JournalEntryStatus.Posted,
            SourceModule = SourceModule.Invoice,
            EntryGid = Guid.NewGuid(),
        };

        decimal debitTotal = 0, creditTotal = 0;
        foreach (var (key, amount) in lines.Where(l => l.Value.Debit != 0 || l.Value.Credit != 0))
        {
            journal.Lines.Add(new JournalEntryLine
            {
                AccountId = key.AccountId,
                DepartmentId = key.Dept,
                ProjectId = key.Proj,
                Debit = Math.Round(amount.Debit, 2),
                Credit = Math.Round(amount.Credit, 2),
                LineGid = Guid.NewGuid(),
            });
            debitTotal += amount.Debit;
            creditTotal += amount.Credit;
        }

        journal.DebitTotal = Math.Round(debitTotal, 2);
        journal.CreditTotal = Math.Round(creditTotal, 2);
        journal.DifferenceAmount = journal.DebitTotal - journal.CreditTotal;

        if (journal.DifferenceAmount != 0)
            return Response<SalesJournalBatchDto>.Failure(
                $"La partida no cuadra (debe {journal.DebitTotal:N2} / haber {journal.CreditTotal:N2}). Revise los totales de las facturas del rango.");

        var batch = new SalesJournalBatch
        {
            PeriodFrom = from,
            PeriodTo = to,
            JournalEntry = journal,
            Notes = request.Notes?.Trim(),
        };

        await unitOfWork.SalesJournalBatches.AddAsync(batch, cancellationToken);

        foreach (var invoice in invoices)
            invoice.SalesBatchId = batch.Id;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var dto = mapper.Map<SalesJournalBatchDto>(batch);
        dto.EntryNumber = journal.EntryNumber;
        dto.InvoiceCount = invoices.Count;
        dto.InvoicedTotal = Math.Round(invoices.Sum(i => i.TotalLocal), 2);

        return Response<SalesJournalBatchDto>.Success(dto, 201);
    }
}
