using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod;

public class UpdatePaymentMethodCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsInactive { get; set; }
    public bool IsDefault { get; set; }
}

public class UpdatePaymentMethodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdatePaymentMethodCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var method = await unitOfWork.PaymentMethods.GetByIdAsync(request.Id, cancellationToken);
        if (method is null)
            return Response<bool>.NotFound($"Método de pago {request.Id} no encontrado.");

        var exists = await unitOfWork.PaymentMethods.ExistsAsync(
            m => m.Name == request.Name.Trim() && m.Id != request.Id, cancellationToken);

        if (exists)
            return Response<bool>.Failure($"El método de pago '{request.Name}' ya existe.");

        if (request.IsDefault)
        {
            var defaults = await unitOfWork.PaymentMethods.Query()
                .Where(m => m.IsDefault && m.Id != request.Id)
                .ToListAsync(cancellationToken);

            foreach (var current in defaults)
                current.IsDefault = false;
        }

        mapper.Map(request, method);
        await unitOfWork.PaymentMethods.UpdateAsync(method, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
