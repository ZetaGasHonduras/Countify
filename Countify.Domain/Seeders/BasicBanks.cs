using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicBanks
{
    public static readonly BankAccount MainBank = new()
    {
        Id = Guid.Parse("83000000-0000-0000-0000-000000000001"), Code = "BANCO-001", Name = "Banco principal",
        AccountNumber = "012345678901", AccountingAccountId = BasicAccounts.Banks.Id, CurrencyId = BasicCurrencies.Lempira.Id, CutoffDay = 30,
        Balance = 125000m, DefaultNdNcText = "Movimiento bancario"
    };
    public static BankAccount[] Accounts { get; } = [MainBank];
    public static readonly BankTransactionType Deposit = NewType("DEPOSITO", "DEPOSITO", "DEBITO");
    public static readonly BankTransactionType Check = NewType("CHEQUE", "CHEQUE", "CREDITO");
    public static readonly BankTransactionType CreditNote = NewType("NDNC", "NOTA DE CREDITO", "CREDITO");
    public static readonly BankTransactionType DebitNote = NewType("NDDN", "NOTA DE DEBITO", "DEBITO");
    public static BankTransactionType[] TransactionTypes { get; } = [Deposit, Check, CreditNote, DebitNote];
    private static BankTransactionType NewType(string code, string movement, string transaction) => new() { Id = Guid.NewGuid(), Code = code, MovementType = movement, TransactionType = transaction };
}
