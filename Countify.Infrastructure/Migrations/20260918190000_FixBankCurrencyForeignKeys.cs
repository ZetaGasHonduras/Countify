using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Countify.Infrastructure.Migrations;

[Migration("20260918190000_FixBankCurrencyForeignKeys")]
public partial class FixBankCurrencyForeignKeys : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Guid>("CurrencyId", "BankAccounts", nullable: true);
        migrationBuilder.AddColumn<Guid>("CurrencyId", "BankTransactions", nullable: true);

        migrationBuilder.Sql("UPDATE b SET CurrencyId = c.Id FROM BankAccounts b INNER JOIN Currencies c ON c.Code = b.Currency");
        migrationBuilder.Sql("UPDATE t SET CurrencyId = c.Id FROM BankTransactions t INNER JOIN Currencies c ON c.Code = t.Currency");

        migrationBuilder.Sql("UPDATE BankAccounts SET CurrencyId = (SELECT TOP 1 Id FROM Currencies ORDER BY Code) WHERE CurrencyId IS NULL");
        migrationBuilder.Sql("UPDATE BankTransactions SET CurrencyId = (SELECT TOP 1 Id FROM Currencies ORDER BY Code) WHERE CurrencyId IS NULL");

        migrationBuilder.AlterColumn<Guid>("CurrencyId", "BankAccounts", nullable: false, oldNullable: true);
        migrationBuilder.AlterColumn<Guid>("CurrencyId", "BankTransactions", nullable: false, oldNullable: true);
        migrationBuilder.DropColumn("Currency", "BankAccounts");
        migrationBuilder.DropColumn("Currency", "BankTransactions");

        migrationBuilder.CreateIndex("IX_BankAccounts_CurrencyId", "BankAccounts", "CurrencyId");
        migrationBuilder.CreateIndex("IX_BankTransactions_CurrencyId", "BankTransactions", "CurrencyId");
        migrationBuilder.AddForeignKey("FK_BankAccounts_Currencies_CurrencyId", "BankAccounts", "CurrencyId", "Currencies", "Id", onDelete: ReferentialAction.Restrict);
        migrationBuilder.AddForeignKey("FK_BankTransactions_Currencies_CurrencyId", "BankTransactions", "CurrencyId", "Currencies", "Id", onDelete: ReferentialAction.Restrict);

        migrationBuilder.DropForeignKey("FK_BankTransactions_BankReconciliations_BankReconciliationId1", "BankTransactions");
        migrationBuilder.DropIndex("IX_BankTransactions_BankReconciliationId1", "BankTransactions");
        migrationBuilder.DropColumn("BankReconciliationId1", "BankTransactions");
        migrationBuilder.CreateIndex("IX_BankTransactions_BankAccountId_Reference", "BankTransactions", new[] { "BankAccountId", "Reference" }, unique: true, filter: "[Reference] IS NOT NULL");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex("IX_BankTransactions_BankAccountId_Reference", "BankTransactions");
        migrationBuilder.DropForeignKey("FK_BankAccounts_Currencies_CurrencyId", "BankAccounts");
        migrationBuilder.DropForeignKey("FK_BankTransactions_Currencies_CurrencyId", "BankTransactions");
        migrationBuilder.DropIndex("IX_BankAccounts_CurrencyId", "BankAccounts");
        migrationBuilder.DropIndex("IX_BankTransactions_CurrencyId", "BankTransactions");
        migrationBuilder.AddColumn<string>("Currency", "BankAccounts", "nvarchar(10)", nullable: true);
        migrationBuilder.AddColumn<string>("Currency", "BankTransactions", "nvarchar(10)", nullable: true);
        migrationBuilder.DropColumn("CurrencyId", "BankAccounts");
        migrationBuilder.DropColumn("CurrencyId", "BankTransactions");
        migrationBuilder.AddColumn<Guid>("BankReconciliationId1", "BankTransactions", nullable: true);
    }
}
