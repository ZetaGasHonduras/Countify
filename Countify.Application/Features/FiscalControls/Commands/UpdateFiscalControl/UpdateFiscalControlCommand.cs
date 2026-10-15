using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Enums;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.FiscalControls.Commands.UpdateFiscalControl;

public class UpdateFiscalControlCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public FiscalDocumentType DocumentType { get; set; }
    public string? Branch { get; set; }
    public string? EmissionPoint { get; set; }
    public string? DocumentCode { get; set; }
    public string? CAI { get; set; }
    public string? RangeFrom { get; set; }
    public string? RangeTo { get; set; }
    public DateTime? EmissionDate { get; set; }
    public DateTime? EmissionLimitDate { get; set; }
    public bool IsActive { get; set; }
    public int LastNumber { get; set; }
    public int WarningNumber { get; set; }
    public string? Observations { get; set; }
}

public class UpdateFiscalControlCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateFiscalControlCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateFiscalControlCommand request, CancellationToken cancellationToken)
    {
        var control = await unitOfWork.FiscalControls.GetByIdAsync(request.Id, cancellationToken);
        if (control is null)
            return Response<bool>.NotFound($"Control fiscal {request.Id} no encontrado.");

        var exists = await unitOfWork.FiscalControls.ExistsAsync(
            c => c.DocumentType == request.DocumentType
                 && c.Branch == request.Branch
                 && c.EmissionPoint == request.EmissionPoint
                 && c.Id != request.Id,
            cancellationToken);

        if (exists)
            return Response<bool>.Failure("Ya existe un control fiscal para ese tipo y punto de emisión.");

        mapper.Map(request, control);
        await unitOfWork.FiscalControls.UpdateAsync(control, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
