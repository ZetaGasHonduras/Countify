using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Billing;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Invoices.Commands.CreateInvoice;

public class CreateInvoiceCommand : IRequest<Response<Guid>>
{
    public Guid CustomerId { get; set; }
    public int PaymentTerms { get; set; } = 2; // 1=Contado, 2=Crédito
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
    public List<InvoiceLineInput> Lines { get; set; } = [];

    public class InvoiceLineInput
    {
        public Guid? ProductId { get; set; }
        public string? Code { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Unit { get; set; }
        public decimal Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool IsTaxable { get; set; } = true;
        public decimal TaxRate { get; set; } = 15;
        public string? Notes { get; set; }
    }
}

public class CreateInvoiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateInvoiceCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        if (request.IsTaxExempt && request.IsExonerated)
            return Response<Guid>.Failure("Una factura no puede ser exenta y exonerada a la vez.");

        var customer = await unitOfWork.Customers.GetByIdAsync(request.CustomerId, cancellationToken);
        if (customer is null)
            return Response<Guid>.Failure($"El cliente {request.CustomerId} no existe.");
        if (customer.IsInactive)
            return Response<Guid>.Failure($"El cliente {customer.Name} está inactivo.");

        if (!await unitOfWork.Currencies.ExistsAsync(c => c.Id == request.CurrencyId, cancellationToken))
            return Response<Guid>.Failure($"La moneda {request.CurrencyId} no existe.");

        var invoice = mapper.Map<Invoice>(request);
        invoice.PaymentTerms = (InvoicePaymentTerms)request.PaymentTerms;
        if (invoice.ExchangeRate <= 0) invoice.ExchangeRate = 1;

        // Legacy: Vence = Fecha + Cliente.Dias cuando no se informa vencimiento.
        if (invoice.DueDate == default)
            invoice.DueDate = invoice.Date.Date.AddDays(customer.CreditDays);

        // Snapshot del cliente (histórico, como BaseFacturacion.OnChanged("Cliente")).
        invoice.CustomerName = customer.Name;
        invoice.CustomerTaxId = customer.TaxId;
        invoice.CustomerAddress = customer.Address;
        invoice.CustomerPhone = customer.Phone;

        var order = 1;
        foreach (var line in invoice.Lines)
            line.Order = order++;

        InvoiceTotals.Apply(invoice);

        // Correlativo interno para ordenar el listado (Number es un string fiscal).
        var maxCorrelativo = await unitOfWork.Invoices.Query()
            .Select(i => (int?)i.Correlativo).MaxAsync(cancellationToken);
        invoice.Correlativo = (maxCorrelativo ?? 0) + 1;

        var numberingError = await InvoiceNumberingFactory.AssignAsync(unitOfWork, invoice, cancellationToken);
        if (numberingError is not null)
            return Response<Guid>.Failure(numberingError);

        await unitOfWork.Invoices.AddAsync(invoice, cancellationToken);

        // Legacy CrearCXC: factura a Crédito crea su documento en cuentas por cobrar (sin partida;
        // el asiento de ventas se genera aparte, como en el viejo).
        if (invoice.PaymentTerms == InvoicePaymentTerms.Credito)
        {
            var linkError = await ReceivableLinkHelper.CreateForInvoiceAsync(unitOfWork, invoice, cancellationToken);
            if (linkError is not null)
                return Response<Guid>.Failure(linkError);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(invoice.Id, 201);
    }
}
