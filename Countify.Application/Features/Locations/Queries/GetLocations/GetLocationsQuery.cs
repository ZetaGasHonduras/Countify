using AutoMapper;
using Countify.Application.Features.Locations.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Locations.Queries.GetLocations;

public class GetLocationsQuery : IRequest<Response<List<LocationDto>>>;

public class GetLocationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetLocationsQuery, Response<List<LocationDto>>>
{
    public async Task<Response<List<LocationDto>>> Handle(
        GetLocationsQuery request, CancellationToken cancellationToken)
    {
        var locations = await unitOfWork.Locations.ToListAsync(
            unitOfWork.Locations.Query()
                .Include(l => l.Warehouse)
                .Include(l => l.Account)
                .Include(l => l.Project)
                .OrderBy(l => l.Warehouse!.Name).ThenBy(l => l.Code),
            cancellationToken);

        return Response<List<LocationDto>>.Success(mapper.Map<List<LocationDto>>(locations));
    }
}
