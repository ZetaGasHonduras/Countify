using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using Countify.Domain.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PayableDocuments;

/// <summary>
/// Rama de Ingreso de Compras (FASE 6 Etapa 5): la partida ya no va al concepto,
/// sino a la <b>cuenta de inventario de cada producto</b> (ProductAccount),
/// con la contrapartida acreedora en la cuenta contable del proveedor.
/// Legacy: el "Ingreso de Compras" de CXPDocumentosPadre débitaba
/// Grupo.CuentaInventario por línea y acreditaba al proveedor por el monto.
/// </summary>
internal static partial class PayablePostingFactory
{
    internal static async Task<string?> CreateOrUpdatePurchaseEntryAsync(
        IUnitOfWork unitOfWork,
        PayableDocument document,
        Supplier supplier,
        InventoryMovement movement,
        CancellationToken cancellationToken)
    {
        if (supplier.AccountingAccountId is null)
            return "El proveedor no tiene asignada una cuenta contable de Cuentas por Pagar.";

        if (movement.Lines.Count == 0)
            return "El ingreso de compras debe tener al menos una línea de producto.";

        var productIds = movement.Lines.Select(l => l.ProductId).Distinct().ToList();
        var accountsByProduct = await unitOfWork.ProductAccounts.Query()
            .Where(pa => productIds.Contains(pa.ProductId))
            .ToListAsync(cancellationToken);

        var missing = productIds
            .Where(id => accountsByProduct.All(pa => pa.ProductId != id))
            .ToList();
        if (missing.Count > 0)
            return "Algunos productos del ingreso no tienen cuentas de inventario asignadas (Cuentas por Producto).";

        var period = await unitOfWork.AccountingPeriods.Query()
            .FirstOrDefaultAsync(
                p => p.Month.Month == document.Date.Month && p.Month.Year == document.Date.Year,
                cancellationToken);
        if (period is null || period.IsClosed)
            return $"No existe un período contable abierto para {document.Date:MM/yyyy}.";

        if (document.JournalEntryId is null)
        {
            var max = await unitOfWork.JournalEntries.Query()
                .Select(e => (int?)e.EntryNumber).MaxAsync(cancellationToken);

            var journal = new JournalEntry
            {
                TypeId = BasicDocumentTypes.Partida.Id,
                PeriodId = period.Id,
                EntryNumber = (max ?? 0) + 1,
                ReferenceDate = document.Date,
                Reference = BuildPurchaseEntryReference(document),
                Concept = BuildPurchaseEntryConcept(supplier),
                Observations = "Generada automáticamente desde Ingreso de Compras.",
                Status = JournalEntryStatus.Posted,
                SourceModule = SourceModule.Payable,
                EntryGid = Guid.NewGuid(),
            };

            await unitOfWork.JournalEntries.AddAsync(journal, cancellationToken);
            document.JournalEntry = journal;
        }

        var entry = document.JournalEntry
            ?? await unitOfWork.JournalEntries.Query()
                .Include(e => e.Lines)
                .FirstOrDefaultAsync(e => e.Id == document.JournalEntryId, cancellationToken);

        if (entry is null)
            return "No se pudo cargar la partida asociada al documento.";

        entry.PeriodId = period.Id;
        entry.ReferenceDate = document.Date;
        entry.Reference = BuildPurchaseEntryReference(document);
        entry.Concept = BuildPurchaseEntryConcept(supplier);

        // Reconstrucción total: a diferencia del documento CxP genérico (2 líneas fijas),
        // el ingreso tiene una línea de débito por cada cuenta de inventario distinta.
        foreach (var oldLine in entry.Lines.ToList())
        {
            entry.Lines.Remove(oldLine);
            await unitOfWork.JournalEntryLines.DeleteAsync(oldLine, cancellationToken);
        }

        var debits = new Dictionary<Guid, decimal>();
        decimal total = 0;

        foreach (var line in movement.Lines)
        {
            var pa = accountsByProduct.First(x => x.ProductId == line.ProductId);
            var amountLocal = Math.Round(
                line.LineTotal * document.ExchangeRate, 2, MidpointRounding.AwayFromZero);

            debits.TryGetValue(pa.InventoryAccountId, out var acc);
            debits[pa.InventoryAccountId] = acc + amountLocal;
            total += amountLocal;
        }

        total = Math.Round(total, 2);

        foreach (var (accountId, amount) in debits.Where(d => d.Value != 0))
        {
            entry.Lines.Add(new JournalEntryLine
            {
                AccountId = accountId,
                DepartmentId = document.DepartmentId,
                ProjectId = document.ProjectId,
                EntryConceptType = EntryConceptType.Debit,
                Concept = BuildPurchaseEntryConcept(supplier),
                Debit = Math.Round(amount, 2),
                Credit = 0,
                AppliesToPayableId = document.Id,
                CustomerName = supplier.Name,
                LineGid = Guid.NewGuid(),
            });
        }

        entry.Lines.Add(new JournalEntryLine
        {
            AccountId = supplier.AccountingAccountId.Value,
            DepartmentId = document.DepartmentId,
            ProjectId = document.ProjectId,
            EntryConceptType = EntryConceptType.Credit,
            Concept = BuildPurchaseEntryConcept(supplier),
            Debit = 0,
            Credit = total,
            AppliesToPayableId = document.Id,
            CustomerName = supplier.Name,
            LineGid = Guid.NewGuid(),
        });

        entry.DebitTotal = Math.Round(debits.Values.Sum(), 2);
        entry.CreditTotal = total;
        entry.DifferenceAmount = entry.DebitTotal - entry.CreditTotal;

        await unitOfWork.JournalEntries.UpdateAsync(entry, cancellationToken);
        return null;
    }

    private static string BuildPurchaseEntryReference(PayableDocument document)
        => !string.IsNullOrWhiteSpace(document.Reference)
            ? document.Reference.Trim()
            : $"CXP-{document.DocumentNo}";

    private static string BuildPurchaseEntryConcept(Supplier supplier)
        => $"Ingreso de compras - {supplier.Name}";
}
