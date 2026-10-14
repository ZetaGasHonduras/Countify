using System.Globalization;
using Countify.Application.Features.Configurations.DTOs;
using Countify.Application.Features.JournalEntries.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Countify.Infrastructure.TemplateBuilder;

public static class JournalEntryPdfBuilder
{
    public static byte[] Build(JournalEntryDto entry, CompanySettingsDto? settings)
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
                var contact = string.Join(" | ", new[] { settings?.Phone, settings?.Mobile, settings?.Email }.Where(value => !string.IsNullOrWhiteSpace(value)));
                if (!string.IsNullOrWhiteSpace(contact))
                    column.Item().AlignCenter().Text(contact);
                column.Item().PaddingTop(8).AlignCenter().Text($"PARTIDA CONTABLE N° {entry.EntryNumber}")
                    .FontSize(16).Bold().FontColor(Colors.Blue.Darken2);
                column.Item().PaddingTop(4).AlignCenter().Text($"Tipo: {entry.TypeName}    Fecha: {entry.ReferenceDate:yyyy-MM-dd}");
                column.Item().AlignCenter().Text($"Estado: {StatusLabel(entry.Status.ToString())}    Origen: {SourceLabel(entry.SourceModule.ToString())}");
            });

            page.Content().PaddingTop(18).Column(column =>
            {
                column.Spacing(10);
                column.Item().Text($"Referencia: {entry.Reference}").SemiBold();
                column.Item().Text($"Concepto: {entry.Concept}");
                if (!string.IsNullOrWhiteSpace(entry.Observations))
                    column.Item().Text($"Observaciones: {entry.Observations}");

                column.Item().PaddingTop(8).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(65);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                        columns.ConstantColumn(85);
                        columns.ConstantColumn(85);
                    });

                    table.Header(header =>
                    {
                        HeaderCell(header.Cell(), "Cuenta");
                        HeaderCell(header.Cell(), "Nombre");
                        HeaderCell(header.Cell(), "Concepto");
                        HeaderCell(header.Cell(), "Débito");
                        HeaderCell(header.Cell(), "Crédito");
                    });

                    foreach (var line in entry.Lines)
                    {
                        BodyCell(table.Cell(), line.AccountCode);
                        BodyCell(table.Cell(), line.AccountName);
                        BodyCell(table.Cell(), line.Concept ?? "-");
                        BodyCell(table.Cell(), Money(line.Debit), true);
                        BodyCell(table.Cell(), Money(line.Credit), true);
                    }

                    BodyCell(table.Cell().ColumnSpan(3), "Totales", true);
                    BodyCell(table.Cell(), Money(entry.DebitTotal), true, true);
                    BodyCell(table.Cell(), Money(entry.CreditTotal), true, true);
                });
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

    private static void HeaderCell(IContainer container, string value)
        => container.Background(Colors.Blue.Darken2).Padding(5).Text(value).FontColor(Colors.White).Bold();

    private static void BodyCell(IContainer container, string? value, bool alignRight = false, bool bold = false)
    {
        var cell = container.BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5);
        if (alignRight && bold) cell.AlignRight().Text(value ?? "-").Bold();
        else if (alignRight) cell.AlignRight().Text(value ?? "-");
        else if (bold) cell.Text(value ?? "-").Bold();
        else cell.Text(value ?? "-");
    }

    private static string Money(decimal value) => value.ToString("N2", CultureInfo.InvariantCulture);

    private static string StatusLabel(string status) => status switch
    {
        "Draft" => "Borrador",
        "Approved" => "Aprobada",
        "Posted" => "Contabilizada",
        "Voided" => "Anulada",
        _ => status
    };

    private static string SourceLabel(string source) => source switch
    {
        "Manually" => "Manual",
        "Bank" => "Bancos",
        "Invoice" => "Facturación",
        "Receivable" => "Cuentas por cobrar",
        "Payable" => "Cuentas por pagar",
        _ => source
    };
}
