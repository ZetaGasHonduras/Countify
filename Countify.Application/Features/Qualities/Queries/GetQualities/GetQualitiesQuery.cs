using AutoMapper;
using Countify.Application.Features.Qualities.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Qualities.Queries.GetQualities;

public class GetQualitiesQuery : IRequest<Response<List<QualityDto>>>;

public class GetQualitiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetQualitiesQuery, Response<List<QualityDto>>>
{
    public async Task<Response<List<QualityDto>>> Handle(
        GetQualitiesQuery request, CancellationToken cancellationToken)
    {
        var qualities = await unitOfWork.Qualities.ToListAsync(
            unitOfWork.Qualities.Query().OrderBy(q => q.Name),
            cancellationToken);

        return Response<List<QualityDto>>.Success(
            mapper.Map<List<QualityDto>>(qualities));
    }
}