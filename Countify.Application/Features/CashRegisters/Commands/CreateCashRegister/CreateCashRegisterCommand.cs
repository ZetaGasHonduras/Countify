using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Billing;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.CashRegisters.Commands.CreateCashRegister;

public class CreateCashRegisterCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
    public bool IsInactive { get; set; }
}

public class CreateCashRegisterCommandValidator : AbstractValidator<CreateCashRegisterCommand>
{
    public CreateCashRegisterCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}

public class CreateCashRegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateCashRegisterCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateCashRegisterCommand request, CancellationToken cancellationToken)
    {
        var code = request.Code.Trim();
        var name = request.Name.Trim();

        if (await unitOfWork.CashRegisters.ExistsAsync(c => c.Code == code, cancellationToken))
            return Response<Guid>.Failure($"Ya existe una caja con el código '{code}'.");

        if (await unitOfWork.CashRegisters.ExistsAsync(c => c.Name == name, cancellationToken))
            return Response<Guid>.Failure($"Ya existe una caja llamada '{name}'.");

        if (request.IsDefault)
        {
            var defaults = await unitOfWork.CashRegisters.Query()
                .Where(c => c.IsDefault).ToListAsync(cancellationToken);
            foreach (var current in defaults)
                current.IsDefault = false;
        }

        var register = mapper.Map<CashRegister>(request);
        register.Code = code;
        register.Name = name;

        await unitOfWork.CashRegisters.AddAsync(register, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(register.Id, 201);
    }
}
