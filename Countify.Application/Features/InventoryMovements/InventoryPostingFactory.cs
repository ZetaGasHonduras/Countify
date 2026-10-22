using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using Countify.Domain.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryMovements;

/// <summary>
/// Partida del ajuste de inventario (espejo de los sps
/// <c>PRDCNTPartidaAjustePositivo/Negativo</c> del legacy, rediseñados en C#):
/// AJ+: débito cuenta de inventario del producto / crédito cuenta de ajustes;
/// AJ−: débito cuenta de costo del producto / crédito cuenta de inventario.
/// Como el legacy, la partida se recrea en cada guardado del movimiento.
/// </summary>
internal static class InventoryPostingFactory
{
    public static async Task<string?> CreateOrUpdatePostingAsync(
        IUnitOfWork unitOfWork,
        InventoryMovement movement,
        CompanySettings settings,
        CancellationToken cancellationToken)
    {
        if (movement.Type is not { GeneratesPosting: true } || movement.IsVoided)
            return null;

        if (settings.InventoryAdjustmentAccountId is null)
            return "Configure la cuenta de ajustes de inventario en Configuración Contable.";

        var productIds = movement.Lines.Select(l => l.ProductId).Distinct().ToList();
        var accountsByProduct = await unitOfWork.ProductAccounts.Query()
            .Where(pa => productIds.Contains(pa.ProductId))
            .ToListAsync(cancellationToken);

        var missing = productIds
            .Where(id => accountsByProduct.All(pa => pa.ProductId != id))
            .ToList();
        if (missing.Count > 0)
            return "Algunos productos del movimiento no tienen cuentas de inventario asignadas (Cuentas por Producto).";

        var isEntry = movement.Type.Direction == InventoryMovementDirection.Entry;
        var isExit = movement.Type.Direction == InventoryMovementDirection.Exit;
        if (!isEntry && !isExit)
            return "El tipo de movimiento no es de entrada ni de salida; no puede generar partida.";

        var period = await unitOfWork.AccountingPeriods.Query()
            .FirstOrDefaultAsync(
                p => p.Month.Month == movement.Date.Month && p.Month.Year == movement.Date.Year,
                cancellationToken);
        if (period is null || period.IsClosed)
            return $"No existe un período contable abierto para {movement.Date:MM/yyyy}.";

        // ---- Acumula débitos por cuenta (inventario o costo) ----
        var debits = new Dictionary<Guid, decimal>();
        var credits = new Dictionary<Guid, decimal>();

        foreach (var line in movement.Lines)
        {
            var pa = accountsByProduct.First(x => x.ProductId == line.ProductId);

            if (isEntry)
            {
                debits.TryGetValue(pa.InventoryAccountId, out var d);
                debits[pa.InventoryAccountId] = d + line.LineTotal;
            }
            else
            {
                debits.TryGetValue(pa.CostAccountId, out var d);
                debits[pa.CostAccountId] = d + line.LineTotal;

                credits.TryGetValue(pa.InventoryAccountId, out var c);
                credits[pa.InventoryAccountId] = c + line.LineTotal;
            }
        }

        if (isEntry)
        {
            var grandTotal = movement.Lines.Sum(l => l.LineTotal);
            credits.TryGetValue(settings.InventoryAdjustmentAccountId.Value, out var adj);
            credits[settings.InventoryAdjustmentAccountId.Value] = adj + Math.Round(grandTotal, 2);
        }

        // ---- Crea o reutiliza la partida ----
        if (movement.JournalEntryId is null)
        {
            var max = await unitOfWork.JournalEntries.Query()
                .Select(e => (int?)e.EntryNumber).MaxAsync(cancellationToken);

            var journal = new JournalEntry
            {
                TypeId = BasicDocumentTypes.Partida.Id,
                PeriodId = period.Id,
                EntryNumber = (max ?? 0) + 1,
                ReferenceDate = movement.Date,
                Reference = movement.Code ?? $"AJ-{movement.Id:N}",
                Concept = $"Ajuste de inventario {movement.Code}",
                Observations = "Generada automáticamente desde Inventario.",
                Status = JournalEntryStatus.Posted,
                SourceModule = SourceModule.Inventory,
                EntryGid = Guid.NewGuid(),
            };

            await unitOfWork.JournalEntries.AddAsync(journal, cancellationToken);
            movement.JournalEntry = journal;
        }

        var entry = movement.JournalEntry
            ?? await unitOfWork.JournalEntries.Query()
                .Include(e => e.Lines)
                .FirstOrDefaultAsync(e => e.Id == movement.JournalEntryId, cancellationToken);

        if (entry is null)
            return "No se pudo cargar la partida asociada al movimiento.";

        if (entry.PeriodId != period.Id)
            entry.PeriodId = period.Id;

        // El legacy recreaba la partida en cada guardado: se reemplazan todas las líneas.
        foreach (var oldLine in entry.Lines.ToList())
        {
            entry.Lines.Remove(oldLine);
            await unitOfWork.JournalEntryLines.DeleteAsync(oldLine, cancellationToken);
        }

        decimal debitTotal = 0, creditTotal = 0;

        foreach (var (accountId, amount) in debits)
        {
            if (amount <= 0) continue;
            entry.Lines.Add(new JournalEntryLine
            {
                AccountId = accountId,
                DepartmentId = movement.DepartmentId,
                Debit = Math.Round(amount, 2),
                Credit = 0,
                Concept = movement.Concept,
                LineGid = Guid.NewGuid(),
            });
            debitTotal += amount;
        }

        foreach (var (accountId, amount) in credits)
        {
            if (amount <= 0) continue;
            entry.Lines.Add(new JournalEntryLine
            {
                AccountId = accountId,
                DepartmentId = movement.DepartmentId,
                Debit = 0,
                Credit = Math.Round(amount, 2),
                Concept = movement.Concept,
                LineGid = Guid.NewGuid(),
            });
            creditTotal += amount;
        }

        entry.DebitTotal = Math.Round(debitTotal, 2);
        entry.CreditTotal = Math.Round(creditTotal, 2);
        entry.DifferenceAmount = entry.DebitTotal - entry.CreditTotal;

        if (entry.DifferenceAmount != 0)
            return $"La partida de ajuste no cuadra (debe {entry.DebitTotal:N2} / haber {entry.CreditTotal:N2}).";

        await unitOfWork.JournalEntries.UpdateAsync(entry, cancellationToken);
        return null;
    }
}
