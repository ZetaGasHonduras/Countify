using AutoMapper;
using Countify.Application.Features.ProductAccounts.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.ProductAccounts.Commands.CreateProductAccount;

public class CreateProductAccountCommand : ProductAccountRequest, IRequest<Response<Guid>>
{
}

public class CreateProductAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateProductAccountCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateProductAccountCommand request, CancellationToken cancellationToken)
    {
        var validationError = await ProductAccountRules.ValidateAsync(
            unitOfWork, request.ProductId, request.QualityId,
            request.InventoryAccountId, request.IncomeAccountId, request.CostAccountId,
            productAccountId: null, cancellationToken);

        if (validationError is not null)
            return Response<Guid>.Failure(validationError);

        var productAccount = mapper.Map<ProductAccount>(request);
        await unitOfWork.ProductAccounts.AddAsync(productAccount, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(productAccount.Id, 201);
    }
}