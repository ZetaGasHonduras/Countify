using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Qualities.Commands.CreateQuality;

public class CreateQualityCommand : IRequest<Response<Guid>>
{
    public string? Code { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class CreateQualityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateQualityCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateQualityCommand request, CancellationToken cancellationToken)
    {
        var quality = mapper.Map<Quality>(request);
        await unitOfWork.Qualities.AddAsync(quality, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(quality.Id, 201);
    }
}