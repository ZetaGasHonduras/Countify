# Graph Report - Countify  (2026-10-14)

## Corpus Check
- 414 files · ~74,715 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 2, .user 1)

## Summary
- 3882 nodes · 7774 edges · 239 communities (222 shown, 17 thin omitted)
- Extraction: 95% EXTRACTED · 5% INFERRED · 0% AMBIGUOUS · INFERRED: 351 edges (avg confidence: 0.86)
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
- BanksController
- RolePermission
- BankTransaction
- GetTrialBalanceQuery
- GetProjectGroupsQueryHandler
- UnitOfWork
- ValidationException
- AccountMovementsResponse
- BudgetLine
- IUnitOfWork
- HistoryDto
- Account
- Countify.Infrastructure
- LoginCommandHandler
- JournalEntryLine
- AccountsReceivableDocumentDraftRequest
- Countify.Api.Controllers
- BankTransactionDto
- UserDto
- ProductAccount
- ApiKeyAuthenticationHandler
- JournalEntryDto
- CompanySettings
- CompanySettingsDto
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
- Countify.Domain.Enums
- ProductAccountDto
- GetRoleByIdQueryHandler
- IEntityTypeConfiguration
- .Delete
- CreateCustomerCommand
- .SaveChangesAsync
- Budget
- Countify.Application.Features.Auth.DTOs
- UpdateDocumentTypeCommand
- CustomerMovementDto
- CustomersController.cs
- http
- JournalEntryLineRequest
- .CreateOrUpdatePostingAsync
- UpdateUserCommand
- Countify.Infrastructure.Persistence
- PermissionService
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
- UpdateQualityCommand
- RoleDto
- RolesController.cs
- Migration
- Program.cs
- DocumentType
- .AddApiServices
- YearEndClosingEntry
- AddAccountingModule
- .BuildTargetModel
- DepartmentsController.cs
- GetAccountsQuery
- AccountsReceivableConcept
- CreateAccountsReceivableDocumentCommand
- GetJournalEntryByIdQuery
- .BuildTargetModel
- BudgetLineRequest
- Customer
- UpdateFiscalControlCommand
- UpdateRoleCommand
- AccountsReceivableDocumentsController
- SourceModule
- .Delete
- DeleteRoleCommandHandler
- CurrentUserService
- fluentvalidation
- ApiKeyAuthenticationHandler.cs
- .Validate
- AccountsReceivableDocumentLineDto
- AccountsReceivableConceptDto
- AssignRoleCommand
- RequestParameter
- .AddInfrastructureServices
- .OnModelCreating
- .Delete
- .Delete
- IEmailService
- JournalEntriesController.cs
- .Close
- .Handle
- 20260919192955_RenameBankOpeningBalanceToBalance.Designer.cs
- .BuildSection
- CreateFiscalControlCommand
- Seeding — GENERALIZADO (base para futuras entidades/fases)
- IncomeStatementLineDto
- Currency
- .BuildModel
- CustomerMovementApplicationDto
- IncomeStatementDto
- JournalEntryStatus
- .ApplyOrder
- CustomerTypesController.cs
- UserRoleHasPermissionRequirement
- BaseController
- DeleteCustomerTypeCommand
- GetCompanySettingsQuery.cs
- CreateProjectGroupCommand
- .HandleResult
- GetProductsQueryHandler
- CreateAccountingPeriodCommand
- Countify.Domain.Entities.Auth
- CreateAccountsReceivableDocumentLinesCommand
- microsoft_aspnetcore_authorization
- FiscalControl
- 4. Qué falta implementar (backend)
- AuthResponse
- TrialBalanceLineDto
- CreateCustomerTypeCommand
- UpdateProductAccountCommand
- TransactionSeeder
- CustomerMovementsDto
- GetCustomerMovementsQuery
- UpdateProductCommand
- Flujo bancario
- BudgetRequest
- DeleteJournalEntryCommand
- UpdateCustomerTypeCommand
- AccountsReceivableConceptsController.cs
- UpdateProjectGroupCommand
- CreateQualityCommand
- GetPendingAccountsReceivableDocumentsQuery
- .Delete
- AccountsReceivableDocumentLine
- EntryConceptType
- AccountsReceivableDocumentsController.cs
- CreateRoleCommand
- Profile
- .Delete
- AccountsReceivableDocumentAttachmentDto
- CloseAccountingPeriodCommand
- DeleteAccountingPeriodCommand
- GetAccountsReceivableDocumentByIdQuery
- AccountMovementDto
- GetCustomersQueryHandler
- ISeeder
- DeleteAccountCommand
- Cuentas por Cobrar (FASE 3 del roadmap maestro) — plan de cierre
- DeleteProjectGroupCommand
- UpdateRolePermissionsCommand
- IRequestHandler
- ProjectGroupsController.cs
- DeleteProjectCommand
- .ValidateAsync
- DeleteAccountsReceivableConceptCommand
- IConfigureOptions
- FiscalControlsController.cs
- .SaveChangesAsync
- BankPolicies
- GetAccountsReceivableDocumentsQueryHandler
- GetDocumentTypesQuery.cs
- ChangePasswordCommand
- DeleteDepartmentCommand
- Countify — Convenciones del proyecto
- GetAccountByIdQuery
- .CreateAsync
- CustomerType
- GetCustomersQuery.cs
- GetUserInfoQueryHandler
- CompanySettingsPolicies
- DocumentTypePolicies
- GetDepartmentsQuery.cs
- GetProductsQuery.cs
- ProjectGroupPolicies
- VoidAccountsReceivableDocumentCommand
- ResetPasswordRequest
- DeleteCustomerCommand
- .Up
- .Up
- BudgetPolicies
- DeleteFiscalControlCommand
- .ValidateAsync
- DeleteQualityCommand
- DeleteUserCommand
- FiscalDocumentType
- .BuildTargetModel
- CurrencyPolicies
- FixBankCurrencyForeignKeys
- Permissions.cs
- .Up
- CustomerTypePolicies
- ReportsPolicies
- AccountsReceivableDocumentPolicies
- CustomerPolicies
- FiscalControlPolicies
- HistoryPolicies
- JournalEntryPolicies
- ProductAccountPolicies
- UserPolicies

## God Nodes (most connected - your core abstractions)
1. `Response` - 309 edges
2. `IUnitOfWork` - 165 edges
3. `Countify.Domain.Entities.Accounting` - 104 edges
4. `Countify.Domain.Interfaces` - 104 edges
5. `Countify.Application.Wrappers` - 102 edges
6. `CountifyDbContext` - 82 edges
7. `UnitOfWork` - 70 edges
8. `AccountsReceivableDocument` - 65 edges
9. `AccountsReceivableDocumentDto` - 56 edges
10. `BankTransaction` - 49 edges

## Surprising Connections (you probably didn't know these)
- `Modelo contable (FASE 1 — corregido)` --references--> `CompanySettings`  [INFERRED]
  AGENTS.md → Countify.Domain/Entities/Accounting/CompanySettings.cs
- `4.6 Adjuntos` --references--> `AccountsReceivableDocumentAttachment`  [INFERRED]
  AccountsReceivable-Fase3-Plan.md → Countify.Domain/Entities/AccountsReceivable/AccountsReceivableDocumentAttachment.cs
- `4.8 Migración EF` --references--> `AddReceivableFiscalNotesAndAttachments`  [INFERRED]
  AccountsReceivable-Fase3-Plan.md → Countify.Infrastructure/Migrations/20261014195831_AddReceivableFiscalNotesAndAttachments.Designer.cs
- `Permisos (patrón de futuras fases también)` --references--> `CompanySettingsPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/CompanySettingsPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `DocumentTypePolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/DocumentTypePolicies.cs

## Import Cycles
- None detected.

## Communities (239 total, 17 thin omitted)

### Community 0 - "Countify.Domain.Interfaces"
Cohesion: 0.08
Nodes (20): automapper, Countify.Application.Features.Accounts.DTOs, Countify.Application.Features.Accounts.Commands.CreateAccount, Countify.Application.Features.Qualities.DTOs, Countify.Application.Features.AccountsReceivableDocuments.DTOs, Countify.Application.Features.ProductAccounts.DTOs, Countify.Application.Features.Qualities.Commands.UpdateQuality, Countify.Application.Features.ProductAccounts (+12 more)

### Community 1 - "CatalogSeeder"
Cohesion: 0.35
Nodes (5): CatalogSeeder, CancellationToken, ILogger, IOptions, Task

### Community 2 - "UpdateCompanySettingsCommand"
Cohesion: 0.11
Nodes (19): UpdateCompanySettingsCommand, Address, CompanyName, DefaultDepartmentId, DefaultProjectId, Email, FiscalYear, Mobile (+11 more)

### Community 3 - "CountifyDbContext"
Cohesion: 0.04
Nodes (53): ICurrentUserService, Guid, UserId, UserName, CountifyDbContext, AccountingPeriods, Accounts, AccountsReceivableConcepts (+45 more)

### Community 4 - "UpdateDepartmentCommand"
Cohesion: 0.07
Nodes (37): DepartmentsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+29 more)

### Community 5 - "PaginatedResponse"
Cohesion: 0.15
Nodes (15): GetProductAccountsQuery, Search, GetProductAccountsQueryHandler, CancellationToken, IMapper, List, Task, PaginatedResponse (+7 more)

### Community 6 - "microsoft_entityframeworkcore"
Cohesion: 0.12
Nodes (8): Countify.Domain.Seeders, Countify.Infrastructure.Seeders, Countify.Infrastructure.Persistence.Configurations, Countify.Infrastructure.Extensions, microsoft_entityframeworkcore, microsoft_entityframeworkcore_metadata_builders, microsoft_extensions_hosting, microsoft_extensions_logging

### Community 7 - ".Delete"
Cohesion: 0.28
Nodes (9): ProductsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 8 - "Response"
Cohesion: 0.05
Nodes (41): ForgotPasswordCommand, ForgotPasswordCommandHandler, CancellationToken, Task, UserManager, LoginCommand, RefreshTokenCommand, RefreshTokenCommandHandler (+33 more)

### Community 9 - "CustomerTypeDto"
Cohesion: 0.18
Nodes (14): CustomerTypeDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Code, Id, Name, Guid (+6 more)

### Community 10 - "JournalEntry"
Cohesion: 0.06
Nodes (33): AccountingPeriod, EndDate, IsClosed, Month, StartDate, DateTime, JournalEntry, Code (+25 more)

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
Cohesion: 0.08
Nodes (28): ProjectsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+20 more)

### Community 16 - "IRepository"
Cohesion: 0.11
Nodes (20): IRepository, CancellationToken, Expression, Func, Guid, IEnumerable, IQueryable, List (+12 more)

### Community 17 - "CurrencyFeatures.cs"
Cohesion: 0.21
Nodes (17): CreateCurrencyCommand, CurrencyDto, Code, ExchangeRate, Id, IsActive, Name, CurrencyHandler (+9 more)

### Community 18 - "BanksController"
Cohesion: 0.27
Nodes (9): BanksController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 19 - "RolePermission"
Cohesion: 0.12
Nodes (14): Permission, Description, Id, Name, RolePermission, Permission, PermissionId, Role (+6 more)

### Community 20 - "BankTransaction"
Cohesion: 0.06
Nodes (32): BankTransaction, Amount, AppliesToReceivableId, BankAccount, BankAccountId, BankReconciliation, BankReconciliationId, Beneficiary (+24 more)

### Community 21 - "GetTrialBalanceQuery"
Cohesion: 0.16
Nodes (14): TrialBalanceDto, CreditTotal, DebitTotal, Difference, Lines, List, GetTrialBalanceQuery, DepartmentId (+6 more)

### Community 22 - "GetProjectGroupsQueryHandler"
Cohesion: 0.18
Nodes (12): ProjectGroupDto, Code, Id, Name, Guid, GetProjectGroupsQuery, GetProjectGroupsQueryHandler, CancellationToken (+4 more)

### Community 23 - "UnitOfWork"
Cohesion: 0.05
Nodes (42): UnitOfWork, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentAttachments, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts (+34 more)

### Community 24 - "ValidationException"
Cohesion: 0.08
Nodes (24): ExceptionHandlerMiddleware, Exception, ILogger, Task, ValidationBehavior, CancellationToken, IEnumerable, Task (+16 more)

### Community 25 - "AccountMovementsResponse"
Cohesion: 0.13
Nodes (16): AccountMovementsResponse, AccountCode, AccountId, AccountName, Balance, CreditTotal, DebitTotal, Movements (+8 more)

### Community 26 - "BudgetLine"
Cohesion: 0.08
Nodes (26): Department, BudgetLine, Account, AccountId, April, August, Budget, BudgetId (+18 more)

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

### Community 31 - "LoginCommandHandler"
Cohesion: 0.13
Nodes (11): IJwtService, IList, LoginCommandHandler, CancellationToken, IdentityRole, RoleManager, Task, UserManager (+3 more)

### Community 32 - "JournalEntryLine"
Cohesion: 0.08
Nodes (26): JournalEntryLine, Account, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName (+18 more)

### Community 33 - "AccountsReceivableDocumentDraftRequest"
Cohesion: 0.12
Nodes (15): AccountsReceivableDocumentDraftRequest, Amount, AppliesTo, ConceptId, CurrencyId, CustomerId, Date, DepartmentId (+7 more)

### Community 34 - "Countify.Api.Controllers"
Cohesion: 0.09
Nodes (17): Countify.Application.Features.AccountingPeriods.Queries.GetAccountingPeriods, Countify.Application.Features.Projects.Queries.GetProjects, Countify.Api.Controllers, Countify.Application.Features.Reports.Queries.GetTrialBalance, Countify.Application.Features.Users.Queries.GetUsers, Countify.Application.Features.Users.Queries.GetUserById, Countify.Application.Features.Products.Queries.GetProducts, Countify.Application.Features.Reports.Queries.GetIncomeStatement (+9 more)

### Community 35 - "BankTransactionDto"
Cohesion: 0.08
Nodes (25): BankTransactionDto, Amount, AppliesToReceivableId, BankAccountId, BankAccountName, BankReconciliationId, Beneficiary, Concept (+17 more)

### Community 36 - "UserDto"
Cohesion: 0.11
Nodes (22): UserDto, CreatedAt, Email, FirstName, FullName, Id, IsActive, LastName (+14 more)

### Community 37 - "ProductAccount"
Cohesion: 0.10
Nodes (19): ProductAccount, CostAccount, CostAccountId, IncomeAccount, IncomeAccountId, InventoryAccount, InventoryAccountId, Product (+11 more)

### Community 38 - "ApiKeyAuthenticationHandler"
Cohesion: 0.10
Nodes (17): AuthenticateResult, AuthenticationHandler, AuthenticationProperties, AuthenticationSchemeOptions, ApiKeyAuthenticationHandler, IOptions, Task, ApiKeyAuthenticationOptions (+9 more)

### Community 39 - "JournalEntryDto"
Cohesion: 0.09
Nodes (22): JournalEntryDto, Code, Concept, CreditTotal, DebitTotal, DifferenceAmount, EntryNumber, Gid (+14 more)

### Community 40 - "CompanySettings"
Cohesion: 0.09
Nodes (23): CompanySettings, Address, CompanyName, DefaultDepartment, DefaultDepartmentId, DefaultProject, DefaultProjectId, Email (+15 more)

### Community 41 - "CompanySettingsDto"
Cohesion: 0.05
Nodes (37): CompanySettingsDto, Address, CompanyName, DefaultDepartmentId, DefaultProjectId, Email, FiscalYear, Id (+29 more)

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
Cohesion: 0.07
Nodes (10): OrderColumns, Ascending, Descending, BasicProducts, BasicQualities, Countify.Domain.Entities.Audit, Countify.Domain.Common, Countify.Domain.Entities.Accounting (+2 more)

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
Cohesion: 0.07
Nodes (27): BankAccount, AccountingAccount, AccountingAccountId, AccountNumber, Balance, CheckNumber, Code, CurrencyId (+19 more)

### Community 50 - "ApplicationUser"
Cohesion: 0.12
Nodes (16): ApplicationUser, CreatedAt, CreatedBy, FirstName, FullName, IsActive, LastActivity, LastName (+8 more)

### Community 51 - "BudgetsController"
Cohesion: 0.29
Nodes (10): BudgetRequest, BudgetsController, Authorize, CancellationToken, HttpDelete, HttpGet, HttpPost, HttpPut (+2 more)

### Community 52 - "CreateProductCommand"
Cohesion: 0.31
Nodes (8): CreateProductCommand, Code, Name, CreateProductCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 53 - "Countify.Domain.Enums"
Cohesion: 0.13
Nodes (7): JournalEntryProfile, Countify.Application.Features.JournalEntries.Commands.CreateJournalEntry, Countify.Application.Features.JournalEntries.DTOs, Countify.Application.Features.JournalEntries.Profiles, Countify.Application.Features.JournalEntries, Countify.Domain.Enums, Countify.Application.Features.JournalEntries.Commands.UpdateJournalEntry

### Community 54 - "ProductAccountDto"
Cohesion: 0.11
Nodes (17): ProductAccountDto, CostAccountCode, CostAccountId, CostAccountName, Id, IncomeAccountCode, IncomeAccountId, IncomeAccountName (+9 more)

### Community 55 - "GetRoleByIdQueryHandler"
Cohesion: 0.14
Nodes (13): PermissionDto, Description, Id, Name, RoleDetailDto, Permissions, IList, GetRoleByIdQueryHandler (+5 more)

### Community 56 - "IEntityTypeConfiguration"
Cohesion: 0.08
Nodes (22): Project, ProjectGroup, Code, Name, Projects, List, BasicProjectGroups, Items (+14 more)

### Community 57 - ".Delete"
Cohesion: 0.28
Nodes (9): AccountsReceivableConceptsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 58 - "CreateCustomerCommand"
Cohesion: 0.12
Nodes (18): CreateCustomerCommand, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId, Email (+10 more)

### Community 59 - ".SaveChangesAsync"
Cohesion: 0.22
Nodes (6): CancellationToken, Task, CancellationToken, Task, CancellationToken, Task

### Community 60 - "Budget"
Cohesion: 0.14
Nodes (13): BudgetLine, Budget, FiscalYear, Lines, Name, List, BasicBudgets, Items (+5 more)

### Community 61 - "Countify.Application.Features.Auth.DTOs"
Cohesion: 0.14
Nodes (9): ForgotPasswordRequest, Email, LoginRequest, Password, Username, RefreshTokenRequest, AccessToken, RefreshToken (+1 more)

### Community 62 - "UpdateDocumentTypeCommand"
Cohesion: 0.06
Nodes (40): DocumentTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+32 more)

### Community 63 - "CustomerMovementDto"
Cohesion: 0.11
Nodes (19): CustomerMovementDto, Amount, AmountLocal, Applications, AppliedAmount, ConceptDescription, Credit, CurrencyCode (+11 more)

### Community 64 - "CustomersController.cs"
Cohesion: 0.22
Nodes (6): CreateCustomerCommandValidator, UpdateCustomerCommandValidator, Countify.Application.Features.Customers.Commands.DeleteCustomer, Countify.Application.Features.Customers.Queries.GetCustomers, Countify.Application.Features.Customers.Commands.UpdateCustomer, Countify.Application.Features.Customers.Commands.CreateCustomer

### Community 65 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 66 - "JournalEntryLineRequest"
Cohesion: 0.12
Nodes (16): JournalEntryLineRequest, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName, Debit (+8 more)

### Community 67 - ".CreateOrUpdatePostingAsync"
Cohesion: 0.18
Nodes (9): AccountsReceivablePostingFactory, CancellationToken, Task, Customer, BasicCustomers, CashCustomer, Items, CustomerConfiguration (+1 more)

### Community 68 - "UpdateUserCommand"
Cohesion: 0.10
Nodes (24): UsersController, Authorize, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult, Task (+16 more)

### Community 69 - "Countify.Infrastructure.Persistence"
Cohesion: 0.28
Nodes (12): AddBudgetsAndBudgetPermissions, AddBanksAndBankReconciliation, AddReceivableFiscalNotesAndAttachments, CountifyDbContextModelSnapshot, Countify.Infrastructure.Migrations, Countify.Infrastructure.Persistence, microsoft_entityframeworkcore_infrastructure, microsoft_entityframeworkcore_metadata (+4 more)

### Community 70 - "PermissionService"
Cohesion: 0.22
Nodes (7): IPermissionService, HashSet, Task, PermissionService, HashSet, Task, UserManager

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
Cohesion: 0.05
Nodes (40): IFileStorage, CancellationToken, Stream, Task, DeleteAccountsReceivableDocumentAttachmentCommand, Id, DeleteAccountsReceivableDocumentAttachmentCommandHandler, CancellationToken (+32 more)

### Community 84 - "CustomerDto"
Cohesion: 0.11
Nodes (19): CustomerDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Address, Code, CreditDays, CreditLimit (+11 more)

### Community 85 - "AccountsReceivableDocumentAttachment"
Cohesion: 0.15
Nodes (13): AccountsReceivableDocumentAttachment, ContentType, Document, DocumentId, FileName, Size, StoragePath, UploadedBy (+5 more)

### Community 86 - "UpdateAccountsReceivableDocumentCommand"
Cohesion: 0.09
Nodes (23): UpdateAccountsReceivableDocumentCommand, Amount, AppliesTo, ConceptId, CreditNoteReason, CurrencyId, CustomerId, Date (+15 more)

### Community 87 - "UpdateCustomerCommand"
Cohesion: 0.11
Nodes (19): UpdateCustomerCommand, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId, Email (+11 more)

### Community 88 - "FiscalControlDto"
Cohesion: 0.10
Nodes (24): FiscalControlDto, Branch, CAI, DocumentCode, DocumentType, DocumentTypeName, EmissionDate, EmissionLimitDate (+16 more)

### Community 89 - "BaseEntity"
Cohesion: 0.07
Nodes (26): BaseEntity, Id, Guid, Currency, Code, ExchangeRate, IsActive, Name (+18 more)

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

### Community 95 - "Program.cs"
Cohesion: 0.17
Nodes (9): ApplicationServiceRegistration, IServiceCollection, Countify.Api.DependencyInjection, Countify.Application.DependencyInjection, Countify.Infrastructure.DependencyInjection, microsoft_extensions_dependencyinjection, quick_autoinject_dependencyannotation, scalar_aspnetcore (+1 more)

### Community 96 - "DocumentType"
Cohesion: 0.22
Nodes (8): DocumentType, Code, IsDefault, Name, BasicDocumentTypes, Items, DocumentTypeConfiguration, EntityTypeBuilder

### Community 97 - ".AddApiServices"
Cohesion: 0.18
Nodes (12): Permisos (patrón de futuras fases también), AccountingPeriodPolicies, AuthorizationOptions, AccountPolicies, AuthorizationOptions, DepartmentPolicies, AuthorizationOptions, ProjectPolicies (+4 more)

### Community 98 - "YearEndClosingEntry"
Cohesion: 0.20
Nodes (9): YearEndClosingEntry, GeneratedBy, JournalEntryId, PeriodId, Guid, BasicYearEndClosingEntries, Items, YearEndClosingEntryConfiguration (+1 more)

### Community 99 - "AddAccountingModule"
Cohesion: 0.18
Nodes (8): DateTime, Guid, MigrationBuilder, AddAccountingModule, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 100 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

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

### Community 106 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

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

### Community 115 - "CurrentUserService"
Cohesion: 0.33
Nodes (5): CurrentUserService, Guid, UserId, UserName, IHttpContextAccessor

### Community 116 - "fluentvalidation"
Cohesion: 0.04
Nodes (44): AbstractValidator, CloseAccountingPeriodCommandValidator, CreateAccountingPeriodCommandValidator, DeleteAccountingPeriodCommandValidator, CreateAccountCommandValidator, UpdateAccountCommandValidator, CreateAccountsReceivableDocumentCommandValidator, UpdateAccountsReceivableDocumentCommandValidator (+36 more)

### Community 117 - "ApiKeyAuthenticationHandler.cs"
Cohesion: 0.15
Nodes (9): AuthorizeAttribute, ApiKeyAuthenticationDefaults, ApiKeyAttribute, Countify.Api.Authorization.Handlers, Countify.Api.ApiKeyAuthentication, microsoft_aspnetcore_authentication, microsoft_extensions_primitives, system_security_claims (+1 more)

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
Cohesion: 0.18
Nodes (10): SeederOptions, Enabled, SeedConfiguration, SeedTransactions, IConfiguration, IdentityRole, IServiceCollection, ConfigurationSeeder (+2 more)

### Community 124 - ".OnModelCreating"
Cohesion: 0.25
Nodes (7): IdentityRole, IdentityUserRole, ModelBuilder, IdentityRoleClaim, IdentityUserClaim, IdentityUserLogin, IdentityUserToken

### Community 125 - ".Delete"
Cohesion: 0.28
Nodes (9): ProjectGroupsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 126 - ".Delete"
Cohesion: 0.28
Nodes (9): CurrenciesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 127 - "IEmailService"
Cohesion: 0.33
Nodes (4): IEmailService, Task, EmailService, Task

### Community 128 - "JournalEntriesController.cs"
Cohesion: 0.09
Nodes (18): DeleteAccountCommandValidator, DeleteJournalEntryCommandValidator, VoidJournalEntryCommand, Id, VoidJournalEntryCommandHandler, CancellationToken, Guid, Task (+10 more)

### Community 129 - ".Close"
Cohesion: 0.33
Nodes (8): AccountingPeriodsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, IActionResult, Task

### Community 130 - ".Handle"
Cohesion: 0.16
Nodes (11): BudgetAvailabilityValidator, CancellationToken, DateTime, Guid, IEnumerable, Task, UpdateJournalEntryCommandHandler, CancellationToken (+3 more)

### Community 131 - "20260919192955_RenameBankOpeningBalanceToBalance.Designer.cs"
Cohesion: 0.20
Nodes (6): MigrationBuilder, RenameBankOpeningBalanceToBalance, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 132 - ".BuildSection"
Cohesion: 0.22
Nodes (9): IncomeStatementSectionDto, Code, Lines, Name, Total, List, Dictionary, List (+1 more)

### Community 133 - "CreateFiscalControlCommand"
Cohesion: 0.11
Nodes (20): CreateFiscalControlCommand, Branch, CAI, DocumentCode, DocumentType, EmissionDate, EmissionLimitDate, EmissionPoint (+12 more)

### Community 134 - "Seeding — GENERALIZADO (base para futuras entidades/fases)"
Cohesion: 0.11
Nodes (13): Seeding — GENERALIZADO (base para futuras entidades/fases), BasicCompanySettings, Items, BasicDepartments, Items, BasicProjects, Items, BasicRoles (+5 more)

### Community 135 - "IncomeStatementLineDto"
Cohesion: 0.22
Nodes (7): IncomeStatementLineDto, AccountCode, AccountId, AccountName, Balance, Guid, Countify.Application.Features.Reports.DTOs

### Community 136 - "Currency"
Cohesion: 0.32
Nodes (5): Currency, BasicCurrencies, Items, CurrencyConfiguration, EntityTypeBuilder

### Community 137 - ".BuildModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 138 - "CustomerMovementApplicationDto"
Cohesion: 0.17
Nodes (11): CustomerMovementApplicationDto, Amount, Id, RelatedConcept, RelatedDate, RelatedDocumentId, RelatedDocumentNo, RelatedIsCredit (+3 more)

### Community 139 - "IncomeStatementDto"
Cohesion: 0.22
Nodes (9): IncomeStatementDto, EndDate, GrossProfit, NetResult, Sections, TotalCostOfSales, TotalExpenses, TotalRevenue (+1 more)

### Community 140 - "JournalEntryStatus"
Cohesion: 0.33
Nodes (5): JournalEntryStatus, Approved, Draft, Posted, Voided

### Community 141 - ".ApplyOrder"
Cohesion: 0.46
Nodes (5): QueryableExtensions, Dictionary, Expression, Func, IQueryable

### Community 142 - "CustomerTypesController.cs"
Cohesion: 0.22
Nodes (6): CreateCustomerTypeCommandValidator, UpdateCustomerTypeCommandValidator, Countify.Application.Features.CustomerTypes.Commands.DeleteCustomerType, Countify.Application.Features.CustomerTypes.Commands.UpdateCustomerType, Countify.Application.Features.CustomerTypes.Commands.CreateCustomerType, Countify.Application.Features.CustomerTypes.Queries.GetCustomerTypes

### Community 143 - "UserRoleHasPermissionRequirement"
Cohesion: 0.25
Nodes (8): AuthorizationHandler, AuthorizationHandlerContext, PermissionAuthorizationHandler, Task, UserRoleHasPermissionRequirement, Permission, Permission, IAuthorizationRequirement

### Community 144 - "BaseController"
Cohesion: 0.15
Nodes (15): ControllerBase, BaseController, Mediator, ReportsController, Authorize, HttpGet, IActionResult, Task (+7 more)

### Community 145 - "DeleteCustomerTypeCommand"
Cohesion: 0.33
Nodes (6): DeleteCustomerTypeCommand, Id, DeleteCustomerTypeCommandHandler, CancellationToken, Guid, Task

### Community 146 - "GetCompanySettingsQuery.cs"
Cohesion: 0.33
Nodes (3): SettingsProfile, Countify.Application.Features.Configurations.DTOs, Countify.Application.Features.Configurations.Profiles

### Community 147 - "CreateProjectGroupCommand"
Cohesion: 0.31
Nodes (8): CreateProjectGroupCommand, Code, Name, CreateProjectGroupCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 148 - ".HandleResult"
Cohesion: 0.31
Nodes (8): AuthController, Authorize, HttpGet, HttpPost, IActionResult, Task, IActionResult, StatusCode

### Community 149 - "GetProductsQueryHandler"
Cohesion: 0.24
Nodes (11): ProductDto, Code, Id, Name, Guid, GetProductsQuery, GetProductsQueryHandler, CancellationToken (+3 more)

### Community 150 - "CreateAccountingPeriodCommand"
Cohesion: 0.36
Nodes (7): CreateAccountingPeriodCommand, Month, CreateAccountingPeriodCommandHandler, CancellationToken, DateTime, Guid, Task

### Community 151 - "Countify.Domain.Entities.Auth"
Cohesion: 0.06
Nodes (22): automapper_queryableextensions, RoleProfile, UserProfile, Countify.Infrastructure.Persistence.Services, Countify.Infrastructure.Services, Countify.Application.Common.Interfaces, Countify.Application.Features.Users.DTOs, Countify.Application.Features.Users.Profiles (+14 more)

### Community 152 - "CreateAccountsReceivableDocumentLinesCommand"
Cohesion: 0.18
Nodes (12): CreateAccountsReceivableDocumentLinesCommand, DocumentId, Lines, CreateAccountsReceivableDocumentLinesCommandHandler, LineItem, Amount, AppliedDocumentId, CancellationToken (+4 more)

### Community 153 - "microsoft_aspnetcore_authorization"
Cohesion: 0.29
Nodes (5): Countify.Domain.Authorization, Countify.Api.Authorization.Requirements, Countify.Api.Authorization.Policies, microsoft_aspnetcore_authorization, microsoft_extensions_options

### Community 154 - "FiscalControl"
Cohesion: 0.11
Nodes (18): FiscalControl, Branch, CAI, DocumentCode, DocumentType, EmissionDate, EmissionLimitDate, EmissionPoint (+10 more)

### Community 155 - "4. Qué falta implementar (backend)"
Cohesion: 0.13
Nodes (15): 4.1 Campos fiscales en `AccountsReceivableDocument` (nullable; solo N/C y N/D), 4.2 Nueva entidad `FiscalControl` (← `ControlesFiscales`), 4.3 Enums nuevos, 4.4 Numeración, 4.5 Conceptos (seeder), 4.6 Adjuntos, 4.7 Permisos, 4.8 Migración EF (+7 more)

### Community 156 - "AuthResponse"
Cohesion: 0.18
Nodes (11): AuthResponse, AccessToken, ExpiresAt, FullName, Permissions, RefreshToken, Roles, UserId (+3 more)

### Community 157 - "TrialBalanceLineDto"
Cohesion: 0.25
Nodes (8): TrialBalanceLineDto, AccountCode, AccountId, AccountName, Balance, Credit, Debit, Guid

### Community 158 - "CreateCustomerTypeCommand"
Cohesion: 0.27
Nodes (9): CreateCustomerTypeCommand, AccountingAccountId, Code, Name, CreateCustomerTypeCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 159 - "UpdateProductAccountCommand"
Cohesion: 0.10
Nodes (23): ProductAccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+15 more)

### Community 160 - "TransactionSeeder"
Cohesion: 0.47
Nodes (5): TransactionSeeder, CancellationToken, ILogger, IOptions, Task

### Community 161 - "CustomerMovementsDto"
Cohesion: 0.17
Nodes (12): CustomerMovementsDto, CustomerCode, CustomerId, CustomerName, FromDate, Movements, Saldo, ToDate (+4 more)

### Community 162 - "GetCustomerMovementsQuery"
Cohesion: 0.22
Nodes (9): GetCustomerMovementsQuery, CustomerId, FromDate, ToDate, GetCustomerMovementsQueryHandler, CancellationToken, DateTime, Guid (+1 more)

### Community 163 - "UpdateProductCommand"
Cohesion: 0.22
Nodes (9): UpdateProductCommand, Code, Id, Name, UpdateProductCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 165 - "BudgetRequest"
Cohesion: 0.17
Nodes (11): BudgetLineRequest, BudgetLineResponse, BudgetResponse, BudgetLineResponse, BudgetRequest, FiscalYear, Lines, Name (+3 more)

### Community 166 - "DeleteJournalEntryCommand"
Cohesion: 0.33
Nodes (6): DeleteJournalEntryCommand, Id, DeleteJournalEntryCommandHandler, CancellationToken, Guid, Task

### Community 167 - "UpdateCustomerTypeCommand"
Cohesion: 0.20
Nodes (10): UpdateCustomerTypeCommand, AccountingAccountId, Code, Id, Name, UpdateCustomerTypeCommandHandler, CancellationToken, Guid (+2 more)

### Community 168 - "AccountsReceivableConceptsController.cs"
Cohesion: 0.22
Nodes (6): CreateAccountsReceivableConceptCommandValidator, UpdateAccountsReceivableConceptCommandValidator, Countify.Application.Features.AccountsReceivableConcepts.Commands.DeleteAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Commands.CreateAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Commands.UpdateAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Queries.GetAccountsReceivableConcepts

### Community 169 - "UpdateProjectGroupCommand"
Cohesion: 0.22
Nodes (9): UpdateProjectGroupCommand, Code, Id, Name, UpdateProjectGroupCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 170 - "CreateQualityCommand"
Cohesion: 0.31
Nodes (8): CreateQualityCommand, Code, Name, CreateQualityCommandHandler, CancellationToken, Guid, IMapper, Task

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

### Community 175 - "AccountsReceivableDocumentsController.cs"
Cohesion: 0.10
Nodes (14): AccountsReceivableDocumentProfile, Countify.Application.Features.AccountsReceivableDocuments.Queries.GetAccountsReceivableDocumentById, Countify.Application.Features.AccountsReceivableDocuments.Queries.GetCustomerMovements, Countify.Application.Features.AccountsReceivableDocuments.Commands.VoidAccountsReceivableDocument, Countify.Application.Features.AccountsReceivableDocuments.Queries.GetAccountsReceivableDocumentAttachment, Countify.Application.Features.AccountsReceivableDocuments.Commands.UpdateAccountsReceivableDocumentLine, Countify.Application.Features.AccountsReceivableDocuments.Commands.UpdateAccountsReceivableDocument, Countify.Application.Features.AccountsReceivableDocuments.Queries.GetAccountsReceivableDocuments (+6 more)

### Community 176 - "CreateRoleCommand"
Cohesion: 0.29
Nodes (7): CreateRoleCommand, Name, CreateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 177 - "Profile"
Cohesion: 0.05
Nodes (24): AccountingPeriodProfile, AccountProfile, AccountsReceivableConceptProfile, BankAccountProfile, CurrencyProfile, CustomerTypeProfile, FiscalControlProfile, HistoryProfile (+16 more)

### Community 178 - ".Delete"
Cohesion: 0.28
Nodes (9): FiscalControlsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 179 - "AccountsReceivableDocumentAttachmentDto"
Cohesion: 0.18
Nodes (10): AccountsReceivableDocumentAttachmentDto, ContentType, DocumentId, FileName, Id, Size, UploadedBy, UploadedOn (+2 more)

### Community 180 - "CloseAccountingPeriodCommand"
Cohesion: 0.33
Nodes (6): CloseAccountingPeriodCommand, Id, CloseAccountingPeriodCommandHandler, CancellationToken, Guid, Task

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

### Community 185 - "ISeeder"
Cohesion: 0.22
Nodes (7): ISeeder, CancellationToken, Task, DatabaseExtensions, IEnumerable, ILogger, IHost

### Community 186 - "DeleteAccountCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountCommand, Id, DeleteAccountCommandHandler, CancellationToken, Guid, Task

### Community 187 - "Cuentas por Cobrar (FASE 3 del roadmap maestro) — plan de cierre"
Cohesion: 0.11
Nodes (17): 1. Estado actual en Countify, 2. Decisión de modelado (validada contra el legacy), 3. Decisiones tomadas, 5. Frontend (Angular, `Countify-PanelUser`), 6. Migración de datos (FASE 14, cuando toque), 7. Consultas/Reportes pendientes, 8. Criterio de terminado (FASE 3), 9. Fuera de alcance aquí (+9 more)

### Community 188 - "DeleteProjectGroupCommand"
Cohesion: 0.33
Nodes (6): DeleteProjectGroupCommand, Id, DeleteProjectGroupCommandHandler, CancellationToken, Guid, Task

### Community 189 - "UpdateRolePermissionsCommand"
Cohesion: 0.22
Nodes (9): UpdateRolePermissionsCommand, PermissionIds, RoleId, UpdateRolePermissionsCommandHandler, CancellationToken, IdentityRole, List, RoleManager (+1 more)

### Community 190 - "IRequestHandler"
Cohesion: 0.08
Nodes (24): UpdateAccountCommandHandler, CancellationToken, IMapper, Task, DeleteAccountsReceivableDocumentLineCommand, Id, DeleteAccountsReceivableDocumentLineCommandHandler, CancellationToken (+16 more)

### Community 191 - "ProjectGroupsController.cs"
Cohesion: 0.13
Nodes (11): CreateProjectCommandValidator, CreateProjectGroupCommandValidator, UpdateProjectCommandValidator, ProjectProfile, Countify.Application.Features.Projects.Commands.UpdateProject, Countify.Application.Features.Projects.Profiles, Countify.Application.Features.Projects.Commands.UpdateProjectGroup, Countify.Application.Features.Projects.Commands.DeleteProjectGroup (+3 more)

### Community 192 - "DeleteProjectCommand"
Cohesion: 0.33
Nodes (6): DeleteProjectCommand, Id, DeleteProjectCommandHandler, CancellationToken, Guid, Task

### Community 193 - ".ValidateAsync"
Cohesion: 0.60
Nodes (4): ProductAccountRules, CancellationToken, Guid, Task

### Community 194 - "DeleteAccountsReceivableConceptCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountsReceivableConceptCommand, Id, DeleteAccountsReceivableConceptCommandHandler, CancellationToken, Guid, Task

### Community 195 - "IConfigureOptions"
Cohesion: 0.38
Nodes (5): AccountsReceivableConceptPolicies, AuthorizationOptions, RolePolicies, AuthorizationOptions, IConfigureOptions

### Community 196 - "FiscalControlsController.cs"
Cohesion: 0.22
Nodes (6): CreateFiscalControlCommandValidator, UpdateFiscalControlCommandValidator, Countify.Application.Features.FiscalControls.Commands.DeleteFiscalControl, Countify.Application.Features.FiscalControls.Commands.UpdateFiscalControl, Countify.Application.Features.FiscalControls.Commands.CreateFiscalControl, Countify.Application.Features.FiscalControls.Queries.GetFiscalControls

### Community 197 - ".SaveChangesAsync"
Cohesion: 0.29
Nodes (5): UpdateCompanySettingsCommandHandler, CancellationToken, Task, CancellationToken, Task

### Community 199 - "GetAccountsReceivableDocumentsQueryHandler"
Cohesion: 0.43
Nodes (6): GetAccountsReceivableDocumentsQuery, GetAccountsReceivableDocumentsQueryHandler, CancellationToken, IMapper, List, Task

### Community 200 - "GetDocumentTypesQuery.cs"
Cohesion: 0.33
Nodes (3): DocumentTypeProfile, Countify.Application.Features.DocumentTypes.DTOs, Countify.Application.Features.DocumentTypes.Profiles

### Community 201 - "ChangePasswordCommand"
Cohesion: 0.25
Nodes (8): ChangePasswordCommand, CurrentPassword, Id, NewPassword, ChangePasswordCommandHandler, CancellationToken, Task, UserManager

### Community 202 - "DeleteDepartmentCommand"
Cohesion: 0.33
Nodes (6): DeleteDepartmentCommand, Id, DeleteDepartmentCommandHandler, CancellationToken, Guid, Task

### Community 203 - "Countify — Convenciones del proyecto"
Cohesion: 0.33
Nodes (5): Arquitectura / capas, Contrato API (FASE 1), Countify — Convenciones del proyecto, Flujo de trabajo (obligatorio), Modelo contable (FASE 1 — corregido)

### Community 204 - "GetAccountByIdQuery"
Cohesion: 0.29
Nodes (7): GetAccountByIdQuery, Id, GetAccountByIdQueryHandler, CancellationToken, Guid, IMapper, Task

### Community 205 - ".CreateAsync"
Cohesion: 0.22
Nodes (7): DraftCreationResult, CancellationToken, Task, FiscalNoteNumberingFactory, CancellationToken, FiscalControl, Task

### Community 206 - "CustomerType"
Cohesion: 0.33
Nodes (5): CustomerType, BasicCustomerTypes, Items, CustomerTypeConfiguration, EntityTypeBuilder

### Community 207 - "GetCustomersQuery.cs"
Cohesion: 0.33
Nodes (3): CustomerProfile, Countify.Application.Features.Customers.Profiles, Countify.Application.Features.Customers.DTOs

### Community 208 - "GetUserInfoQueryHandler"
Cohesion: 0.15
Nodes (15): UserInfoResponse, Email, FullName, Permissions, Roles, UserId, UserName, IList (+7 more)

### Community 211 - "GetDepartmentsQuery.cs"
Cohesion: 0.33
Nodes (3): DepartmentProfile, Countify.Application.Features.Departments.Profiles, Countify.Application.Features.Departments.DTOs

### Community 212 - "GetProductsQuery.cs"
Cohesion: 0.33
Nodes (3): ProductProfile, Countify.Application.Features.Products.DTOs, Countify.Application.Features.Products.Profiles

### Community 214 - "VoidAccountsReceivableDocumentCommand"
Cohesion: 0.33
Nodes (6): VoidAccountsReceivableDocumentCommand, Id, VoidAccountsReceivableDocumentCommandHandler, CancellationToken, Guid, Task

### Community 215 - "ResetPasswordRequest"
Cohesion: 0.40
Nodes (4): ResetPasswordRequest, Email, NewPassword, Token

### Community 216 - "DeleteCustomerCommand"
Cohesion: 0.33
Nodes (6): DeleteCustomerCommand, Id, DeleteCustomerCommandHandler, CancellationToken, Guid, Task

### Community 217 - ".Up"
Cohesion: 0.40
Nodes (3): DateTime, Guid, MigrationBuilder

### Community 218 - ".Up"
Cohesion: 0.40
Nodes (3): DateTime, Guid, MigrationBuilder

### Community 220 - "DeleteFiscalControlCommand"
Cohesion: 0.33
Nodes (6): DeleteFiscalControlCommand, Id, DeleteFiscalControlCommandHandler, CancellationToken, Guid, Task

### Community 221 - ".ValidateAsync"
Cohesion: 0.29
Nodes (6): JournalEntryAuxValidator, CancellationToken, Guid, Task, IReadOnlyCollection, IReadOnlyDictionary

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

### Community 227 - "FixBankCurrencyForeignKeys"
Cohesion: 0.22
Nodes (6): MigrationBuilder, FixBankCurrencyForeignKeys, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 228 - "Permissions.cs"
Cohesion: 0.50
Nodes (3): Permissions, Items, system_reflection

## Knowledge Gaps
- **1275 isolated node(s):** `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName`, `ApiKey`, `Permission` (+1270 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 2039 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **17 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Response` connect `Response` to `UpdateCompanySettingsCommand`, `UpdateDepartmentCommand`, `PaginatedResponse`, `CustomerTypeDto`, `UpdateAccountsReceivableConceptCommand`, `IRequest`, `UpdateProjectCommand`, `CurrencyFeatures.cs`, `GetTrialBalanceQuery`, `GetProjectGroupsQueryHandler`, `AccountMovementsResponse`, `HistoryDto`, `LoginCommandHandler`, `CompanySettingsDto`, `UpdateJournalEntryCommand`, `CreateAccountCommand`, `CreateJournalEntryCommand`, `BudgetsController`, `CreateProductCommand`, `GetRoleByIdQueryHandler`, `CreateCustomerCommand`, `UpdateDocumentTypeCommand`, `UpdateUserCommand`, `AccountingPeriodDto`, `CreateAccountsReceivableConceptCommand`, `GetUserByIdQueryHandler`, `CreateUserCommand`, `GetIncomeStatementQuery`, `UpdateAccountCommand`, `UploadAccountsReceivableDocumentAttachmentCommand`, `UpdateAccountsReceivableDocumentCommand`, `UpdateCustomerCommand`, `FiscalControlDto`, `UpdateQualityCommand`, `CreateAccountsReceivableDocumentCommand`, `GetJournalEntryByIdQuery`, `UpdateFiscalControlCommand`, `UpdateRoleCommand`, `DeleteRoleCommandHandler`, `AccountsReceivableConceptDto`, `AssignRoleCommand`, `JournalEntriesController.cs`, `.Handle`, `CreateFiscalControlCommand`, `DeleteCustomerTypeCommand`, `CreateProjectGroupCommand`, `.HandleResult`, `GetProductsQueryHandler`, `CreateAccountingPeriodCommand`, `CreateAccountsReceivableDocumentLinesCommand`, `CreateCustomerTypeCommand`, `UpdateProductAccountCommand`, `GetCustomerMovementsQuery`, `UpdateProductCommand`, `DeleteJournalEntryCommand`, `UpdateCustomerTypeCommand`, `UpdateProjectGroupCommand`, `CreateQualityCommand`, `GetPendingAccountsReceivableDocumentsQuery`, `CreateRoleCommand`, `CloseAccountingPeriodCommand`, `DeleteAccountingPeriodCommand`, `GetAccountsReceivableDocumentByIdQuery`, `GetCustomersQueryHandler`, `DeleteAccountCommand`, `DeleteProjectGroupCommand`, `UpdateRolePermissionsCommand`, `IRequestHandler`, `DeleteProjectCommand`, `DeleteAccountsReceivableConceptCommand`, `.SaveChangesAsync`, `GetAccountsReceivableDocumentsQueryHandler`, `ChangePasswordCommand`, `DeleteDepartmentCommand`, `GetAccountByIdQuery`, `GetUserInfoQueryHandler`, `VoidAccountsReceivableDocumentCommand`, `DeleteCustomerCommand`, `DeleteFiscalControlCommand`, `DeleteQualityCommand`, `DeleteUserCommand`?**
  _High betweenness centrality (0.323) - this node is a cross-community bridge._
- **Why does `IUnitOfWork` connect `IUnitOfWork` to `UpdateDepartmentCommand`, `PaginatedResponse`, `Response`, `CustomerTypeDto`, `JournalEntry`, `UpdateAccountsReceivableConceptCommand`, `IRequest`, `History`, `UpdateProjectCommand`, `IRepository`, `CurrencyFeatures.cs`, `RolePermission`, `BankTransaction`, `GetTrialBalanceQuery`, `GetProjectGroupsQueryHandler`, `UnitOfWork`, `AccountMovementsResponse`, `HistoryDto`, `LoginCommandHandler`, `JournalEntryLine`, `UserDto`, `ProductAccount`, `CompanySettingsDto`, `CreateAccountCommand`, `Countify.Domain.Entities.Accounting`, `CreateJournalEntryCommand`, `BankAccount`, `ApplicationUser`, `BudgetsController`, `CreateProductCommand`, `GetRoleByIdQueryHandler`, `IEntityTypeConfiguration`, `CreateCustomerCommand`, `Budget`, `UpdateDocumentTypeCommand`, `.CreateOrUpdatePostingAsync`, `AccountingPeriodDto`, `CreateAccountsReceivableConceptCommand`, `BankReconciliation`, `AccountsReceivableDocument`, `GetProjectsQuery`, `GetIncomeStatementQuery`, `UploadAccountsReceivableDocumentAttachmentCommand`, `AccountsReceivableDocumentAttachment`, `UpdateAccountsReceivableDocumentCommand`, `UpdateCustomerCommand`, `FiscalControlDto`, `BaseEntity`, `GetJournalEntriesQuery`, `UpdateQualityCommand`, `RoleDto`, `DocumentType`, `YearEndClosingEntry`, `GetAccountsQuery`, `AccountsReceivableConcept`, `CreateAccountsReceivableDocumentCommand`, `GetJournalEntryByIdQuery`, `UpdateFiscalControlCommand`, `AccountsReceivableConceptDto`, `JournalEntriesController.cs`, `.Handle`, `CreateFiscalControlCommand`, `DeleteCustomerTypeCommand`, `CreateProjectGroupCommand`, `GetProductsQueryHandler`, `CreateAccountingPeriodCommand`, `CreateAccountsReceivableDocumentLinesCommand`, `CreateCustomerTypeCommand`, `UpdateProductAccountCommand`, `GetCustomerMovementsQuery`, `UpdateProductCommand`, `DeleteJournalEntryCommand`, `UpdateCustomerTypeCommand`, `UpdateProjectGroupCommand`, `CreateQualityCommand`, `GetPendingAccountsReceivableDocumentsQuery`, `AccountsReceivableDocumentLine`, `CloseAccountingPeriodCommand`, `DeleteAccountingPeriodCommand`, `GetAccountsReceivableDocumentByIdQuery`, `GetCustomersQueryHandler`, `DeleteAccountCommand`, `DeleteProjectGroupCommand`, `UpdateRolePermissionsCommand`, `IRequestHandler`, `DeleteProjectCommand`, `.ValidateAsync`, `DeleteAccountsReceivableConceptCommand`, `.SaveChangesAsync`, `GetAccountsReceivableDocumentsQueryHandler`, `DeleteDepartmentCommand`, `Countify — Convenciones del proyecto`, `GetAccountByIdQuery`, `.CreateAsync`, `CustomerType`, `GetUserInfoQueryHandler`, `VoidAccountsReceivableDocumentCommand`, `DeleteCustomerCommand`, `DeleteFiscalControlCommand`, `.ValidateAsync`, `DeleteQualityCommand`?**
  _High betweenness centrality (0.196) - this node is a cross-community bridge._
- **Why does `AccountsReceivableDocument` connect `AccountsReceivableDocument` to `GetCustomerMovementsQuery`, `.CreateOrUpdatePostingAsync`, `CountifyDbContext`, `AccountsReceivableConcept`, `CreateAccountsReceivableDocumentCommand`, `IUnitOfWork`, `4. Qué falta implementar (backend)`, `.CreateAsync`, `Countify.Domain.Entities.Accounting`, `AccountsReceivableDocumentLine`, `AccountsReceivableDocumentAttachment`, `UnitOfWork`, `BaseEntity`, `Cuentas por Cobrar (FASE 3 del roadmap maestro) — plan de cierre`?**
  _High betweenness centrality (0.043) - this node is a cross-community bridge._
- **What connects `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName` to the rest of the system?**
  _1275 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Countify.Domain.Interfaces` be split into smaller, more focused modules?**
  _Cohesion score 0.07746913580246914 - nodes in this community are weakly interconnected._
- **Should `UpdateCompanySettingsCommand` be split into smaller, more focused modules?**
  _Cohesion score 0.10526315789473684 - nodes in this community are weakly interconnected._
- **Should `CountifyDbContext` be split into smaller, more focused modules?**
  _Cohesion score 0.03672316384180791 - nodes in this community are weakly interconnected._