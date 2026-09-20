using System.Globalization;
using Countify.Application.Features.Banks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Countify.Api.Controllers;

internal static class BankStatementPdfBuilder
{
    public static byte[] Build(BankStatementDto statement)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        return Document.Create(document => document.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(36);
            page.DefaultTextStyle(style => style.FontSize(9));

            page.Header().Column(column =>
            {
                column.Item().Text("Estado de Cuenta Bancario").FontSize(18).Bold().FontColor(Colors.Blue.Darken2);
                column.Item().PaddingTop(4).Text($"Banco: {statement.BankAccountName}");
                column.Item().Text($"Periodo: {statement.FromDate:yyyy-MM-dd} al {statement.ToDate:yyyy-MM-dd}");
            });

            page.Content().PaddingTop(18).Column(column =>
            {
                column.Spacing(12);
                column.Item().Row(row =>
                {
                    row.RelativeItem().Text($"Saldo inicial\n{Money(statement.OpeningBalance)}").SemiBold();
                    row.RelativeItem().Text($"Debitos\n{Money(statement.DebitTotal)}").SemiBold();
                    row.RelativeItem().Text($"Creditos\n{Money(statement.CreditTotal)}").SemiBold();
                    row.RelativeItem().Text($"Saldo final\n{Money(statement.ClosingBalance)}").SemiBold();
                });

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(72);
                        columns.RelativeColumn(1.2f);
                        columns.RelativeColumn(2.2f);
                        columns.ConstantColumn(75);
                        columns.ConstantColumn(70);
                    });

                    table.Header(header =>
                    {
                        HeaderCell(header.Cell(), "Fecha");
                        HeaderCell(header.Cell(), "Referencia");
                        HeaderCell(header.Cell(), "Concepto");
                        HeaderCell(header.Cell(), "Monto");
                        HeaderCell(header.Cell(), "Estado");
                    });

                    foreach (var transaction in statement.Transactions)
                    {
                        BodyCell(table.Cell(), transaction.Date.ToString("yyyy-MM-dd"));
                        BodyCell(table.Cell(), transaction.Reference ?? "-");
                        BodyCell(table.Cell(), transaction.Concept ?? "-");
                        BodyCell(table.Cell(), Money(transaction.LocalAmount), true);
                        BodyCell(table.Cell(), transaction.Reconciled ? "Conciliado" : "Pendiente");
                    }
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

    private static void BodyCell(IContainer container, string value, bool alignRight = false)
    {
        var cell = container.BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5);
        if (alignRight) cell.AlignRight().Text(value);
        else cell.Text(value);
    }

    private static string Money(decimal value) => value.ToString("N2", CultureInfo.InvariantCulture);
}
