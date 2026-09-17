using AutoMapper;
using Countify.Application.Features.Departments.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Departments.Queries.GetDepartments;

public class GetDepartmentsQuery : IRequest<Response<List<DepartmentDto>>>;

public class GetDepartmentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetDepartmentsQuery, Response<List<DepartmentDto>>>
{
    public async Task<Response<List<DepartmentDto>>> Handle(
        GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var departments = await unitOfWork.Departments.ToListAsync(
            unitOfWork.Departments.Query().OrderBy(d => d.Code),
            cancellationToken);

        return Response<List<DepartmentDto>>.Success(
            mapper.Map<List<DepartmentDto>>(departments));
    }
}