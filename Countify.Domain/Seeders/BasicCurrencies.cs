using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicCurrencies
{
    public static readonly Currency Lempira = New("10000000-0000-0000-0000-000000000001", "LPS", "Lempira hondureño", 1m);
    public static readonly Currency Dollar = New("10000000-0000-0000-0000-000000000002", "USD", "Dólar estadounidense", 24.75m);
    public static readonly Currency Euro = New("10000000-0000-0000-0000-000000000003", "EUR", "Euro", 27.55m);
    public static Currency[] Items { get; } = [Lempira, Dollar, Euro];

    private static Currency New(string id, string code, string name, decimal rate) => new()
    {
        Id = Guid.Parse(id), Code = code, Name = name, ExchangeRate = rate, IsActive = true
    };
}
