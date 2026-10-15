# Graph Report - Countify  (2026-10-14)

## Corpus Check
- 415 files · ~75,967 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 2, .user 1)

## Summary
- 3923 nodes · 7860 edges · 234 communities (222 shown, 12 thin omitted)
- Extraction: 95% EXTRACTED · 5% INFERRED · 0% AMBIGUOUS · INFERRED: 360 edges (avg confidence: 0.86)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `c08e62e3`
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
- .Delete
- Response
- CustomerTypeDto
- JournalEntry
- JournalEntriesController
- UpdateAccountsReceivableConceptCommand
- IRequest
- History
- UpdateProjectCommand
- IRepository
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
- Account
- Countify.Infrastructure
- AuthResponse
- JournalEntryLine
- AccountsReceivableDocumentDraftRequest
- Countify.Api.Controllers
- BankTransactionDto
- UserDto
- ProductAccount
- ApiKeyAuthenticationHandler
- JournalEntryDto
- CompanySettings
- JournalEntryPdfBuilder.cs
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
- CreateProductCommand
- UpdateUserCommand
- ProductAccountDto
- GetRoleByIdQueryHandler
- IEntityTypeConfiguration
- .Delete
- CreateCustomerCommand
- .SaveChangesAsync
- Budget
- LoginRequest
- DocumentTypeDto
- CustomerMovementDto
- AccountsController.cs
- http
- JournalEntryLineRequest
- .CreateOrUpdatePostingAsync
- UsersController
- Countify.Infrastructure.Persistence
- UserRoleHasPermissionRequirement
- AccountsController
- AccountingPeriodDto
- CreateAccountsReceivableConceptCommand
- AccountsReceivableDocumentDto
- GetUserByIdQueryHandler
- CreateUserCommand
- BankReconciliation
- AccountsReceivableDocument
- GetProjectsQuery
- GetIncomeStatementQuery
- UpdateAccountCommand
- RolesController
- UploadAccountsReceivableDocumentAttachmentCommand
- CustomerDto
- AccountsReceivableDocumentAttachment
- UpdateAccountsReceivableDocumentCommand
- UpdateCustomerCommand
- FiscalControlDto
- BaseEntity
- GetJournalEntriesQuery
- CreateQualityCommand
- RoleDto
- RolesController.cs
- InitialCreate
- DatabaseExtensions.cs
- AccountingPeriod
- .AddApiServices
- YearEndClosingEntry
- AddAccountingModule
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
- ICurrentUserService
- fluentvalidation
- CreateProjectCommand
- .Validate
- AccountsReceivableDocumentLineDto
- AccountsReceivableConceptDto
- AssignRoleCommand
- RequestParameter
- .AddInfrastructureServices
- .OnModelCreating
- UpdateProjectGroupCommand
- .Delete
- IEmailService
- VoidJournalEntryCommand
- .Close
- .Handle
- Migration
- .BuildSection
- CreateFiscalControlCommand
- Countify.Domain.Seeders
- IncomeStatementLineDto
- Currency
- .BuildModel
- CustomerMovementApplicationDto
- IncomeStatementDto
- JournalEntryStatus
- CreateDepartmentCommand
- CustomerTypesController.cs
- CustomerAgingDto
- BaseController
- BankTransactionType
- UpdateDocumentTypeCommand
- CreateProjectGroupCommand
- AuthController
- GetProductsQueryHandler
- CreateAccountingPeriodCommand
- Countify.Domain.Entities.Auth
- CreateAccountsReceivableDocumentLinesCommand
- microsoft_aspnetcore_authorization
- FiscalControl
- 4. Qué falta implementar (backend)
- ProductAccountsController.cs
- TrialBalanceLineDto
- .SaveChangesAsync
- .Delete
- TransactionSeeder
- CustomerMovementsDto
- GetCustomerMovementsQuery
- UpdateProductCommand
- Flujo bancario
- BudgetRequest
- DeleteJournalEntryCommand
- UpdateCustomerTypeCommand
- AccountsReceivableConceptsController.cs
- CreateDocumentTypeCommand
- UpdateQualityCommand
- GetPendingAccountsReceivableDocumentsQuery
- .Delete
- AccountsReceivableDocumentLine
- EntryConceptType
- Countify.Domain.Entities.AccountsReceivable
- CreateRoleCommand
- Profile
- .Delete
- AccountsReceivableDocumentAttachmentDto
- CloseAccountingPeriodCommand
- DeleteAccountingPeriodCommand
- GetAccountsReceivableDocumentByIdQuery
- AccountMovementDto
- GetCustomersQueryHandler
- .SeedDatabase
- DeleteAccountCommand
- Cuentas por Cobrar (FASE 3 del roadmap maestro) — plan de cierre
- RolePermission
- UpdateRolePermissionsCommand
- IRequestHandler
- ProjectGroupsController.cs
- UpdateAccountsReceivableDocumentLineCommand
- .ValidateAsync
- DeleteAccountsReceivableConceptCommand
- IConfigureOptions
- FiscalControlsController.cs
- UpdateReceiptNumberCommand
- UpdateProductAccountCommand
- GetAccountsReceivableDocumentsQueryHandler
- ProductAccountRequest
- ChangePasswordCommand
- CountifyDbContextFactory
- .Build
- GetAccountByIdQuery
- .AssignAsync
- .Get
- DeleteAccountsReceivableDocumentLineCommand
- GetUserInfoQueryHandler
- CompanySettingsPolicies.cs
- DocumentTypePolicies.cs
- ResetPasswordCommand.cs
- DeleteDocumentTypeCommand
- ProjectGroupPolicies.cs
- VoidAccountsReceivableDocumentCommand
- ResetPasswordRequest
- DeleteCustomerCommand
- DeleteProductCommand
- .CreateAsync
- BudgetPolicies.cs
- GetCompanySettingsQuery
- .ValidateAsync
- DeleteQualityCommand
- DeleteUserCommand
- FiscalDocumentType
- .BuildTargetModel
- CurrencyPolicies.cs
- AccountingPeriodPolicies.cs
- DepartmentPolicies.cs
- CustomerTypePolicies.cs
- FiscalControlPolicies.cs
- Countify.Domain.Authorization
- ProductAccountPolicies.cs
- Countify.Api.Authorization.Policies

## God Nodes (most connected - your core abstractions)
1. `Response` - 312 edges
2. `IUnitOfWork` - 166 edges
3. `Countify.Domain.Interfaces` - 105 edges
4. `Countify.Domain.Entities.Accounting` - 104 edges
5. `Countify.Application.Wrappers` - 103 edges
6. `CountifyDbContext` - 82 edges
7. `UnitOfWork` - 70 edges
8. `AccountsReceivableDocument` - 66 edges
9. `AccountsReceivableDocumentDto` - 56 edges
10. `BankTransaction` - 49 edges

## Surprising Connections (you probably didn't know these)
- `Modelo contable (FASE 1 — corregido)` --references--> `CompanySettings`  [INFERRED]
  AGENTS.md → Countify.Domain/Entities/Accounting/CompanySettings.cs
- `4.6 Adjuntos` --references--> `AccountsReceivableDocumentAttachment`  [INFERRED]
  AccountsReceivable-Fase3-Plan.md → Countify.Domain/Entities/AccountsReceivable/AccountsReceivableDocumentAttachment.cs
- `4.8 Migración EF` --references--> `AddReceivableFiscalNotesAndAttachments`  [INFERRED]
  AccountsReceivable-Fase3-Plan.md → Countify.Infrastructure/Migrations/20261014195831_AddReceivableFiscalNotesAndAttachments.Designer.cs
- `Permisos (patrón de futuras fases también)` --references--> `AccountingPeriodPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/AccountingPeriodPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `CompanySettingsPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/CompanySettingsPolicies.cs

## Import Cycles
- None detected.

## Communities (234 total, 12 thin omitted)

### Community 0 - "Countify.Domain.Interfaces"
Cohesion: 0.07
Nodes (12): automapper, Countify.Application.Features.JournalEntries.Commands.CreateJournalEntry, Countify.Application.Features.JournalEntries.DTOs, Countify.Application.Features.ProductAccounts, Countify.Application.Extensions, Countify.Application.Wrappers, Countify.Domain.Interfaces, Countify.Application.Features.JournalEntries.Profiles (+4 more)

### Community 1 - "CatalogSeeder"
Cohesion: 0.35
Nodes (5): CatalogSeeder, CancellationToken, ILogger, IOptions, Task

### Community 2 - "UpdateCompanySettingsCommand"
Cohesion: 0.09
Nodes (22): UpdateCompanySettingsCommand, Address, CompanyName, DefaultDepartmentId, DefaultProjectId, Email, FiscalYear, Mobile (+14 more)

### Community 3 - "CountifyDbContext"
Cohesion: 0.05
Nodes (42): CountifyDbContext, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentAttachments, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts (+34 more)

### Community 4 - "UpdateDepartmentCommand"
Cohesion: 0.08
Nodes (30): DepartmentsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+22 more)

### Community 5 - "PaginatedResponse"
Cohesion: 0.15
Nodes (15): GetProductAccountsQuery, Search, GetProductAccountsQueryHandler, CancellationToken, IMapper, List, Task, PaginatedResponse (+7 more)

### Community 6 - "microsoft_entityframeworkcore"
Cohesion: 0.16
Nodes (3): Countify.Infrastructure.Persistence.Configurations, microsoft_entityframeworkcore, microsoft_entityframeworkcore_metadata_builders

### Community 7 - ".Delete"
Cohesion: 0.28
Nodes (9): ProductsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 8 - "Response"
Cohesion: 0.05
Nodes (45): DeleteCustomerTypeCommand, Id, DeleteCustomerTypeCommandHandler, CancellationToken, Guid, Task, DeleteDepartmentCommand, Id (+37 more)

### Community 9 - "CustomerTypeDto"
Cohesion: 0.18
Nodes (14): CustomerTypeDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Code, Id, Name, Guid (+6 more)

### Community 10 - "JournalEntry"
Cohesion: 0.07
Nodes (28): DocumentType, Code, IsDefault, Name, JournalEntry, Code, Concept, CreditTotal (+20 more)

### Community 11 - "JournalEntriesController"
Cohesion: 0.33
Nodes (9): JournalEntriesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 12 - "UpdateAccountsReceivableConceptCommand"
Cohesion: 0.13
Nodes (15): UpdateAccountsReceivableConceptCommand, AccountId, Description, GeneratePosting, Id, IsFiscalNote, IsInactive, IsReceipt (+7 more)

### Community 13 - "IRequest"
Cohesion: 0.10
Nodes (52): BankHandler, BankReconciliationDto, BankAccountId, BankAccountName, BookBalance, Id, IsClosed, Notes (+44 more)

### Community 14 - "History"
Cohesion: 0.14
Nodes (13): History, Date, Entity, EntityId, NewValue, OldValue, Property, UserId (+5 more)

### Community 15 - "UpdateProjectCommand"
Cohesion: 0.11
Nodes (20): ProjectsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+12 more)

### Community 16 - "IRepository"
Cohesion: 0.08
Nodes (26): QueryableExtensions, Dictionary, Expression, Func, IQueryable, IRepository, CancellationToken, Expression (+18 more)

### Community 17 - "CurrencyFeatures.cs"
Cohesion: 0.12
Nodes (26): CurrenciesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+18 more)

### Community 18 - ".HandleResult"
Cohesion: 0.26
Nodes (11): BanksController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+3 more)

### Community 19 - "Permission"
Cohesion: 0.16
Nodes (10): BankPolicies, AuthorizationOptions, Permissions, Items, Permission, Description, Id, Name (+2 more)

### Community 20 - "BankTransaction"
Cohesion: 0.06
Nodes (32): BankTransaction, Amount, AppliesToReceivableId, BankAccount, BankAccountId, BankReconciliation, BankReconciliationId, Beneficiary (+24 more)

### Community 21 - "GetTrialBalanceQuery"
Cohesion: 0.16
Nodes (14): TrialBalanceDto, CreditTotal, DebitTotal, Difference, Lines, List, GetTrialBalanceQuery, DepartmentId (+6 more)

### Community 22 - "CompanySettingsDto"
Cohesion: 0.10
Nodes (20): CompanySettingsDto, Address, CompanyName, DefaultDepartmentId, DefaultProjectId, Email, FiscalYear, Id (+12 more)

### Community 23 - "UnitOfWork"
Cohesion: 0.04
Nodes (44): UnitOfWork, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentAttachments, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts (+36 more)

### Community 24 - "ValidationException"
Cohesion: 0.08
Nodes (25): ExceptionHandlerMiddleware, Exception, ILogger, Task, ValidationBehavior, CancellationToken, IEnumerable, Task (+17 more)

### Community 25 - "AccountMovementsResponse"
Cohesion: 0.13
Nodes (16): AccountMovementsResponse, AccountCode, AccountId, AccountName, Balance, CreditTotal, DebitTotal, Movements (+8 more)

### Community 26 - "BudgetLine"
Cohesion: 0.09
Nodes (23): BudgetLine, Account, AccountId, April, August, Budget, BudgetId, December (+15 more)

### Community 27 - "IUnitOfWork"
Cohesion: 0.05
Nodes (42): IUnitOfWork, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentAttachments, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts (+34 more)

### Community 28 - "HistoryDto"
Cohesion: 0.08
Nodes (26): HistoryController, Authorize, HttpGet, IActionResult, Task, HistoryDto, Date, Entity (+18 more)

### Community 29 - "Account"
Cohesion: 0.14
Nodes (14): Account, BudgetControlled, Code, IsAuxAsset, IsAuxCxc, IsAuxCxp, IsAuxLoan, IsBankAccount (+6 more)

### Community 30 - "Countify.Infrastructure"
Cohesion: 0.08
Nodes (29): Countify.Api, net10.0, Countify.Application, net10.0, Microsoft.NET.Sdk, Countify.Domain, net10.0, Microsoft.NET.Sdk (+21 more)

### Community 31 - "AuthResponse"
Cohesion: 0.08
Nodes (28): IJwtService, IList, LoginCommand, LoginCommandHandler, CancellationToken, IdentityRole, RoleManager, Task (+20 more)

### Community 32 - "JournalEntryLine"
Cohesion: 0.07
Nodes (26): JournalEntryLine, Account, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName (+18 more)

### Community 33 - "AccountsReceivableDocumentDraftRequest"
Cohesion: 0.12
Nodes (15): AccountsReceivableDocumentDraftRequest, Amount, AppliesTo, ConceptId, CurrencyId, CustomerId, Date, DepartmentId (+7 more)

### Community 34 - "Countify.Api.Controllers"
Cohesion: 0.06
Nodes (25): SettingsController, CreateCustomerCommandValidator, UpdateCustomerCommandValidator, CustomerProfile, ProductProfile, Countify.Application.Features.Customers.Commands.DeleteCustomer, Countify.Application.Features.Configurations.Queries.GetCompanySettings, Countify.Application.Features.Products.DTOs (+17 more)

### Community 35 - "BankTransactionDto"
Cohesion: 0.08
Nodes (25): BankTransactionDto, Amount, AppliesToReceivableId, BankAccountId, BankAccountName, BankReconciliationId, Beneficiary, Concept (+17 more)

### Community 36 - "UserDto"
Cohesion: 0.11
Nodes (22): UserDto, CreatedAt, Email, FirstName, FullName, Id, IsActive, LastName (+14 more)

### Community 37 - "ProductAccount"
Cohesion: 0.09
Nodes (21): Product, Code, Name, ProductAccount, CostAccount, CostAccountId, IncomeAccount, IncomeAccountId (+13 more)

### Community 38 - "ApiKeyAuthenticationHandler"
Cohesion: 0.07
Nodes (25): AuthenticateResult, AuthenticationHandler, AuthenticationProperties, AuthenticationSchemeOptions, AuthorizeAttribute, ApiKeyAuthenticationDefaults, ApiKeyAuthenticationHandler, IOptions (+17 more)

### Community 39 - "JournalEntryDto"
Cohesion: 0.09
Nodes (22): JournalEntryDto, Code, Concept, CreditTotal, DebitTotal, DifferenceAmount, EntryNumber, Gid (+14 more)

### Community 40 - "CompanySettings"
Cohesion: 0.09
Nodes (23): CompanySettings, Address, CompanyName, DefaultDepartment, DefaultDepartmentId, DefaultProject, DefaultProjectId, Email (+15 more)

### Community 41 - "JournalEntryPdfBuilder.cs"
Cohesion: 0.16
Nodes (10): BankStatementPdfBuilder, IContainer, CustomerMovementsPdfBuilder, IContainer, Countify.Infrastructure.TemplateBuilder, Countify.Application.Features.Banks, questpdf_fluent, questpdf_helpers (+2 more)

### Community 42 - "UpdateJournalEntryCommand"
Cohesion: 0.15
Nodes (13): UpdateJournalEntryCommand, Code, Concept, Id, Lines, Observations, PeriodId, Reference (+5 more)

### Community 43 - "JournalEntryLineDto"
Cohesion: 0.10
Nodes (19): JournalEntryLineDto, AccountCode, AccountId, AccountName, AppliesToPayableId, AppliesToReceivableId, Concept, Credit (+11 more)

### Community 44 - "CreateAccountCommand"
Cohesion: 0.12
Nodes (18): CreateAccountCommand, BudgetControlled, BudgetLine, Code, IsAuxAsset, IsAuxCxc, IsAuxCxp, IsAuxLoan (+10 more)

### Community 45 - "Countify.Domain.Entities.Accounting"
Cohesion: 0.12
Nodes (5): OrderColumns, Ascending, Descending, Countify.Domain.Common, Countify.Domain.Entities.Accounting

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
Cohesion: 0.11
Nodes (18): BankAccount, AccountingAccount, AccountingAccountId, AccountNumber, Balance, CheckNumber, Code, CurrencyId (+10 more)

### Community 50 - "ApplicationUser"
Cohesion: 0.12
Nodes (16): ApplicationUser, CreatedAt, CreatedBy, FirstName, FullName, IsActive, LastActivity, LastName (+8 more)

### Community 51 - "BudgetsController"
Cohesion: 0.22
Nodes (13): BudgetRequest, BudgetResponse, BudgetLineResponse, BudgetsController, Authorize, CancellationToken, Guid, HttpDelete (+5 more)

### Community 52 - "CreateProductCommand"
Cohesion: 0.31
Nodes (8): CreateProductCommand, Code, Name, CreateProductCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 53 - "UpdateUserCommand"
Cohesion: 0.13
Nodes (15): UpdateUserCommand, Email, FirstName, Id, IsActive, LastName, Phone, RoleId (+7 more)

### Community 54 - "ProductAccountDto"
Cohesion: 0.11
Nodes (17): ProductAccountDto, CostAccountCode, CostAccountId, CostAccountName, Id, IncomeAccountCode, IncomeAccountId, IncomeAccountName (+9 more)

### Community 55 - "GetRoleByIdQueryHandler"
Cohesion: 0.14
Nodes (13): PermissionDto, Description, Id, Name, RoleDetailDto, Permissions, IList, GetRoleByIdQueryHandler (+5 more)

### Community 56 - "IEntityTypeConfiguration"
Cohesion: 0.12
Nodes (14): CustomerType, BasicCustomerTypes, Items, AccountConfiguration, EntityTypeBuilder, CustomerTypeConfiguration, EntityTypeBuilder, RoleConfiguration (+6 more)

### Community 57 - ".Delete"
Cohesion: 0.28
Nodes (9): AccountsReceivableConceptsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 58 - "CreateCustomerCommand"
Cohesion: 0.12
Nodes (18): CreateCustomerCommand, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId, Email (+10 more)

### Community 59 - ".SaveChangesAsync"
Cohesion: 0.20
Nodes (5): CancellationToken, List, Task, CancellationToken, Task

### Community 60 - "Budget"
Cohesion: 0.16
Nodes (11): BudgetLine, Budget, FiscalYear, Lines, Name, List, Guid, BudgetConfiguration (+3 more)

### Community 61 - "LoginRequest"
Cohesion: 0.50
Nodes (3): LoginRequest, Password, Username

### Community 62 - "DocumentTypeDto"
Cohesion: 0.18
Nodes (13): DocumentTypeDto, Code, Id, IsDefault, Name, Guid, GetDocumentTypesQuery, GetDocumentTypesQueryHandler (+5 more)

### Community 63 - "CustomerMovementDto"
Cohesion: 0.10
Nodes (21): CustomerMovementDto, AgingBucket, Amount, AmountLocal, Applications, AppliedAmount, ConceptDescription, Credit (+13 more)

### Community 64 - "AccountsController.cs"
Cohesion: 0.15
Nodes (10): CreateAccountCommandValidator, UpdateAccountCommandValidator, AccountProfile, Countify.Application.Features.Accounts.DTOs, Countify.Application.Features.Accounts.Commands.CreateAccount, Countify.Application.Features.JournalEntries.Queries.GetAccountMovements, Countify.Application.Features.Accounts.Profiles, Countify.Application.Features.Accounts.Queries.GetAccounts (+2 more)

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

### Community 69 - "Countify.Infrastructure.Persistence"
Cohesion: 0.22
Nodes (11): DateTime, Guid, MigrationBuilder, AddReceivableFiscalNotesAndAttachments, Countify.Infrastructure.Migrations, Countify.Infrastructure.Persistence, microsoft_entityframeworkcore_infrastructure, microsoft_entityframeworkcore_metadata (+3 more)

### Community 70 - "UserRoleHasPermissionRequirement"
Cohesion: 0.09
Nodes (20): Arquitectura / capas, Contrato API (FASE 1), Countify — Convenciones del proyecto, Flujo de trabajo (obligatorio), Modelo contable (FASE 1 — corregido), AuthorizationHandler, AuthorizationHandlerContext, PermissionAuthorizationHandler (+12 more)

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
Nodes (11): UserDetailDto, CreatedBy, LastActivity, DateTime, GetUserByIdQueryHandler, CancellationToken, IdentityRole, IMapper (+3 more)

### Community 76 - "CreateUserCommand"
Cohesion: 0.13
Nodes (15): CreateUserCommand, Email, FirstName, LastName, Password, Phone, RoleId, Username (+7 more)

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

### Community 83 - "UploadAccountsReceivableDocumentAttachmentCommand"
Cohesion: 0.06
Nodes (37): IFileStorage, CancellationToken, Stream, Task, DeleteAccountsReceivableDocumentAttachmentCommand, Id, DeleteAccountsReceivableDocumentAttachmentCommandHandler, CancellationToken (+29 more)

### Community 84 - "CustomerDto"
Cohesion: 0.11
Nodes (19): CustomerDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Address, Code, CreditDays, CreditLimit (+11 more)

### Community 85 - "AccountsReceivableDocumentAttachment"
Cohesion: 0.12
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
Cohesion: 0.07
Nodes (28): BaseEntity, Id, Guid, Currency, Code, ExchangeRate, IsActive, Name (+20 more)

### Community 90 - "GetJournalEntriesQuery"
Cohesion: 0.21
Nodes (11): GetJournalEntriesQuery, FromDate, Search, Status, ToDate, GetJournalEntriesQueryHandler, CancellationToken, DateTime (+3 more)

### Community 91 - "CreateQualityCommand"
Cohesion: 0.08
Nodes (31): QualitiesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+23 more)

### Community 92 - "RoleDto"
Cohesion: 0.24
Nodes (10): RoleDto, Id, Name, PermissionCount, GetRolesQuery, GetRolesQueryHandler, CancellationToken, IMapper (+2 more)

### Community 93 - "RolesController.cs"
Cohesion: 0.08
Nodes (14): automapper_queryableextensions, CreateRoleCommandValidator, UpdateRoleCommandValidator, RoleProfile, UserProfile, Countify.Application.Features.Roles.Commands.UpdateRole, Countify.Application.Features.Roles.Queries.GetRoles, Countify.Application.Features.Users.Queries.GetUserById (+6 more)

### Community 94 - "InitialCreate"
Cohesion: 0.18
Nodes (9): DateTime, DateTimeOffset, Guid, MigrationBuilder, InitialCreate, DateTime, DateTimeOffset, Guid (+1 more)

### Community 95 - "DatabaseExtensions.cs"
Cohesion: 0.14
Nodes (11): ApplicationServiceRegistration, IServiceCollection, Countify.Api.DependencyInjection, Countify.Application.DependencyInjection, Countify.Infrastructure.Extensions, Countify.Infrastructure.DependencyInjection, microsoft_extensions_dependencyinjection, microsoft_extensions_hosting (+3 more)

### Community 96 - "AccountingPeriod"
Cohesion: 0.16
Nodes (11): AccountingPeriod, EndDate, IsClosed, Month, StartDate, DateTime, BasicAccountingPeriods, Items (+3 more)

### Community 97 - ".AddApiServices"
Cohesion: 0.16
Nodes (10): Permisos (patrón de futuras fases también), AccountPolicies, AuthorizationOptions, JournalEntryPolicies, AuthorizationOptions, ProjectPolicies, AuthorizationOptions, ApiServiceRegistration (+2 more)

### Community 98 - "YearEndClosingEntry"
Cohesion: 0.29
Nodes (7): YearEndClosingEntry, GeneratedBy, JournalEntryId, PeriodId, Guid, YearEndClosingEntryConfiguration, EntityTypeBuilder

### Community 99 - "AddAccountingModule"
Cohesion: 0.20
Nodes (8): DateTime, Guid, MigrationBuilder, AddAccountingModule, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 100 - "AddBanksAndBankReconciliation"
Cohesion: 0.20
Nodes (8): DateTime, Guid, MigrationBuilder, AddBanksAndBankReconciliation, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 101 - "DepartmentsController.cs"
Cohesion: 0.18
Nodes (8): CreateDepartmentCommandValidator, UpdateDepartmentCommandValidator, DepartmentProfile, Countify.Application.Features.Departments.Commands.UpdateDepartment, Countify.Application.Features.Departments.Profiles, Countify.Application.Features.Departments.Commands.CreateDepartment, Countify.Application.Features.Departments.Queries.GetDepartments, Countify.Application.Features.Departments.Commands.DeleteDepartment

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

### Community 115 - "ICurrentUserService"
Cohesion: 0.17
Nodes (9): ICurrentUserService, Guid, UserId, UserName, CurrentUserService, Guid, UserId, UserName (+1 more)

### Community 116 - "fluentvalidation"
Cohesion: 0.04
Nodes (51): AbstractValidator, DeleteAccountingPeriodCommandValidator, DeleteAccountCommandValidator, CreateAccountsReceivableDocumentLinesCommandValidator, ForgotPasswordCommandValidator, LoginCommandValidator, RefreshTokenCommandValidator, ResetPasswordCommandValidator (+43 more)

### Community 117 - "CreateProjectCommand"
Cohesion: 0.19
Nodes (12): CreateProjectCommand, Code, GroupId, Name, CreateProjectCommandHandler, CancellationToken, Guid, IMapper (+4 more)

### Community 118 - ".Validate"
Cohesion: 0.36
Nodes (4): JournalEntryRules, EntryConceptType, Guid, IEnumerable

### Community 119 - "AccountsReceivableDocumentLineDto"
Cohesion: 0.14
Nodes (14): AccountsReceivableDocumentLineDto, Amount, AppliedAmount, AppliedConcept, AppliedCurrencyCode, AppliedDate, AppliedDocumentId, AppliedDocumentNo (+6 more)

### Community 120 - "AccountsReceivableConceptDto"
Cohesion: 0.12
Nodes (20): AccountsReceivableConceptDto, AccountCode, AccountId, AccountName, Description, GeneratePosting, Id, IsFiscalNote (+12 more)

### Community 121 - "AssignRoleCommand"
Cohesion: 0.29
Nodes (7): AssignRoleCommand, RoleName, UserId, AssignRoleCommandHandler, CancellationToken, Task, UserManager

### Community 122 - "RequestParameter"
Cohesion: 0.25
Nodes (7): RequestParameter, All, Column, Order, PageNumber, PageSize, Parameter

### Community 123 - ".AddInfrastructureServices"
Cohesion: 0.11
Nodes (15): ISeeder, CancellationToken, Task, SeederOptions, Enabled, SeedConfiguration, SeedTransactions, IConfiguration (+7 more)

### Community 124 - ".OnModelCreating"
Cohesion: 0.25
Nodes (7): IdentityRole, IdentityUserRole, ModelBuilder, IdentityRoleClaim, IdentityUserClaim, IdentityUserLogin, IdentityUserToken

### Community 125 - "UpdateProjectGroupCommand"
Cohesion: 0.08
Nodes (29): ProjectGroupsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+21 more)

### Community 126 - ".Delete"
Cohesion: 0.28
Nodes (9): DocumentTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 127 - "IEmailService"
Cohesion: 0.33
Nodes (4): IEmailService, Task, EmailService, Task

### Community 128 - "VoidJournalEntryCommand"
Cohesion: 0.33
Nodes (6): VoidJournalEntryCommand, Id, VoidJournalEntryCommandHandler, CancellationToken, Guid, Task

### Community 129 - ".Close"
Cohesion: 0.33
Nodes (8): AccountingPeriodsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, IActionResult, Task

### Community 130 - ".Handle"
Cohesion: 0.16
Nodes (11): BudgetAvailabilityValidator, CancellationToken, DateTime, Guid, IEnumerable, Task, UpdateJournalEntryCommandHandler, CancellationToken (+3 more)

### Community 131 - "Migration"
Cohesion: 0.08
Nodes (20): Guid, MigrationBuilder, AddBudgetsAndBudgetPermissions, DateTime, DateTimeOffset, Guid, ModelBuilder, MigrationBuilder (+12 more)

### Community 132 - ".BuildSection"
Cohesion: 0.22
Nodes (9): IncomeStatementSectionDto, Code, Lines, Name, Total, List, Dictionary, List (+1 more)

### Community 133 - "CreateFiscalControlCommand"
Cohesion: 0.11
Nodes (20): CreateFiscalControlCommand, Branch, CAI, DocumentCode, DocumentType, EmissionDate, EmissionLimitDate, EmissionPoint (+12 more)

### Community 134 - "Countify.Domain.Seeders"
Cohesion: 0.05
Nodes (30): Seeding — GENERALIZADO (base para futuras entidades/fases), BasicBudgets, Items, BasicCompanySettings, Items, BasicDepartments, Items, BasicDocumentTypes (+22 more)

### Community 135 - "IncomeStatementLineDto"
Cohesion: 0.22
Nodes (7): IncomeStatementLineDto, AccountCode, AccountId, AccountName, Balance, Guid, Countify.Application.Features.Reports.DTOs

### Community 136 - "Currency"
Cohesion: 0.32
Nodes (5): Currency, BasicCurrencies, Items, CurrencyConfiguration, EntityTypeBuilder

### Community 137 - ".BuildModel"
Cohesion: 0.29
Nodes (6): CountifyDbContextModelSnapshot, DateTime, DateTimeOffset, Guid, ModelBuilder, ModelSnapshot

### Community 138 - "CustomerMovementApplicationDto"
Cohesion: 0.18
Nodes (11): CustomerMovementApplicationDto, Amount, Id, RelatedConcept, RelatedDate, RelatedDocumentId, RelatedDocumentNo, RelatedIsCredit (+3 more)

### Community 139 - "IncomeStatementDto"
Cohesion: 0.22
Nodes (9): IncomeStatementDto, EndDate, GrossProfit, NetResult, Sections, TotalCostOfSales, TotalExpenses, TotalRevenue (+1 more)

### Community 140 - "JournalEntryStatus"
Cohesion: 0.33
Nodes (5): JournalEntryStatus, Approved, Draft, Posted, Voided

### Community 141 - "CreateDepartmentCommand"
Cohesion: 0.21
Nodes (11): CreateDepartmentCommand, Code, Name, CreateDepartmentCommandHandler, CancellationToken, Guid, IMapper, Task (+3 more)

### Community 142 - "CustomerTypesController.cs"
Cohesion: 0.15
Nodes (9): CreateCustomerTypeCommandValidator, UpdateCustomerTypeCommandValidator, CustomerTypeProfile, Countify.Application.Features.CustomerTypes.DTOs, Countify.Application.Features.CustomerTypes.Commands.DeleteCustomerType, Countify.Application.Features.CustomerTypes.Commands.UpdateCustomerType, Countify.Application.Features.CustomerTypes.Commands.CreateCustomerType, Countify.Application.Features.CustomerTypes.Profiles (+1 more)

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

### Community 147 - "CreateProjectGroupCommand"
Cohesion: 0.31
Nodes (8): CreateProjectGroupCommand, Code, Name, CreateProjectGroupCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 148 - "AuthController"
Cohesion: 0.38
Nodes (6): AuthController, Authorize, HttpGet, HttpPost, IActionResult, Task

### Community 149 - "GetProductsQueryHandler"
Cohesion: 0.24
Nodes (11): ProductDto, Code, Id, Name, Guid, GetProductsQuery, GetProductsQueryHandler, CancellationToken (+3 more)

### Community 150 - "CreateAccountingPeriodCommand"
Cohesion: 0.31
Nodes (8): CreateAccountingPeriodCommand, Month, CreateAccountingPeriodCommandHandler, CancellationToken, DateTime, Guid, Task, CreateAccountingPeriodCommandValidator

### Community 151 - "Countify.Domain.Entities.Auth"
Cohesion: 0.08
Nodes (22): ForgotPasswordRequest, Email, RefreshTokenRequest, AccessToken, RefreshToken, Countify.Infrastructure.Persistence.Services, Countify.Application.Features.Auth.DTOs, Countify.Infrastructure.Services (+14 more)

### Community 152 - "CreateAccountsReceivableDocumentLinesCommand"
Cohesion: 0.18
Nodes (12): CreateAccountsReceivableDocumentLinesCommand, DocumentId, Lines, CreateAccountsReceivableDocumentLinesCommandHandler, LineItem, Amount, AppliedDocumentId, CancellationToken (+4 more)

### Community 153 - "microsoft_aspnetcore_authorization"
Cohesion: 0.21
Nodes (7): AccountsReceivableDocumentPolicies, AuthorizationOptions, CustomerPolicies, AuthorizationOptions, Countify.Api.Authorization.Handlers, Countify.Api.Authorization.Requirements, microsoft_aspnetcore_authorization

### Community 154 - "FiscalControl"
Cohesion: 0.11
Nodes (18): FiscalControl, Branch, CAI, DocumentCode, DocumentType, EmissionDate, EmissionLimitDate, EmissionPoint (+10 more)

### Community 155 - "4. Qué falta implementar (backend)"
Cohesion: 0.13
Nodes (15): 4.1 Campos fiscales en `AccountsReceivableDocument` (nullable; solo N/C y N/D), 4.2 Nueva entidad `FiscalControl` (← `ControlesFiscales`), 4.3 Enums nuevos, 4.4 Numeración, 4.5 Conceptos (seeder), 4.6 Adjuntos, 4.7 Permisos, 4.8 Migración EF (+7 more)

### Community 156 - "ProductAccountsController.cs"
Cohesion: 0.24
Nodes (7): ProductAccountProfile, Countify.Application.Features.ProductAccounts.Profiles, Countify.Application.Features.ProductAccounts.DTOs, Countify.Application.Features.ProductAccounts.Commands.CreateProductAccount, Countify.Application.Features.ProductAccounts.Queries.GetProductAccounts, Countify.Application.Features.ProductAccounts.Commands.UpdateProductAccount, Countify.Application.Features.ProductAccounts.Commands.DeleteProductAccount

### Community 157 - "TrialBalanceLineDto"
Cohesion: 0.25
Nodes (8): TrialBalanceLineDto, AccountCode, AccountId, AccountName, Balance, Credit, Debit, Guid

### Community 158 - ".SaveChangesAsync"
Cohesion: 0.19
Nodes (11): CreateCustomerTypeCommand, AccountingAccountId, Code, Name, CreateCustomerTypeCommandHandler, CancellationToken, Guid, IMapper (+3 more)

### Community 159 - ".Delete"
Cohesion: 0.28
Nodes (9): ProductAccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 160 - "TransactionSeeder"
Cohesion: 0.47
Nodes (5): TransactionSeeder, CancellationToken, ILogger, IOptions, Task

### Community 161 - "CustomerMovementsDto"
Cohesion: 0.18
Nodes (11): CustomerMovementsDto, Aging, CustomerCode, CustomerId, CustomerName, FromDate, Movements, Saldo (+3 more)

### Community 162 - "GetCustomerMovementsQuery"
Cohesion: 0.28
Nodes (9): GetCustomerMovementsQuery, CustomerId, FromDate, ToDate, GetCustomerMovementsQueryHandler, CancellationToken, DateTime, Guid (+1 more)

### Community 163 - "UpdateProductCommand"
Cohesion: 0.22
Nodes (9): UpdateProductCommand, Code, Id, Name, UpdateProductCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 165 - "BudgetRequest"
Cohesion: 0.25
Nodes (8): BudgetLineRequest, BudgetLineResponse, BudgetRequest, FiscalYear, Lines, Name, BudgetResponse, List

### Community 166 - "DeleteJournalEntryCommand"
Cohesion: 0.33
Nodes (6): DeleteJournalEntryCommand, Id, DeleteJournalEntryCommandHandler, CancellationToken, Guid, Task

### Community 167 - "UpdateCustomerTypeCommand"
Cohesion: 0.20
Nodes (10): UpdateCustomerTypeCommand, AccountingAccountId, Code, Id, Name, UpdateCustomerTypeCommandHandler, CancellationToken, Guid (+2 more)

### Community 168 - "AccountsReceivableConceptsController.cs"
Cohesion: 0.15
Nodes (9): CreateAccountsReceivableConceptCommandValidator, UpdateAccountsReceivableConceptCommandValidator, AccountsReceivableConceptProfile, Countify.Application.Features.AccountsReceivableConcepts.Profiles, Countify.Application.Features.AccountsReceivableConcepts.DTOs, Countify.Application.Features.AccountsReceivableConcepts.Commands.DeleteAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Commands.CreateAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Commands.UpdateAccountsReceivableConcept (+1 more)

### Community 169 - "CreateDocumentTypeCommand"
Cohesion: 0.27
Nodes (9): CreateDocumentTypeCommand, Code, IsDefault, Name, CreateDocumentTypeCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 170 - "UpdateQualityCommand"
Cohesion: 0.22
Nodes (9): UpdateQualityCommand, Code, Id, Name, UpdateQualityCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 171 - "GetPendingAccountsReceivableDocumentsQuery"
Cohesion: 0.27
Nodes (9): GetPendingAccountsReceivableDocumentsQuery, CustomerId, ExcludeDocumentIds, GetPendingAccountsReceivableDocumentsQueryHandler, CancellationToken, Guid, IMapper, List (+1 more)

### Community 172 - ".Delete"
Cohesion: 0.28
Nodes (9): CustomerTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 173 - "AccountsReceivableDocumentLine"
Cohesion: 0.20
Nodes (9): AccountsReceivableDocumentLine, Amount, AppliedDocument, AppliedDocumentId, Document, DocumentId, Guid, AccountsReceivableDocumentLineConfiguration (+1 more)

### Community 174 - "EntryConceptType"
Cohesion: 0.40
Nodes (4): EntryConceptType, Credit, Debit, Other

### Community 175 - "Countify.Domain.Entities.AccountsReceivable"
Cohesion: 0.07
Nodes (21): CreateAccountsReceivableDocumentCommandValidator, UpdateAccountsReceivableDocumentCommandValidator, AccountsReceivableDocumentProfile, Countify.Application.Features.AccountsReceivableDocuments.Queries.GetAccountsReceivableDocumentById, Countify.Application.Features.AccountsReceivableDocuments.Queries.GetCustomerMovements, Countify.Application.Features.AccountsReceivableDocuments.Commands.UpdateReceiptNumber, Countify.Application.Features.AccountsReceivableDocuments.DTOs, Countify.Application.Features.AccountsReceivableDocuments.Commands.VoidAccountsReceivableDocument (+13 more)

### Community 176 - "CreateRoleCommand"
Cohesion: 0.29
Nodes (7): CreateRoleCommand, Name, CreateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 177 - "Profile"
Cohesion: 0.06
Nodes (22): AccountingPeriodProfile, BankAccountProfile, SettingsProfile, CurrencyProfile, DocumentTypeProfile, HistoryProfile, JournalEntryProfile, QualityProfile (+14 more)

### Community 178 - ".Delete"
Cohesion: 0.28
Nodes (9): FiscalControlsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 179 - "AccountsReceivableDocumentAttachmentDto"
Cohesion: 0.18
Nodes (10): AccountsReceivableDocumentAttachmentDto, ContentType, DocumentId, FileName, Id, Size, UploadedBy, UploadedOn (+2 more)

### Community 180 - "CloseAccountingPeriodCommand"
Cohesion: 0.29
Nodes (7): CloseAccountingPeriodCommand, Id, CloseAccountingPeriodCommandHandler, CancellationToken, Guid, Task, CloseAccountingPeriodCommandValidator

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

### Community 186 - "DeleteAccountCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountCommand, Id, DeleteAccountCommandHandler, CancellationToken, Guid, Task

### Community 187 - "Cuentas por Cobrar (FASE 3 del roadmap maestro) — plan de cierre"
Cohesion: 0.12
Nodes (16): 10. Estado de cierre (FASE 3) — actualizado, 1. Estado actual en Countify, 3. Decisiones tomadas, 5. Frontend (Angular, `Countify-PanelUser`), 6. Migración de datos (FASE 14, cuando toque), 7. Consultas/Reportes, 8. Criterio de terminado (FASE 3), 9. Fuera de alcance aquí (+8 more)

### Community 188 - "RolePermission"
Cohesion: 0.25
Nodes (8): RolePermission, Permission, PermissionId, Role, RoleId, IdentityRole, RolePermissionConfiguration, EntityTypeBuilder

### Community 189 - "UpdateRolePermissionsCommand"
Cohesion: 0.22
Nodes (9): UpdateRolePermissionsCommand, PermissionIds, RoleId, UpdateRolePermissionsCommandHandler, CancellationToken, IdentityRole, List, RoleManager (+1 more)

### Community 190 - "IRequestHandler"
Cohesion: 0.13
Nodes (16): UpdateAccountCommandHandler, CancellationToken, IMapper, Task, ForgotPasswordCommand, ForgotPasswordCommandHandler, CancellationToken, Task (+8 more)

### Community 191 - "ProjectGroupsController.cs"
Cohesion: 0.13
Nodes (10): CreateProjectCommandValidator, CreateProjectGroupCommandValidator, ProjectProfile, Countify.Application.Features.Projects.Profiles, Countify.Application.Features.Projects.DTOs, Countify.Application.Features.Projects.Commands.UpdateProjectGroup, Countify.Application.Features.Projects.Commands.DeleteProjectGroup, Countify.Application.Features.Projects.Queries.GetProjectGroups (+2 more)

### Community 192 - "UpdateAccountsReceivableDocumentLineCommand"
Cohesion: 0.29
Nodes (7): UpdateAccountsReceivableDocumentLineCommand, Amount, Id, UpdateAccountsReceivableDocumentLineCommandHandler, CancellationToken, Guid, Task

### Community 193 - ".ValidateAsync"
Cohesion: 0.60
Nodes (4): ProductAccountRules, CancellationToken, Guid, Task

### Community 194 - "DeleteAccountsReceivableConceptCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountsReceivableConceptCommand, Id, DeleteAccountsReceivableConceptCommandHandler, CancellationToken, Guid, Task

### Community 195 - "IConfigureOptions"
Cohesion: 0.32
Nodes (5): AccountsReceivableConceptPolicies, AuthorizationOptions, ReportsPolicies, AuthorizationOptions, IConfigureOptions

### Community 196 - "FiscalControlsController.cs"
Cohesion: 0.15
Nodes (9): CreateFiscalControlCommandValidator, UpdateFiscalControlCommandValidator, FiscalControlProfile, Countify.Application.Features.FiscalControls.Commands.DeleteFiscalControl, Countify.Application.Features.FiscalControls.Commands.UpdateFiscalControl, Countify.Application.Features.FiscalControls.Commands.CreateFiscalControl, Countify.Application.Features.FiscalControls.Profiles, Countify.Application.Features.FiscalControls.Queries.GetFiscalControls (+1 more)

### Community 197 - "UpdateReceiptNumberCommand"
Cohesion: 0.29
Nodes (7): UpdateReceiptNumberCommand, Id, ReceiptNumber, UpdateReceiptNumberCommandHandler, CancellationToken, Guid, Task

### Community 198 - "UpdateProductAccountCommand"
Cohesion: 0.29
Nodes (7): UpdateProductAccountCommand, Id, UpdateProductAccountCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 199 - "GetAccountsReceivableDocumentsQueryHandler"
Cohesion: 0.43
Nodes (6): GetAccountsReceivableDocumentsQuery, GetAccountsReceivableDocumentsQueryHandler, CancellationToken, IMapper, List, Task

### Community 200 - "ProductAccountRequest"
Cohesion: 0.25
Nodes (7): ProductAccountRequest, CostAccountId, IncomeAccountId, InventoryAccountId, ProductId, QualityId, Guid

### Community 201 - "ChangePasswordCommand"
Cohesion: 0.25
Nodes (8): ChangePasswordCommand, CurrentPassword, Id, NewPassword, ChangePasswordCommandHandler, CancellationToken, Task, UserManager

### Community 202 - "CountifyDbContextFactory"
Cohesion: 0.29
Nodes (6): CountifyDbContextFactory, DesignTimeCurrentUserService, Guid, UserId, UserName, IDesignTimeDbContextFactory

### Community 204 - "GetAccountByIdQuery"
Cohesion: 0.29
Nodes (7): GetAccountByIdQuery, Id, GetAccountByIdQueryHandler, CancellationToken, Guid, IMapper, Task

### Community 205 - ".AssignAsync"
Cohesion: 0.22
Nodes (8): UpdateAccountsReceivableDocumentCommandHandler, CancellationToken, IMapper, Task, FiscalNoteNumberingFactory, CancellationToken, FiscalControl, Task

### Community 206 - ".Get"
Cohesion: 0.38
Nodes (5): Authorize, HttpGet, HttpPut, IActionResult, Task

### Community 207 - "DeleteAccountsReceivableDocumentLineCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountsReceivableDocumentLineCommand, Id, DeleteAccountsReceivableDocumentLineCommandHandler, CancellationToken, Guid, Task

### Community 208 - "GetUserInfoQueryHandler"
Cohesion: 0.14
Nodes (15): UserInfoResponse, Email, FullName, Permissions, Roles, UserId, UserName, IList (+7 more)

### Community 211 - "ResetPasswordCommand.cs"
Cohesion: 0.38
Nodes (5): ResetPasswordCommand, ResetPasswordCommandHandler, CancellationToken, Task, UserManager

### Community 212 - "DeleteDocumentTypeCommand"
Cohesion: 0.33
Nodes (6): DeleteDocumentTypeCommand, Id, DeleteDocumentTypeCommandHandler, CancellationToken, Guid, Task

### Community 214 - "VoidAccountsReceivableDocumentCommand"
Cohesion: 0.33
Nodes (6): VoidAccountsReceivableDocumentCommand, Id, VoidAccountsReceivableDocumentCommandHandler, CancellationToken, Guid, Task

### Community 215 - "ResetPasswordRequest"
Cohesion: 0.40
Nodes (4): ResetPasswordRequest, Email, NewPassword, Token

### Community 216 - "DeleteCustomerCommand"
Cohesion: 0.33
Nodes (6): DeleteCustomerCommand, Id, DeleteCustomerCommandHandler, CancellationToken, Guid, Task

### Community 217 - "DeleteProductCommand"
Cohesion: 0.33
Nodes (6): DeleteProductCommand, Id, DeleteProductCommandHandler, CancellationToken, Guid, Task

### Community 218 - ".CreateAsync"
Cohesion: 0.47
Nodes (3): DraftCreationResult, CancellationToken, Task

### Community 220 - "GetCompanySettingsQuery"
Cohesion: 0.40
Nodes (5): GetCompanySettingsQuery, GetCompanySettingsQueryHandler, CancellationToken, IMapper, Task

### Community 221 - ".ValidateAsync"
Cohesion: 0.29
Nodes (6): JournalEntryAuxValidator, CancellationToken, Guid, Task, IReadOnlyCollection, IReadOnlyDictionary

### Community 222 - "DeleteQualityCommand"
Cohesion: 0.33
Nodes (6): DeleteQualityCommand, Id, DeleteQualityCommandHandler, CancellationToken, Guid, Task

### Community 223 - "DeleteUserCommand"
Cohesion: 0.32
Nodes (6): DeleteUserCommand, Id, DeleteUserCommandHandler, CancellationToken, Task, UserManager

### Community 224 - "FiscalDocumentType"
Cohesion: 0.29
Nodes (6): FiscalDocumentType, CreditNote, DebitNote, DispatchGuide, Invoicing, Retention

### Community 225 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 235 - "Countify.Domain.Authorization"
Cohesion: 0.29
Nodes (4): HistoryPolicies, AuthorizationOptions, Countify.Domain.Authorization, system_reflection

### Community 238 - "Countify.Api.Authorization.Policies"
Cohesion: 0.22
Nodes (6): RolePolicies, AuthorizationOptions, UserPolicies, AuthorizationOptions, Countify.Application.Features.DocumentTypes.Queries.GetDocumentTypes, Countify.Api.Authorization.Policies

## Knowledge Gaps
- **1297 isolated node(s):** `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName`, `ApiKey`, `Permission` (+1292 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 2060 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **12 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Response` connect `Response` to `UpdateCompanySettingsCommand`, `UpdateDepartmentCommand`, `PaginatedResponse`, `CustomerTypeDto`, `UpdateAccountsReceivableConceptCommand`, `IRequest`, `UpdateProjectCommand`, `CurrencyFeatures.cs`, `.HandleResult`, `GetTrialBalanceQuery`, `AccountMovementsResponse`, `HistoryDto`, `AuthResponse`, `UpdateJournalEntryCommand`, `CreateAccountCommand`, `CreateJournalEntryCommand`, `BudgetsController`, `CreateProductCommand`, `UpdateUserCommand`, `GetRoleByIdQueryHandler`, `CreateCustomerCommand`, `DocumentTypeDto`, `AccountingPeriodDto`, `CreateAccountsReceivableConceptCommand`, `GetUserByIdQueryHandler`, `CreateUserCommand`, `GetIncomeStatementQuery`, `UpdateAccountCommand`, `UploadAccountsReceivableDocumentAttachmentCommand`, `UpdateAccountsReceivableDocumentCommand`, `UpdateCustomerCommand`, `FiscalControlDto`, `CreateQualityCommand`, `CreateAccountsReceivableDocumentCommand`, `GetJournalEntryByIdQuery`, `UpdateFiscalControlCommand`, `UpdateRoleCommand`, `DeleteRoleCommandHandler`, `CreateProjectCommand`, `AccountsReceivableConceptDto`, `AssignRoleCommand`, `UpdateProjectGroupCommand`, `VoidJournalEntryCommand`, `.Handle`, `CreateFiscalControlCommand`, `CreateDepartmentCommand`, `UpdateDocumentTypeCommand`, `CreateProjectGroupCommand`, `GetProductsQueryHandler`, `CreateAccountingPeriodCommand`, `CreateAccountsReceivableDocumentLinesCommand`, `.SaveChangesAsync`, `GetCustomerMovementsQuery`, `UpdateProductCommand`, `DeleteJournalEntryCommand`, `UpdateCustomerTypeCommand`, `CreateDocumentTypeCommand`, `UpdateQualityCommand`, `GetPendingAccountsReceivableDocumentsQuery`, `CreateRoleCommand`, `CloseAccountingPeriodCommand`, `DeleteAccountingPeriodCommand`, `GetAccountsReceivableDocumentByIdQuery`, `GetCustomersQueryHandler`, `DeleteAccountCommand`, `UpdateRolePermissionsCommand`, `IRequestHandler`, `UpdateAccountsReceivableDocumentLineCommand`, `DeleteAccountsReceivableConceptCommand`, `UpdateReceiptNumberCommand`, `UpdateProductAccountCommand`, `GetAccountsReceivableDocumentsQueryHandler`, `ChangePasswordCommand`, `GetAccountByIdQuery`, `.AssignAsync`, `DeleteAccountsReceivableDocumentLineCommand`, `GetUserInfoQueryHandler`, `ResetPasswordCommand.cs`, `DeleteDocumentTypeCommand`, `VoidAccountsReceivableDocumentCommand`, `DeleteCustomerCommand`, `DeleteProductCommand`, `GetCompanySettingsQuery`, `DeleteQualityCommand`, `DeleteUserCommand`?**
  _High betweenness centrality (0.308) - this node is a cross-community bridge._
- **Why does `IUnitOfWork` connect `IUnitOfWork` to `UpdateCompanySettingsCommand`, `UpdateDepartmentCommand`, `PaginatedResponse`, `Response`, `CustomerTypeDto`, `JournalEntry`, `UpdateAccountsReceivableConceptCommand`, `IRequest`, `History`, `UpdateProjectCommand`, `IRepository`, `CurrencyFeatures.cs`, `Permission`, `BankTransaction`, `GetTrialBalanceQuery`, `UnitOfWork`, `AccountMovementsResponse`, `HistoryDto`, `AuthResponse`, `JournalEntryLine`, `UserDto`, `ProductAccount`, `CreateAccountCommand`, `CreateJournalEntryCommand`, `BankAccount`, `ApplicationUser`, `BudgetsController`, `CreateProductCommand`, `GetRoleByIdQueryHandler`, `IEntityTypeConfiguration`, `CreateCustomerCommand`, `Budget`, `DocumentTypeDto`, `.CreateOrUpdatePostingAsync`, `UserRoleHasPermissionRequirement`, `AccountingPeriodDto`, `CreateAccountsReceivableConceptCommand`, `BankReconciliation`, `AccountsReceivableDocument`, `GetProjectsQuery`, `GetIncomeStatementQuery`, `UploadAccountsReceivableDocumentAttachmentCommand`, `AccountsReceivableDocumentAttachment`, `UpdateCustomerCommand`, `FiscalControlDto`, `BaseEntity`, `GetJournalEntriesQuery`, `CreateQualityCommand`, `RoleDto`, `AccountingPeriod`, `YearEndClosingEntry`, `GetAccountsQuery`, `AccountsReceivableConcept`, `CreateAccountsReceivableDocumentCommand`, `GetJournalEntryByIdQuery`, `UpdateFiscalControlCommand`, `CreateProjectCommand`, `AccountsReceivableConceptDto`, `UpdateProjectGroupCommand`, `VoidJournalEntryCommand`, `.Handle`, `CreateFiscalControlCommand`, `CreateDepartmentCommand`, `BankTransactionType`, `UpdateDocumentTypeCommand`, `CreateProjectGroupCommand`, `GetProductsQueryHandler`, `CreateAccountingPeriodCommand`, `Countify.Domain.Entities.Auth`, `CreateAccountsReceivableDocumentLinesCommand`, `.SaveChangesAsync`, `GetCustomerMovementsQuery`, `UpdateProductCommand`, `DeleteJournalEntryCommand`, `UpdateCustomerTypeCommand`, `CreateDocumentTypeCommand`, `UpdateQualityCommand`, `GetPendingAccountsReceivableDocumentsQuery`, `AccountsReceivableDocumentLine`, `CloseAccountingPeriodCommand`, `DeleteAccountingPeriodCommand`, `GetAccountsReceivableDocumentByIdQuery`, `GetCustomersQueryHandler`, `DeleteAccountCommand`, `RolePermission`, `UpdateRolePermissionsCommand`, `IRequestHandler`, `UpdateAccountsReceivableDocumentLineCommand`, `.ValidateAsync`, `DeleteAccountsReceivableConceptCommand`, `UpdateReceiptNumberCommand`, `UpdateProductAccountCommand`, `GetAccountsReceivableDocumentsQueryHandler`, `GetAccountByIdQuery`, `.AssignAsync`, `DeleteAccountsReceivableDocumentLineCommand`, `GetUserInfoQueryHandler`, `DeleteDocumentTypeCommand`, `VoidAccountsReceivableDocumentCommand`, `DeleteCustomerCommand`, `DeleteProductCommand`, `.CreateAsync`, `GetCompanySettingsQuery`, `.ValidateAsync`, `DeleteQualityCommand`?**
  _High betweenness centrality (0.196) - this node is a cross-community bridge._
- **Why does `Countify.Domain.Entities.Accounting` connect `Countify.Domain.Entities.Accounting` to `Countify.Domain.Interfaces`, `Countify.Domain.Seeders`, `microsoft_entityframeworkcore`, `Currency`, `IRequest`, `CurrencyFeatures.cs`, `BankTransactionType`, `Countify.Domain.Entities.Auth`, `ProductAccountsController.cs`, `JournalEntryLine`, `Countify.Api.Controllers`, `ProductAccount`, `Countify.Domain.Entities.AccountsReceivable`, `Profile`, `ProjectGroupsController.cs`, `AccountsController.cs`, `FiscalControlsController.cs`, `AccountingPeriod`, `DepartmentsController.cs`?**
  _High betweenness centrality (0.062) - this node is a cross-community bridge._
- **What connects `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName` to the rest of the system?**
  _1297 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Countify.Domain.Interfaces` be split into smaller, more focused modules?**
  _Cohesion score 0.07237972508591066 - nodes in this community are weakly interconnected._
- **Should `UpdateCompanySettingsCommand` be split into smaller, more focused modules?**
  _Cohesion score 0.09090909090909091 - nodes in this community are weakly interconnected._
- **Should `CountifyDbContext` be split into smaller, more focused modules?**
  _Cohesion score 0.047619047619047616 - nodes in this community are weakly interconnected._