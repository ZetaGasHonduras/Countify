using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Billing;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PaymentMethods.Commands.CreatePaymentMethod;

public class CreatePaymentMethodCommand : IRequest<Response<Guid>>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsInactive { get; set; }
    public bool IsDefault { get; set; }
}

public class CreatePaymentMethodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreatePaymentMethodCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.PaymentMethods.ExistsAsync(
            m => m.Name == request.Name.Trim(), cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"El método de pago '{request.Name}' ya existe.");

        if (request.IsDefault)
        {
            // El nuevo método aún no está en BD: desmarca todos los vigentes.
            var defaults = await unitOfWork.PaymentMethods.Query()
                .Where(m => m.IsDefault)
                .ToListAsync(cancellationToken);

            foreach (var current in defaults)
                current.IsDefault = false;
        }

        var method = mapper.Map<PaymentMethod>(request);
        await unitOfWork.PaymentMethods.AddAsync(method, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(method.Id, 201);
    }
}
