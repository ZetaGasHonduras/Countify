using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.CashRegisters.Commands.UpdateCashRegister;

public class UpdateCashRegisterCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
    public bool IsInactive { get; set; }
}

public class UpdateCashRegisterCommandValidator : AbstractValidator<UpdateCashRegisterCommand>
{
    public UpdateCashRegisterCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}

public class UpdateCashRegisterCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCashRegisterCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateCashRegisterCommand request, CancellationToken cancellationToken)
    {
        var register = await unitOfWork.CashRegisters.GetByIdAsync(request.Id, cancellationToken);
        if (register is null)
            return Response<bool>.NotFound($"Caja {request.Id} no encontrada.");

        var code = request.Code.Trim();
        var name = request.Name.Trim();

        if (await unitOfWork.CashRegisters.ExistsAsync(
                c => c.Id != register.Id && (c.Code == code || c.Name == name), cancellationToken))
            return Response<bool>.Failure("Otra caja ya usa ese código o nombre.");

        if (request.IsDefault && !register.IsDefault)
        {
            var defaults = await unitOfWork.CashRegisters.Query()
                .Where(c => c.IsDefault && c.Id != register.Id).ToListAsync(cancellationToken);
            foreach (var current in defaults)
                current.IsDefault = false;
        }

        if (!request.IsDefault && register.IsDefault && !request.IsInactive)
            return Response<bool>.Failure("La caja predeterminada no se puede desmarcar; marque otra como predeterminada.");

        register.Code = code;
        register.Name = name;
        register.IsDefault = request.IsDefault;
        register.IsInactive = request.IsInactive;

        await unitOfWork.CashRegisters.UpdateAsync(register, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
