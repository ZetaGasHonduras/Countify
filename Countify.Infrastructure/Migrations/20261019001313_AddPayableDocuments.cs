using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Countify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPayableDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayableDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConceptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AppliesTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxLocal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsVoided = table.Column<bool>(type: "bit", nullable: false),
                    SupplierRegistration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupplierAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CAI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RangeFrom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RangeTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Correlative = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmissionLimitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JournalEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayableDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayableDocuments_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayableDocuments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayableDocuments_JournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayableDocuments_PayableConcepts_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "PayableConcepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayableDocuments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayableDocuments_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayableDocumentAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    StoragePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UploadedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayableDocumentAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayableDocumentAttachments_PayableDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "PayableDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayableDocumentLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppliedDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayableDocumentLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayableDocumentLines_PayableDocuments_AppliedDocumentId",
                        column: x => x.AppliedDocumentId,
                        principalTable: "PayableDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayableDocumentLines_PayableDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "PayableDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 107, "Ver documentos por pagar.", "CanViewPayableDocuments" },
                    { 108, "Crear documentos por pagar.", "CanCreatePayableDocuments" },
                    { 109, "Editar documentos por pagar.", "CanEditPayableDocuments" },
                    { 110, "Anular documentos por pagar.", "CanVoidPayableDocuments" },
                    { 111, "Gestionar adjuntos de documentos por pagar.", "CanManagePayableAttachments" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 107, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 108, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 109, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 110, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 111, "f3d1e2c4-0000-0000-0000-000000000001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayableDocumentAttachments_DocumentId",
                table: "PayableDocumentAttachments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableDocumentLines_AppliedDocumentId",
                table: "PayableDocumentLines",
                column: "AppliedDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableDocumentLines_DocumentId_AppliedDocumentId",
                table: "PayableDocumentLines",
                columns: new[] { "DocumentId", "AppliedDocumentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayableDocuments_ConceptId",
                table: "PayableDocuments",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableDocuments_CurrencyId",
                table: "PayableDocuments",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableDocuments_DepartmentId",
                table: "PayableDocuments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableDocuments_DocumentNo",
                table: "PayableDocuments",
                column: "DocumentNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayableDocuments_JournalEntryId",
                table: "PayableDocuments",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableDocuments_ProjectId",
                table: "PayableDocuments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableDocuments_SupplierId",
                table: "PayableDocuments",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayableDocumentAttachments");

            migrationBuilder.DropTable(
                name: "PayableDocumentLines");

            migrationBuilder.DropTable(
                name: "PayableDocuments");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 107, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 108, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 109, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 110, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 111, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 111);
        }
    }
}
