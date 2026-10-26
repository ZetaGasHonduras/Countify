using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Countify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPosCatalogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LastCost",
                table: "Products",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SalePrice",
                table: "Products",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Cashiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashRegisters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRegisters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 141, "Ver cajas.", "CanViewCashRegisters" },
                    { 142, "Crear cajas.", "CanCreateCashRegisters" },
                    { 143, "Editar cajas.", "CanEditCashRegisters" },
                    { 144, "Eliminar cajas.", "CanDeleteCashRegisters" },
                    { 145, "Ver cajeros.", "CanViewCashiers" },
                    { 146, "Crear cajeros.", "CanCreateCashiers" },
                    { 147, "Editar cajeros.", "CanEditCashiers" },
                    { 148, "Eliminar cajeros.", "CanDeleteCashiers" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 141, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 142, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 143, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 144, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 145, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 146, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 147, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 148, "f3d1e2c4-0000-0000-0000-000000000001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cashiers_Code",
                table: "Cashiers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cashiers_Name",
                table: "Cashiers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_Code",
                table: "CashRegisters",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_Name",
                table: "CashRegisters",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cashiers");

            migrationBuilder.DropTable(
                name: "CashRegisters");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 141, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 142, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 143, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 144, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 145, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 146, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 147, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 148, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DropColumn(
                name: "LastCost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "Products");
        }
    }
}
