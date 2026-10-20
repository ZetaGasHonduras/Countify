# Graph Report - Countify  (2026-10-15)

## Corpus Check
- 434 files · ~83,969 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 2, .user 1)

## Summary
- 4121 nodes · 8208 edges · 250 communities (230 shown, 20 thin omitted)
- Extraction: 95% EXTRACTED · 5% INFERRED · 0% AMBIGUOUS · INFERRED: 384 edges (avg confidence: 0.86)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `82c09938`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- Countify.Domain.Interfaces
- CatalogSeeder
- UpdateCompanySettingsCommand
- CountifyDbContext
- UpdateDepartmentCommand
- PaginatedResponse
- microsoft_entityframeworkcore
- UpdateProductCommand
- Response
- CustomerTypeDto
- JournalEntry
- JournalEntriesController
- UpdateSupplierTypeCommand
- IRequest
- .AddApiServices
- .Delete
- Repository
- CurrencyFeatures.cs
- .HandleResult
- Permission
- BankTransaction
- GetTrialBalanceQuery
- CompanySettingsDto
- UnitOfWork
- ValidationException
- AccountMovementsResponse
- BudgetLine
- IUnitOfWork
- HistoryDto
- IEntityTypeConfiguration
- Countify.Infrastructure
- AuthResponse
- JournalEntryLine
- AccountsReceivableDocumentDraftRequest
- QualitiesController.cs
- BankTransactionDto
- UserDto
- ProductAccount
- ApiKeyAuthenticationHandler
- JournalEntryDto
- CompanySettings
- SupplierFiscalData
- UpdateJournalEntryCommand
- JournalEntryLineDto
- CreateAccountCommand
- Countify.Domain.Entities.Accounting
- AccountDto
- BankAccountDto
- CreateJournalEntryCommand
- BankAccount
- ApplicationUser
- BudgetsController
- Supplier
- UpdateUserCommand
- ProductAccountDto
- GetRoleByIdQueryHandler
- CustomerType
- UsersController.cs
- CreateCustomerCommand
- .SaveChangesAsync
- Budget
- Countify.Domain.Enums
- DocumentTypeDto
- CustomerMovementDto
- AccountingPeriod
- http
- JournalEntryLineRequest
- .CreateOrUpdatePostingAsync
- UsersController
- Countify.Infrastructure.Migrations
- PermissionAuthorizationHandler.cs
- AccountsController
- AccountingPeriodDto
- CreateAccountsReceivableConceptCommand
- AccountsReceivableDocumentDto
- GetUserByIdQueryHandler
- UploadAccountsReceivableDocumentAttachmentCommand
- BankReconciliation
- AccountsReceivableDocument
- GetProjectsQuery
- GetIncomeStatementQuery
- UpdateAccountCommand
- RolesController
- AuthController.cs
- CustomerDto
- AccountsReceivableDocumentAttachment
- UpdateAccountsReceivableDocumentCommand
- UpdateCustomerCommand
- FiscalControlDto
- BaseEntity
- GetJournalEntriesQuery
- UpdateQualityCommand
- RoleDto
- RolesController.cs
- Migration
- DatabaseExtensions.cs
- Countify.Domain.Seeders
- UserRoleHasPermissionRequirement
- YearEndClosingEntry
- .Up
- AddBanksAndBankReconciliation
- DepartmentsController.cs
- GetAccountsQuery
- AccountsReceivableConcept
- CreateAccountsReceivableDocumentCommand
- GetJournalEntryByIdQuery
- CustomerAgingDetailDto
- BudgetLineRequest
- Customer
- UpdateFiscalControlCommand
- UpdateRoleCommand
- AccountsReceivableDocumentsController
- SourceModule
- .Delete
- DeleteRoleCommandHandler
- .GetCurrentUser
- fluentvalidation
- CreateProjectCommand
- .Validate
- AccountsReceivableDocumentLineDto
- UpdateAccountsReceivableConceptCommand
- AssignRoleCommand
- RequestParameter
- ProductsController.cs
- .OnModelCreating
- CreateProjectGroupCommand
- .Delete
- IEmailService
- CreateSupplierTypeCommand
- .Close
- .ValidateAsync
- AddBudgetsAndBudgetPermissions
- .BuildSection
- CreateFiscalControlCommand
- Seeding — GENERALIZADO (base para futuras entidades/fases)
- IncomeStatementLineDto
- History
- .BuildModel
- CustomerMovementApplicationDto
- IncomeStatementDto
- JournalEntryStatus
- AccountsController.cs
- Countify.Api.Controllers
- CustomerAgingDto
- BaseController
- BankTransactionType
- UpdateDocumentTypeCommand
- GetProductAccountsQuery.cs
- AuthController
- .Delete
- SettingsController.cs
- mediatr
- CreateAccountsReceivableDocumentLinesCommand
- microsoft_aspnetcore_authorization
- FiscalControl
- 4. Qué falta implementar (backend)
- DocumentTypesController.cs
- TrialBalanceLineDto
- CreateCustomerTypeCommand
- UpdateProductAccountCommand
- TransactionSeeder
- CustomerMovementsDto
- GetCustomerMovementsQuery
- CreateDepartmentCommand
- Flujo bancario
- BudgetRequest
- DeleteJournalEntryCommand
- UpdateCustomerTypeCommand
- AccountsReceivableConceptsController.cs
- .SaveChangesAsync
- FiscalControlsController.cs
- GetPendingAccountsReceivableDocumentsQuery
- .Delete
- AccountsReceivableDocumentLine
- EntryConceptType
- countify_application_features_accountsreceivabledocuments_commands_createaccountsreceivabledocumentlines
- CreateRoleCommand
- Profile
- .Delete
- AccountsReceivableDocumentAttachmentDto
- SupplierTypesController.cs
- DeleteAccountingPeriodCommand
- GetAccountsReceivableDocumentByIdQuery
- AccountMovementDto
- GetCustomersQueryHandler
- .SeedDatabase
- 20260919192955_RenameBankOpeningBalanceToBalance.Designer.cs
- Cuentas por Cobrar (FASE 3 del roadmap maestro) — plan de cierre
- RolePermission
- FixBankCurrencyForeignKeys
- IRequestHandler
- ProjectGroupsController.cs
- UpdateAccountsReceivableDocumentLineCommand
- .ValidateAsync
- GetEntityHistory.cs
- CustomerTypePolicies.cs
- UpdateProjectCommand
- 2. Entidades legacy (campos)
- CustomersController.cs
- GetAccountsReceivableDocumentsQueryHandler
- UpdateRolePermissionsCommand
- ChangePasswordCommand
- DeleteProjectGroupCommand
- CreateAccountingPeriodCommand
- GetAccountByIdQuery
- .AssignAsync
- .ApplyOrder
- DeleteAccountsReceivableDocumentLineCommand
- GetUserInfoQueryHandler
- CloseAccountingPeriodCommand
- DeleteAccountCommand
- VoidAccountsReceivableDocumentCommand
- VoidJournalEntryCommand
- DeleteProjectCommand
- DeleteDepartmentCommand
- ResetPasswordRequest
- DeleteSupplierTypeCommand
- DeleteProductCommand
- .ValidateAsync
- .CreateAsync
- DeleteProductAccountCommand
- BankPolicies.cs
- DeleteQualityCommand
- DeleteUserCommand
- FiscalDocumentType
- .BuildTargetModel
- .BuildTargetModel
- .Up
- DepartmentPolicies.cs
- .BuildTargetModel
- AccountPolicies.cs
- AccountsReceivableDocumentPolicies.cs
- JournalEntryPolicies.cs
- LoginRequest
- IConfigureOptions
- RefreshTokenRequest
- OrderColumns
- countify_api_authorization_handlers
- countify_api_authorization_requirements
- countify_application_features_accountsreceivabledocuments_commands_deleteaccountsreceivabledocumentline
- countify_application_features_accountsreceivabledocuments_commands_updateaccountsreceivabledocumentline
- countify_application_features_accountsreceivabledocuments_commands_voidaccountsreceivabledocument
- countify_application_features_accountsreceivabledocuments_queries_getaccountsreceivabledocuments
- countify_application_features_accountsreceivabledocuments_queries_getpendingaccountsreceivabledocuments
- countify_application_wrappers
- countify_domain_common
- countify_domain_entities_audit
- countify_domain_entities_auth
- countify_infrastructure_seeders
- .Up

## God Nodes (most connected - your core abstractions)
1. `Response` - 324 edges
2. `IUnitOfWork` - 176 edges
3. `Countify.Domain.Interfaces` - 109 edges
4. `Countify.Application.Wrappers` - 107 edges
5. `Countify.Domain.Entities.Accounting` - 106 edges
6. `CountifyDbContext` - 88 edges
7. `UnitOfWork` - 76 edges
8. `AccountsReceivableDocument` - 66 edges
9. `AccountsReceivableDocumentDto` - 56 edges
10. `BankTransaction` - 49 edges

## Surprising Connections (you probably didn't know these)
- `Modelo contable (FASE 1 — corregido)` --references--> `CompanySettings`  [INFERRED]
  AGENTS.md → Countify.Domain/Entities/Accounting/CompanySettings.cs
- `2.4 `CXPDocumentos` (Movimiento de CxP) — clase base` --references--> `FiscalControl`  [INFERRED]
  AccountsPayable-Fase4-Plan.md → Countify.Domain/Entities/Accounting/FiscalControl.cs
- `4.6 Adjuntos` --references--> `AccountsReceivableDocumentAttachment`  [INFERRED]
  AccountsReceivable-Fase3-Plan.md → Countify.Domain/Entities/AccountsReceivable/AccountsReceivableDocumentAttachment.cs
- `1. Alcance del roadmap` --references--> `AccountsReceivableDocumentLine`  [INFERRED]
  AccountsPayable-Fase4-Plan.md → Countify.Domain/Entities/AccountsReceivable/AccountsReceivableDocumentLine.cs
- `2.2 `Tiposproveedor` (Tipo de proveedor)` --references--> `CustomerType`  [INFERRED]
  AccountsPayable-Fase4-Plan.md → Countify.Domain/Entities/AccountsReceivable/CustomerType.cs

## Import Cycles
- None detected.

## Communities (250 total, 20 thin omitted)

### Community 0 - "Countify.Domain.Interfaces"
Cohesion: 0.06
Nodes (23): automapper, AccountsReceivableConceptProfile, AccountsReceivableDocumentProfile, Countify.Application.Features.AccountsReceivableDocuments.Queries.GetAccountsReceivableDocumentById, Countify.Application.Features.AccountsReceivableConcepts.Profiles, Countify.Application.Features.AccountsReceivableDocuments.Queries.GetCustomerMovements, Countify.Application.Features.AccountsReceivableDocuments.Commands.UpdateReceiptNumber, Countify.Application.Features.AccountsReceivableConcepts.DTOs (+15 more)

### Community 1 - "CatalogSeeder"
Cohesion: 0.35
Nodes (5): CatalogSeeder, CancellationToken, ILogger, IOptions, Task

### Community 2 - "UpdateCompanySettingsCommand"
Cohesion: 0.09
Nodes (22): UpdateCompanySettingsCommand, Address, CompanyName, DefaultDepartmentId, DefaultProjectId, Email, FiscalYear, Mobile (+14 more)

### Community 3 - "CountifyDbContext"
Cohesion: 0.04
Nodes (46): CountifyDbContext, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentAttachments, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts (+38 more)

### Community 4 - "UpdateDepartmentCommand"
Cohesion: 0.08
Nodes (29): DepartmentsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+21 more)

### Community 5 - "PaginatedResponse"
Cohesion: 0.15
Nodes (15): GetProductAccountsQuery, Search, GetProductAccountsQueryHandler, CancellationToken, IMapper, List, Task, PaginatedResponse (+7 more)

### Community 6 - "microsoft_entityframeworkcore"
Cohesion: 0.15
Nodes (3): Countify.Infrastructure.Persistence.Configurations, microsoft_entityframeworkcore, microsoft_entityframeworkcore_metadata_builders

### Community 7 - "UpdateProductCommand"
Cohesion: 0.07
Nodes (37): ProductsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+29 more)

### Community 8 - "Response"
Cohesion: 0.05
Nodes (49): DeleteAccountsReceivableConceptCommand, Id, DeleteAccountsReceivableConceptCommandHandler, CancellationToken, Guid, Task, UpdateReceiptNumberCommand, Id (+41 more)

### Community 9 - "CustomerTypeDto"
Cohesion: 0.18
Nodes (14): CustomerTypeDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Code, Id, Name, Guid (+6 more)

### Community 10 - "JournalEntry"
Cohesion: 0.06
Nodes (31): 4.2 Nueva entidad `FiscalControl` (← `ControlesFiscales`), DocumentType, Code, IsDefault, Name, JournalEntry, Code, Concept (+23 more)

### Community 11 - "JournalEntriesController"
Cohesion: 0.33
Nodes (9): JournalEntriesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 12 - "UpdateSupplierTypeCommand"
Cohesion: 0.07
Nodes (34): SupplierTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+26 more)

### Community 13 - "IRequest"
Cohesion: 0.10
Nodes (52): BankHandler, BankReconciliationDto, BankAccountId, BankAccountName, BookBalance, Id, IsClosed, Notes (+44 more)

### Community 14 - ".AddApiServices"
Cohesion: 0.22
Nodes (6): BudgetPolicies, AuthorizationOptions, CompanySettingsPolicies, AuthorizationOptions, IServiceCollection, IAuthorizationHandler

### Community 15 - ".Delete"
Cohesion: 0.28
Nodes (9): ProjectsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 16 - "Repository"
Cohesion: 0.11
Nodes (20): IRepository, CancellationToken, Expression, Func, Guid, IEnumerable, IQueryable, List (+12 more)

### Community 17 - "CurrencyFeatures.cs"
Cohesion: 0.13
Nodes (25): CurrenciesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+17 more)

### Community 18 - ".HandleResult"
Cohesion: 0.26
Nodes (11): BanksController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+3 more)

### Community 19 - "Permission"
Cohesion: 0.16
Nodes (10): CurrencyPolicies, AuthorizationOptions, Permissions, Items, Permission, Description, Id, Name (+2 more)

### Community 20 - "BankTransaction"
Cohesion: 0.06
Nodes (32): BankTransaction, Amount, AppliesToReceivableId, BankAccount, BankAccountId, BankReconciliation, BankReconciliationId, Beneficiary (+24 more)

### Community 21 - "GetTrialBalanceQuery"
Cohesion: 0.16
Nodes (14): TrialBalanceDto, CreditTotal, DebitTotal, Difference, Lines, List, GetTrialBalanceQuery, DepartmentId (+6 more)

### Community 22 - "CompanySettingsDto"
Cohesion: 0.05
Nodes (37): CompanySettingsDto, Address, CompanyName, DefaultDepartmentId, DefaultProjectId, Email, FiscalYear, Id (+29 more)

### Community 23 - "UnitOfWork"
Cohesion: 0.04
Nodes (46): UnitOfWork, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentAttachments, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts (+38 more)

### Community 24 - "ValidationException"
Cohesion: 0.08
Nodes (24): ExceptionHandlerMiddleware, Exception, ILogger, Task, ValidationBehavior, CancellationToken, IEnumerable, Task (+16 more)

### Community 25 - "AccountMovementsResponse"
Cohesion: 0.13
Nodes (16): AccountMovementsResponse, AccountCode, AccountId, AccountName, Balance, CreditTotal, DebitTotal, Movements (+8 more)

### Community 26 - "BudgetLine"
Cohesion: 0.09
Nodes (23): BudgetLine, Account, AccountId, April, August, Budget, BudgetId, December (+15 more)

### Community 27 - "IUnitOfWork"
Cohesion: 0.04
Nodes (46): IUnitOfWork, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentAttachments, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts (+38 more)

### Community 28 - "HistoryDto"
Cohesion: 0.08
Nodes (26): HistoryController, Authorize, HttpGet, IActionResult, Task, HistoryDto, Date, Entity (+18 more)

### Community 29 - "IEntityTypeConfiguration"
Cohesion: 0.08
Nodes (24): Account, BudgetControlled, Code, IsAuxAsset, IsAuxCxc, IsAuxCxp, IsAuxLoan, IsBankAccount (+16 more)

### Community 30 - "Countify.Infrastructure"
Cohesion: 0.08
Nodes (29): Countify.Api, net10.0, Countify.Application, net10.0, Microsoft.NET.Sdk, Countify.Domain, net10.0, Microsoft.NET.Sdk (+21 more)

### Community 31 - "AuthResponse"
Cohesion: 0.08
Nodes (28): IJwtService, IList, LoginCommand, LoginCommandHandler, CancellationToken, IdentityRole, RoleManager, Task (+20 more)

### Community 32 - "JournalEntryLine"
Cohesion: 0.08
Nodes (26): JournalEntryLine, Account, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName (+18 more)

### Community 33 - "AccountsReceivableDocumentDraftRequest"
Cohesion: 0.12
Nodes (15): AccountsReceivableDocumentDraftRequest, Amount, AppliesTo, ConceptId, CurrencyId, CustomerId, Date, DepartmentId (+7 more)

### Community 34 - "QualitiesController.cs"
Cohesion: 0.16
Nodes (7): QualityProfile, Countify.Application.Features.Qualities.DTOs, Countify.Application.Features.Qualities.Commands.UpdateQuality, Countify.Application.Features.Qualities.Commands.CreateQuality, Countify.Application.Features.Qualities.Commands.DeleteQuality, Countify.Application.Features.Qualities.Queries.GetQualities, Countify.Application.Features.Qualities.Profiles

### Community 35 - "BankTransactionDto"
Cohesion: 0.08
Nodes (25): BankTransactionDto, Amount, AppliesToReceivableId, BankAccountId, BankAccountName, BankReconciliationId, Beneficiary, Concept (+17 more)

### Community 36 - "UserDto"
Cohesion: 0.11
Nodes (22): UserDto, CreatedAt, Email, FirstName, FullName, Id, IsActive, LastName (+14 more)

### Community 37 - "ProductAccount"
Cohesion: 0.07
Nodes (26): Product, Code, Name, ProductAccount, CostAccount, CostAccountId, IncomeAccount, IncomeAccountId (+18 more)

### Community 38 - "ApiKeyAuthenticationHandler"
Cohesion: 0.07
Nodes (25): AuthenticateResult, AuthenticationHandler, AuthenticationProperties, AuthenticationSchemeOptions, AuthorizeAttribute, ApiKeyAuthenticationDefaults, ApiKeyAuthenticationHandler, IOptions (+17 more)

### Community 39 - "JournalEntryDto"
Cohesion: 0.09
Nodes (22): JournalEntryDto, Code, Concept, CreditTotal, DebitTotal, DifferenceAmount, EntryNumber, Gid (+14 more)

### Community 40 - "CompanySettings"
Cohesion: 0.09
Nodes (23): CompanySettings, Address, CompanyName, DefaultDepartment, DefaultDepartmentId, DefaultProject, DefaultProjectId, Email (+15 more)

### Community 41 - "SupplierFiscalData"
Cohesion: 0.07
Nodes (32): 1. Alcance del roadmap, 3.1 Enum invertido, 3.2 Dependencia con Inventarios (FASE 6), 3.3 Datos fiscales del proveedor, 3.4 Impuestos, 3.5 Estado de cuenta con antigüedad, 3.6 Snapshot vs lectura viva, 3. Decisiones de modelado y riesgos (+24 more)

### Community 42 - "UpdateJournalEntryCommand"
Cohesion: 0.12
Nodes (18): UpdateJournalEntryCommand, Code, Concept, Id, Lines, Observations, PeriodId, Reference (+10 more)

### Community 43 - "JournalEntryLineDto"
Cohesion: 0.10
Nodes (19): JournalEntryLineDto, AccountCode, AccountId, AccountName, AppliesToPayableId, AppliesToReceivableId, Concept, Credit (+11 more)

### Community 44 - "CreateAccountCommand"
Cohesion: 0.12
Nodes (18): CreateAccountCommand, BudgetControlled, BudgetLine, Code, IsAuxAsset, IsAuxCxc, IsAuxCxp, IsAuxLoan (+10 more)

### Community 45 - "Countify.Domain.Entities.Accounting"
Cohesion: 0.10
Nodes (5): Countify.Domain.Entities.Audit, Countify.Domain.Common, Countify.Domain.Entities.AccountsPayable, Countify.Domain.Entities.Accounting, microsoft_aspnetcore_identity_entityframeworkcore

### Community 46 - "AccountDto"
Cohesion: 0.11
Nodes (18): AccountDto, Balance, BudgetControlled, BudgetLine, Code, Id, IsAuxAsset, IsAuxCxc (+10 more)

### Community 47 - "BankAccountDto"
Cohesion: 0.11
Nodes (19): BankAccountDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, AccountNumber, Balance, CheckNumber, Code (+11 more)

### Community 48 - "CreateJournalEntryCommand"
Cohesion: 0.12
Nodes (20): CreateJournalEntryCommand, Code, Concept, Lines, Observations, PeriodId, Reference, ReferenceDate (+12 more)

### Community 49 - "BankAccount"
Cohesion: 0.08
Nodes (23): BankAccount, AccountingAccount, AccountingAccountId, AccountNumber, Balance, CheckNumber, Code, Currency (+15 more)

### Community 50 - "ApplicationUser"
Cohesion: 0.06
Nodes (36): ForgotPasswordCommand, ForgotPasswordCommandHandler, CancellationToken, Task, UserManager, CreateUserCommand, Email, FirstName (+28 more)

### Community 51 - "BudgetsController"
Cohesion: 0.22
Nodes (13): BudgetRequest, BudgetResponse, BudgetLineResponse, BudgetsController, Authorize, CancellationToken, Guid, HttpDelete (+5 more)

### Community 52 - "Supplier"
Cohesion: 0.08
Nodes (26): Supplier, AccountingAccount, AccountingAccountId, Address, City, Code, ContactEmail, ContactName (+18 more)

### Community 53 - "UpdateUserCommand"
Cohesion: 0.13
Nodes (15): UpdateUserCommand, Email, FirstName, Id, IsActive, LastName, Phone, RoleId (+7 more)

### Community 54 - "ProductAccountDto"
Cohesion: 0.11
Nodes (17): ProductAccountDto, CostAccountCode, CostAccountId, CostAccountName, Id, IncomeAccountCode, IncomeAccountId, IncomeAccountName (+9 more)

### Community 55 - "GetRoleByIdQueryHandler"
Cohesion: 0.14
Nodes (13): PermissionDto, Description, Id, Name, RoleDetailDto, Permissions, IList, GetRoleByIdQueryHandler (+5 more)

### Community 56 - "CustomerType"
Cohesion: 0.33
Nodes (5): CustomerType, BasicCustomerTypes, Items, CustomerTypeConfiguration, EntityTypeBuilder

### Community 57 - "UsersController.cs"
Cohesion: 0.11
Nodes (12): AssignRoleCommandValidator, ChangePasswordCommandValidator, CreateUserCommandValidator, DeleteUserCommandValidator, UpdateUserCommandValidator, Countify.Application.Features.Users.Commands.UpdateUser, Countify.Application.Features.Users.Commands.DeleteUser, Countify.Application.Features.Users.Commands.CreateUser (+4 more)

### Community 58 - "CreateCustomerCommand"
Cohesion: 0.12
Nodes (18): CreateCustomerCommand, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId, Email (+10 more)

### Community 59 - ".SaveChangesAsync"
Cohesion: 0.15
Nodes (7): CancellationToken, List, Task, CancellationToken, Task, CancellationToken, Task

### Community 60 - "Budget"
Cohesion: 0.14
Nodes (13): BudgetLine, Budget, FiscalYear, Lines, Name, List, BasicBudgets, Items (+5 more)

### Community 61 - "Countify.Domain.Enums"
Cohesion: 0.11
Nodes (11): JournalEntryProfile, Countify.Application.Features.JournalEntries.Commands.CreateJournalEntry, Countify.Application.Features.JournalEntries.DTOs, Countify.Application.Features.JournalEntries.Queries.GetAccountMovements, Countify.Application.Features.JournalEntries.Queries.GetJournalEntries, Countify.Application.Features.JournalEntries.Queries.GetJournalEntryById, Countify.Application.Features.JournalEntries.Profiles, Countify.Application.Features.AccountsReceivableDocuments (+3 more)

### Community 62 - "DocumentTypeDto"
Cohesion: 0.22
Nodes (12): DocumentTypeDto, Code, Id, IsDefault, Name, Guid, GetDocumentTypesQuery, GetDocumentTypesQueryHandler (+4 more)

### Community 63 - "CustomerMovementDto"
Cohesion: 0.10
Nodes (21): CustomerMovementDto, AgingBucket, Amount, AmountLocal, Applications, AppliedAmount, ConceptDescription, Credit (+13 more)

### Community 64 - "AccountingPeriod"
Cohesion: 0.16
Nodes (11): AccountingPeriod, EndDate, IsClosed, Month, StartDate, DateTime, BasicAccountingPeriods, Items (+3 more)

### Community 65 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 66 - "JournalEntryLineRequest"
Cohesion: 0.12
Nodes (16): JournalEntryLineRequest, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName, Debit (+8 more)

### Community 67 - ".CreateOrUpdatePostingAsync"
Cohesion: 0.18
Nodes (9): AccountsReceivablePostingFactory, CancellationToken, Task, Customer, BasicCustomers, CashCustomer, Items, CustomerConfiguration (+1 more)

### Community 68 - "UsersController"
Cohesion: 0.29
Nodes (9): UsersController, Authorize, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult, Task (+1 more)

### Community 69 - "Countify.Infrastructure.Migrations"
Cohesion: 0.25
Nodes (13): AddAccountingModule, AddReceivableFiscalNotesAndAttachments, AddSupplierTypesAndSuppliers, CountifyDbContextModelSnapshot, Countify.Infrastructure.Migrations, Countify.Infrastructure.Persistence, microsoft_entityframeworkcore_design, microsoft_entityframeworkcore_infrastructure (+5 more)

### Community 70 - "PermissionAuthorizationHandler.cs"
Cohesion: 0.13
Nodes (12): AuthorizationHandler, AuthorizationHandlerContext, PermissionAuthorizationHandler, Task, IPermissionService, HashSet, Task, PermissionService (+4 more)

### Community 71 - "AccountsController"
Cohesion: 0.32
Nodes (9): AccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 72 - "AccountingPeriodDto"
Cohesion: 0.18
Nodes (14): AccountingPeriodDto, EndDate, Id, IsClosed, Month, StartDate, DateTime, Guid (+6 more)

### Community 73 - "CreateAccountsReceivableConceptCommand"
Cohesion: 0.16
Nodes (14): CreateAccountsReceivableConceptCommand, AccountId, Description, GeneratePosting, IsFiscalNote, IsInactive, IsReceipt, Observations (+6 more)

### Community 74 - "AccountsReceivableDocumentDto"
Cohesion: 0.05
Nodes (43): AccountsReceivableDocumentDto, Amount, AmountLocal, AppliesTo, Attachments, CAI, ConceptDescription, ConceptId (+35 more)

### Community 75 - "GetUserByIdQueryHandler"
Cohesion: 0.18
Nodes (13): UserDetailDto, CreatedBy, LastActivity, DateTime, GetUserByIdQuery, Id, GetUserByIdQueryHandler, CancellationToken (+5 more)

### Community 76 - "UploadAccountsReceivableDocumentAttachmentCommand"
Cohesion: 0.05
Nodes (40): IFileStorage, CancellationToken, Stream, Task, DeleteAccountsReceivableDocumentAttachmentCommand, Id, DeleteAccountsReceivableDocumentAttachmentCommandHandler, CancellationToken (+32 more)

### Community 77 - "BankReconciliation"
Cohesion: 0.14
Nodes (14): BankReconciliation, BankAccount, BankAccountId, BookBalance, IsClosed, Notes, ReconciliationDate, StatementBalance (+6 more)

### Community 78 - "AccountsReceivableDocument"
Cohesion: 0.04
Nodes (47): AccountsReceivableDocument, Amount, AppliesTo, Attachments, CAI, Concept, ConceptId, CreditNoteReason (+39 more)

### Community 79 - "GetProjectsQuery"
Cohesion: 0.20
Nodes (13): ProjectDto, Code, GroupId, Id, Name, Guid, GetProjectsQuery, Search (+5 more)

### Community 80 - "GetIncomeStatementQuery"
Cohesion: 0.19
Nodes (11): GetIncomeStatementQuery, Date, DepartmentId, ProjectId, GetIncomeStatementQueryHandler, CancellationToken, DateTime, Guid (+3 more)

### Community 81 - "UpdateAccountCommand"
Cohesion: 0.13
Nodes (15): UpdateAccountCommand, BudgetControlled, BudgetLine, Code, Id, IsAuxAsset, IsAuxCxc, IsAuxCxp (+7 more)

### Community 82 - "RolesController"
Cohesion: 0.33
Nodes (8): RolesController, Authorize, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult, Task

### Community 83 - "AuthController.cs"
Cohesion: 0.14
Nodes (9): ForgotPasswordCommandValidator, LoginCommandValidator, RefreshTokenCommandValidator, ResetPasswordCommandValidator, Countify.Application.Features.Auth.Commands.Login, Countify.Application.Features.Auth.Commands.ResetPassword, Countify.Application.Features.Auth.Commands.ForgotPassword, Countify.Application.Features.Auth.Queries.GetUserInfo (+1 more)

### Community 84 - "CustomerDto"
Cohesion: 0.10
Nodes (20): CustomerDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Address, Code, CreditDays, CreditLimit (+12 more)

### Community 85 - "AccountsReceivableDocumentAttachment"
Cohesion: 0.13
Nodes (15): 2. Decisión de modelado (validada contra el legacy), Mapeo campo a campo (CXCDocumentos → AccountsReceivableDocument), AccountsReceivableDocumentAttachment, ContentType, Document, DocumentId, FileName, Size (+7 more)

### Community 86 - "UpdateAccountsReceivableDocumentCommand"
Cohesion: 0.11
Nodes (19): UpdateAccountsReceivableDocumentCommand, Amount, AppliesTo, ConceptId, CreditNoteReason, CurrencyId, CustomerId, Date (+11 more)

### Community 87 - "UpdateCustomerCommand"
Cohesion: 0.11
Nodes (19): UpdateCustomerCommand, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId, Email (+11 more)

### Community 88 - "FiscalControlDto"
Cohesion: 0.10
Nodes (24): FiscalControlDto, Branch, CAI, DocumentCode, DocumentType, DocumentTypeName, EmissionDate, EmissionLimitDate (+16 more)

### Community 89 - "BaseEntity"
Cohesion: 0.06
Nodes (31): BaseEntity, Id, Guid, Currency, Code, ExchangeRate, IsActive, Name (+23 more)

### Community 90 - "GetJournalEntriesQuery"
Cohesion: 0.21
Nodes (11): GetJournalEntriesQuery, FromDate, Search, Status, ToDate, GetJournalEntriesQueryHandler, CancellationToken, DateTime (+3 more)

### Community 91 - "UpdateQualityCommand"
Cohesion: 0.08
Nodes (29): QualitiesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+21 more)

### Community 92 - "RoleDto"
Cohesion: 0.24
Nodes (10): RoleDto, Id, Name, PermissionCount, GetRolesQuery, GetRolesQueryHandler, CancellationToken, IMapper (+2 more)

### Community 93 - "RolesController.cs"
Cohesion: 0.13
Nodes (10): CreateRoleCommandValidator, DeleteRoleCommandValidator, UpdateRoleCommandValidator, UpdateRolePermissionsCommandValidator, Countify.Application.Features.Roles.Commands.UpdateRole, Countify.Application.Features.Roles.Queries.GetRoles, Countify.Application.Features.Roles.Commands.DeleteRole, Countify.Application.Features.Roles.Commands.UpdateRolePermissions (+2 more)

### Community 94 - "Migration"
Cohesion: 0.15
Nodes (10): DateTime, DateTimeOffset, Guid, MigrationBuilder, InitialCreate, DateTime, DateTimeOffset, Guid (+2 more)

### Community 95 - "DatabaseExtensions.cs"
Cohesion: 0.13
Nodes (11): ApplicationServiceRegistration, IServiceCollection, Countify.Api.DependencyInjection, Countify.Application.DependencyInjection, Countify.Infrastructure.Extensions, Countify.Infrastructure.DependencyInjection, microsoft_extensions_dependencyinjection, microsoft_extensions_hosting (+3 more)

### Community 96 - "Countify.Domain.Seeders"
Cohesion: 0.31
Nodes (6): RolePolicies, AuthorizationOptions, Countify.Domain.Seeders, Countify.Infrastructure.Seeders, microsoft_extensions_logging, microsoft_extensions_options

### Community 97 - "UserRoleHasPermissionRequirement"
Cohesion: 0.11
Nodes (17): Arquitectura / capas, Contrato API (FASE 1), Countify — Convenciones del proyecto, Flujo de trabajo (obligatorio), Modelo contable (FASE 1 — corregido), Permisos (patrón de futuras fases también), DocumentTypePolicies, AuthorizationOptions (+9 more)

### Community 98 - "YearEndClosingEntry"
Cohesion: 0.20
Nodes (9): YearEndClosingEntry, GeneratedBy, JournalEntryId, PeriodId, Guid, BasicYearEndClosingEntries, Items, YearEndClosingEntryConfiguration (+1 more)

### Community 99 - ".Up"
Cohesion: 0.40
Nodes (3): DateTime, Guid, MigrationBuilder

### Community 100 - "AddBanksAndBankReconciliation"
Cohesion: 0.18
Nodes (8): DateTime, Guid, MigrationBuilder, AddBanksAndBankReconciliation, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 101 - "DepartmentsController.cs"
Cohesion: 0.22
Nodes (6): CreateDepartmentCommandValidator, UpdateDepartmentCommandValidator, Countify.Application.Features.Departments.Commands.UpdateDepartment, Countify.Application.Features.Departments.Commands.CreateDepartment, Countify.Application.Features.Departments.Queries.GetDepartments, Countify.Application.Features.Departments.Commands.DeleteDepartment

### Community 102 - "GetAccountsQuery"
Cohesion: 0.36
Nodes (8): GetAccountsQuery, IsOperable, Search, GetAccountsQueryHandler, CancellationToken, IMapper, List, Task

### Community 103 - "AccountsReceivableConcept"
Cohesion: 0.10
Nodes (19): AccountsReceivableConcept, Account, AccountId, Description, GeneratePosting, IsFiscalNote, IsInactive, IsReceipt (+11 more)

### Community 104 - "CreateAccountsReceivableDocumentCommand"
Cohesion: 0.10
Nodes (22): CreateAccountsReceivableDocumentCommand, Amount, AppliesTo, ConceptId, CreditNoteReason, CurrencyId, CustomerId, Date (+14 more)

### Community 105 - "GetJournalEntryByIdQuery"
Cohesion: 0.29
Nodes (7): GetJournalEntryByIdQuery, Id, GetJournalEntryByIdQueryHandler, CancellationToken, Guid, IMapper, Task

### Community 106 - "CustomerAgingDetailDto"
Cohesion: 0.14
Nodes (14): CustomerAgingDetailDto, AmountLocal, AppliedAmount, BucketKey, ConceptDescription, CurrencyCode, Date, DaysOverdue (+6 more)

### Community 107 - "BudgetLineRequest"
Cohesion: 0.11
Nodes (17): BudgetLineRequest, AccountId, April, August, December, DepartmentId, February, January (+9 more)

### Community 108 - "Customer"
Cohesion: 0.12
Nodes (16): Customer, AccountingAccount, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId (+8 more)

### Community 109 - "UpdateFiscalControlCommand"
Cohesion: 0.10
Nodes (21): UpdateFiscalControlCommand, Branch, CAI, DocumentCode, DocumentType, EmissionDate, EmissionLimitDate, EmissionPoint (+13 more)

### Community 110 - "UpdateRoleCommand"
Cohesion: 0.25
Nodes (8): UpdateRoleCommand, Id, Name, UpdateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 111 - "AccountsReceivableDocumentsController"
Cohesion: 0.24
Nodes (11): AccountsReceivableDocumentsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+3 more)

### Community 112 - "SourceModule"
Cohesion: 0.22
Nodes (8): SourceModule, Bank, Closing, Invoice, Manually, Payable, Payroll, Receivable

### Community 113 - ".Delete"
Cohesion: 0.28
Nodes (9): CustomersController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 114 - "DeleteRoleCommandHandler"
Cohesion: 0.25
Nodes (8): DeleteRoleCommand, Id, DeleteRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task, UserManager

### Community 115 - ".GetCurrentUser"
Cohesion: 0.11
Nodes (15): ICurrentUserService, Guid, UserId, UserName, CountifyDbContextFactory, DesignTimeCurrentUserService, Guid, UserId (+7 more)

### Community 116 - "fluentvalidation"
Cohesion: 0.08
Nodes (20): AbstractValidator, CloseAccountingPeriodCommandValidator, CreateAccountingPeriodCommandValidator, DeleteAccountingPeriodCommandValidator, CreateAccountCommandValidator, DeleteAccountCommandValidator, UpdateAccountCommandValidator, CreateAccountsReceivableDocumentCommandValidator (+12 more)

### Community 117 - "CreateProjectCommand"
Cohesion: 0.19
Nodes (12): CreateProjectCommand, Code, GroupId, Name, CreateProjectCommandHandler, CancellationToken, Guid, IMapper (+4 more)

### Community 118 - ".Validate"
Cohesion: 0.36
Nodes (4): JournalEntryRules, EntryConceptType, Guid, IEnumerable

### Community 119 - "AccountsReceivableDocumentLineDto"
Cohesion: 0.14
Nodes (14): AccountsReceivableDocumentLineDto, Amount, AppliedAmount, AppliedConcept, AppliedCurrencyCode, AppliedDate, AppliedDocumentId, AppliedDocumentNo (+6 more)

### Community 120 - "UpdateAccountsReceivableConceptCommand"
Cohesion: 0.05
Nodes (44): AccountsReceivableConceptsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+36 more)

### Community 121 - "AssignRoleCommand"
Cohesion: 0.29
Nodes (7): AssignRoleCommand, RoleName, UserId, AssignRoleCommandHandler, CancellationToken, Task, UserManager

### Community 122 - "RequestParameter"
Cohesion: 0.25
Nodes (7): RequestParameter, All, Column, Order, PageNumber, PageSize, Parameter

### Community 123 - "ProductsController.cs"
Cohesion: 0.16
Nodes (7): ProductProfile, Countify.Application.Features.Products.DTOs, Countify.Application.Features.Products.Queries.GetProducts, Countify.Application.Features.Products.Commands.CreateProduct, Countify.Application.Features.Products.Commands.DeleteProduct, Countify.Application.Features.Products.Commands.UpdateProduct, Countify.Application.Features.Products.Profiles

### Community 124 - ".OnModelCreating"
Cohesion: 0.25
Nodes (7): IdentityRole, IdentityUserRole, ModelBuilder, IdentityRoleClaim, IdentityUserClaim, IdentityUserLogin, IdentityUserToken

### Community 125 - "CreateProjectGroupCommand"
Cohesion: 0.07
Nodes (37): ProjectGroupsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+29 more)

### Community 126 - ".Delete"
Cohesion: 0.28
Nodes (9): DocumentTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 127 - "IEmailService"
Cohesion: 0.33
Nodes (4): IEmailService, Task, EmailService, Task

### Community 128 - "CreateSupplierTypeCommand"
Cohesion: 0.19
Nodes (12): CreateSupplierTypeCommand, AccountingAccountId, Code, Name, CreateSupplierTypeCommandHandler, CancellationToken, Guid, IMapper (+4 more)

### Community 129 - ".Close"
Cohesion: 0.33
Nodes (8): AccountingPeriodsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, IActionResult, Task

### Community 130 - ".ValidateAsync"
Cohesion: 0.29
Nodes (6): JournalEntryAuxValidator, CancellationToken, Guid, Task, IReadOnlyCollection, IReadOnlyDictionary

### Community 131 - "AddBudgetsAndBudgetPermissions"
Cohesion: 0.20
Nodes (7): Guid, MigrationBuilder, AddBudgetsAndBudgetPermissions, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 132 - ".BuildSection"
Cohesion: 0.22
Nodes (9): IncomeStatementSectionDto, Code, Lines, Name, Total, List, Dictionary, List (+1 more)

### Community 133 - "CreateFiscalControlCommand"
Cohesion: 0.11
Nodes (20): CreateFiscalControlCommand, Branch, CAI, DocumentCode, DocumentType, EmissionDate, EmissionLimitDate, EmissionPoint (+12 more)

### Community 134 - "Seeding — GENERALIZADO (base para futuras entidades/fases)"
Cohesion: 0.06
Nodes (26): Seeding — GENERALIZADO (base para futuras entidades/fases), ISeeder, CancellationToken, Task, SeederOptions, Enabled, SeedConfiguration, SeedTransactions (+18 more)

### Community 135 - "IncomeStatementLineDto"
Cohesion: 0.22
Nodes (7): IncomeStatementLineDto, AccountCode, AccountId, AccountName, Balance, Guid, Countify.Application.Features.Reports.DTOs

### Community 136 - "History"
Cohesion: 0.14
Nodes (13): History, Date, Entity, EntityId, NewValue, OldValue, Property, UserId (+5 more)

### Community 137 - ".BuildModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 138 - "CustomerMovementApplicationDto"
Cohesion: 0.18
Nodes (11): CustomerMovementApplicationDto, Amount, Id, RelatedConcept, RelatedDate, RelatedDocumentId, RelatedDocumentNo, RelatedIsCredit (+3 more)

### Community 139 - "IncomeStatementDto"
Cohesion: 0.22
Nodes (9): IncomeStatementDto, EndDate, GrossProfit, NetResult, Sections, TotalCostOfSales, TotalExpenses, TotalRevenue (+1 more)

### Community 140 - "JournalEntryStatus"
Cohesion: 0.33
Nodes (5): JournalEntryStatus, Approved, Draft, Posted, Voided

### Community 141 - "AccountsController.cs"
Cohesion: 0.19
Nodes (7): AccountProfile, Countify.Application.Features.Accounts.DTOs, Countify.Application.Features.Accounts.Commands.CreateAccount, Countify.Application.Features.Accounts.Profiles, Countify.Application.Features.Accounts.Queries.GetAccounts, Countify.Application.Features.Accounts.Commands.UpdateAccount, Countify.Application.Features.Accounts.Queries.GetAccountById

### Community 142 - "Countify.Api.Controllers"
Cohesion: 0.13
Nodes (12): CreateCustomerTypeCommandValidator, UpdateCustomerTypeCommandValidator, Countify.Application.Features.CustomerTypes.Commands.DeleteCustomerType, Countify.Api.Controllers, Countify.Application.Features.Reports.Queries.GetTrialBalance, Countify.Application.Features.Currencies, Countify.Application.Features.Reports.Queries.GetIncomeStatement, Countify.Application.Features.CustomerTypes.Commands.UpdateCustomerType (+4 more)

### Community 143 - "CustomerAgingDto"
Cohesion: 0.18
Nodes (11): CustomerAgingBucketDto, Amount, Key, Label, CustomerAgingDto, AsOfDate, Buckets, Details (+3 more)

### Community 144 - "BaseController"
Cohesion: 0.25
Nodes (9): ControllerBase, BaseController, Mediator, ReportsController, Authorize, HttpGet, IActionResult, Task (+1 more)

### Community 145 - "BankTransactionType"
Cohesion: 0.20
Nodes (9): BankTransactionType, Code, MovementType, TransactionType, BasicBanks, Accounts, TransactionTypes, BankTransactionTypeConfiguration (+1 more)

### Community 146 - "UpdateDocumentTypeCommand"
Cohesion: 0.20
Nodes (10): UpdateDocumentTypeCommand, Code, Id, IsDefault, Name, UpdateDocumentTypeCommandHandler, CancellationToken, Guid (+2 more)

### Community 147 - "GetProductAccountsQuery.cs"
Cohesion: 0.21
Nodes (7): ProductAccountProfile, Countify.Application.Features.ProductAccounts.Profiles, Countify.Application.Features.ProductAccounts.DTOs, Countify.Application.Features.ProductAccounts.Commands.CreateProductAccount, Countify.Application.Features.ProductAccounts.Queries.GetProductAccounts, Countify.Application.Features.ProductAccounts.Commands.UpdateProductAccount, Countify.Application.Features.ProductAccounts.Commands.DeleteProductAccount

### Community 148 - "AuthController"
Cohesion: 0.38
Nodes (6): AuthController, Authorize, HttpGet, HttpPost, IActionResult, Task

### Community 149 - ".Delete"
Cohesion: 0.28
Nodes (9): ProductAccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 150 - "SettingsController.cs"
Cohesion: 0.19
Nodes (9): SettingsController, Authorize, HttpGet, HttpPut, IActionResult, Task, UpdateCompanySettingsCommandValidator, Countify.Application.Features.Configurations.Queries.GetCompanySettings (+1 more)

### Community 151 - "mediatr"
Cohesion: 0.08
Nodes (22): automapper_queryableextensions, ForgotPasswordRequest, Email, Countify.Infrastructure.Persistence.Services, Countify.Application.Features.Auth.DTOs, Countify.Infrastructure.Services, Countify.Application.Common.Interfaces, Countify.Application.Features.Users.DTOs (+14 more)

### Community 152 - "CreateAccountsReceivableDocumentLinesCommand"
Cohesion: 0.18
Nodes (12): CreateAccountsReceivableDocumentLinesCommand, DocumentId, Lines, CreateAccountsReceivableDocumentLinesCommandHandler, LineItem, Amount, AppliedDocumentId, CancellationToken (+4 more)

### Community 153 - "microsoft_aspnetcore_authorization"
Cohesion: 0.11
Nodes (18): AccountingPeriodPolicies, AuthorizationOptions, AccountsReceivableConceptPolicies, AuthorizationOptions, CustomerPolicies, AuthorizationOptions, ProductAccountPolicies, AuthorizationOptions (+10 more)

### Community 154 - "FiscalControl"
Cohesion: 0.11
Nodes (18): FiscalControl, Branch, CAI, DocumentCode, DocumentType, EmissionDate, EmissionLimitDate, EmissionPoint (+10 more)

### Community 155 - "4. Qué falta implementar (backend)"
Cohesion: 0.14
Nodes (14): 4.1 Campos fiscales en `AccountsReceivableDocument` (nullable; solo N/C y N/D), 4.3 Enums nuevos, 4.4 Numeración, 4.5 Conceptos (seeder), 4.6 Adjuntos, 4.7 Permisos, 4.8 Migración EF, 4. Qué falta implementar (backend) (+6 more)

### Community 156 - "DocumentTypesController.cs"
Cohesion: 0.18
Nodes (7): CreateDocumentTypeCommandValidator, DeleteDocumentTypeCommandValidator, UpdateDocumentTypeCommandValidator, Countify.Application.Features.DocumentTypes.Commands.CreateDocumentType, Countify.Application.Features.DocumentTypes.Commands.DeleteDocumentType, Countify.Application.Features.DocumentTypes.Queries.GetDocumentTypes, Countify.Application.Features.DocumentTypes.Commands.UpdateDocumentType

### Community 157 - "TrialBalanceLineDto"
Cohesion: 0.25
Nodes (8): TrialBalanceLineDto, AccountCode, AccountId, AccountName, Balance, Credit, Debit, Guid

### Community 158 - "CreateCustomerTypeCommand"
Cohesion: 0.27
Nodes (9): CreateCustomerTypeCommand, AccountingAccountId, Code, Name, CreateCustomerTypeCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 159 - "UpdateProductAccountCommand"
Cohesion: 0.13
Nodes (14): UpdateProductAccountCommand, Id, UpdateProductAccountCommandHandler, CancellationToken, Guid, IMapper, Task, ProductAccountRequest (+6 more)

### Community 160 - "TransactionSeeder"
Cohesion: 0.47
Nodes (5): TransactionSeeder, CancellationToken, ILogger, IOptions, Task

### Community 161 - "CustomerMovementsDto"
Cohesion: 0.18
Nodes (11): CustomerMovementsDto, Aging, CustomerCode, CustomerId, CustomerName, FromDate, Movements, Saldo (+3 more)

### Community 162 - "GetCustomerMovementsQuery"
Cohesion: 0.28
Nodes (9): GetCustomerMovementsQuery, CustomerId, FromDate, ToDate, GetCustomerMovementsQueryHandler, CancellationToken, DateTime, Guid (+1 more)

### Community 163 - "CreateDepartmentCommand"
Cohesion: 0.21
Nodes (11): CreateDepartmentCommand, Code, Name, CreateDepartmentCommandHandler, CancellationToken, Guid, IMapper, Task (+3 more)

### Community 165 - "BudgetRequest"
Cohesion: 0.25
Nodes (8): BudgetLineRequest, BudgetLineResponse, BudgetRequest, FiscalYear, Lines, Name, BudgetResponse, List

### Community 166 - "DeleteJournalEntryCommand"
Cohesion: 0.22
Nodes (8): DeleteJournalEntryCommand, Id, DeleteJournalEntryCommandHandler, CancellationToken, Guid, Task, DeleteJournalEntryCommandValidator, Countify.Application.Features.JournalEntries.Commands.DeleteJournalEntry

### Community 167 - "UpdateCustomerTypeCommand"
Cohesion: 0.20
Nodes (10): UpdateCustomerTypeCommand, AccountingAccountId, Code, Id, Name, UpdateCustomerTypeCommandHandler, CancellationToken, Guid (+2 more)

### Community 168 - "AccountsReceivableConceptsController.cs"
Cohesion: 0.22
Nodes (6): CreateAccountsReceivableConceptCommandValidator, UpdateAccountsReceivableConceptCommandValidator, Countify.Application.Features.AccountsReceivableConcepts.Commands.DeleteAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Commands.CreateAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Commands.UpdateAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Queries.GetAccountsReceivableConcepts

### Community 169 - ".SaveChangesAsync"
Cohesion: 0.19
Nodes (11): CreateDocumentTypeCommand, Code, IsDefault, Name, CreateDocumentTypeCommandHandler, CancellationToken, Guid, IMapper (+3 more)

### Community 170 - "FiscalControlsController.cs"
Cohesion: 0.22
Nodes (6): CreateFiscalControlCommandValidator, UpdateFiscalControlCommandValidator, Countify.Application.Features.FiscalControls.Commands.DeleteFiscalControl, Countify.Application.Features.FiscalControls.Commands.UpdateFiscalControl, Countify.Application.Features.FiscalControls.Commands.CreateFiscalControl, Countify.Application.Features.FiscalControls.Queries.GetFiscalControls

### Community 171 - "GetPendingAccountsReceivableDocumentsQuery"
Cohesion: 0.27
Nodes (9): GetPendingAccountsReceivableDocumentsQuery, CustomerId, ExcludeDocumentIds, GetPendingAccountsReceivableDocumentsQueryHandler, CancellationToken, Guid, IMapper, List (+1 more)

### Community 172 - ".Delete"
Cohesion: 0.28
Nodes (9): CustomerTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 173 - "AccountsReceivableDocumentLine"
Cohesion: 0.22
Nodes (9): AccountsReceivableDocumentLine, Amount, AppliedDocument, AppliedDocumentId, Document, DocumentId, Guid, AccountsReceivableDocumentLineConfiguration (+1 more)

### Community 174 - "EntryConceptType"
Cohesion: 0.40
Nodes (4): EntryConceptType, Credit, Debit, Other

### Community 176 - "CreateRoleCommand"
Cohesion: 0.29
Nodes (7): CreateRoleCommand, Name, CreateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 177 - "Profile"
Cohesion: 0.05
Nodes (24): AccountingPeriodProfile, BankAccountProfile, SettingsProfile, CurrencyProfile, CustomerTypeProfile, DepartmentProfile, DocumentTypeProfile, FiscalControlProfile (+16 more)

### Community 178 - ".Delete"
Cohesion: 0.28
Nodes (9): FiscalControlsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 179 - "AccountsReceivableDocumentAttachmentDto"
Cohesion: 0.18
Nodes (10): AccountsReceivableDocumentAttachmentDto, ContentType, DocumentId, FileName, Id, Size, UploadedBy, UploadedOn (+2 more)

### Community 180 - "SupplierTypesController.cs"
Cohesion: 0.18
Nodes (8): CreateSupplierTypeCommandValidator, UpdateSupplierTypeCommandValidator, SupplierTypeProfile, Countify.Application.Features.SupplierTypes.Commands.DeleteSupplierType, Countify.Application.Features.SupplierTypes.Commands.UpdateSupplierType, Countify.Application.Features.SupplierTypes.Queries.GetSupplierTypes, Countify.Application.Features.SupplierTypes.Profiles, Countify.Application.Features.SupplierTypes.Commands.CreateSupplierType

### Community 181 - "DeleteAccountingPeriodCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountingPeriodCommand, Id, DeleteAccountingPeriodCommandHandler, CancellationToken, Guid, Task

### Community 182 - "GetAccountsReceivableDocumentByIdQuery"
Cohesion: 0.29
Nodes (7): GetAccountsReceivableDocumentByIdQuery, Id, GetAccountsReceivableDocumentByIdQueryHandler, CancellationToken, Guid, IMapper, Task

### Community 183 - "AccountMovementDto"
Cohesion: 0.18
Nodes (10): AccountMovementDto, Balance, Concept, Credit, Debit, EntryNumber, JournalEntryId, ReferenceDate (+2 more)

### Community 184 - "GetCustomersQueryHandler"
Cohesion: 0.43
Nodes (6): GetCustomersQuery, GetCustomersQueryHandler, CancellationToken, IMapper, List, Task

### Community 185 - ".SeedDatabase"
Cohesion: 0.47
Nodes (4): DatabaseExtensions, IEnumerable, ILogger, IHost

### Community 186 - "20260919192955_RenameBankOpeningBalanceToBalance.Designer.cs"
Cohesion: 0.20
Nodes (6): MigrationBuilder, RenameBankOpeningBalanceToBalance, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 187 - "Cuentas por Cobrar (FASE 3 del roadmap maestro) — plan de cierre"
Cohesion: 0.12
Nodes (16): 10. Estado de cierre (FASE 3) — actualizado, 1. Estado actual en Countify, 3. Decisiones tomadas, 5. Frontend (Angular, `Countify-PanelUser`), 6. Migración de datos (FASE 14, cuando toque), 7. Consultas/Reportes, 8. Criterio de terminado (FASE 3), 9. Fuera de alcance aquí (+8 more)

### Community 188 - "RolePermission"
Cohesion: 0.25
Nodes (8): RolePermission, Permission, PermissionId, Role, RoleId, IdentityRole, RolePermissionConfiguration, EntityTypeBuilder

### Community 189 - "FixBankCurrencyForeignKeys"
Cohesion: 0.22
Nodes (6): MigrationBuilder, FixBankCurrencyForeignKeys, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 190 - "IRequestHandler"
Cohesion: 0.12
Nodes (19): UpdateAccountCommandHandler, CancellationToken, IMapper, Task, CreateProductAccountCommand, CreateProductAccountCommandHandler, CancellationToken, Guid (+11 more)

### Community 191 - "ProjectGroupsController.cs"
Cohesion: 0.09
Nodes (15): CreateProjectCommandValidator, CreateProjectGroupCommandValidator, DeleteProjectCommandValidator, UpdateProjectCommandValidator, ProjectProfile, Countify.Application.Features.Projects.Queries.GetProjects, Countify.Application.Features.Projects.Commands.UpdateProject, Countify.Application.Features.Projects.Profiles (+7 more)

### Community 192 - "UpdateAccountsReceivableDocumentLineCommand"
Cohesion: 0.29
Nodes (7): UpdateAccountsReceivableDocumentLineCommand, Amount, Id, UpdateAccountsReceivableDocumentLineCommandHandler, CancellationToken, Guid, Task

### Community 193 - ".ValidateAsync"
Cohesion: 0.60
Nodes (4): ProductAccountRules, CancellationToken, Guid, Task

### Community 194 - "GetEntityHistory.cs"
Cohesion: 0.17
Nodes (5): HistoryProfile, Countify.Application.Features.Historie.Profiles, Countify.Application.Extensions, Countify.Application.Features.Historie.DTOs, system_linq_expressions

### Community 196 - "UpdateProjectCommand"
Cohesion: 0.20
Nodes (10): UpdateProjectCommand, Code, GroupId, Id, Name, UpdateProjectCommandHandler, CancellationToken, Guid (+2 more)

### Community 197 - "2. Entidades legacy (campos)"
Cohesion: 0.20
Nodes (10): 2.1 `Proveedores` (Proveedor), 2.2 `Tiposproveedor` (Tipo de proveedor), 2.3 `CXPConceptos` (Concepto de CxP), 2.4 `CXPDocumentos` (Movimiento de CxP) — clase base, 2.5 `CXPDocumentosHijo` (Aplicación pago↔factura), 2.6 `CXPDocumentosPadre : CXPDocumentos` (Ingreso de Compras), 2.7 `ProveedoresDatosFiscales` (Datos fiscales del proveedor), 2.8 `VSTCXPEstadoDeCuenta` (vista — Estado de Cuenta) (+2 more)

### Community 198 - "CustomersController.cs"
Cohesion: 0.18
Nodes (8): CreateCustomerCommandValidator, UpdateCustomerCommandValidator, CustomerProfile, Countify.Application.Features.Customers.Commands.DeleteCustomer, Countify.Application.Features.Customers.Queries.GetCustomers, Countify.Application.Features.Customers.Profiles, Countify.Application.Features.Customers.Commands.UpdateCustomer, Countify.Application.Features.Customers.Commands.CreateCustomer

### Community 199 - "GetAccountsReceivableDocumentsQueryHandler"
Cohesion: 0.43
Nodes (6): GetAccountsReceivableDocumentsQuery, GetAccountsReceivableDocumentsQueryHandler, CancellationToken, IMapper, List, Task

### Community 200 - "UpdateRolePermissionsCommand"
Cohesion: 0.22
Nodes (9): UpdateRolePermissionsCommand, PermissionIds, RoleId, UpdateRolePermissionsCommandHandler, CancellationToken, IdentityRole, List, RoleManager (+1 more)

### Community 201 - "ChangePasswordCommand"
Cohesion: 0.25
Nodes (8): ChangePasswordCommand, CurrentPassword, Id, NewPassword, ChangePasswordCommandHandler, CancellationToken, Task, UserManager

### Community 202 - "DeleteProjectGroupCommand"
Cohesion: 0.33
Nodes (6): DeleteProjectGroupCommand, Id, DeleteProjectGroupCommandHandler, CancellationToken, Guid, Task

### Community 203 - "CreateAccountingPeriodCommand"
Cohesion: 0.36
Nodes (7): CreateAccountingPeriodCommand, Month, CreateAccountingPeriodCommandHandler, CancellationToken, DateTime, Guid, Task

### Community 204 - "GetAccountByIdQuery"
Cohesion: 0.29
Nodes (7): GetAccountByIdQuery, Id, GetAccountByIdQueryHandler, CancellationToken, Guid, IMapper, Task

### Community 205 - ".AssignAsync"
Cohesion: 0.22
Nodes (8): UpdateAccountsReceivableDocumentCommandHandler, CancellationToken, IMapper, Task, FiscalNoteNumberingFactory, CancellationToken, FiscalControl, Task

### Community 206 - ".ApplyOrder"
Cohesion: 0.46
Nodes (5): QueryableExtensions, Dictionary, Expression, Func, IQueryable

### Community 207 - "DeleteAccountsReceivableDocumentLineCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountsReceivableDocumentLineCommand, Id, DeleteAccountsReceivableDocumentLineCommandHandler, CancellationToken, Guid, Task

### Community 208 - "GetUserInfoQueryHandler"
Cohesion: 0.14
Nodes (15): UserInfoResponse, Email, FullName, Permissions, Roles, UserId, UserName, IList (+7 more)

### Community 209 - "CloseAccountingPeriodCommand"
Cohesion: 0.33
Nodes (6): CloseAccountingPeriodCommand, Id, CloseAccountingPeriodCommandHandler, CancellationToken, Guid, Task

### Community 210 - "DeleteAccountCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountCommand, Id, DeleteAccountCommandHandler, CancellationToken, Guid, Task

### Community 211 - "VoidAccountsReceivableDocumentCommand"
Cohesion: 0.33
Nodes (6): VoidAccountsReceivableDocumentCommand, Id, VoidAccountsReceivableDocumentCommandHandler, CancellationToken, Guid, Task

### Community 212 - "VoidJournalEntryCommand"
Cohesion: 0.33
Nodes (6): VoidJournalEntryCommand, Id, VoidJournalEntryCommandHandler, CancellationToken, Guid, Task

### Community 213 - "DeleteProjectCommand"
Cohesion: 0.33
Nodes (6): DeleteProjectCommand, Id, DeleteProjectCommandHandler, CancellationToken, Guid, Task

### Community 214 - "DeleteDepartmentCommand"
Cohesion: 0.33
Nodes (6): DeleteDepartmentCommand, Id, DeleteDepartmentCommandHandler, CancellationToken, Guid, Task

### Community 215 - "ResetPasswordRequest"
Cohesion: 0.40
Nodes (4): ResetPasswordRequest, Email, NewPassword, Token

### Community 216 - "DeleteSupplierTypeCommand"
Cohesion: 0.33
Nodes (6): DeleteSupplierTypeCommand, Id, DeleteSupplierTypeCommandHandler, CancellationToken, Guid, Task

### Community 217 - "DeleteProductCommand"
Cohesion: 0.33
Nodes (6): DeleteProductCommand, Id, DeleteProductCommandHandler, CancellationToken, Guid, Task

### Community 218 - ".ValidateAsync"
Cohesion: 0.29
Nodes (6): BudgetAvailabilityValidator, CancellationToken, DateTime, Guid, IEnumerable, Task

### Community 219 - ".CreateAsync"
Cohesion: 0.47
Nodes (3): DraftCreationResult, CancellationToken, Task

### Community 220 - "DeleteProductAccountCommand"
Cohesion: 0.33
Nodes (6): DeleteProductAccountCommand, Id, DeleteProductAccountCommandHandler, CancellationToken, Guid, Task

### Community 222 - "DeleteQualityCommand"
Cohesion: 0.33
Nodes (6): DeleteQualityCommand, Id, DeleteQualityCommandHandler, CancellationToken, Guid, Task

### Community 223 - "DeleteUserCommand"
Cohesion: 0.33
Nodes (6): DeleteUserCommand, Id, DeleteUserCommandHandler, CancellationToken, Task, UserManager

### Community 224 - "FiscalDocumentType"
Cohesion: 0.29
Nodes (6): FiscalDocumentType, CreditNote, DebitNote, DispatchGuide, Invoicing, Retention

### Community 225 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 226 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 227 - ".Up"
Cohesion: 0.40
Nodes (3): DateTime, Guid, MigrationBuilder

### Community 229 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 233 - "LoginRequest"
Cohesion: 0.50
Nodes (3): LoginRequest, Password, Username

### Community 234 - "IConfigureOptions"
Cohesion: 0.21
Nodes (7): FiscalControlPolicies, AuthorizationOptions, HistoryPolicies, AuthorizationOptions, SupplierTypePolicies, AuthorizationOptions, IConfigureOptions

### Community 235 - "RefreshTokenRequest"
Cohesion: 0.50
Nodes (3): RefreshTokenRequest, AccessToken, RefreshToken

### Community 236 - "OrderColumns"
Cohesion: 0.50
Nodes (3): OrderColumns, Ascending, Descending

### Community 249 - ".Up"
Cohesion: 0.40
Nodes (3): DateTime, Guid, MigrationBuilder

## Knowledge Gaps
- **1367 isolated node(s):** `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName`, `ApiKey`, `Permission` (+1362 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 2179 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **20 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Response` connect `Response` to `UpdateCompanySettingsCommand`, `UpdateDepartmentCommand`, `PaginatedResponse`, `UpdateProductCommand`, `CustomerTypeDto`, `UpdateSupplierTypeCommand`, `IRequest`, `CurrencyFeatures.cs`, `.HandleResult`, `GetTrialBalanceQuery`, `CompanySettingsDto`, `AccountMovementsResponse`, `HistoryDto`, `AuthResponse`, `UpdateJournalEntryCommand`, `CreateAccountCommand`, `CreateJournalEntryCommand`, `ApplicationUser`, `BudgetsController`, `UpdateUserCommand`, `GetRoleByIdQueryHandler`, `CreateCustomerCommand`, `DocumentTypeDto`, `AccountingPeriodDto`, `CreateAccountsReceivableConceptCommand`, `GetUserByIdQueryHandler`, `UploadAccountsReceivableDocumentAttachmentCommand`, `GetIncomeStatementQuery`, `UpdateAccountCommand`, `UpdateAccountsReceivableDocumentCommand`, `UpdateCustomerCommand`, `FiscalControlDto`, `UpdateQualityCommand`, `CreateAccountsReceivableDocumentCommand`, `GetJournalEntryByIdQuery`, `UpdateFiscalControlCommand`, `UpdateRoleCommand`, `DeleteRoleCommandHandler`, `CreateProjectCommand`, `UpdateAccountsReceivableConceptCommand`, `AssignRoleCommand`, `CreateProjectGroupCommand`, `CreateSupplierTypeCommand`, `CreateFiscalControlCommand`, `UpdateDocumentTypeCommand`, `CreateAccountsReceivableDocumentLinesCommand`, `CreateCustomerTypeCommand`, `UpdateProductAccountCommand`, `GetCustomerMovementsQuery`, `CreateDepartmentCommand`, `DeleteJournalEntryCommand`, `UpdateCustomerTypeCommand`, `.SaveChangesAsync`, `GetPendingAccountsReceivableDocumentsQuery`, `CreateRoleCommand`, `DeleteAccountingPeriodCommand`, `GetAccountsReceivableDocumentByIdQuery`, `GetCustomersQueryHandler`, `IRequestHandler`, `UpdateAccountsReceivableDocumentLineCommand`, `UpdateProjectCommand`, `GetAccountsReceivableDocumentsQueryHandler`, `UpdateRolePermissionsCommand`, `ChangePasswordCommand`, `DeleteProjectGroupCommand`, `CreateAccountingPeriodCommand`, `GetAccountByIdQuery`, `.AssignAsync`, `DeleteAccountsReceivableDocumentLineCommand`, `GetUserInfoQueryHandler`, `CloseAccountingPeriodCommand`, `DeleteAccountCommand`, `VoidAccountsReceivableDocumentCommand`, `VoidJournalEntryCommand`, `DeleteProjectCommand`, `DeleteDepartmentCommand`, `DeleteSupplierTypeCommand`, `DeleteProductCommand`, `DeleteProductAccountCommand`, `DeleteQualityCommand`, `DeleteUserCommand`?**
  _High betweenness centrality (0.299) - this node is a cross-community bridge._
- **Why does `IUnitOfWork` connect `IUnitOfWork` to `UpdateCompanySettingsCommand`, `UpdateDepartmentCommand`, `PaginatedResponse`, `UpdateProductCommand`, `Response`, `CustomerTypeDto`, `JournalEntry`, `UpdateSupplierTypeCommand`, `IRequest`, `Repository`, `CurrencyFeatures.cs`, `Permission`, `BankTransaction`, `GetTrialBalanceQuery`, `CompanySettingsDto`, `UnitOfWork`, `AccountMovementsResponse`, `HistoryDto`, `AuthResponse`, `JournalEntryLine`, `UserDto`, `ProductAccount`, `UpdateJournalEntryCommand`, `CreateAccountCommand`, `Countify.Domain.Entities.Accounting`, `CreateJournalEntryCommand`, `BankAccount`, `ApplicationUser`, `BudgetsController`, `Supplier`, `GetRoleByIdQueryHandler`, `CustomerType`, `CreateCustomerCommand`, `Budget`, `DocumentTypeDto`, `AccountingPeriod`, `.CreateOrUpdatePostingAsync`, `AccountingPeriodDto`, `CreateAccountsReceivableConceptCommand`, `UploadAccountsReceivableDocumentAttachmentCommand`, `BankReconciliation`, `AccountsReceivableDocument`, `GetProjectsQuery`, `GetIncomeStatementQuery`, `AccountsReceivableDocumentAttachment`, `UpdateCustomerCommand`, `FiscalControlDto`, `BaseEntity`, `GetJournalEntriesQuery`, `UpdateQualityCommand`, `RoleDto`, `UserRoleHasPermissionRequirement`, `YearEndClosingEntry`, `GetAccountsQuery`, `AccountsReceivableConcept`, `CreateAccountsReceivableDocumentCommand`, `GetJournalEntryByIdQuery`, `UpdateFiscalControlCommand`, `CreateProjectCommand`, `UpdateAccountsReceivableConceptCommand`, `CreateProjectGroupCommand`, `CreateSupplierTypeCommand`, `.ValidateAsync`, `CreateFiscalControlCommand`, `History`, `BankTransactionType`, `UpdateDocumentTypeCommand`, `CreateAccountsReceivableDocumentLinesCommand`, `CreateCustomerTypeCommand`, `UpdateProductAccountCommand`, `GetCustomerMovementsQuery`, `CreateDepartmentCommand`, `DeleteJournalEntryCommand`, `UpdateCustomerTypeCommand`, `.SaveChangesAsync`, `GetPendingAccountsReceivableDocumentsQuery`, `AccountsReceivableDocumentLine`, `DeleteAccountingPeriodCommand`, `GetAccountsReceivableDocumentByIdQuery`, `GetCustomersQueryHandler`, `RolePermission`, `IRequestHandler`, `UpdateAccountsReceivableDocumentLineCommand`, `.ValidateAsync`, `UpdateProjectCommand`, `GetAccountsReceivableDocumentsQueryHandler`, `UpdateRolePermissionsCommand`, `DeleteProjectGroupCommand`, `CreateAccountingPeriodCommand`, `GetAccountByIdQuery`, `.AssignAsync`, `DeleteAccountsReceivableDocumentLineCommand`, `GetUserInfoQueryHandler`, `CloseAccountingPeriodCommand`, `DeleteAccountCommand`, `VoidAccountsReceivableDocumentCommand`, `VoidJournalEntryCommand`, `DeleteProjectCommand`, `DeleteDepartmentCommand`, `DeleteSupplierTypeCommand`, `DeleteProductCommand`, `.ValidateAsync`, `.CreateAsync`, `DeleteProductAccountCommand`, `DeleteQualityCommand`?**
  _High betweenness centrality (0.235) - this node is a cross-community bridge._
- **Why does `Supplier` connect `Supplier` to `CreateSupplierTypeCommand`, `CountifyDbContext`, `SupplierFiscalData`, `Countify.Domain.Entities.Accounting`, `UnitOfWork`, `BaseEntity`, `IUnitOfWork`, `IEntityTypeConfiguration`?**
  _High betweenness centrality (0.057) - this node is a cross-community bridge._
- **What connects `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName` to the rest of the system?**
  _1367 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Countify.Domain.Interfaces` be split into smaller, more focused modules?**
  _Cohesion score 0.05809979494190021 - nodes in this community are weakly interconnected._
- **Should `UpdateCompanySettingsCommand` be split into smaller, more focused modules?**
  _Cohesion score 0.09090909090909091 - nodes in this community are weakly interconnected._
- **Should `CountifyDbContext` be split into smaller, more focused modules?**
  _Cohesion score 0.043478260869565216 - nodes in this community are weakly interconnected._