using AutoMapper;
using Countify.Application.Features.Invoices.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Invoices.Queries.GetInvoices;

public class GetInvoicesQuery : IRequest<Response<List<InvoiceDto>>>;

public class GetInvoicesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetInvoicesQuery, Response<List<InvoiceDto>>>
{
    public async Task<Response<List<InvoiceDto>>> Handle(
        GetInvoicesQuery request, CancellationToken cancellationToken)
    {
        var invoices = await unitOfWork.Invoices.ToListAsync(
            unitOfWork.Invoices.Query()
                .Include(i => i.Customer)
                .Include(i => i.Currency)
                .OrderByDescending(i => i.Correlativo),
            cancellationToken);

        return Response<List<InvoiceDto>>.Success(mapper.Map<List<InvoiceDto>>(invoices));
    }
}
