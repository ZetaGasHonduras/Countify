using AutoMapper;
using Countify.Application.Features.Roles.DTOs;
using Countify.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Roles.Profiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<IdentityRole, RoleDto>()
            .ForMember(d => d.PermissionCount, o => o.Ignore());

        CreateMap<IdentityRole, RoleDetailDto>()
            .ForMember(d => d.PermissionCount, o => o.Ignore())
            .ForMember(d => d.Permissions, o => o.Ignore());

        CreateMap<Permission, PermissionDto>();

        CreateMap<RolePermission, PermissionDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Permission != null ? s.Permission.Id : 0))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Permission != null ? s.Permission.Name : null))
            .ForMember(d => d.Description,
                o => o.MapFrom(s => s.Permission != null ? s.Permission.Description : null));
    }
}