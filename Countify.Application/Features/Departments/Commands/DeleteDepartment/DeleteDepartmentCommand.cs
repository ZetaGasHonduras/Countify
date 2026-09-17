using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Departments.Commands.DeleteDepartment;

public class DeleteDepartmentCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteDepartmentCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteDepartmentCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await unitOfWork.Departments.GetByIdAsync(request.Id, cancellationToken);
        if (department is null)
            return Response<bool>.NotFound($"Departamento {request.Id} no encontrado.");

        var hasMovements = await unitOfWork.JournalEntryLines.ExistsAsync(
            l => l.DepartmentId == request.Id, cancellationToken);

        if (hasMovements)
            return Response<bool>.Failure("No se puede eliminar: el departamento está usado en partidas contables.");

        var isDefault = await unitOfWork.CompanySettings.Query()
            .AnyAsync(s => s.DefaultDepartmentId == request.Id, cancellationToken);

        if (isDefault)
            return Response<bool>.Failure("No se puede eliminar: es el departamento predeterminado de la configuración.");

        await unitOfWork.Departments.DeleteAsync(department, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}