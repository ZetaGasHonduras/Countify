using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Countify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReceivableFiscalNotesAndAttachments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppliesToReceivableId",
                table: "BankTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "BankTransactions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountsReceivableConcepts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false),
                    GeneratePosting = table.Column<bool>(type: "bit", nullable: false),
                    IsReceipt = table.Column<bool>(type: "bit", nullable: false),
                    IsFiscalNote = table.Column<bool>(type: "bit", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsReceivableConcepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountsReceivableConcepts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountingAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerTypes_Accounts_AccountingAccountId",
                        column: x => x.AccountingAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FiscalControls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmissionPoint = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DocumentCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CAI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RangeFrom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RangeTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmissionLimitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastNumber = table.Column<int>(type: "int", nullable: false),
                    WarningNumber = table.Column<int>(type: "int", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalControls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaxId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IdentityDocument = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreditDays = table.Column<int>(type: "int", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AccountingAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Accounts_AccountingAccountId",
                        column: x => x.AccountingAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountsReceivableDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsVoided = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptNumber = table.Column<int>(type: "int", nullable: true),
                    ReceiptNumberAssigned = table.Column<bool>(type: "bit", nullable: false),
                    JournalEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FiscalControlId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NoteNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvoiceCAI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CAI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RangeFrom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RangeTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmissionLimitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditNoteReason = table.Column<int>(type: "int", nullable: true),
                    FiscalConcept = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsReceivableDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountsReceivableDocuments_AccountsReceivableConcepts_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "AccountsReceivableConcepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountsReceivableDocuments_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountsReceivableDocuments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountsReceivableDocuments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountsReceivableDocuments_FiscalControls_FiscalControlId",
                        column: x => x.FiscalControlId,
                        principalTable: "FiscalControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountsReceivableDocuments_JournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountsReceivableDocuments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountsReceivableDocumentAttachments",
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
                    table.PrimaryKey("PK_AccountsReceivableDocumentAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountsReceivableDocumentAttachments_AccountsReceivableDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "AccountsReceivableDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountsReceivableDocumentLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppliedDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsReceivableDocumentLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountsReceivableDocumentLines_AccountsReceivableDocuments_AppliedDocumentId",
                        column: x => x.AppliedDocumentId,
                        principalTable: "AccountsReceivableDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountsReceivableDocumentLines_AccountsReceivableDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "AccountsReceivableDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 73, "Ver tipos de cliente.", "CanViewCustomerTypes" },
                    { 74, "Crear tipos de cliente.", "CanCreateCustomerTypes" },
                    { 75, "Editar tipos de cliente.", "CanEditCustomerTypes" },
                    { 76, "Eliminar tipos de cliente.", "CanDeleteCustomerTypes" },
                    { 77, "Ver clientes.", "CanViewCustomers" },
                    { 78, "Crear clientes.", "CanCreateCustomers" },
                    { 79, "Editar clientes.", "CanEditCustomers" },
                    { 80, "Eliminar clientes.", "CanDeleteCustomers" },
                    { 81, "Ver conceptos de cuentas por cobrar.", "CanViewAccountsReceivableConcepts" },
                    { 82, "Crear conceptos de cuentas por cobrar.", "CanCreateAccountsReceivableConcepts" },
                    { 83, "Editar conceptos de cuentas por cobrar.", "CanEditAccountsReceivableConcepts" },
                    { 84, "Eliminar conceptos de cuentas por cobrar.", "CanDeleteAccountsReceivableConcepts" },
                    { 85, "Ver documentos por cobrar.", "CanViewAccountsReceivableDocuments" },
                    { 86, "Crear documentos por cobrar.", "CanCreateAccountsReceivableDocuments" },
                    { 87, "Editar documentos por cobrar.", "CanEditAccountsReceivableDocuments" },
                    { 88, "Anular documentos por cobrar.", "CanVoidAccountsReceivableDocuments" },
                    { 89, "Ver controles fiscales.", "CanViewFiscalControls" },
                    { 90, "Crear controles fiscales.", "CanCreateFiscalControls" },
                    { 91, "Editar controles fiscales.", "CanEditFiscalControls" },
                    { 92, "Eliminar controles fiscales.", "CanDeleteFiscalControls" },
                    { 93, "Editar el correlativo de recibo.", "CanEditReceiptNumber" },
                    { 94, "Gestionar adjuntos de documentos por cobrar.", "CanManageAccountsReceivableAttachments" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 73, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 74, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 75, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 76, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 77, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 78, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 79, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 80, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 81, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 82, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 83, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 84, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 85, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 86, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 87, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 88, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 89, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 90, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 91, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 92, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 93, "f3d1e2c4-0000-0000-0000-000000000001" },
                    { 94, "f3d1e2c4-0000-0000-0000-000000000001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableConcepts_AccountId",
                table: "AccountsReceivableConcepts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocumentAttachments_DocumentId",
                table: "AccountsReceivableDocumentAttachments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocumentLines_AppliedDocumentId",
                table: "AccountsReceivableDocumentLines",
                column: "AppliedDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocumentLines_DocumentId_AppliedDocumentId",
                table: "AccountsReceivableDocumentLines",
                columns: new[] { "DocumentId", "AppliedDocumentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocuments_ConceptId",
                table: "AccountsReceivableDocuments",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocuments_CurrencyId",
                table: "AccountsReceivableDocuments",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocuments_CustomerId",
                table: "AccountsReceivableDocuments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocuments_DepartmentId",
                table: "AccountsReceivableDocuments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocuments_DocumentNo",
                table: "AccountsReceivableDocuments",
                column: "DocumentNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocuments_FiscalControlId",
                table: "AccountsReceivableDocuments",
                column: "FiscalControlId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocuments_JournalEntryId",
                table: "AccountsReceivableDocuments",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocuments_NoteNumber",
                table: "AccountsReceivableDocuments",
                column: "NoteNumber",
                unique: true,
                filter: "[NoteNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocuments_ProjectId",
                table: "AccountsReceivableDocuments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsReceivableDocuments_ReceiptNumber",
                table: "AccountsReceivableDocuments",
                column: "ReceiptNumber",
                unique: true,
                filter: "[ReceiptNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountingAccountId",
                table: "Customers",
                column: "AccountingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Code",
                table: "Customers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTypes_AccountingAccountId",
                table: "CustomerTypes",
                column: "AccountingAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTypes_Code",
                table: "CustomerTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FiscalControls_DocumentType",
                table: "FiscalControls",
                column: "DocumentType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsReceivableDocumentAttachments");

            migrationBuilder.DropTable(
                name: "AccountsReceivableDocumentLines");

            migrationBuilder.DropTable(
                name: "AccountsReceivableDocuments");

            migrationBuilder.DropTable(
                name: "AccountsReceivableConcepts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "FiscalControls");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 73, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 74, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 75, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 76, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 77, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 78, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 79, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 80, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 81, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 82, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 83, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 84, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 85, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 86, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 87, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 88, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 89, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 90, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 91, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 92, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 93, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 94, "f3d1e2c4-0000-0000-0000-000000000001" });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DropColumn(
                name: "AppliesToReceivableId",
                table: "BankTransactions");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "BankTransactions");
        }
    }
}
