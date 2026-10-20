using AutoMapper;
using Countify.Application.Features.Invoices.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Invoices.Queries.GetInvoiceById;

public class GetInvoiceByIdQuery : IRequest<Response<InvoiceDto>>
{
    public Guid Id { get; set; }
}

public class GetInvoiceByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetInvoiceByIdQuery, Response<InvoiceDto>>
{
    public async Task<Response<InvoiceDto>> Handle(
        GetInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        var invoice = await unitOfWork.Invoices.FirstOrDefaultAsync(
            unitOfWork.Invoices.Query()
                .Include(i => i.Customer)
                .Include(i => i.Currency)
                .Include(i => i.Department)
                .Include(i => i.Project)
                .Include(i => i.FiscalControl)
                .Include(i => i.ReceivableDocument)
                .Include(i => i.Lines).ThenInclude(l => l.Product)
                .Where(i => i.Id == request.Id),
            cancellationToken);

        if (invoice is null)
            return Response<InvoiceDto>.NotFound($"Factura {request.Id} no encontrada.");

        var dto = mapper.Map<InvoiceDto>(invoice);
        dto.Lines = [.. dto.Lines.OrderBy(l => l.Order)];

        return Response<InvoiceDto>.Success(dto);
    }
}
