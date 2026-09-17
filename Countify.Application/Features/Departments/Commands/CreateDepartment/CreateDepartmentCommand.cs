using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class CreateDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateDepartmentCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.Departments.ExistsAsync(
            d => d.Code == request.Code, cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"El departamento '{request.Code}' ya existe.");

        var department = mapper.Map<Department>(request);
        await unitOfWork.Departments.AddAsync(department, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(department.Id, 201);
    }
}