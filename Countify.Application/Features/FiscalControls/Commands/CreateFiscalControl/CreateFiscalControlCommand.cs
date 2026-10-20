using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.FiscalControls.Commands.CreateFiscalControl;

public class CreateFiscalControlCommand : IRequest<Response<Guid>>
{
    public FiscalDocumentType DocumentType { get; set; }
    public string? Branch { get; set; }
    public string? EmissionPoint { get; set; }
    public string? DocumentCode { get; set; }
    public string? CAI { get; set; }
    public string? RangeFrom { get; set; }
    public string? RangeTo { get; set; }
    public DateTime? EmissionDate { get; set; }
    public DateTime? EmissionLimitDate { get; set; }
    public bool IsActive { get; set; } = true;
    public int LastNumber { get; set; }
    public int WarningNumber { get; set; }
    public string? Observations { get; set; }
}

public class CreateFiscalControlCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateFiscalControlCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateFiscalControlCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.FiscalControls.ExistsAsync(
            c => c.DocumentType == request.DocumentType && c.Branch == request.Branch &&
                 c.EmissionPoint == request.EmissionPoint,
            cancellationToken);

        if (exists)
            return Response<Guid>.Failure("Ya existe un control fiscal para ese tipo y punto de emisión.");

        var control = mapper.Map<FiscalControl>(request);
        await unitOfWork.FiscalControls.AddAsync(control, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(control.Id, 201);
    }
}