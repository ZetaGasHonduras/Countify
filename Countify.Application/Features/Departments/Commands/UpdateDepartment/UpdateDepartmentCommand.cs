using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class UpdateDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateDepartmentCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await unitOfWork.Departments.GetByIdAsync(request.Id, cancellationToken);
        if (department is null)
            return Response<bool>.NotFound($"Departamento {request.Id} no encontrado.");

        var codeInUse = await unitOfWork.Departments.ExistsAsync(
            d => d.Code == request.Code && d.Id != request.Id, cancellationToken);

        if (codeInUse)
            return Response<bool>.Failure($"El departamento '{request.Code}' ya existe.");

        mapper.Map(request, department);
        await unitOfWork.Departments.UpdateAsync(department, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}