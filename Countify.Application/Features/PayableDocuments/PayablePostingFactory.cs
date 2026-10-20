using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using Countify.Domain.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PayableDocuments;

internal static class PayablePostingFactory
{
    public static async Task<string?> CreateOrUpdatePostingAsync(
        IUnitOfWork unitOfWork,
        PayableDocument document,
        Supplier supplier,
        PayableConcept concept,
        CancellationToken cancellationToken)
    {
        if (!concept.GeneratePosting)
            return null;

        if (supplier.AccountingAccountId is null)
            return $"El proveedor {supplier.Name} no tiene asignada una cuenta contable de Cuentas por Pagar.";

        if (concept.AccountId is null)
            return $"El concepto {concept.Description} genera partida pero no tiene asignada una cuenta contable.";

        var period = await unitOfWork.AccountingPeriods.Query()
            .FirstOrDefaultAsync(p => p.Month.Month == document.Date.Month && p.Month.Year == document.Date.Year, cancellationToken);
        if (period is null || period.IsClosed)
            return $"No existe un período contable abierto para {document.Date:MM yyyy}.";

        if (document.JournalEntryId is null)
        {
            // Numeración global correlativa (legacy: Documento era PK autoincrementada).
            var max = await unitOfWork.JournalEntries.Query()
                .Select(e => (int?)e.EntryNumber).MaxAsync(cancellationToken);

            var journal = new JournalEntry
            {
                TypeId = BasicDocumentTypes.Partida.Id,
                PeriodId = period.Id,
                EntryNumber = (max ?? 0) + 1,
                ReferenceDate = document.Date,
                Reference = BuildReference(document),
                Concept = BuildConcept(concept, supplier),
                Observations = "Generada automáticamente desde Cuentas por Pagar.",
                Status = JournalEntryStatus.Posted,
                SourceModule = SourceModule.Payable,
                EntryGid = Guid.NewGuid(),
            };

            await unitOfWork.JournalEntries.AddAsync(journal, cancellationToken);
            document.JournalEntry = journal;
        }

        var entry = document.JournalEntry
            ?? await unitOfWork.JournalEntries.FirstOrDefaultAsync(
                unitOfWork.JournalEntries.Query().Include(e => e.Lines).Where(e => e.Id == document.JournalEntryId),
                cancellationToken);

        if (entry is null)
            return "No se pudo cargar la partida asociada al documento.";

        while (entry.Lines.Count > 2)
        {
            var line = entry.Lines[^1];
            entry.Lines.Remove(line);
            await unitOfWork.JournalEntryLines.DeleteAsync(line, cancellationToken);
        }

        while (entry.Lines.Count < 2)
            entry.Lines.Add(new JournalEntryLine { LineGid = Guid.NewGuid() });

        var amountLocal = Math.Round(
            (document.Amount + document.Tax) * document.ExchangeRate, 2, MidpointRounding.AwayFromZero);

        var isPayment = concept.Type == PayableConceptType.Credit;
        var first = entry.Lines[0];
        var second = entry.Lines[1];

        first.LineGid = Guid.NewGuid();
        first.DepartmentId = document.DepartmentId;
        first.ProjectId = document.ProjectId;
        first.Concept = BuildConcept(concept, supplier);
        first.AppliesToPayableId = document.Id;
        first.CustomerName = supplier.Name;

        second.LineGid = Guid.NewGuid();
        second.DepartmentId = document.DepartmentId;
        second.ProjectId = document.ProjectId;
        second.Concept = BuildConcept(concept, supplier);
        second.AppliesToPayableId = document.Id;
        second.CustomerName = supplier.Name;

        if (isPayment)
        {
            // Pago: Débito a Cuentas por Pagar (reduce el pasivo) / Crédito a la cuenta del concepto (banca, caja, gasto).
            first.AccountId = supplier.AccountingAccountId.Value;
            first.EntryConceptType = EntryConceptType.Debit;
            first.Debit = amountLocal;
            first.Credit = 0;

            second.AccountId = concept.AccountId.Value;
            second.EntryConceptType = EntryConceptType.Credit;
            second.Debit = 0;
            second.Credit = amountLocal;
        }
        else
        {
            // Compra/factura: Débito a compras/gasto (cuenta del concepto) / Crédito a Cuentas por Pagar del proveedor.
            first.AccountId = concept.AccountId.Value;
            first.EntryConceptType = EntryConceptType.Debit;
            first.Debit = amountLocal;
            first.Credit = 0;

            second.AccountId = supplier.AccountingAccountId.Value;
            second.EntryConceptType = EntryConceptType.Credit;
            second.Debit = 0;
            second.Credit = amountLocal;
        }

        entry.ReferenceDate = document.Date;
        entry.Reference = BuildReference(document);
        entry.Concept = BuildConcept(concept, supplier);
        entry.PeriodId = period.Id;
        entry.DebitTotal = amountLocal;
        entry.CreditTotal = amountLocal;
        entry.DifferenceAmount = 0;

        return null;
    }

    private static string BuildReference(PayableDocument document)
    {
        if (!string.IsNullOrWhiteSpace(document.Reference))
            return document.Reference.Trim();
        return $"CXP-{document.DocumentNo}";
    }

    private static string BuildConcept(PayableConcept concept, Supplier supplier)
        => $"{concept.Description} - {supplier.Name}";
}
