using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.CashRegisters.Commands.DeleteCashRegister;

public class DeleteCashRegisterCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteCashRegisterCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteCashRegisterCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        DeleteCashRegisterCommand request, CancellationToken cancellationToken)
    {
        var register = await unitOfWork.CashRegisters.GetByIdAsync(request.Id, cancellationToken);
        if (register is null)
            return Response<bool>.NotFound($"Caja {request.Id} no encontrada.");

        if (register.IsDefault)
            return Response<bool>.Failure("No se puede eliminar la caja predeterminada.");

        await unitOfWork.CashRegisters.DeleteAsync(register, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
