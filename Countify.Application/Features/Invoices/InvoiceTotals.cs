using Countify.Domain.Entities.Billing;

namespace Countify.Application.Features.Invoices;

/// <summary>
/// Motor de totales de la factura. Replica <c>totalizar()</c> del legacy
/// (<c>BaseFacturacion</c>): por línea, base = Cantidad·Precio − Descuento y
/// Total = base + base·%ISV/100, redondeado a 2 decimales.
/// </summary>
internal static class InvoiceTotals
{
    public static void Apply(Invoice invoice)
    {
        decimal subTotal = 0, taxAmount = 0, discountTotal = 0, exemptTotal = 0, total = 0;

        foreach (var line in invoice.Lines)
        {
            var baseGross = Math.Round(line.Quantity * line.UnitPrice, 2, MidpointRounding.AwayFromZero);
            var discount = Math.Round(baseGross * line.DiscountPercent / 100m, 2, MidpointRounding.AwayFromZero);
            if (discount > baseGross) discount = baseGross;
            var net = baseGross - discount;

            // Exenta/exonerada a nivel documento o línea no gravada ⇒ ISV 0 sin modificar el % ingresado.
            var rate = invoice.IsTaxExempt || invoice.IsExonerated || !line.IsTaxable ? 0m : line.TaxRate;
            var tax = Math.Round(net * rate / 100m, 2, MidpointRounding.AwayFromZero);

            line.DiscountAmount = discount;
            line.LineTotal = Math.Round(net + tax, 2, MidpointRounding.AwayFromZero);

            subTotal += net;
            taxAmount += tax;
            discountTotal += discount;
            total += line.LineTotal;
            if (rate == 0m) exemptTotal += net;
        }

        invoice.SubTotal = Math.Round(subTotal, 2);
        invoice.TaxAmount = Math.Round(taxAmount, 2);
        invoice.DiscountTotal = Math.Round(discountTotal, 2);
        invoice.SubTotalExempt = Math.Round(exemptTotal, 2);
        invoice.Total = Math.Round(total, 2);
        invoice.TotalLocal = Math.Round(invoice.Total * invoice.ExchangeRate, 2, MidpointRounding.AwayFromZero);
    }
}
