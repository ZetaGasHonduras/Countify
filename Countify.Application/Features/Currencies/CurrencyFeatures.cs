using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Interfaces;
using MediatR;

namespace Countify.Application.Features.Currencies;

public class CurrencyDto { public Guid Id { get; set; } public string Code { get; set; } = ""; public string Name { get; set; } = ""; public decimal ExchangeRate { get; set; } public bool IsActive { get; set; } }
public class CurrencyProfile : Profile { public CurrencyProfile() => CreateMap<Currency, CurrencyDto>(); }
public record CreateCurrencyCommand(string Code, string Name, decimal ExchangeRate, bool IsActive) : IRequest<Response<Guid>>;
public record UpdateCurrencyCommand(Guid Id, string Code, string Name, decimal ExchangeRate, bool IsActive) : IRequest<Response<bool>>;
public record DeleteCurrencyCommand(Guid Id) : IRequest<Response<bool>>;
public record GetCurrenciesQuery : IRequest<Response<List<CurrencyDto>>>;

public class CurrencyHandler(IUnitOfWork u, IMapper mapper) :
    IRequestHandler<CreateCurrencyCommand, Response<Guid>>, IRequestHandler<UpdateCurrencyCommand, Response<bool>>,
    IRequestHandler<DeleteCurrencyCommand, Response<bool>>, IRequestHandler<GetCurrenciesQuery, Response<List<CurrencyDto>>>
{
    public async Task<Response<Guid>> Handle(CreateCurrencyCommand x, CancellationToken c)
    {
        if (string.IsNullOrWhiteSpace(x.Code) || string.IsNullOrWhiteSpace(x.Name) || x.ExchangeRate <= 0) return Response<Guid>.Failure("Código, nombre y tasa válida son obligatorios.");
        if (await u.Currencies.ExistsAsync(v => v.Code == x.Code.Trim().ToUpper(), c)) return Response<Guid>.Failure("El código de moneda ya existe.");
        var e = new Currency { Code = x.Code.Trim().ToUpperInvariant(), Name = x.Name.Trim(), ExchangeRate = x.ExchangeRate, IsActive = x.IsActive };
        await u.Currencies.AddAsync(e, c); await u.SaveChangesAsync(c); return Response<Guid>.Success(e.Id, 201);
    }
    public async Task<Response<bool>> Handle(UpdateCurrencyCommand x, CancellationToken c)
    {
        var e = await u.Currencies.GetByIdAsync(x.Id, c); if (e is null) return Response<bool>.NotFound("Moneda no encontrada.");
        var code = x.Code.Trim().ToUpperInvariant(); if (await u.Currencies.ExistsAsync(v => v.Code == code && v.Id != x.Id, c)) return Response<bool>.Failure("El código de moneda ya existe.");
        if (x.ExchangeRate <= 0) return Response<bool>.Failure("La tasa de cambio debe ser mayor que cero.");
        e.Code = code; e.Name = x.Name.Trim(); e.ExchangeRate = x.ExchangeRate; e.IsActive = x.IsActive; await u.SaveChangesAsync(c); return Response<bool>.Success(true, 204);
    }
    public async Task<Response<bool>> Handle(DeleteCurrencyCommand x, CancellationToken c)
    {
        var e = await u.Currencies.GetByIdAsync(x.Id, c); if (e is null) return Response<bool>.NotFound("Moneda no encontrada.");
        if (await u.BankAccounts.ExistsAsync(a => a.CurrencyId == x.Id, c) || await u.BankTransactions.ExistsAsync(t => t.CurrencyId == x.Id, c)) return Response<bool>.Failure("No se puede eliminar una moneda en uso.");
        await u.Currencies.DeleteAsync(e, c); await u.SaveChangesAsync(c); return Response<bool>.Success(true, 204);
    }
    public async Task<Response<List<CurrencyDto>>> Handle(GetCurrenciesQuery x, CancellationToken c) => Response<List<CurrencyDto>>.Success(mapper.Map<List<CurrencyDto>>(await u.Currencies.ToListAsync(u.Currencies.Query().OrderBy(v => v.Code), c)));
}
