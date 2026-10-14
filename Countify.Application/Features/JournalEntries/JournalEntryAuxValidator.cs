using Countify.Application.Features.JournalEntries.DTOs;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.JournalEntries;

internal static class JournalEntryAuxValidator
{
    public static async Task<string?> ValidateAsync(
        IUnitOfWork unitOfWork,
        IReadOnlyCollection<JournalEntryLineRequest> lines,
        IReadOnlyDictionary<Guid, Account> accounts,
        CancellationToken cancellationToken)
    {
        foreach (var line in lines)
        {
            if (!accounts.TryGetValue(line.AccountId, out var account)) continue;

            if (account.IsAuxCxc && !line.AppliesToReceivableId.HasValue && line.PendingDocument is null)
            {
                return $"La cuenta {account.Code} es auxiliar de CxC: aplique un documento de cuentas por cobrar antes de guardar.";
            }
        }

        var appliesIds = lines
            .Where(l => l.AppliesToReceivableId.HasValue)
            .Select(l => l.AppliesToReceivableId!.Value)
            .Distinct()
            .ToList();

        if (appliesIds.Count == 0) return null;

        var docs = await unitOfWork.AccountsReceivableDocuments.Query()
            .Where(d => appliesIds.Contains(d.Id))
            .ToListAsync(cancellationToken);

        foreach (var id in appliesIds)
        {
            var doc = docs.FirstOrDefault(d => d.Id == id);
            if (doc is null || doc.IsVoided)
            {
                return "Un documento de cuentas por cobrar vinculado no existe o está anulado.";
            }
        }

        return null;
    }
}