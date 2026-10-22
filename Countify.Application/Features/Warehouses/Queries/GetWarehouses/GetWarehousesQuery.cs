using AutoMapper;
using Countify.Application.Features.Warehouses.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Warehouses.Queries.GetWarehouses;

public class GetWarehousesQuery : IRequest<Response<List<WarehouseDto>>>;

public class GetWarehousesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetWarehousesQuery, Response<List<WarehouseDto>>>
{
    public async Task<Response<List<WarehouseDto>>> Handle(
        GetWarehousesQuery request, CancellationToken cancellationToken)
    {
        var warehouses = await unitOfWork.Warehouses.ToListAsync(
            unitOfWork.Warehouses.Query().Include(w => w.Locations).OrderBy(w => w.Name),
            cancellationToken);

        var dtos = mapper.Map<List<WarehouseDto>>(warehouses);
        foreach (var dto in dtos)
        {
            var source = warehouses.FirstOrDefault(w => w.Id == dto.Id);
            dto.LocationCount = source?.Locations.Count ?? 0;
        }

        return Response<List<WarehouseDto>>.Success(dtos);
    }
}
