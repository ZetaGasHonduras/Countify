using AutoMapper;
using Countify.Application.Features.Projects.Commands.CreateProject;
using Countify.Application.Features.Projects.Commands.CreateProjectGroup;
using Countify.Application.Features.Projects.Commands.UpdateProject;
using Countify.Application.Features.Projects.DTOs;
using Countify.Domain.Entities.Accounting;

namespace Countify.Application.Features.Projects.Profiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<ProjectGroup, ProjectGroupDto>();

        CreateMap<CreateProjectGroupCommand, ProjectGroup>();

        CreateMap<Project, ProjectDto>();

        CreateMap<CreateProjectCommand, Project>();

        CreateMap<UpdateProjectCommand, Project>();
    }
}