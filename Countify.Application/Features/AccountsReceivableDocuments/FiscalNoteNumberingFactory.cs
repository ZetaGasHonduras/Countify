using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;

namespace Countify.Application.Features.AccountsReceivableDocuments;

/// <summary>
/// Numeración de documentos por cobrar: correlativo de recibo y correlativo fiscal
/// (notas de crédito/débito) a partir del control fiscal activo.
/// </summary>
internal static class FiscalNoteNumberingFactory
{
    public static async Task<int> NextReceiptNumberAsync(IUnitOfWork unitOfWork, CancellationToken cancellationToken)
    {
        var last = await unitOfWork.AccountsReceivableDocuments.FirstOrDefaultAsync(
            unitOfWork.AccountsReceivableDocuments.Query()
                .Where(d => d.ReceiptNumber != null)
                .OrderByDescending(d => d.ReceiptNumber),
            cancellationToken);

        return (last?.ReceiptNumber ?? 0) + 1;
    }

    /// <summary>
    /// Asigna los datos fiscales (CAI, rango, correlativo) cuando el concepto es una nota fiscal.
    /// Devuelve <c>null</c> si todo está correcto, o el mensaje de error.
    /// </summary>
    public static async Task<string?> AssignAsync(
        IUnitOfWork unitOfWork,
        AccountsReceivableDocument document,
        AccountsReceivableConcept concept,
        CancellationToken cancellationToken)
    {
        if (!concept.IsFiscalNote || document.NoteNumber is not null)
            return null;

        var fiscalType = concept.Type == AccountsReceivableConceptType.Credit
            ? FiscalDocumentType.CreditNote
            : FiscalDocumentType.DebitNote;

        var control = await unitOfWork.FiscalControls.FirstOrDefaultAsync(
            unitOfWork.FiscalControls.Query()
                .Where(c => c.DocumentType == fiscalType && c.IsActive)
                .OrderByDescending(c => c.LastNumber),
            cancellationToken);

        if (control is null)
            return $"No existe un control fiscal activo para {fiscalType}.";

        if (control.EmissionLimitDate is not null && document.Date.Date > control.EmissionLimitDate.Value.Date)
            return $"El rango fiscal de {fiscalType} venció el {control.EmissionLimitDate:dd/MM/yyyy}.";

        var next = control.LastNumber + 1;

        var rangeEnd = ParseRangeEnd(control.RangeTo);
        if (rangeEnd is not null && next > rangeEnd)
            return $"El rango fiscal de {fiscalType} está agotado (hasta {control.RangeTo}). " +
                   "Por favor ingrese nuevos datos fiscales.";

        control.LastNumber = next;
        await unitOfWork.FiscalControls.UpdateAsync(control, cancellationToken);

        document.FiscalControlId = control.Id;
        document.CAI = control.CAI;
        document.RangeFrom = control.RangeFrom;
        document.RangeTo = control.RangeTo;
        document.EmissionDate = document.Date;
        document.EmissionLimitDate = control.EmissionLimitDate;
        document.NoteNumber = BuildNoteNumber(control, next);

        return null;
    }

    private static string BuildNoteNumber(FiscalControl control, int number)
    {
        var branch = string.IsNullOrWhiteSpace(control.Branch) ? "000" : control.Branch!.Trim();
        var point = string.IsNullOrWhiteSpace(control.EmissionPoint) ? "000" : control.EmissionPoint!.Trim();
        var code = string.IsNullOrWhiteSpace(control.DocumentCode) ? "00" : control.DocumentCode!.Trim();
        return $"{branch}-{point}-{code}-{number:D8}";
    }

    /// <summary>
    /// Obtiene el correlativo final autorizado a partir de <c>RangeTo</c>
    /// (legacy tomaba los últimos 8 dígitos del rango).
    /// </summary>
    private static int? ParseRangeEnd(string? rangeTo)
    {
        if (string.IsNullOrWhiteSpace(rangeTo))
            return null;

        var digits = new string(rangeTo.Where(char.IsDigit).ToArray());
        if (digits.Length == 0)
            return null;

        var tail = digits.Length > 8 ? digits[^8..] : digits;
        return int.TryParse(tail, out var value) ? value : null;
    }
}
