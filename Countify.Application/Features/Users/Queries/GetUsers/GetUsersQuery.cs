using Countify.Application.Extensions;
using Countify.Application.Features.Roles.DTOs;
using Countify.Application.Features.Users.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Common;
using Countify.Domain.Entities.Auth;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Users.Queries.GetUsers;

public class GetUsersQuery : RequestParameter, IRequest<PaginatedResponse<List<UserDto>>>;

public class GetUsersQueryHandler(
    IUnitOfWork unitOfWork,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
    : IRequestHandler<GetUsersQuery, PaginatedResponse<List<UserDto>>>
{
    public async Task<PaginatedResponse<List<UserDto>>> Handle(
        GetUsersQuery request, CancellationToken cancellationToken)
    {
        var query = unitOfWork.Users.Query()
            .ApplySearch(request.Parameter, x =>
                x.FirstName.Contains(request.Parameter!) ||
                x.LastName.Contains(request.Parameter!) ||
                x.Email!.Contains(request.Parameter!))
            .ApplyOrder(request.Column, request.Order == OrderColumns.Descending, x => x.LastName, new()
            {
                ["FirstName"] = x => x.FirstName,
                ["LastName"] = x => x.LastName,
                ["Email"] = x => x.Email!,
                ["CreatedAt"] = x => x.CreatedAt
            });

        var totalCount = await unitOfWork.Users.CountAsync(query, cancellationToken);

        if (request.All)
        {
            request.PageNumber = 1;
            request.PageSize = totalCount;
        }

        var users = await unitOfWork.Users.ToListAsync(
            query.Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize),
            cancellationToken);

        var dtos = new List<UserDto>();
        foreach (var user in users)
        {
            var roleNames = await userManager.GetRolesAsync(user);

            var roles = new List<RoleDto>();
            foreach (var roleName in roleNames)
            {
                var role = await roleManager.FindByNameAsync(roleName);
                if (role is null) continue;
                roles.Add(new RoleDto { Id = role.Id, Name = role.Name! });
            }

            dtos.Add(new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                UserName = user.UserName!,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt,
                Roles = roles
            });
        }

        return new PaginatedResponse<List<UserDto>>(dtos, request.PageNumber, request.PageSize, totalCount);
    }
}