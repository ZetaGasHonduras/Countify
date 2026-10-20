using AutoMapper;
using Countify.Application.Features.PayableConcepts.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.PayableConcepts.Queries.GetPayableConcepts;

public class GetPayableConceptsQuery : IRequest<Response<List<PayableConceptDto>>>;

public class GetPayableConceptsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetPayableConceptsQuery, Response<List<PayableConceptDto>>>
{
    public async Task<Response<List<PayableConceptDto>>> Handle(
        GetPayableConceptsQuery request, CancellationToken cancellationToken)
    {
        var concepts = await unitOfWork.PayableConcepts.ToListAsync(
            unitOfWork.PayableConcepts.Query()
                .Include(c => c.Account)
                .OrderBy(c => c.Description),
            cancellationToken);

        return Response<List<PayableConceptDto>>.Success(
            mapper.Map<List<PayableConceptDto>>(concepts));
    }
}
