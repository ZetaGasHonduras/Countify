using AutoMapper;
using Countify.Application.Features.Warehouses.Commands.CreateWarehouse;
using Countify.Application.Features.Warehouses.Commands.UpdateWarehouse;
using Countify.Application.Features.Warehouses.DTOs;
using Countify.Domain.Entities.Inventory;

namespace Countify.Application.Features.Warehouses.Profiles;

public class WarehouseProfile : Profile
{
    public WarehouseProfile()
    {
        CreateMap<Warehouse, WarehouseDto>();
        CreateMap<CreateWarehouseCommand, Warehouse>();
        CreateMap<UpdateWarehouseCommand, Warehouse>();
    }
}
