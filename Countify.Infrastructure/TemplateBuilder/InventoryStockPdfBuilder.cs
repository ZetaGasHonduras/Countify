using System.Globalization;
using Countify.Application.Features.Configurations.DTOs;
using Countify.Application.Features.InventoryMovements.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Countify.Infrastructure.TemplateBuilder;

/// <summary>
/// Reporte de existencias por producto × ubicación (espejo moderno de la
/// consulta <c>VSTExistenciasUbicaciones</c> del legacy).
/// </summary>
public static class InventoryStockPdfBuilder
{
    public static byte[] Build(IReadOnlyList<InventoryStockDto> rows, string filterLabel, CompanySettingsDto? settings)
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

                column.Item().PaddingTop(8).AlignCenter()
                    .Text("EXISTENCIAS POR UBICACIÓN").FontSize(14).Bold().FontColor(Colors.Blue.Darken2);
                column.Item().PaddingTop(2).AlignCenter()
                    .Text($"{filterLabel}    Emitido: {DateTime.Now:yyyy-MM-dd HH:mm}");
            });

            page.Content().PaddingTop(14).Column(column =>
            {
                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(2);   // producto codigo
                        columns.RelativeColumn(4);   // producto nombre
                        columns.RelativeColumn(3);   // almacen
                        columns.RelativeColumn(2);   // ubicacion
                        columns.RelativeColumn(2);   // entradas
                        columns.RelativeColumn(2);   // salidas
                        columns.RelativeColumn(2);   // existencia
                    });

                    table.Header(header =>
                    {
                        HeadCell(header.Cell(), "Código");
                        HeadCell(header.Cell(), "Producto");
                        HeadCell(header.Cell(), "Almacén");
                        HeadCell(header.Cell(), "Ubicación");
                        HeadCell(header.Cell(), "Entradas", true);
                        HeadCell(header.Cell(), "Salidas", true);
                        HeadCell(header.Cell(), "Existencia", true);
                    });

                    foreach (var row in rows)
                    {
                        BodyCell(table.Cell(), row.ProductCode);
                        BodyCell(table.Cell(), row.ProductName);
                        BodyCell(table.Cell(), row.WarehouseName);
                        BodyCell(table.Cell(), $"{row.LocationCode} — {row.LocationName}");
                        BodyCell(table.Cell(), Num(row.Inbound), true);
                        BodyCell(table.Cell(), Num(row.Outbound), true);
                        BodyCell(table.Cell(), Num(row.OnHand), true);
                    }
                });

                if (rows.Count == 0)
                    column.Item().PaddingTop(10).AlignCenter().Text("Sin existencias registradas para el filtro.")
                        .FontColor(Colors.Grey.Darken1);
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

    private static void HeadCell(IContainer container, string value, bool alignRight = false)
    {
        var cell = container.Background(Colors.Blue.Darken2).Padding(5);
        if (alignRight) cell.AlignRight().Text(value).FontColor(Colors.White).Bold();
        else cell.Text(value).FontColor(Colors.White).Bold();
    }

    private static void BodyCell(IContainer container, string value, bool alignRight = false)
    {
        var cell = container.BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(5);
        if (alignRight) cell.AlignRight().Text(value);
        else cell.Text(value);
    }

    private static string Num(decimal value) => value.ToString("N3", CultureInfo.InvariantCulture);
}
