using AutoMapper;
using Countify.Application.Features.SupplierTypes.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.SupplierTypes.Queries.GetSupplierTypes;

public class GetSupplierTypesQuery : IRequest<Response<List<SupplierTypeDto>>>;

public class GetSupplierTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetSupplierTypesQuery, Response<List<SupplierTypeDto>>>
{
    public async Task<Response<List<SupplierTypeDto>>> Handle(
        GetSupplierTypesQuery request, CancellationToken cancellationToken)
    {
        var supplierTypes = await unitOfWork.SupplierTypes.ToListAsync(
            unitOfWork.SupplierTypes.Query()
                .Include(st => st.AccountingAccount)
                .OrderBy(st => st.Name),
            cancellationToken);

        return Response<List<SupplierTypeDto>>.Success(
            mapper.Map<List<SupplierTypeDto>>(supplierTypes));
    }
}
