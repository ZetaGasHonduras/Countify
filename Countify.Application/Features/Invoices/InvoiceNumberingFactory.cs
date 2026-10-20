using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.Billing;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Invoices;

/// <summary>
/// Asigna el número fiscal de la factura desde el <see cref="Domain.Entities.Accounting.FiscalControl"/>
/// activo de tipo Invoicing (legacy: FacturaComercial.OnSaving con ControlesFiscales激活).
/// A diferencia del legacy, SÍ valida vencimiento del CAI y agotamiento del rango
/// (decisión del roadmap: "lo agregamos bien").
/// </summary>
internal static class InvoiceNumberingFactory
{
    public static async Task<string?> AssignAsync(
        IUnitOfWork unitOfWork, Invoice invoice, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(invoice.Number))
            return null;

        var control = await unitOfWork.FiscalControls.FirstOrDefaultAsync(
            unitOfWork.FiscalControls.Query()
                .Where(c => c.DocumentType == FiscalDocumentType.Invoicing && c.IsActive)
                .OrderByDescending(c => c.LastNumber),
            cancellationToken);

        if (control is null)
            return "No existe un control fiscal (CAI) activo para facturación.";

        if (control.EmissionLimitDate is not null && invoice.Date.Date > control.EmissionLimitDate.Value.Date)
            return $"El CAI de facturación venció el {control.EmissionLimitDate:dd/MM/yyyy}.";

        var next = control.NextNumber;

        var rangeEnd = ParseRangeEnd(control.RangeTo);
        if (rangeEnd is not null && next > rangeEnd)
            return $"El rango del CAI está agotado (hasta {control.RangeTo}). " +
                   "Registre un nuevo control fiscal antes de facturar.";

        control.LastNumber = next;
        await unitOfWork.FiscalControls.UpdateAsync(control, cancellationToken);

        invoice.FiscalControlId = control.Id;
        invoice.CAI = control.CAI;
        invoice.RangeFrom = control.RangeFrom;
        invoice.RangeTo = control.RangeTo;
        invoice.EmissionLimitDate = control.EmissionLimitDate;
        invoice.Number = BuildNumber(control, next);

        return null;
    }

    private static string BuildNumber(FiscalControl control, int number)
    {
        var branch = string.IsNullOrWhiteSpace(control.Branch) ? "000" : control.Branch!.Trim();
        var point = string.IsNullOrWhiteSpace(control.EmissionPoint) ? "000" : control.EmissionPoint!.Trim();
        var code = string.IsNullOrWhiteSpace(control.DocumentCode) ? "01" : control.DocumentCode!.Trim();
        return $"{branch}-{point}-{code}-{number:D8}";
    }

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
