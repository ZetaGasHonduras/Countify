using System.Globalization;
using Countify.Application.Features.Configurations.DTOs;
using Countify.Application.Features.Invoices.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


namespace Countify.Infrastructure.TemplateBuilder;

public static class InvoicePdfBuilder
{
    public static byte[] Build(InvoiceDto invoice, CompanySettingsDto? settings)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        return Document.Create(document => document.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(36);
            page.DefaultTextStyle(style => style.FontSize(9));

            page.Header().Column(column =>
            {
                if (settings is not null && !string.IsNullOrWhiteSpace(settings.CompanyName))
                    column.Item().AlignCenter().Text(settings.CompanyName).FontSize(15).Bold();
                if (settings is not null && !string.IsNullOrWhiteSpace(settings.TaxId))
                    column.Item().AlignCenter().Text($"RTN: {settings.TaxId}");
                if (settings is not null && !string.IsNullOrWhiteSpace(settings.Address))
                    column.Item().AlignCenter().Text(settings.Address);
                var contact = string.Join(" | ", new[] { settings?.Phone, settings?.Mobile, settings?.Email }
                    .Where(value => !string.IsNullOrWhiteSpace(value)));
                if (!string.IsNullOrWhiteSpace(contact))
                    column.Item().AlignCenter().Text(contact);

                column.Item().PaddingTop(8).AlignCenter()
                    .Text($"FACTURA COMERCIAL N° {invoice.Number}").FontSize(16).Bold().FontColor(Colors.Blue.Darken2);
                column.Item().PaddingTop(2).AlignCenter()
                    .Text($"Fecha: {invoice.Date:yyyy-MM-dd}    Vence: {invoice.DueDate:yyyy-MM-dd}    " +
                          $"{(invoice.PaymentTerms == 2 ? "Crédito" : "Contado")}");
                if (invoice.IsVoided)
                    column.Item().PaddingTop(4).AlignCenter().Text("ANULADA")
                        .FontSize(20).Bold().FontColor(Colors.Red.Darken2);
            });

            page.Content().PaddingTop(14).Column(column =>
            {
                column.Spacing(8);

                column.Item().Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Cliente").Bold();
                        c.Item().Text(invoice.CustomerName);
                        if (!string.IsNullOrWhiteSpace(invoice.CustomerTaxId))
                            c.Item().Text($"RTN: {invoice.CustomerTaxId}");
                        if (!string.IsNullOrWhiteSpace(invoice.CustomerAddress))
                            c.Item().Text(invoice.CustomerAddress);
                        if (!string.IsNullOrWhiteSpace(invoice.CustomerPhone))
                            c.Item().Text(invoice.CustomerPhone);
                    });
                    row.RelativeItem().Column(c =>
                    {
                        if (!string.IsNullOrWhiteSpace(invoice.Reference))
                        {
                            c.Item().Text("Referencia").Bold();
                            c.Item().Text(invoice.Reference);
                        }
                        if (!string.IsNullOrWhiteSpace(invoice.OrderNumber))
                        {
                            c.Item().Text("Orden de compra").Bold();
                            c.Item().Text(invoice.OrderNumber);
                        }
                        c.Item().Text($"Moneda: {invoice.CurrencyCode}    Factor: {Num(invoice.ExchangeRate)}");
                        if (!string.IsNullOrWhiteSpace(invoice.CAI))
                            c.Item().Text($"CAI: {invoice.CAI}");
                    });
                });

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(1);   // código
                        columns.RelativeColumn(3);   // descripción
                        columns.ConstantColumn(45);  // cantidad
                        columns.ConstantColumn(40);  // unidad
                        columns.ConstantColumn(65);  // precio
                        columns.ConstantColumn(45);  // %desc
                        columns.ConstantColumn(40);  // %isv
                        columns.ConstantColumn(70);  // total
                    });

                    table.Header(header =>
                    {
                        HeaderCell(header.Cell(), "Código");
                        HeaderCell(header.Cell(), "Descripción");
                        HeaderCell(header.Cell(), "Cant.");
                        HeaderCell(header.Cell(), "Unid.");
                        HeaderCell(header.Cell(), "Precio");
                        HeaderCell(header.Cell(), "%Desc");
                        HeaderCell(header.Cell(), "%ISV");
                        HeaderCell(header.Cell(), "Total");
                    });

                    foreach (var line in invoice.Lines)
                    {
                        var rate = line.IsTaxable ? line.TaxRate : 0m;
                        BodyCell(table.Cell(), line.Code ?? "-");
                        BodyCell(table.Cell(), line.Description);
                        BodyCell(table.Cell(), Num(line.Quantity), true);
                        BodyCell(table.Cell(), line.Unit ?? "-");
                        BodyCell(table.Cell(), Num(line.UnitPrice), true);
                        BodyCell(table.Cell(), Num(line.DiscountPercent), true);
                        BodyCell(table.Cell(), Num(rate), true);
                        BodyCell(table.Cell(), Num(line.LineTotal), true);
                    }
                });

                column.Item().AlignRight().Width(240).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });
                    TotalRow(table, "Subtotal", invoice.SubTotal);
                    if (invoice.DiscountTotal > 0)
                        TotalRow(table, "Descuento", -invoice.DiscountTotal);
                    if (invoice.SubTotalExempt > 0 && invoice.TaxAmount == 0)
                        TotalRow(table, "Exento", invoice.SubTotalExempt);
                    TotalRow(table, "ISV", invoice.TaxAmount);
                    table.Cell().BorderTop(1).Padding(4).Text("TOTAL").Bold();
                    table.Cell().BorderTop(1).Padding(4).AlignRight().Text(Money(invoice.Total)).Bold();
                    if (invoice.CurrencyCode != "L" && invoice.CurrencyCode != "LEMPRAS")
                        table.Cell().Padding(4).AlignRight().Text($"Total {invoice.CurrencyCode}: {Money(invoice.TotalLocal)}");
                });

                if (!string.IsNullOrWhiteSpace(invoice.Notes))
                    column.Item().Text($"Observaciones: {invoice.Notes}");
                if (invoice.IsVoided && !string.IsNullOrWhiteSpace(invoice.VoidReason))
                    column.Item().Text($"Motivo de anulación: {invoice.VoidReason}");
                if (!invoice.IsPrinted)
                    column.Item().PaddingTop(6).Text(t => t.Span("Documento en borrador — no válido para efectos fiscales hasta su impresión.").FontColor(Colors.Grey.Darken1));
            });

            page.Footer().AlignCenter().Text(text =>
            {
                text.Span("Pagina ");
                text.CurrentPageNumber();
                text.Span(" de ");
                text.TotalPages();
            });
        })).GeneratePdf();
    }

    private static void TotalRow(TableDescriptor table, string label, decimal value)
    {
        table.Cell().Padding(4).Text(label);
        table.Cell().Padding(4).AlignRight().Text(Money(value));
    }

    private static void HeaderCell(IContainer container, string value)
        => container.Background(Colors.Blue.Darken2).Padding(5).Text(value).FontColor(Colors.White).Bold();

    private static void BodyCell(IContainer container, string value, bool alignRight = false)
    {
        var cell = container.BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5);
        if (alignRight) cell.AlignRight().Text(value);
        else cell.Text(value);
    }

    private static string Num(decimal value) => value.ToString("0.###", CultureInfo.InvariantCulture);

    private static string Money(decimal value) => value.ToString("N2", CultureInfo.InvariantCulture);
}
