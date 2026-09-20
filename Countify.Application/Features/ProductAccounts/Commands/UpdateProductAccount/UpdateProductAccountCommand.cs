using AutoMapper;
using Countify.Application.Features.ProductAccounts.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.ProductAccounts.Commands.UpdateProductAccount;

public class UpdateProductAccountCommand : ProductAccountRequest, IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class UpdateProductAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateProductAccountCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateProductAccountCommand request, CancellationToken cancellationToken)
    {
        var productAccount = await unitOfWork.ProductAccounts.GetByIdAsync(request.Id, cancellationToken);
        if (productAccount is null)
            return Response<bool>.NotFound($"Configuración {request.Id} no encontrada.");

        var validationError = await ProductAccountRules.ValidateAsync(
            unitOfWork, request.ProductId, request.QualityId,
            request.InventoryAccountId, request.IncomeAccountId, request.CostAccountId,
            productAccountId: request.Id, cancellationToken);

        if (validationError is not null)
            return Response<bool>.Failure(validationError);

        mapper.Map(request, productAccount);
        await unitOfWork.ProductAccounts.UpdateAsync(productAccount, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}