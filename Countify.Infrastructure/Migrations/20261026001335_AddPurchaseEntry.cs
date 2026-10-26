using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Countify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPurchaseEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InventoryMovementId",
                table: "PayableDocuments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPurchaseEntry",
                table: "PayableDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "WarehouseId",
                table: "PayableDocuments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayableDocuments_InventoryMovementId",
                table: "PayableDocuments",
                column: "InventoryMovementId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableDocuments_WarehouseId",
                table: "PayableDocuments",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayableDocuments_InventoryMovements_InventoryMovementId",
                table: "PayableDocuments",
                column: "InventoryMovementId",
                principalTable: "InventoryMovements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PayableDocuments_Warehouses_WarehouseId",
                table: "PayableDocuments",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayableDocuments_InventoryMovements_InventoryMovementId",
                table: "PayableDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_PayableDocuments_Warehouses_WarehouseId",
                table: "PayableDocuments");

            migrationBuilder.DropIndex(
                name: "IX_PayableDocuments_InventoryMovementId",
                table: "PayableDocuments");

            migrationBuilder.DropIndex(
                name: "IX_PayableDocuments_WarehouseId",
                table: "PayableDocuments");

            migrationBuilder.DropColumn(
                name: "InventoryMovementId",
                table: "PayableDocuments");

            migrationBuilder.DropColumn(
                name: "IsPurchaseEntry",
                table: "PayableDocuments");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "PayableDocuments");
        }
    }
}
