using Countify.Api.Authorization.Policies;
using Countify.Application.Features.Banks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Countify.Api.Controllers;
[Authorize]
[Route("api/banks")]
public class BanksController : BaseController
{
    [HttpGet("accounts"), Authorize(BankPolicies.ViewAccounts)] public async Task<IActionResult> Accounts() => HandleResult(await Mediator.Send(new GetBankAccountsQuery()));
    [HttpPost("accounts"), Authorize(BankPolicies.CreateAccounts)] public async Task<IActionResult> CreateAccount(CreateBankAccountCommand c) => HandleResult(await Mediator.Send(c));
    [HttpPut("accounts/{id:guid}"), Authorize(BankPolicies.EditAccounts)] public async Task<IActionResult> UpdateAccount(Guid id, UpdateBankAccountCommand c) => id != c.Id ? BadRequest() : HandleResult(await Mediator.Send(c));
    [HttpDelete("accounts/{id:guid}"), Authorize(BankPolicies.DeleteAccounts)] public async Task<IActionResult> DeleteAccount(Guid id) => HandleResult(await Mediator.Send(new DeleteBankAccountCommand(id)));
    [HttpGet("transaction-types"), Authorize(BankPolicies.ViewTypes)] public async Task<IActionResult> Types() => HandleResult(await Mediator.Send(new GetBankTransactionTypesQuery()));
    [HttpPost("transaction-types"), Authorize(BankPolicies.CreateTypes)] public async Task<IActionResult> CreateType(CreateBankTransactionTypeCommand c) => HandleResult(await Mediator.Send(c));
    [HttpPut("transaction-types/{id:guid}"), Authorize(BankPolicies.EditTypes)] public async Task<IActionResult> UpdateType(Guid id, UpdateBankTransactionTypeCommand c) => id != c.Id ? BadRequest() : HandleResult(await Mediator.Send(c));
    [HttpDelete("transaction-types/{id:guid}"), Authorize(BankPolicies.DeleteTypes)] public async Task<IActionResult> DeleteType(Guid id) => HandleResult(await Mediator.Send(new DeleteBankTransactionTypeCommand(id)));
    [HttpGet("transactions"), Authorize(BankPolicies.ViewTransactions)] public async Task<IActionResult> Transactions([FromQuery] Guid? bankAccountId = null) => HandleResult(await Mediator.Send(new GetBankTransactionsQuery(bankAccountId)));
    [HttpPost("transactions"), Authorize(BankPolicies.CreateTransactions)] public async Task<IActionResult> CreateTransaction(CreateBankTransactionCommand c) => HandleResult(await Mediator.Send(c));
    [HttpPut("transactions/{id:guid}"), Authorize(BankPolicies.EditTransactions)] public async Task<IActionResult> UpdateTransaction(Guid id, UpdateBankTransactionCommand c) => id != c.Id ? BadRequest() : HandleResult(await Mediator.Send(c));
    [HttpPost("transactions/{id:guid}/void"), Authorize(BankPolicies.EditTransactions)] public async Task<IActionResult> VoidTransaction(Guid id) => HandleResult(await Mediator.Send(new VoidBankTransactionCommand(id)));
    [HttpDelete("transactions/{id:guid}"), Authorize(BankPolicies.DeleteTransactions)] public async Task<IActionResult> DeleteTransaction(Guid id) => HandleResult(await Mediator.Send(new DeleteBankTransactionCommand(id)));
    [HttpGet("reconciliations"), Authorize(BankPolicies.ViewReconciliations)] public async Task<IActionResult> Reconciliations() => HandleResult(await Mediator.Send(new GetBankReconciliationsQuery()));
    [HttpPost("reconciliations"), Authorize(BankPolicies.CreateReconciliations)] public async Task<IActionResult> CreateReconciliation(CreateBankReconciliationCommand c) => HandleResult(await Mediator.Send(c));
    [HttpPut("reconciliations/{reconciliationId:guid}/transactions/{transactionId:guid}"), Authorize(BankPolicies.EditReconciliations)] public async Task<IActionResult> SetReconciliation(Guid reconciliationId, Guid transactionId, bool reconciled = true) => HandleResult(await Mediator.Send(new SetBankTransactionReconciliationCommand(reconciliationId, transactionId, reconciled)));
    [HttpPost("transactions/{id:guid}/unreconcile"), Authorize(BankPolicies.Unreconcile)] public async Task<IActionResult> Unreconcile(Guid id) => HandleResult(await Mediator.Send(new UnreconcileBankTransactionCommand(id)));
    [HttpPost("reconciliations/{id:guid}/close"), Authorize(BankPolicies.EditReconciliations)] public async Task<IActionResult> CloseReconciliation(Guid id) => HandleResult(await Mediator.Send(new CloseBankReconciliationCommand(id)));
    [HttpGet("statement"), Authorize(BankPolicies.ViewTransactions)] public async Task<IActionResult> Statement([FromQuery] GetBankStatementQuery query) => HandleResult(await Mediator.Send(query));
    [HttpGet("statement/export"), Authorize(BankPolicies.ViewTransactions)] public async Task<IActionResult> ExportStatement([FromQuery] GetBankStatementQuery query)
    {
        var result = await Mediator.Send(query);
        if (!result.IsSuccess || result.Data is null) return HandleResult(result);
        var s = result.Data;
        var csv = "Fecha,Referencia,Concepto,Débito,Crédito,Conciliado\n" + string.Join("\n", s.Transactions.Select(t => $"{t.Date:yyyy-MM-dd},\"{t.Reference}\",\"{t.Concept}\",{(t.TransactionTypeValue.Equals("DEBITO", StringComparison.OrdinalIgnoreCase) ? t.LocalAmount : 0):0.00},{(t.TransactionTypeValue.Equals("DEBITO", StringComparison.OrdinalIgnoreCase) ? 0 : t.LocalAmount):0.00},{t.Reconciled}"));
        return File(System.Text.Encoding.UTF8.GetBytes(csv), "text/csv", $"estado-cuenta-{s.BankAccountName}-{s.FromDate:yyyyMMdd}-{s.ToDate:yyyyMMdd}.csv");
     }

    [HttpGet("statement/export/pdf"), Authorize(BankPolicies.ViewTransactions)] public async Task<IActionResult> ExportStatementPdf([FromQuery] GetBankStatementQuery query)
    {
        var result = await Mediator.Send(query);
        if (!result.IsSuccess || result.Data is null) return HandleResult(result);
        var statement = result.Data;
        return File(BankStatementPdfBuilder.Build(statement), "application/pdf", $"estado-de-cuenta-{statement.BankAccountName}-{statement.FromDate:yyyyMMdd}-{statement.ToDate:yyyyMMdd}.pdf");
    }
}
