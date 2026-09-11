using AutoMapper;
using Countify.Application.Features.Users.Commands.CreateUser;
using Countify.Application.Features.Users.Commands.UpdateUser;
using Countify.Application.Features.Users.DTOs;
using Countify.Domain.Entities.Auth;

namespace Countify.Application.Features.Users.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<ApplicationUser, UserDto>()
            .ForMember(d => d.Roles, o => o.Ignore());

        CreateMap<ApplicationUser, UserDetailDto>()
            .ForMember(d => d.Roles, o => o.Ignore());

        CreateMap<CreateUserCommand, ApplicationUser>()
            .ForMember(d => d.UserName, o => o.MapFrom(s => s.Username))
            .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.Phone));

        CreateMap<UpdateUserCommand, ApplicationUser>()
            .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.Phone));
    }
}