using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Countify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixBankCurrencyForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CompanySettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "CompanySettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CompanySettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "CompanySettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "CompanySettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxId",
                table: "CompanySettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "CompanySettings");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "CompanySettings");
        }
    }
}
