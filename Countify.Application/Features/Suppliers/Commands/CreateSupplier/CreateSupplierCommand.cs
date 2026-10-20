using AutoMapper;
using Countify.Application.Features.Suppliers.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommand : IRequest<Response<Guid>>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? SupplierTypeId { get; set; }
    public string? TaxId { get; set; }
    public string? IdentityDocument { get; set; }
    public string? Registration { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPosition { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public int CreditDays { get; set; }
    public decimal CreditLimit { get; set; }
    public Guid? AccountingAccountId { get; set; }
    public bool IsInactive { get; set; }
    public List<SupplierFiscalDataDto> FiscalData { get; set; } = [];
}

public class CreateSupplierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateSupplierCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        var exists = await unitOfWork.Suppliers.ExistsAsync(
            s => s.Code == request.Code, cancellationToken);

        if (exists)
            return Response<Guid>.Failure($"El proveedor '{request.Code}' ya existe.");

        var supplier = mapper.Map<Supplier>(request);

        // El Id de las filas nuevas se asigna en SaveChanges.
        foreach (var fiscal in request.FiscalData)
        {
            supplier.FiscalData.Add(new SupplierFiscalData
            {
                Branch = fiscal.Branch,
                CAI = fiscal.CAI,
                RangeFrom = fiscal.RangeFrom,
                RangeTo = fiscal.RangeTo,
                Correlative = fiscal.Correlative,
                EmissionLimitDate = fiscal.EmissionLimitDate,
                IsActive = fiscal.IsActive,
            });
        }

        await unitOfWork.Suppliers.AddAsync(supplier, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(supplier.Id, 201);
    }
}