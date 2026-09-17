using AutoMapper;
using Countify.Application.Features.Accounts.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Accounts.Queries.GetAccountById;

public class GetAccountByIdQuery : IRequest<Response<AccountDto>>
{
    public Guid Id { get; set; }
}

public class GetAccountByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAccountByIdQuery, Response<AccountDto>>
{
    public async Task<Response<AccountDto>> Handle(
        GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        var account = await unitOfWork.Accounts.GetByIdAsync(request.Id, cancellationToken);
        if (account is null)
            return Response<AccountDto>.NotFound($"Cuenta {request.Id} no encontrada.");

        return Response<AccountDto>.Success(mapper.Map<AccountDto>(account));
    }
}