using AutoMapper;
using Countify.Application.Features.Suppliers.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Suppliers.Queries.GetSuppliers;

public class GetSuppliersQuery : IRequest<Response<List<SupplierDto>>>;

public class GetSuppliersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetSuppliersQuery, Response<List<SupplierDto>>>
{
    public async Task<Response<List<SupplierDto>>> Handle(
        GetSuppliersQuery request, CancellationToken cancellationToken)
    {
        var suppliers = await unitOfWork.Suppliers.ToListAsync(
            unitOfWork.Suppliers.Query()
                .Include(s => s.SupplierType)
                .Include(s => s.AccountingAccount)
                .Include(s => s.FiscalData)
                .OrderBy(s => s.Name),
            cancellationToken);

        return Response<List<SupplierDto>>.Success(
            mapper.Map<List<SupplierDto>>(suppliers));
    }
}
