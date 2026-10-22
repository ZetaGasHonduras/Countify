using AutoMapper;
using Countify.Application.Features.InventoryMovementTypes.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.InventoryMovementTypes.Queries.GetInventoryMovementTypes;

public class GetInventoryMovementTypesQuery : IRequest<Response<List<InventoryMovementTypeDto>>>;

public class GetInventoryMovementTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetInventoryMovementTypesQuery, Response<List<InventoryMovementTypeDto>>>
{
    public async Task<Response<List<InventoryMovementTypeDto>>> Handle(
        GetInventoryMovementTypesQuery request, CancellationToken cancellationToken)
    {
        var types = await unitOfWork.InventoryMovementTypes.ToListAsync(
            unitOfWork.InventoryMovementTypes.Query().OrderBy(t => t.Code),
            cancellationToken);

        return Response<List<InventoryMovementTypeDto>>.Success(mapper.Map<List<InventoryMovementTypeDto>>(types));
    }
}
