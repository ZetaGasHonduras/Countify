using System.Globalization;
using Countify.Application.Features.AccountsReceivableDocuments.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Countify.Infrastructure.TemplateBuilder;

public static class CustomerMovementsPdfBuilder
{
    public static byte[] Build(CustomerMovementsDto dto)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        return Document.Create(document => document.Page(page =>
        {
            page.Size(PageSizes.A4.Landscape());
            page.Margin(36);
            page.DefaultTextStyle(style => style.FontSize(9));

            page.Header().Column(column =>
            {
                column.Item().Text("Movimientos del Cliente").FontSize(18).Bold().FontColor(Colors.Blue.Darken2);
                column.Item().PaddingTop(4).Text($"Cliente: {dto.CustomerCode} - {dto.CustomerName}");
                column.Item().Text($"Periodo: {dto.FromDate:yyyy-MM-dd} al {dto.ToDate:yyyy-MM-dd}");
            });

            page.Content().PaddingTop(18).Column(column =>
            {
                column.Spacing(12);
                column.Item().Row(row =>
                {
                    row.RelativeItem().Text($"Cargos\n{Money(dto.TotalCargos)}").SemiBold();
                    row.RelativeItem().Text($"Abonos\n{Money(dto.TotalAbonos)}").SemiBold();
                    row.RelativeItem().Text($"Saldo\n{Money(dto.Saldo)}").SemiBold();
                    row.RelativeItem().Text($"Movimientos: {dto.Movements.Count}");
                });

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(70);
                        columns.ConstantColumn(45);
                        columns.ConstantColumn(45);
                        columns.RelativeColumn(1.4f);
                        columns.RelativeColumn(1.2f);
                        columns.ConstantColumn(55);
                        columns.ConstantColumn(60);
                        columns.ConstantColumn(60);
                        columns.ConstantColumn(60);
                        columns.ConstantColumn(42);
                    });

                    table.Header(header =>
                    {
                        HeaderCell(header.Cell(), "Fecha");
                        HeaderCell(header.Cell(), "Doc");
                        HeaderCell(header.Cell(), "Recibo");
                        HeaderCell(header.Cell(), "Concepto");
                        HeaderCell(header.Cell(), "Referencia");
                        HeaderCell(header.Cell(), "Tipo");
                        HeaderCell(header.Cell(), "Débito");
                        HeaderCell(header.Cell(), "Crédito");
                        HeaderCell(header.Cell(), "Saldo Acum.");
                        HeaderCell(header.Cell(), "Días");
                    });

                    foreach (var movement in dto.Movements)
                    {
                        var tipo = movement.IsVoided ? "Anulado" : movement.IsCredit ? "Abono" : "Cargo";
                        BodyCell(table.Cell(), movement.Date.ToString("yyyy-MM-dd"));
                        BodyCell(table.Cell(), movement.DocumentNo.ToString());
                        BodyCell(table.Cell(), movement.ReceiptNumber?.ToString() ?? "-");
                        BodyCell(table.Cell(), movement.ConceptDescription ?? "-");
                        BodyCell(table.Cell(), movement.Reference ?? "-");
                        BodyCell(table.Cell(), tipo);
                        BodyCell(table.Cell(), Money(movement.Debit), true);
                        BodyCell(table.Cell(), Money(movement.Credit), true);
                        BodyCell(table.Cell(), Money(movement.RunningBalance), true);
                        BodyCell(table.Cell(), movement.IsVoided || movement.IsCredit ? "" : movement.DaysOverdue?.ToString() ?? "", true);

                        foreach (var line in movement.Applications)
                        {
                            BodyCell(table.Cell(), line.RelatedDate.ToString("yyyy-MM-dd"));
                            BodyCell(table.Cell(), $"-> {line.RelatedDocumentNo}");
                            BodyCell(table.Cell(), line.RelatedReceiptNumber?.ToString() ?? "-");
                            BodyCell(table.Cell(), line.RelatedConcept ?? "-");
                            BodyCell(table.Cell(), line.RelatedReference ?? "-");
                            BodyCell(table.Cell(), line.RelatedIsCredit ? "Abono" : "Cargo");
                            BodyCell(table.Cell(), "", true);
                            BodyCell(table.Cell(), "", true);
                            BodyCell(table.Cell(), "", true);
                            BodyCell(table.Cell(), "", true);
                        }
                    }
                });

                column.Item().PaddingTop(10).Text($"Antigüedad de Saldos al {dto.Aging.AsOfDate:yyyy-MM-dd}")
                    .Bold().FontSize(11).FontColor(Colors.Blue.Darken2);

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        foreach (var _ in dto.Aging.Buckets) columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    table.Header(header =>
                    {
                        foreach (var bucket in dto.Aging.Buckets)
                            HeaderCell(header.Cell(), bucket.Label);
                        HeaderCell(header.Cell(), "TOTAL");
                    });

                    foreach (var bucket in dto.Aging.Buckets)
                        BodyCell(table.Cell(), Money(bucket.Amount), true);
                    BodyCell(table.Cell(), Money(dto.Aging.TotalOutstanding), true);
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