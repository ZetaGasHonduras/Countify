using AutoMapper;
using Countify.Application.Features.InventoryMovementTypes.Commands.CreateInventoryMovementType;
using Countify.Application.Features.InventoryMovementTypes.DTOs;
using Countify.Domain.Entities.Inventory;

namespace Countify.Application.Features.InventoryMovementTypes.Profiles;

public class InventoryMovementTypeProfile : Profile
{
    public InventoryMovementTypeProfile()
    {
        CreateMap<InventoryMovementType, InventoryMovementTypeDto>()
            .ForMember(d => d.Direction, o => o.MapFrom(s => (int)s.Direction));

        CreateMap<CreateInventoryMovementTypeCommand, InventoryMovementType>()
            .ForMember(d => d.Direction, o => o.MapFrom(s => (InventoryMovementDirection)s.Direction));
    }
}
