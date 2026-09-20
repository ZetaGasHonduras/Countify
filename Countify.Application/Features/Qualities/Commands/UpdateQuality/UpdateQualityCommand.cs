using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Qualities.Commands.UpdateQuality;

public class UpdateQualityCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class UpdateQualityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateQualityCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateQualityCommand request, CancellationToken cancellationToken)
    {
        var quality = await unitOfWork.Qualities.GetByIdAsync(request.Id, cancellationToken);
        if (quality is null)
            return Response<bool>.NotFound($"Calidad {request.Id} no encontrada.");

        mapper.Map(request, quality);
        await unitOfWork.Qualities.UpdateAsync(quality, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}