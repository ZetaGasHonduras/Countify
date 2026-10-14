using Countify.Api.Authorization.Policies;
using Countify.Application.Features.AccountsReceivableDocuments.Commands.CreateAccountsReceivableDocument;
using Countify.Application.Features.AccountsReceivableDocuments.Commands.CreateAccountsReceivableDocumentLines;
using Countify.Application.Features.AccountsReceivableDocuments.Commands.DeleteAccountsReceivableDocumentLine;
using Countify.Application.Features.AccountsReceivableDocuments.Commands.UpdateAccountsReceivableDocument;
using Countify.Application.Features.AccountsReceivableDocuments.Commands.UpdateAccountsReceivableDocumentLine;
using Countify.Application.Features.AccountsReceivableDocuments.Commands.VoidAccountsReceivableDocument;
using Countify.Application.Features.AccountsReceivableDocuments.Queries.GetAccountsReceivableDocumentById;
using Countify.Application.Features.AccountsReceivableDocuments.Queries.GetAccountsReceivableDocuments;
using Countify.Application.Features.AccountsReceivableDocuments.Queries.GetCustomerMovements;
using Countify.Application.Features.AccountsReceivableDocuments.Queries.GetPendingAccountsReceivableDocuments;
using Countify.Infrastructure.TemplateBuilder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/accounts-receivable-documents")]
public class AccountsReceivableDocumentsController : BaseController
{
    [HttpGet]
    [Authorize(AccountsReceivableDocumentPolicies.CanViewAccountsReceivableDocuments)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetAccountsReceivableDocumentsQuery()));

    [HttpGet("{id:guid}")]
    [Authorize(AccountsReceivableDocumentPolicies.CanViewAccountsReceivableDocuments)]
    public async Task<IActionResult> GetById(Guid id)
        => HandleResult(await Mediator.Send(new GetAccountsReceivableDocumentByIdQuery { Id = id }));

    [HttpGet("pending")]
    [Authorize(AccountsReceivableDocumentPolicies.CanViewAccountsReceivableDocuments)]
    public async Task<IActionResult> GetPending(Guid customerId, [FromQuery] string? excludeDocumentIds)
        => HandleResult(await Mediator.Send(new GetPendingAccountsReceivableDocumentsQuery
        {
            CustomerId = customerId,
            ExcludeDocumentIds = ParseGuids(excludeDocumentIds)
        }));

    [HttpGet("movements")]
    [Authorize(AccountsReceivableDocumentPolicies.CanViewAccountsReceivableDocuments)]
    public async Task<IActionResult> GetCustomerMovements([FromQuery] GetCustomerMovementsQuery query)
        => HandleResult(await Mediator.Send(query));

    [HttpGet("movements/export")]
    [Authorize(AccountsReceivableDocumentPolicies.CanViewAccountsReceivableDocuments)]
    public async Task<IActionResult> ExportCustomerMovements([FromQuery] GetCustomerMovementsQuery query)
    {
        var result = await Mediator.Send(query);
        if (!result.IsSuccess || result.Data is null) return HandleResult(result);
        var dto = result.Data;

        var sb = new System.Text.StringBuilder();
        sb.AppendLine("Fecha,Documento,Recibo,Cliente,Concepto,Referencia,Tipo,Debito,Credito,Saldo,Saldo Acumulado");
        foreach (var m in dto.Movements)
        {
            var tipo = m.IsVoided ? "Anulado" : m.IsCredit ? "Abono" : "Cargo";
            sb.AppendLine($"{m.Date:yyyy-MM-dd},{m.DocumentNo},{(m.ReceiptNumber?.ToString() ?? "")},\"{dto.CustomerName}\",\"{Escape(m.ConceptDescription)}\",\"{Escape(m.Reference)} \",{tipo},{m.Debit.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)},{m.Credit.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)},{m.OutstandingAmount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)},{m.RunningBalance.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}");
            foreach (var line in m.Applications)
            {
                sb.AppendLine(",,,,,,\"  Aplica a doc " + line.RelatedDocumentNo + " (" + Escape(line.RelatedConcept) + ")\",,");
            }
        }
        sb.AppendLine();
        sb.AppendLine($",,,\"{dto.CustomerName}\",Totales,,,,,");
        sb.AppendLine($"Cargos: {dto.TotalCargos.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)},Abonos: {dto.TotalAbonos.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)},Saldo: {dto.Saldo.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}");

        return File(System.Text.Encoding.UTF8.GetBytes(sb.ToString()), "text/csv",
            $"movimientos-{dto.CustomerCode}-{dto.FromDate:yyyyMMdd}-{dto.ToDate:yyyyMMdd}.csv");
    }

    [HttpGet("movements/export/pdf")]
    [Authorize(AccountsReceivableDocumentPolicies.CanViewAccountsReceivableDocuments)]
    public async Task<IActionResult> ExportCustomerMovementsPdf([FromQuery] GetCustomerMovementsQuery query)
    {
        var result = await Mediator.Send(query);
        if (!result.IsSuccess || result.Data is null) return HandleResult(result);
        var dto = result.Data;
        return File(CustomerMovementsPdfBuilder.Build(dto), "application/pdf",
            $"movimientos-{dto.CustomerCode}-{dto.FromDate:yyyyMMdd}-{dto.ToDate:yyyyMMdd}.pdf");
    }

    [HttpPost]
    [Authorize(AccountsReceivableDocumentPolicies.CanCreateAccountsReceivableDocuments)]
    public async Task<IActionResult> Create([FromBody] CreateAccountsReceivableDocumentCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(AccountsReceivableDocumentPolicies.CanEditAccountsReceivableDocuments)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAccountsReceivableDocumentCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpPost("{id:guid}/lines")]
    [Authorize(AccountsReceivableDocumentPolicies.CanEditAccountsReceivableDocuments)]
    public async Task<IActionResult> ApplyDocuments(Guid id, [FromBody] CreateAccountsReceivableDocumentLinesCommand command)
    {
        if (id != command.DocumentId)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpPut("lines/{id:guid}")]
    [Authorize(AccountsReceivableDocumentPolicies.CanEditAccountsReceivableDocuments)]
    public async Task<IActionResult> UpdateLine(Guid id, [FromBody] UpdateAccountsReceivableDocumentLineCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("lines/{id:guid}")]
    [Authorize(AccountsReceivableDocumentPolicies.CanEditAccountsReceivableDocuments)]
    public async Task<IActionResult> DeleteLine(Guid id)
        => HandleResult(await Mediator.Send(new DeleteAccountsReceivableDocumentLineCommand { Id = id }));

    [HttpPost("{id:guid}/void")]
    [Authorize(AccountsReceivableDocumentPolicies.CanVoidAccountsReceivableDocuments)]
    public async Task<IActionResult> Void(Guid id)
        => HandleResult(await Mediator.Send(new VoidAccountsReceivableDocumentCommand { Id = id }));

    private static List<Guid> ParseGuids(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return [];

        return value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(v => Guid.TryParse(v, out var id) ? id : Guid.Empty)
            .Where(id => id != Guid.Empty)
            .ToList();
    }

    private static string Escape(string? value)
        => (value ?? string.Empty).Replace("\"", "\"\"").Replace("\r", " ").Replace("\n", " ");
}