using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using Countify.Domain.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.AccountsReceivableDocuments;

internal static class AccountsReceivablePostingFactory
{
    public static async Task<string?> CreateOrUpdatePostingAsync(
        IUnitOfWork unitOfWork,
        AccountsReceivableDocument document,
        Customer customer,
        AccountsReceivableConcept concept,
        CancellationToken cancellationToken)
    {
        if (!concept.GeneratePosting)
            return null;

        if (customer.AccountingAccountId is null)
            return $"El cliente {customer.Name} no tiene asignada una cuenta contable de Cuentas por Cobrar.";

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
                Concept = BuildConcept(concept, customer),
                Observations = "Generada automáticamente desde Cuentas por Cobrar.",
                Status = JournalEntryStatus.Posted,
                SourceModule = SourceModule.Receivable,
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

        var amountLocal = decimal.Round(document.Amount * document.ExchangeRate, 2, MidpointRounding.AwayFromZero);

        var isCredit = concept.Type == AccountsReceivableConceptType.Credit;
        var first = entry.Lines[0];
        var second = entry.Lines[1];

        first.LineGid = Guid.NewGuid();
        first.DepartmentId = document.DepartmentId;
        first.ProjectId = document.ProjectId;
        first.Concept = BuildConcept(concept, customer);
        first.AppliesToReceivableId = document.Id;
        first.CustomerName = customer.Name;

        second.LineGid = Guid.NewGuid();
        second.DepartmentId = document.DepartmentId;
        second.ProjectId = document.ProjectId;
        second.Concept = BuildConcept(concept, customer);
        second.AppliesToReceivableId = document.Id;
        second.CustomerName = customer.Name;

        if (isCredit)
        {
            first.AccountId = concept.AccountId.Value;
            first.EntryConceptType = EntryConceptType.Debit;
            first.Debit = amountLocal;
            first.Credit = 0;

            second.AccountId = customer.AccountingAccountId.Value;
            second.EntryConceptType = EntryConceptType.Credit;
            second.Debit = 0;
            second.Credit = amountLocal;
        }
        else
        {
            first.AccountId = customer.AccountingAccountId.Value;
            first.EntryConceptType = EntryConceptType.Debit;
            first.Debit = amountLocal;
            first.Credit = 0;

            second.AccountId = concept.AccountId.Value;
            second.EntryConceptType = EntryConceptType.Credit;
            second.Debit = 0;
            second.Credit = amountLocal;
        }

        entry.ReferenceDate = document.Date;
        entry.Reference = BuildReference(document);
        entry.Concept = BuildConcept(concept, customer);
        entry.PeriodId = period.Id;
        entry.DebitTotal = amountLocal;
        entry.CreditTotal = amountLocal;
        entry.DifferenceAmount = 0;

        return null;
    }

    private static string BuildReference(AccountsReceivableDocument document)
    {
        if (!string.IsNullOrWhiteSpace(document.Reference))
            return document.Reference.Trim();
        return document.ReceiptNumber is not null
            ? $"RECIBO-{document.ReceiptNumber}"
            : $"CXC-{document.DocumentNo}";
    }

    private static string BuildConcept(AccountsReceivableConcept concept, Customer customer)
        => $"{concept.Description} - {customer.Name}";
}