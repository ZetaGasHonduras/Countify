using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Countify.Application.Features.Cashiers.Commands.UpdateCashier;

public class UpdateCashierCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? UserId { get; set; }
    public bool IsInactive { get; set; }
}

public class UpdateCashierCommandValidator : AbstractValidator<UpdateCashierCommand>
{
    public UpdateCashierCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}

public class UpdateCashierCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCashierCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateCashierCommand request, CancellationToken cancellationToken)
    {
        var cashier = await unitOfWork.Cashiers.GetByIdAsync(request.Id, cancellationToken);
        if (cashier is null)
            return Response<bool>.NotFound($"Cajero {request.Id} no encontrado.");

        var code = request.Code.Trim();
        var name = request.Name.Trim();

        if (await unitOfWork.Cashiers.ExistsAsync(
                c => c.Id != cashier.Id && (c.Code == code || c.Name == name), cancellationToken))
            return Response<bool>.Failure("Otro cajero ya usa ese código o nombre.");

        var userId = string.IsNullOrWhiteSpace(request.UserId) ? null : request.UserId.Trim();

        if (userId is not null
            && !await unitOfWork.Users.ExistsAsync(u => u.Id == userId, cancellationToken))
            return Response<bool>.Failure("El usuario asignado al cajero no existe.");

        cashier.Code = code;
        cashier.Name = name;
        cashier.UserId = userId;
        cashier.IsInactive = request.IsInactive;

        await unitOfWork.Cashiers.UpdateAsync(cashier, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
