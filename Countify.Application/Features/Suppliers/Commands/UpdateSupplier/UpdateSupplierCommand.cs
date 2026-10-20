using AutoMapper;
using Countify.Application.Features.Suppliers.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Suppliers.Commands.UpdateSupplier;

public class UpdateSupplierCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
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

public class UpdateSupplierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateSupplierCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateSupplierCommand request, CancellationToken cancellationToken)
    {
        var supplier = await unitOfWork.Suppliers.Query()
            .Include(s => s.FiscalData)
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

        if (supplier is null)
            return Response<bool>.NotFound($"Proveedor {request.Id} no encontrado.");

        var exists = await unitOfWork.Suppliers.ExistsAsync(
            s => s.Code == request.Code && s.Id != request.Id, cancellationToken);

        if (exists)
            return Response<bool>.Failure($"El proveedor '{request.Code}' ya existe.");

        mapper.Map(request, supplier);

        // Sincroniza los datos fiscales: actualiza por Id, agrega los nuevos
        // (Id vacío o desconocido) y elimina los que ya no vienen en el payload.
        var keptIds = new HashSet<Guid>();
        var toAdd = new List<SupplierFiscalData>();

        foreach (var fiscal in request.FiscalData)
        {
            var existing = fiscal.Id != Guid.Empty
                ? supplier.FiscalData.FirstOrDefault(f => f.Id == fiscal.Id)
                : null;

            if (existing is not null)
            {
                existing.Branch = fiscal.Branch;
                existing.CAI = fiscal.CAI;
                existing.RangeFrom = fiscal.RangeFrom;
                existing.RangeTo = fiscal.RangeTo;
                existing.Correlative = fiscal.Correlative;
                existing.EmissionLimitDate = fiscal.EmissionLimitDate;
                existing.IsActive = fiscal.IsActive;
                keptIds.Add(existing.Id);
            }
            else
            {
                toAdd.Add(new SupplierFiscalData
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
        }

        var toRemove = supplier.FiscalData.Where(f => !keptIds.Contains(f.Id)).ToList();
        foreach (var fiscal in toRemove)
            supplier.FiscalData.Remove(fiscal);

        // Se agregan al final para que las filas nuevas (Id vacío) no interfieran
        // con el emparejamiento por Id ni con la limpieza anterior.
        foreach (var fiscal in toAdd)
            supplier.FiscalData.Add(fiscal);

        await unitOfWork.Suppliers.UpdateAsync(supplier, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
