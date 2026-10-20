using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Billing;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Invoices.Commands.SetInvoicePayments;

/// <summary>
/// "Totalizar" de la factura (legacy F7): reemplaza el conjunto de pagos y
/// exige la regla <c>"Debe Cuadrar"</c> — la suma debe ser exactamente el Total.
/// </summary>
public class SetInvoicePaymentsCommand : IRequest<Response<bool>>
{
    public Guid InvoiceId { get; set; }
    public List<InvoicePaymentInput> Payments { get; set; } = [];

    public class InvoicePaymentInput
    {
        public Guid PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
    }
}

public class SetInvoicePaymentsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<SetInvoicePaymentsCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        SetInvoicePaymentsCommand request, CancellationToken cancellationToken)
    {
        var invoice = await unitOfWork.Invoices.GetByIdAsync(request.InvoiceId, cancellationToken);
        if (invoice is null)
            return Response<bool>.NotFound($"Factura {request.InvoiceId} no encontrada.");

        if (invoice.IsVoided)
            return Response<bool>.Failure("La factura está anulada y no admite pagos.");

        if (request.Payments.Count == 0)
            return Response<bool>.Failure("Agregue al menos un pago.");

        var methodIds = request.Payments.Select(p => p.PaymentMethodId).Distinct().ToList();
        var methods = await unitOfWork.PaymentMethods.Query()
            .Where(m => methodIds.Contains(m.Id))
            .ToListAsync(cancellationToken);

        foreach (var methodId in methodIds)
        {
            var method = methods.FirstOrDefault(m => m.Id == methodId);
            if (method is null)
                return Response<bool>.Failure($"El método de pago {methodId} no existe.");
            if (method.IsInactive)
                return Response<bool>.Failure($"El método de pago {method.Name} está inactivo.");
        }

        // Legacy "Debe Cuadrar": Σ pagos == Total exacto (en la moneda de la factura).
        var sum = Math.Round(request.Payments.Sum(p => p.Amount), 2, MidpointRounding.AwayFromZero);
        if (sum != invoice.Total)
        {
            var difference = Math.Round(invoice.Total - sum, 2, MidpointRounding.AwayFromZero);
            return Response<bool>.Failure(
                $"Los pagos deben cuadrar exactamente con el total de la factura. " +
                $"Total: {invoice.Total:N2}, pagado: {sum:N2}, diferencia: {difference:N2}.");
        }

        // Reemplazo del conjunto de pagos.
        var existing = await unitOfWork.InvoicePayments.Query()
            .Where(p => p.InvoiceId == invoice.Id)
            .ToListAsync(cancellationToken);
        foreach (var payment in existing)
            await unitOfWork.InvoicePayments.DeleteAsync(payment, cancellationToken);

        foreach (var input in request.Payments)
        {
            var payment = mapper.Map<InvoicePayment>(input);
            payment.InvoiceId = invoice.Id;
            await unitOfWork.InvoicePayments.AddAsync(payment, cancellationToken);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
