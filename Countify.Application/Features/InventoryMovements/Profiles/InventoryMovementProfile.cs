using AutoMapper;
using Countify.Application.Features.InventoryMovements.Commands.CreateInventoryMovement;
using Countify.Application.Features.InventoryMovements.DTOs;
using Countify.Domain.Entities.Inventory;

namespace Countify.Application.Features.InventoryMovements.Profiles;

public class InventoryMovementProfile : Profile
{
    public InventoryMovementProfile()
    {
        CreateMap<InventoryMovement, InventoryMovementDto>()
            .ForMember(d => d.TypeCode, o => o.MapFrom(s => s.Type != null ? s.Type.Code : null))
            .ForMember(d => d.TypeName, o => o.MapFrom(s => s.Type != null ? s.Type.Name : null))
            .ForMember(d => d.Direction, o => o.MapFrom(s => s.Type != null ? (int)s.Type.Direction : 0))
            .ForMember(d => d.WarehouseName, o => o.MapFrom(s => s.Warehouse != null ? s.Warehouse.Name : null))
            .ForMember(d => d.ToWarehouseName, o => o.MapFrom(s => s.ToWarehouse != null ? s.ToWarehouse.Name : null))
            .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.Department != null ? s.Department.Name : null))
            .ForMember(d => d.SourceRequestCode, o => o.MapFrom(s => s.SourceRequest != null ? s.SourceRequest.Code : null))
            .ForMember(d => d.JournalEntryNumber, o => o.MapFrom(s => s.JournalEntry != null ? s.JournalEntry.EntryNumber : (int?)null));

        CreateMap<InventoryMovementLine, InventoryMovementLineDto>()
            .ForMember(d => d.ProductCode, o => o.MapFrom(s => s.Product != null ? s.Product.Code : null))
            .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product != null ? s.Product.Name : null))
            .ForMember(d => d.LocationCode, o => o.MapFrom(s => s.Location != null ? s.Location.Code : null))
            .ForMember(d => d.LocationName, o => o.MapFrom(s => s.Location != null ? s.Location.Name : null));

        CreateMap<InventoryMovementLineInput, InventoryMovementLine>();

        CreateMap<CreateInventoryMovementCommand, InventoryMovement>()
            .ForMember(d => d.Lines, o => o.Ignore())
            .ForMember(d => d.Code, o => o.Ignore())
            .ForMember(d => d.Correlativo, o => o.Ignore());
    }
}
