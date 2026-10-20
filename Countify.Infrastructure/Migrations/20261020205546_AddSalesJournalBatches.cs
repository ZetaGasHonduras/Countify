using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Countify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesJournalBatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SalesBatchId",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CashAccountId",
                table: "CompanySettings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReceivableForeignAccountId",
                table: "CompanySettings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReceivableLocalAccountId",
                table: "CompanySettings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SalesForeignAccountId",
                table: "CompanySettings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SalesLocalAccountId",
                table: "CompanySettings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TaxPayableAccountId",
                table: "CompanySettings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalesJournalBatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JournalEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesJournalBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesJournalBatches_JournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 121, "Ver partidas de ventas.", "CanViewSalesJournalBatches" },
                    { 122, "Generar partidas de ventas.", "CanCreateSalesJournalBatches" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 121, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 122, "f3d1e2c4-0000-0000-0000-000000000001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SalesBatchId",
                table: "Invoices",
                column: "SalesBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySettings_CashAccountId",
                table: "CompanySettings",
                column: "CashAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySettings_ReceivableForeignAccountId",
                table: "CompanySettings",
                column: "ReceivableForeignAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySettings_ReceivableLocalAccountId",
                table: "CompanySettings",
                column: "ReceivableLocalAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySettings_SalesForeignAccountId",
                table: "CompanySettings",
                column: "SalesForeignAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySettings_SalesLocalAccountId",
                table: "CompanySettings",
                column: "SalesLocalAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySettings_TaxPayableAccountId",
                table: "CompanySettings",
                column: "TaxPayableAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesJournalBatches_JournalEntryId",
                table: "SalesJournalBatches",
                column: "JournalEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySettings_Accounts_CashAccountId",
                table: "CompanySettings",
                column: "CashAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySettings_Accounts_ReceivableForeignAccountId",
                table: "CompanySettings",
                column: "ReceivableForeignAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySettings_Accounts_ReceivableLocalAccountId",
                table: "CompanySettings",
                column: "ReceivableLocalAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySettings_Accounts_SalesForeignAccountId",
                table: "CompanySettings",
                column: "SalesForeignAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySettings_Accounts_SalesLocalAccountId",
                table: "CompanySettings",
                column: "SalesLocalAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySettings_Accounts_TaxPayableAccountId",
                table: "CompanySettings",
                column: "TaxPayableAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_SalesJournalBatches_SalesBatchId",
                table: "Invoices",
                column: "SalesBatchId",
                principalTable: "SalesJournalBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanySettings_Accounts_CashAccountId",
                table: "CompanySettings");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySettings_Accounts_ReceivableForeignAccountId",
                table: "CompanySettings");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySettings_Accounts_ReceivableLocalAccountId",
                table: "CompanySettings");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySettings_Accounts_SalesForeignAccountId",
                table: "CompanySettings");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySettings_Accounts_SalesLocalAccountId",
                table: "CompanySettings");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySettings_Accounts_TaxPayableAccountId",
                table: "CompanySettings");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_SalesJournalBatches_SalesBatchId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "SalesJournalBatches");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_SalesBatchId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_CompanySettings_CashAccountId",
                table: "CompanySettings");

            migrationBuilder.DropIndex(
                name: "IX_CompanySettings_ReceivableForeignAccountId",
                table: "CompanySettings");

            migrationBuilder.DropIndex(
                name: "IX_CompanySettings_ReceivableLocalAccountId",
                table: "CompanySettings");

            migrationBuilder.DropIndex(
                name: "IX_CompanySettings_SalesForeignAccountId",
                table: "CompanySettings");

            migrationBuilder.DropIndex(
                name: "IX_CompanySettings_SalesLocalAccountId",
                table: "CompanySettings");

            migrationBuilder.DropIndex(
                name: "IX_CompanySettings_TaxPayableAccountId",
                table: "CompanySettings");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 121, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 122, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DropColumn(
                name: "SalesBatchId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CashAccountId",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "ReceivableForeignAccountId",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "ReceivableLocalAccountId",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "SalesForeignAccountId",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "SalesLocalAccountId",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "TaxPayableAccountId",
                table: "CompanySettings");
        }
    }
}
