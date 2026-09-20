using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Countify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameBankOpeningBalanceToBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpeningBalance",
                table: "BankAccounts",
                newName: "Balance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "BankAccounts",
                newName: "OpeningBalance");
        }
    }
}
