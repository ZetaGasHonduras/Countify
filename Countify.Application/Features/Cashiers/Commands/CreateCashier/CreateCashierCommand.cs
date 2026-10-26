using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Billing;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Countify.Application.Features.Cashiers.Commands.CreateCashier;

public class CreateCashierCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    /// <summary>Usuario de la app que opera esta caja (la identidad reemplaza la Clave del legacy). Id string de ApplicationUser.</summary>
    public string? UserId { get; set; }

    public bool IsInactive { get; set; }
}

public class CreateCashierCommandValidator : AbstractValidator<CreateCashierCommand>
{
    public CreateCashierCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}

public class CreateCashierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateCashierCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateCashierCommand request, CancellationToken cancellationToken)
    {
        var code = request.Code.Trim();
        var name = request.Name.Trim();

        if (await unitOfWork.Cashiers.ExistsAsync(c => c.Code == code, cancellationToken))
            return Response<Guid>.Failure($"Ya existe un cajero con el código '{code}'.");

        if (await unitOfWork.Cashiers.ExistsAsync(c => c.Name == name, cancellationToken))
            return Response<Guid>.Failure($"Ya existe un cajero llamado '{name}'.");

        var userId = string.IsNullOrWhiteSpace(request.UserId) ? null : request.UserId.Trim();

        if (userId is not null
            && !await unitOfWork.Users.ExistsAsync(u => u.Id == userId, cancellationToken))
            return Response<Guid>.Failure("El usuario asignado al cajero no existe.");

        var cashier = mapper.Map<Cashier>(request);
        cashier.Code = code;
        cashier.Name = name;
        cashier.UserId = userId;

        await unitOfWork.Cashiers.AddAsync(cashier, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(cashier.Id, 201);
    }
}
