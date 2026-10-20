using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Configurations.Queries.GetCompanySettings;
using Countify.Application.Features.Invoices.Commands.CreateInvoice;
using Countify.Application.Features.Invoices.Commands.MarkInvoicePrinted;
using Countify.Application.Features.Invoices.Commands.SetInvoicePayments;
using Countify.Application.Features.Invoices.Commands.UpdateInvoice;
using Countify.Application.Features.Invoices.Commands.VoidInvoice;
using Countify.Application.Features.Invoices.Queries.GetInvoiceById;
using Countify.Application.Features.Invoices.Queries.GetInvoicePayments;
using Countify.Application.Features.Invoices.Queries.GetInvoices;
using Countify.Infrastructure.TemplateBuilder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;

[Authorize]
[Route("api/invoices")]
public class InvoicesController : BaseController
{
    [HttpGet]
    [Authorize(InvoicePolicies.CanViewInvoices)]
    public async Task<IActionResult> GetAll()
        => HandleResult(await Mediator.Send(new GetInvoicesQuery()));

    [HttpGet("{id:guid}")]
    [Authorize(InvoicePolicies.CanViewInvoices)]
    public async Task<IActionResult> GetById(Guid id)
        => HandleResult(await Mediator.Send(new GetInvoiceByIdQuery { Id = id }));

    [HttpPost]
    [Authorize(InvoicePolicies.CanCreateInvoices)]
    public async Task<IActionResult> Create([FromBody] CreateInvoiceCommand command)
        => HandleResult(await Mediator.Send(command));

    [HttpPut("{id:guid}")]
    [Authorize(InvoicePolicies.CanEditInvoices)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateInvoiceCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpPost("{id:guid}/void")]
    [Authorize(InvoicePolicies.CanVoidInvoices)]
    public async Task<IActionResult> Void(Guid id, [FromBody] VoidInvoiceCommand command)
    {
        if (id != command.Id)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    /// <summary>Legacy "Guardar e Imprimir": marca impresa (congela) la factura.</summary>
    [HttpPost("{id:guid}/print")]
    [Authorize(InvoicePolicies.CanEditInvoices)]
    public async Task<IActionResult> MarkPrinted(Guid id)
        => HandleResult(await Mediator.Send(new MarkInvoicePrintedCommand { Id = id }));

    /// <summary>Pagos registrados de la factura (legacy FacturaPagos).</summary>
    [HttpGet("{id:guid}/payments")]
    [Authorize(InvoicePolicies.CanViewInvoices)]
    public async Task<IActionResult> GetPayments(Guid id)
        => HandleResult(await Mediator.Send(new GetInvoicePaymentsQuery { InvoiceId = id }));

    /// <summary>Legacy "Totalizar" (F7): reemplaza los pagos; Σ pagos debe cuadrar exacto con el Total.</summary>
    [HttpPut("{id:guid}/payments")]
    [Authorize(InvoicePolicies.CanManageInvoicePayments)]
    public async Task<IActionResult> SetPayments(Guid id, [FromBody] SetInvoicePaymentsCommand command)
    {
        if (id != command.InvoiceId)
            return BadRequest(new { error = "El Id de la ruta no coincide con el del body." });

        return HandleResult(await Mediator.Send(command));
    }

    [HttpGet("{id:guid}/export/pdf")]
    [Authorize(InvoicePolicies.CanViewInvoices)]
    public async Task<IActionResult> ExportPdf(Guid id)
    {
        var result = await Mediator.Send(new GetInvoiceByIdQuery { Id = id });
        if (!result.IsSuccess || result.Data is null) return HandleResult(result);

        var invoice = result.Data;
        var settings = await Mediator.Send(new GetCompanySettingsQuery());
        return File(InvoicePdfBuilder.Build(invoice, settings.Data), "application/pdf",
            $"factura-{invoice.Number ?? invoice.Id.ToString("N")}.pdf");
    }
}
