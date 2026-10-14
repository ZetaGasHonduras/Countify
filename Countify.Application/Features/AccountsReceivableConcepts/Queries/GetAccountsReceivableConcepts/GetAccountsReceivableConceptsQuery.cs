using AutoMapper;
using Countify.Application.Features.AccountsReceivableConcepts.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.AccountsReceivableConcepts.Queries.GetAccountsReceivableConcepts;

public class GetAccountsReceivableConceptsQuery : IRequest<Response<List<AccountsReceivableConceptDto>>>;

public class GetAccountsReceivableConceptsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAccountsReceivableConceptsQuery, Response<List<AccountsReceivableConceptDto>>>
{
    public async Task<Response<List<AccountsReceivableConceptDto>>> Handle(
        GetAccountsReceivableConceptsQuery request, CancellationToken cancellationToken)
    {
        var concepts = await unitOfWork.AccountsReceivableConcepts.ToListAsync(
            unitOfWork.AccountsReceivableConcepts.Query()
                .Include(c => c.Account)
                .OrderBy(c => c.Description),
            cancellationToken);

        return Response<List<AccountsReceivableConceptDto>>.Success(
            mapper.Map<List<AccountsReceivableConceptDto>>(concepts));
    }
}