using AutoMapper;
using Countify.Application.Features.Departments.Commands.CreateDepartment;
using Countify.Application.Features.Departments.Commands.UpdateDepartment;
using Countify.Application.Features.Departments.DTOs;
using Countify.Domain.Entities.Accounting;

namespace Countify.Application.Features.Departments.Profiles;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<Department, DepartmentDto>();

        CreateMap<CreateDepartmentCommand, Department>();

        CreateMap<UpdateDepartmentCommand, Department>();
    }
}