using AutoMapper;
using Countify.Application.Features.Roles.DTOs;
using Countify.Application.Features.Users.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<Response<UserDetailDto>>
{
    public string Id { get; set; } = string.Empty;
}

public class GetUserByIdQueryHandler(
    UserManager<ApplicationUser> userManager, 
    RoleManager<IdentityRole> roleManager,
    IMapper mapper)
    : IRequestHandler<GetUserByIdQuery, Response<UserDetailDto>>
{
    public async Task<Response<UserDetailDto>> Handle(
        GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id);
        if (user is null)
            return Response<UserDetailDto>.Failure($"Usuario {request.Id} no encontrado.");

        var roleNames = await userManager.GetRolesAsync(user);

        var roles = new List<RoleDto>();
        foreach (var roleName in roleNames)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role is null) continue;
            roles.Add(mapper.Map<RoleDto>(role));
        }

        var dto = mapper.Map<UserDetailDto>(user);
        dto.Roles = roles;

        return Response<UserDetailDto>.Success(dto);
    }
}