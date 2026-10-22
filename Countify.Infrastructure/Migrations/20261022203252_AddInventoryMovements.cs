using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Countify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryMovements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CountsForStock",
                table: "InventoryMovementTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "InventoryAdjustmentAccountId",
                table: "CompanySettings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InventoryMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Correlativo = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Concept = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToWarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsTaxExempt = table.Column<bool>(type: "bit", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SourceRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JournalEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsVoided = table.Column<bool>(type: "bit", nullable: false),
                    VoidedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VoidReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_InventoryMovementTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "InventoryMovementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_InventoryMovements_SourceRequestId",
                        column: x => x.SourceRequestId,
                        principalTable: "InventoryMovements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_JournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_Warehouses_ToWarehouseId",
                        column: x => x.ToWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryMovementLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(9,4)", precision: 9, scale: 4, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMovementLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryMovementLines_InventoryMovements_MovementId",
                        column: x => x.MovementId,
                        principalTable: "InventoryMovements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryMovementLines_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMovementLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 135, "Ver movimientos de inventario.", "CanViewInventoryMovements" },
                    { 136, "Crear movimientos de inventario.", "CanCreateInventoryMovements" },
                    { 137, "Editar/eliminar movimientos de inventario.", "CanEditInventoryMovements" },
                    { 138, "Anular movimientos de inventario.", "CanVoidInventoryMovements" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 135, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 136, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 137, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 138, "f3d1e2c4-0000-0000-0000-000000000001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanySettings_InventoryAdjustmentAccountId",
                table: "CompanySettings",
                column: "InventoryAdjustmentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovementLines_LocationId",
                table: "InventoryMovementLines",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovementLines_MovementId_Order",
                table: "InventoryMovementLines",
                columns: new[] { "MovementId", "Order" });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovementLines_ProductId",
                table: "InventoryMovementLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_Code",
                table: "InventoryMovements",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_DepartmentId",
                table: "InventoryMovements",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_JournalEntryId",
                table: "InventoryMovements",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_SourceRequestId",
                table: "InventoryMovements",
                column: "SourceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_ToWarehouseId",
                table: "InventoryMovements",
                column: "ToWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_TypeId_Correlativo",
                table: "InventoryMovements",
                columns: new[] { "TypeId", "Correlativo" });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_WarehouseId",
                table: "InventoryMovements",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySettings_Accounts_InventoryAdjustmentAccountId",
                table: "CompanySettings",
                column: "InventoryAdjustmentAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanySettings_Accounts_InventoryAdjustmentAccountId",
                table: "CompanySettings");

            migrationBuilder.DropTable(
                name: "InventoryMovementLines");

            migrationBuilder.DropTable(
                name: "InventoryMovements");

            migrationBuilder.DropIndex(
                name: "IX_CompanySettings_InventoryAdjustmentAccountId",
                table: "CompanySettings");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 135, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 136, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 137, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 138, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DropColumn(
                name: "CountsForStock",
                table: "InventoryMovementTypes");

            migrationBuilder.DropColumn(
                name: "InventoryAdjustmentAccountId",
                table: "CompanySettings");
        }
    }
}
