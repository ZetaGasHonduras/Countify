using AutoMapper;
using Countify.Application.Features.Invoices.Commands.CreateInvoice;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Billing;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Invoices.Commands.UpdateInvoice;

public class UpdateInvoiceCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }

    /// <summary>1 = Contado, 2 = Crédito.</summary>
    public int PaymentTerms { get; set; } = 2;

    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public string? Reference { get; set; }
    public string? OrderNumber { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? ProjectId { get; set; }
    public Guid CurrencyId { get; set; }
    public decimal ExchangeRate { get; set; } = 1;
    public bool IsTaxExempt { get; set; }
    public bool IsExonerated { get; set; }
    public string? Notes { get; set; }
    public List<CreateInvoiceCommand.InvoiceLineInput> Lines { get; set; } = [];
}

public class UpdateInvoiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateInvoiceCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await unitOfWork.Invoices.Query()
            .Include(i => i.Lines)
            .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

        if (invoice is null)
            return Response<bool>.NotFound($"Factura {request.Id} no encontrada.");

        if (invoice.IsVoided)
            return Response<bool>.Failure("La factura está anulada y no puede modificarse.");

        if (invoice.IsPrinted)
            return Response<bool>.Failure("La factura fue guardada e impresa y está congelada; no puede modificarse.");

        if (request.IsTaxExempt && request.IsExonerated)
            return Response<bool>.Failure("Una factura no puede ser exenta y exonerada a la vez.");

        var customer = await unitOfWork.Customers.GetByIdAsync(request.CustomerId, cancellationToken);
        if (customer is null)
            return Response<bool>.Failure($"El cliente {request.CustomerId} no existe.");

        if (customer.IsInactive && invoice.CustomerId != customer.Id)
            return Response<bool>.Failure($"El cliente {customer.Name} está inactivo.");

        if (!await unitOfWork.Currencies.ExistsAsync(c => c.Id == request.CurrencyId, cancellationToken))
            return Response<bool>.Failure($"La moneda {request.CurrencyId} no existe.");

        var newLines = mapper.Map<List<InvoiceLine>>(request.Lines);
        var order = 1;
        foreach (var line in newLines)
            line.Order = order++;

        mapper.Map(request, invoice);
        invoice.PaymentTerms = (InvoicePaymentTerms)request.PaymentTerms;
        if (invoice.ExchangeRate <= 0) invoice.ExchangeRate = 1;
        if (invoice.DueDate == default)
            invoice.DueDate = invoice.Date.Date.AddDays(customer.CreditDays);

        // Re-snapshot del cliente si cambió.
        invoice.CustomerName = customer.Name;
        invoice.CustomerTaxId = customer.TaxId;
        invoice.CustomerAddress = customer.Address;
        invoice.CustomerPhone = customer.Phone;

        // Reemplazo de líneas.
        foreach (var oldLine in invoice.Lines.ToList())
            await unitOfWork.InvoiceLines.DeleteAsync(oldLine, cancellationToken);
        invoice.Lines = newLines;

        InvoiceTotals.Apply(invoice);

        // Sincronizar el documento de cuentas por cobrar según el término de pago.
        if (invoice.PaymentTerms == InvoicePaymentTerms.Credito)
        {
            var linkError = await ReceivableLinkHelper.SyncWithInvoiceAsync(unitOfWork, invoice, cancellationToken);
            if (linkError is not null)
                return Response<bool>.Failure(linkError);
        }
        else
        {
            var unlinkError = await ReceivableLinkHelper.RemoveForInvoiceAsync(unitOfWork, invoice, cancellationToken);
            if (unlinkError is not null)
                return Response<bool>.Failure(unlinkError);
        }

        await unitOfWork.Invoices.UpdateAsync(invoice, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
