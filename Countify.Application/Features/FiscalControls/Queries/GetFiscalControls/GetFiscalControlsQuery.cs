using AutoMapper;
using Countify.Application.Features.FiscalControls.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.FiscalControls.Queries.GetFiscalControls;

public class GetFiscalControlsQuery : IRequest<Response<List<FiscalControlDto>>>;

public class GetFiscalControlsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetFiscalControlsQuery, Response<List<FiscalControlDto>>>
{
    public async Task<Response<List<FiscalControlDto>>> Handle(
        GetFiscalControlsQuery request, CancellationToken cancellationToken)
    {
        var controls = await unitOfWork.FiscalControls.ToListAsync(
            unitOfWork.FiscalControls.Query()
                .OrderBy(c => c.DocumentType)
                .ThenBy(c => c.Branch),
            cancellationToken);

        return Response<List<FiscalControlDto>>.Success(mapper.Map<List<FiscalControlDto>>(controls));
    }
}
