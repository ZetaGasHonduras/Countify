using Countify.Api.Authorization.Policies;
using Countify.Application.Features.PayableDocuments.Commands.CreatePayableDocument;
using Countify.Application.Features.PayableDocuments.Commands.CreatePayableDocumentLines;
using Countify.Application.Features.PayableDocuments.Commands.DeletePayableDocumentAttachment;
using Countify.Application.Features.PayableDocuments.Commands.DeletePayableDocumentLine;
using Countify.Application.Features.PayableDocuments.Commands.UpdatePayableDocument;
using Countify.Application.Features.PayableDocuments.Commands.UpdatePayableDocumentLine;
using Countify.Application.Features.PayableDocuments.Commands.UploadPayableDocumentAttachment;
using Countify.Application.Features.PayableDocuments.Commands.VoidPayableDocument;
using Countify.Application.Features.PayableDocuments.Queries.GetPayableDocumentAttachment;
using Countify.Application.Features.PayableDocuments.Queries.GetPayableDocumentById;
using Countify.Application.Features.PayableDocuments.Queries.GetPayableDocuments;
using Countify.Application.Features.PayableDocuments.Queries.GetPendingPayableDocuments;
using Countify.Application.Features.PayableDocuments.Queries.GetSupplierMovements;
using Countify.Infrastructure.TemplateBuilder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/payable-documents")]
public class PayableDocumentsController : BaseController
{
    [HttpGet]
    [Authorize(PayableDocumentPolicies.CanViewPayableDocuments)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetPayableDocumentsQuery()));

    [HttpGet("{id:guid}")]
    [Authorize(PayableDocumentPolicies.CanViewPayableDocuments)]
    public async Task<IActionResult> GetById(Guid id)
        => HandleResult(await Mediator.Send(new GetPayableDocumentByIdQuery { Id = id }));

    [HttpGet("pending")]
    [Authorize(PayableDocumentPolicies.CanViewPayableDocuments)]
    public async Task<IActionResult> GetPending(Guid supplierId, [FromQuery] string? excludeDocumentIds)
        => HandleResult(await Mediator.Send(new GetPendingPayableDocumentsQuery
        {
            SupplierId = supplierId,
            ExcludeDocumentIds = ParseGuids(excludeDocumentIds)
        }));

    [HttpGet("movements")]
    [Authorize(PayableDocumentPolicies.CanViewPayableDocuments)]
    public async Task<IActionResult> GetSupplierMovements([FromQuery] GetSupplierMovementsQuery query)
        => HandleResult(await Mediator.Send(query));

    [HttpGet("movements/export")]
    [Authorize(PayableDocumentPolicies.CanViewPayableDocuments)]
    public async Task<IActionResult> ExportSupplierMovements([FromQuery] GetSupplierMovementsQuery query)
    {
        var result = await Mediator.Send(query);
        if (!result.IsSuccess || result.Data is null) return HandleResult(result);
        var dto = result.Data;

        var sb = new System.Text.StringBuilder();
        sb.AppendLine("Fecha,Documento,Proveedor,Concepto,Referencia,Tipo,Monto,Impuesto,Total,Debito,Credito,Saldo Aplicado,Saldo Pendiente,Saldo Acumulado,Dias Vencidos,Bucket");
        foreach (var m in dto.Movements)
        {
            var tipo = m.IsVoided ? "Anulado" : m.IsPayment ? "Pago" : "Compra";
            var bucketLabel = dto.Aging.Buckets.FirstOrDefault(b => b.Key == m.AgingBucket)?.Label ?? "";
            sb.AppendLine($"{m.Date:yyyy-MM-dd},{m.DocumentNo},\"{dto.SupplierName}\",\"{Escape(m.ConceptDescription)}\",\"{Escape(m.Reference)} \",{tipo},{Inv(m.Amount)},{Inv(m.Tax)},{Inv(m.Total)},{Inv(m.Debit)},{Inv(m.Credit)},{Inv(m.AppliedAmount)},{Inv(m.OutstandingAmount)},{Inv(m.RunningBalance)},{(m.IsVoided || m.IsPayment ? "" : m.DaysOverdue?.ToString() ?? "")},{(m.IsVoided || m.IsPayment ? "" : bucketLabel)}");
            foreach (var line in m.Applications)
            {
                sb.AppendLine(",,,,\"  Aplica a doc " + line.RelatedDocumentNo + " (" + Escape(line.RelatedConcept) + ")\",,,,,," + Inv(line.Amount) + ",,,,");
            }
        }
        sb.AppendLine();
        sb.AppendLine($",,\"{dto.SupplierName}\",Totales,,,,,,,");
        sb.AppendLine($"Compras: {Inv(dto.TotalCargos)},Pagos: {Inv(dto.TotalAbonos)},Saldo: {Inv(dto.Saldo)}");
        sb.AppendLine();
        sb.AppendLine($"Antiguedad de Saldos al {dto.Aging.AsOfDate:yyyy-MM-dd}");
        sb.AppendLine("Bucket,Monto");
        foreach (var b in dto.Aging.Buckets)
            sb.AppendLine($"{b.Label},{Inv(b.Amount)}");
        sb.AppendLine($"TOTAL PENDIENTE,{Inv(dto.Aging.TotalOutstanding)}");

        return File(System.Text.Encoding.UTF8.GetBytes(sb.ToString()), "text/csv",
            $"movimientos-{dto.SupplierCode}-{dto.FromDate:yyyyMMdd}-{dto.ToDate:yyyyMMdd}.csv");
    }

    [HttpGet("movements/export/pdf")]
    [Authorize(PayableDocumentPolicies.CanViewPayableDocuments)]
    public async Task<IActionResult> ExportSupplierMovementsPdf([FromQuery] GetSupplierMovementsQuery query)
    {
        var result = await Mediator.Send(query);
        if (!result.IsSuccess || result.Data is null) return HandleResult(result);
        var dto = result.Data;
        return File(SupplierMovementsPdfBuilder.Build(dto), "application/pdf",
            $"movimientos-{dto.SupplierCode}-{dto.FromDate:yyyyMMdd}-{dto.ToDate:yyyyMMdd}.pdf");
    }

    [HttpPost]
    [Authorize(PayableDocumentPolicies.CanCreatePayableDocuments)]
    public async Task<IActionResult> Create([FromBody] CreatePayableDocumentCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(PayableDocumentPolicies.CanEditPayableDocuments)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePayableDocumentCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpPost("{id:guid}/lines")]
    [Authorize(PayableDocumentPolicies.CanEditPayableDocuments)]
    public async Task<IActionResult> ApplyDocuments(Guid id, [FromBody] CreatePayableDocumentLinesCommand command)
    {
        if (id != command.DocumentId)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpPut("lines/{id:guid}")]
    [Authorize(PayableDocumentPolicies.CanEditPayableDocuments)]
    public async Task<IActionResult> UpdateLine(Guid id, [FromBody] UpdatePayableDocumentLineCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("lines/{id:guid}")]
    [Authorize(PayableDocumentPolicies.CanEditPayableDocuments)]
    public async Task<IActionResult> DeleteLine(Guid id)
        => HandleResult(await Mediator.Send(new DeletePayableDocumentLineCommand { Id = id }));

    [HttpPost("{id:guid}/void")]
    [Authorize(PayableDocumentPolicies.CanVoidPayableDocuments)]
    public async Task<IActionResult> Void(Guid id)
        => HandleResult(await Mediator.Send(new VoidPayableDocumentCommand { Id = id }));

    [HttpPost("{id:guid}/attachments")]
    [Authorize(PayableDocumentPolicies.CanManagePayableAttachments)]
    public async Task<IActionResult> UploadAttachment(Guid id, IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest(new { error = "No se recibió ningún archivo." });

        await using var stream = file.OpenReadStream();
        var command = new UploadPayableDocumentAttachmentCommand
        {
            DocumentId = id,
            FileName = file.FileName,
            ContentType = file.ContentType,
            Size = file.Length,
            Content = stream,
            UploadedBy = User.Identity?.Name
        };

        return HandleResult(await Mediator.Send(command));
    }

    [HttpGet("attachments/{attachmentId:guid}/download")]
    [Authorize(PayableDocumentPolicies.CanViewPayableDocuments)]
    public async Task<IActionResult> DownloadAttachment(Guid attachmentId)
    {
        var result = await Mediator.Send(new GetPayableDocumentAttachmentQuery { Id = attachmentId });
        if (!result.IsSuccess || result.Data is null)
            return HandleResult(result);

        var dto = result.Data;
        return File(dto.Content, dto.ContentType ?? "application/octet-stream", dto.FileName);
    }

    [HttpDelete("attachments/{attachmentId:guid}")]
    [Authorize(PayableDocumentPolicies.CanManagePayableAttachments)]
    public async Task<IActionResult> DeleteAttachment(Guid attachmentId)
        => HandleResult(await Mediator.Send(new DeletePayableDocumentAttachmentCommand { Id = attachmentId }));

    private static List<Guid> ParseGuids(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return [];

        return value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(v => Guid.TryParse(v, out var id) ? id : Guid.Empty)
            .Where(id => id != Guid.Empty)
            .ToList();
    }

    private static string Inv(decimal value)
        => value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

    private static string Escape(string? value)
        => (value ?? string.Empty).Replace("\"", "\"\"").Replace("\r", " ").Replace("\n", " ");
}
