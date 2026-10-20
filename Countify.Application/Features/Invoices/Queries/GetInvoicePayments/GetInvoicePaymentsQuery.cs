using AutoMapper;
using Countify.Application.Features.Invoices.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Invoices.Queries.GetInvoicePayments;

public class GetInvoicePaymentsQuery : IRequest<Response<List<InvoicePaymentDto>>>
{
    public Guid InvoiceId { get; set; }
}

public class GetInvoicePaymentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetInvoicePaymentsQuery, Response<List<InvoicePaymentDto>>>
{
    public async Task<Response<List<InvoicePaymentDto>>> Handle(
        GetInvoicePaymentsQuery request, CancellationToken cancellationToken)
    {
        var payments = await unitOfWork.InvoicePayments.ToListAsync(
            unitOfWork.InvoicePayments.Query()
                .Include(p => p.PaymentMethod)
                .Where(p => p.InvoiceId == request.InvoiceId)
                .OrderBy(p => p.PaymentMethod!.Name),
            cancellationToken);

        return Response<List<InvoicePaymentDto>>.Success(mapper.Map<List<InvoicePaymentDto>>(payments));
    }
}
