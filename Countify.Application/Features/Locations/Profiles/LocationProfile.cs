using AutoMapper;
using Countify.Application.Features.Locations.Commands.CreateLocation;
using Countify.Application.Features.Locations.DTOs;
using Countify.Domain.Entities.Inventory;

namespace Countify.Application.Features.Locations.Profiles;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<Location, LocationDto>()
            .ForMember(d => d.WarehouseName, o => o.MapFrom(s => s.Warehouse != null ? s.Warehouse.Name : null))
            .ForMember(d => d.AccountCode, o => o.MapFrom(s => s.Account != null ? s.Account.Code : null))
            .ForMember(d => d.AccountName, o => o.MapFrom(s => s.Account != null ? s.Account.Name : null))
            .ForMember(d => d.ProjectName, o => o.MapFrom(s => s.Project != null ? s.Project.Name : null));

        CreateMap<CreateLocationCommand, Location>();
    }
}
