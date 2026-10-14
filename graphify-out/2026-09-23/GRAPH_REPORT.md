# Graph Report - Countify  (2026-09-23)

## Corpus Check
- 382 files · ~67,311 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 2 file(s) not represented in the graph (top: (none) 1, .user 1)

## Summary
- 3447 nodes · 6977 edges · 213 communities (202 shown, 11 thin omitted)
- Extraction: 96% EXTRACTED · 4% INFERRED · 0% AMBIGUOUS · INFERRED: 300 edges (avg confidence: 0.85)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `68a4490d`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- Countify.Application.Wrappers
- CatalogSeeder
- UpdateCompanySettingsCommand
- CountifyDbContext
- UpdateDepartmentCommand
- AccountsReceivableDocumentsController.cs
- microsoft_entityframeworkcore
- UpdateProductCommand
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
- UpdateProjectGroupCommand
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
- .Delete
- Countify.Domain.Enums
- ProductAccountDto
- GetRoleByIdQueryHandler
- ProjectGroup
- .Delete
- CreateCustomerCommand
- PaginatedResponse
- Budget
- UserInfoResponse
- DocumentTypeDto
- GetQualitiesQueryHandler
- CustomersController.cs
- http
- JournalEntryLineRequest
- UpdateQualityCommand
- UpdateUserCommand
- Countify.Infrastructure.Persistence
- PermissionService
- AccountsController
- AccountingPeriodDto
- CreateAccountsReceivableConceptCommand
- AccountsReceivableDocumentDto
- GetUserByIdQueryHandler
- UsersController
- BankReconciliation
- AccountsReceivableDocument
- GetProjectsQuery
- DatabaseExtensions.cs
- IRequestHandler
- RolesController
- .Delete
- CustomerDto
- AccountingPeriod
- UpdateAccountsReceivableDocumentCommand
- UpdateCustomerCommand
- UpdateRolePermissionsCommand
- BaseEntity
- GetJournalEntriesQuery
- .Delete
- RoleDto
- .Close
- .Up
- Program.cs
- DocumentType
- .AddApiServices
- YearEndClosingEntry
- .BuildTargetModel
- .BuildTargetModel
- DepartmentsController.cs
- GetAccountsQuery
- AccountsReceivableConcept
- CreateAccountsReceivableDocumentCommand
- GetJournalEntryByIdQuery
- .BuildTargetModel
- BudgetLineRequest
- Customer
- IEntityTypeConfiguration
- UpdateRoleCommand
- AccountsReceivableDocumentsController
- SourceModule
- .Delete
- DeleteRoleCommandHandler
- ICurrentUserService
- fluentvalidation
- BankTransactionType
- .Validate
- AccountsReceivableDocumentLineDto
- AccountsReceivableConceptDto
- AssignRoleCommand
- RequestParameter
- .AddInfrastructureServices
- .OnModelCreating
- UpdateDocumentTypeCommand
- .Delete
- IEmailService
- AccountsController.cs
- CreateCustomerTypeCommand
- .Handle
- .BuildTargetModel
- UpdateCustomerTypeCommand
- .BuildTargetModel
- Seeding — GENERALIZADO (base para futuras entidades/fases)
- DeleteUserCommand
- Currency
- .BuildModel
- CreateDocumentTypeCommand
- DeleteCustomerCommand
- JournalEntryStatus
- .ApplyOrder
- CustomerTypesController.cs
- UserRoleHasPermissionRequirement
- BaseController
- DeleteCustomerTypeCommand
- .ValidateAsync
- CreateProjectGroupCommand
- AuthController
- CreateQualityCommand
- ChangePasswordCommand
- Countify.Domain.Entities.Auth
- CreateAccountsReceivableDocumentLinesCommand
- microsoft_aspnetcore_authorization
- CloseAccountingPeriodCommand
- GetAccountByIdQuery
- .CreateAsync
- DeleteQualityCommand
- GetUserInfoQueryHandler
- ProductAccountRequest
- TransactionSeeder
- GetCustomersQueryHandler
- RolePermission
- DeleteProductCommand
- Flujo bancario
- BudgetRequest
- CreateAccountingPeriodCommand
- CountifyDbContextFactory
- AccountsReceivableConceptsController.cs
- GetAccountsReceivableConceptsQueryHandler
- UpdateProductAccountCommand
- GetPendingAccountsReceivableDocumentsQuery
- CurrencyPolicies
- .BuildTargetModel
- EntryConceptType
- Profile
- CreateRoleCommand
- CreateAccountsReceivableDocumentCommandHandler
- DeleteAccountsReceivableDocumentLineCommand
- .SaveChangesAsync
- DeleteDepartmentCommand
- UpdateAccountsReceivableDocumentLineCommand
- GetAccountsReceivableDocumentByIdQuery
- DeleteDocumentTypeCommand
- .Handle
- ProductProfile.cs
- VoidAccountsReceivableDocumentCommand
- Product
- Department
- CustomerType
- DeleteAccountingPeriodCommand
- ProjectGroupsController.cs
- AccountingPeriodProfile.cs
- .ValidateAsync
- ProductAccountProfile.cs
- IConfigureOptions
- BasicAccountingPeriods
- .BuildTargetModel
- ReportsPolicies
- GetAccountsReceivableDocumentsQueryHandler
- OrderColumns
- AccountingPeriodPolicies
- DeleteProductAccountCommand
- Countify — Convenciones del proyecto
- AccountPolicies
- UpdateAccountsReceivableDocumentCommandHandler
- CustomerPolicies
- CustomerTypePolicies
- HistoryPolicies
- AccountsReceivableDocumentPolicies
- UsersController.cs
- DepartmentPolicies
- ProjectPolicies

## God Nodes (most connected - your core abstractions)
1. `Response` - 282 edges
2. `IUnitOfWork` - 152 edges
3. `Countify.Domain.Entities.Accounting` - 97 edges
4. `Countify.Application.Wrappers` - 93 edges
5. `Countify.Domain.Interfaces` - 93 edges
6. `CountifyDbContext` - 78 edges
7. `UnitOfWork` - 66 edges
8. `BankTransaction` - 49 edges
9. `Countify.Api.Authorization.Policies` - 43 edges
10. `AccountsReceivableDocumentDto` - 41 edges

## Surprising Connections (you probably didn't know these)
- `Modelo contable (FASE 1 — corregido)` --references--> `CompanySettings`  [INFERRED]
  AGENTS.md → Countify.Domain/Entities/Accounting/CompanySettings.cs
- `Permisos (patrón de futuras fases también)` --references--> `AccountPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/AccountPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `AccountingPeriodPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/AccountingPeriodPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `DepartmentPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/DepartmentPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `ProjectPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/ProjectPolicies.cs

## Import Cycles
- None detected.

## Communities (213 total, 11 thin omitted)

### Community 0 - "Countify.Application.Wrappers"
Cohesion: 0.08
Nodes (10): automapper, automapper_queryableextensions, Countify.Application.Features.Accounts.DTOs, Countify.Application.Features.ProductAccounts.DTOs, Countify.Application.Features.ProductAccounts, Countify.Application.Extensions, Countify.Application.Wrappers, Countify.Application.Features.Projects.DTOs (+2 more)

### Community 1 - "CatalogSeeder"
Cohesion: 0.35
Nodes (5): CatalogSeeder, CancellationToken, ILogger, IOptions, Task

### Community 2 - "UpdateCompanySettingsCommand"
Cohesion: 0.11
Nodes (19): UpdateCompanySettingsCommand, Address, CompanyName, DefaultDepartmentId, DefaultProjectId, Email, FiscalYear, Mobile (+11 more)

### Community 3 - "CountifyDbContext"
Cohesion: 0.05
Nodes (39): CountifyDbContext, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts, BankReconciliations (+31 more)

### Community 4 - "UpdateDepartmentCommand"
Cohesion: 0.06
Nodes (38): DepartmentsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+30 more)

### Community 5 - "AccountsReceivableDocumentsController.cs"
Cohesion: 0.11
Nodes (15): CreateAccountsReceivableDocumentCommandValidator, UpdateAccountsReceivableDocumentCommandValidator, AccountsReceivableDocumentProfile, CreateAccountsReceivableDocumentLinesCommandValidator, Countify.Application.Features.AccountsReceivableDocuments.Queries.GetAccountsReceivableDocumentById, Countify.Application.Features.AccountsReceivableDocuments.Validators, Countify.Application.Features.AccountsReceivableDocuments.Commands.VoidAccountsReceivableDocument, Countify.Application.Features.AccountsReceivableDocuments.Commands.CreateAccountsReceivableDocumentLines (+7 more)

### Community 6 - "microsoft_entityframeworkcore"
Cohesion: 0.17
Nodes (3): Countify.Infrastructure.Persistence.Configurations, microsoft_entityframeworkcore, microsoft_entityframeworkcore_metadata_builders

### Community 7 - "UpdateProductCommand"
Cohesion: 0.07
Nodes (37): ProductsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+29 more)

### Community 8 - "Response"
Cohesion: 0.05
Nodes (47): DeleteAccountsReceivableConceptCommand, Id, DeleteAccountsReceivableConceptCommandHandler, CancellationToken, Guid, Task, ForgotPasswordCommand, ForgotPasswordCommandHandler (+39 more)

### Community 9 - "CustomerTypeDto"
Cohesion: 0.15
Nodes (15): CustomerTypeDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Code, Id, Name, Guid (+7 more)

### Community 10 - "JournalEntry"
Cohesion: 0.09
Nodes (22): JournalEntry, Code, Concept, CreditTotal, DebitTotal, DifferenceAmount, EntryGid, EntryNumber (+14 more)

### Community 11 - "JournalEntriesController"
Cohesion: 0.33
Nodes (9): JournalEntriesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 12 - "UpdateAccountsReceivableConceptCommand"
Cohesion: 0.15
Nodes (13): UpdateAccountsReceivableConceptCommand, AccountId, Description, GeneratePosting, Id, IsInactive, Observations, Type (+5 more)

### Community 13 - "IRequest"
Cohesion: 0.10
Nodes (52): BankHandler, BankReconciliationDto, BankAccountId, BankAccountName, BookBalance, Id, IsClosed, Notes (+44 more)

### Community 14 - "History"
Cohesion: 0.15
Nodes (13): History, Date, Entity, EntityId, NewValue, OldValue, Property, UserId (+5 more)

### Community 15 - "UpdateProjectCommand"
Cohesion: 0.08
Nodes (28): ProjectsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+20 more)

### Community 16 - "IRepository"
Cohesion: 0.11
Nodes (20): IRepository, CancellationToken, Expression, Func, Guid, IEnumerable, IQueryable, List (+12 more)

### Community 17 - "CurrencyFeatures.cs"
Cohesion: 0.12
Nodes (26): CurrenciesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+18 more)

### Community 18 - ".HandleResult"
Cohesion: 0.26
Nodes (11): BanksController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+3 more)

### Community 19 - "Permission"
Cohesion: 0.15
Nodes (11): BankPolicies, AuthorizationOptions, Permissions, Items, Permission, Description, Id, Name (+3 more)

### Community 20 - "BankTransaction"
Cohesion: 0.06
Nodes (32): BankTransaction, Amount, AppliesToReceivableId, BankAccount, BankAccountId, BankReconciliation, BankReconciliationId, Beneficiary (+24 more)

### Community 21 - "GetTrialBalanceQuery"
Cohesion: 0.10
Nodes (23): TrialBalanceDto, CreditTotal, DebitTotal, Difference, Lines, TrialBalanceLineDto, AccountCode, AccountId (+15 more)

### Community 22 - "UpdateProjectGroupCommand"
Cohesion: 0.08
Nodes (29): ProjectGroupsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+21 more)

### Community 23 - "UnitOfWork"
Cohesion: 0.05
Nodes (40): UnitOfWork, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts, BankReconciliations (+32 more)

### Community 24 - "ValidationException"
Cohesion: 0.08
Nodes (25): ExceptionHandlerMiddleware, Exception, ILogger, Task, ValidationBehavior, CancellationToken, IEnumerable, Task (+17 more)

### Community 25 - "AccountMovementsResponse"
Cohesion: 0.08
Nodes (26): AccountMovementDto, Balance, Concept, Credit, Debit, EntryNumber, JournalEntryId, ReferenceDate (+18 more)

### Community 26 - "BudgetLine"
Cohesion: 0.09
Nodes (23): BudgetLine, Account, AccountId, April, August, Budget, BudgetId, December (+15 more)

### Community 27 - "IUnitOfWork"
Cohesion: 0.05
Nodes (38): IUnitOfWork, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts, BankReconciliations (+30 more)

### Community 28 - "HistoryDto"
Cohesion: 0.07
Nodes (29): HistoryController, Authorize, HttpGet, IActionResult, Task, HistoryDto, Date, Entity (+21 more)

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
Cohesion: 0.08
Nodes (26): JournalEntryLine, Account, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName (+18 more)

### Community 33 - "AccountsReceivableDocumentDraftRequest"
Cohesion: 0.13
Nodes (15): AccountsReceivableDocumentDraftRequest, Amount, AppliesTo, ConceptId, CurrencyId, CustomerId, Date, DepartmentId (+7 more)

### Community 34 - "Countify.Api.Controllers"
Cohesion: 0.10
Nodes (15): Countify.Application.Features.Configurations.Queries.GetCompanySettings, Countify.Application.Features.AccountingPeriods.Queries.GetAccountingPeriods, Countify.Application.Features.Projects.Queries.GetProjects, Countify.Application.Features.JournalEntries.Queries.GetJournalEntries, Countify.Api.Controllers, Countify.Application.Features.Reports.Queries.GetTrialBalance, Countify.Application.Features.Products.Queries.GetProducts, Countify.Application.Features.Auth.Queries.GetUserInfo (+7 more)

### Community 35 - "BankTransactionDto"
Cohesion: 0.08
Nodes (25): BankTransactionDto, Amount, AppliesToReceivableId, BankAccountId, BankAccountName, BankReconciliationId, Beneficiary, Concept (+17 more)

### Community 36 - "UserDto"
Cohesion: 0.11
Nodes (22): UserDto, CreatedAt, Email, FirstName, FullName, Id, IsActive, LastName (+14 more)

### Community 37 - "ProductAccount"
Cohesion: 0.10
Nodes (20): ProductAccount, CostAccount, CostAccountId, IncomeAccount, IncomeAccountId, InventoryAccount, InventoryAccountId, Product (+12 more)

### Community 38 - "ApiKeyAuthenticationHandler"
Cohesion: 0.07
Nodes (24): AuthenticateResult, AuthenticationHandler, AuthenticationProperties, AuthenticationSchemeOptions, AuthorizeAttribute, ApiKeyAuthenticationDefaults, ApiKeyAuthenticationHandler, IOptions (+16 more)

### Community 39 - "JournalEntryDto"
Cohesion: 0.09
Nodes (22): JournalEntryDto, Code, Concept, CreditTotal, DebitTotal, DifferenceAmount, EntryNumber, Gid (+14 more)

### Community 40 - "CompanySettings"
Cohesion: 0.09
Nodes (23): CompanySettings, Address, CompanyName, DefaultDepartment, DefaultDepartmentId, DefaultProject, DefaultProjectId, Email (+15 more)

### Community 41 - "CompanySettingsDto"
Cohesion: 0.05
Nodes (38): CompanySettingsDto, Address, CompanyName, DefaultDepartmentId, DefaultProjectId, Email, FiscalYear, Id (+30 more)

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
Nodes (7): Countify.Domain.Seeders, Countify.Domain.Entities.Audit, Countify.Domain.Entities.AccountsReceivable, Countify.Domain.Common, Countify.Domain.Entities.Accounting, microsoft_aspnetcore_identity_entityframeworkcore, system_linq

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
Cohesion: 0.07
Nodes (31): CreateUserCommand, Email, FirstName, LastName, Password, Phone, RoleId, Username (+23 more)

### Community 51 - "BudgetsController"
Cohesion: 0.29
Nodes (10): BudgetRequest, BudgetsController, Authorize, CancellationToken, HttpDelete, HttpGet, HttpPost, HttpPut (+2 more)

### Community 52 - ".Delete"
Cohesion: 0.28
Nodes (9): DocumentTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 53 - "Countify.Domain.Enums"
Cohesion: 0.17
Nodes (8): Countify.Application.Features.JournalEntries.Commands.CreateJournalEntry, Countify.Application.Features.JournalEntries.DTOs, Countify.Application.Features.AccountsReceivableDocuments.DTOs, Countify.Application.Features.JournalEntries.Profiles, Countify.Application.Features.AccountsReceivableDocuments, Countify.Application.Features.JournalEntries, Countify.Domain.Enums, Countify.Application.Features.JournalEntries.Commands.UpdateJournalEntry

### Community 54 - "ProductAccountDto"
Cohesion: 0.11
Nodes (17): ProductAccountDto, CostAccountCode, CostAccountId, CostAccountName, Id, IncomeAccountCode, IncomeAccountId, IncomeAccountName (+9 more)

### Community 55 - "GetRoleByIdQueryHandler"
Cohesion: 0.14
Nodes (13): PermissionDto, Description, Id, Name, RoleDetailDto, Permissions, IList, GetRoleByIdQueryHandler (+5 more)

### Community 56 - "ProjectGroup"
Cohesion: 0.09
Nodes (21): Project, Project, Code, Group, GroupId, Name, Guid, ProjectGroup (+13 more)

### Community 57 - ".Delete"
Cohesion: 0.28
Nodes (9): AccountsReceivableConceptsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 58 - "CreateCustomerCommand"
Cohesion: 0.09
Nodes (24): CreateCustomerCommand, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId, Email (+16 more)

### Community 59 - "PaginatedResponse"
Cohesion: 0.15
Nodes (15): GetProductAccountsQuery, Search, GetProductAccountsQueryHandler, CancellationToken, IMapper, List, Task, PaginatedResponse (+7 more)

### Community 60 - "Budget"
Cohesion: 0.15
Nodes (13): BudgetLine, Budget, FiscalYear, Lines, Name, List, BasicBudgets, Items (+5 more)

### Community 61 - "UserInfoResponse"
Cohesion: 0.07
Nodes (21): ForgotPasswordRequest, Email, LoginRequest, Password, Username, RefreshTokenRequest, AccessToken, RefreshToken (+13 more)

### Community 62 - "DocumentTypeDto"
Cohesion: 0.18
Nodes (13): DocumentTypeDto, Code, Id, IsDefault, Name, Guid, GetDocumentTypesQuery, GetDocumentTypesQueryHandler (+5 more)

### Community 63 - "GetQualitiesQueryHandler"
Cohesion: 0.20
Nodes (12): QualityDto, Code, Id, Name, Guid, GetQualitiesQuery, GetQualitiesQueryHandler, CancellationToken (+4 more)

### Community 64 - "CustomersController.cs"
Cohesion: 0.18
Nodes (8): CreateCustomerCommandValidator, UpdateCustomerCommandValidator, CustomerProfile, Countify.Application.Features.Customers.Commands.DeleteCustomer, Countify.Application.Features.Customers.Queries.GetCustomers, Countify.Application.Features.Customers.Profiles, Countify.Application.Features.Customers.Commands.UpdateCustomer, Countify.Application.Features.Customers.Commands.CreateCustomer

### Community 65 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 66 - "JournalEntryLineRequest"
Cohesion: 0.12
Nodes (16): JournalEntryLineRequest, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName, Debit (+8 more)

### Community 67 - "UpdateQualityCommand"
Cohesion: 0.22
Nodes (9): UpdateQualityCommand, Code, Id, Name, UpdateQualityCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 68 - "UpdateUserCommand"
Cohesion: 0.13
Nodes (15): UpdateUserCommand, Email, FirstName, Id, IsActive, LastName, Phone, RoleId (+7 more)

### Community 69 - "Countify.Infrastructure.Persistence"
Cohesion: 0.08
Nodes (28): InitialCreate, DateTime, Guid, MigrationBuilder, AddAccountingModule, Guid, MigrationBuilder, AddBudgetsAndBudgetPermissions (+20 more)

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
Cohesion: 0.19
Nodes (12): CreateAccountsReceivableConceptCommand, AccountId, Description, GeneratePosting, IsInactive, Observations, Type, CreateAccountsReceivableConceptCommandHandler (+4 more)

### Community 74 - "AccountsReceivableDocumentDto"
Cohesion: 0.07
Nodes (29): AccountsReceivableDocumentDto, Amount, AmountLocal, AppliesTo, ConceptDescription, ConceptId, CurrencyCode, CurrencyId (+21 more)

### Community 75 - "GetUserByIdQueryHandler"
Cohesion: 0.18
Nodes (13): UserDetailDto, CreatedBy, LastActivity, DateTime, GetUserByIdQuery, Id, GetUserByIdQueryHandler, CancellationToken (+5 more)

### Community 76 - "UsersController"
Cohesion: 0.29
Nodes (9): UsersController, Authorize, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult, Task (+1 more)

### Community 77 - "BankReconciliation"
Cohesion: 0.14
Nodes (14): BankReconciliation, BankAccount, BankAccountId, BookBalance, IsClosed, Notes, ReconciliationDate, StatementBalance (+6 more)

### Community 78 - "AccountsReceivableDocument"
Cohesion: 0.07
Nodes (29): AccountsReceivableDocument, Amount, AppliesTo, Concept, ConceptId, Currency, CurrencyId, CustomerId (+21 more)

### Community 79 - "GetProjectsQuery"
Cohesion: 0.18
Nodes (13): ProjectDto, Code, GroupId, Id, Name, Guid, GetProjectsQuery, Search (+5 more)

### Community 80 - "DatabaseExtensions.cs"
Cohesion: 0.32
Nodes (4): Countify.Infrastructure.Seeders, microsoft_extensions_dependencyinjection, microsoft_extensions_hosting, microsoft_extensions_logging

### Community 81 - "IRequestHandler"
Cohesion: 0.08
Nodes (26): DeleteAccountCommand, Id, DeleteAccountCommandHandler, CancellationToken, Guid, Task, UpdateAccountCommand, BudgetControlled (+18 more)

### Community 82 - "RolesController"
Cohesion: 0.33
Nodes (8): RolesController, Authorize, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult, Task

### Community 83 - ".Delete"
Cohesion: 0.28
Nodes (9): ProductAccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 84 - "CustomerDto"
Cohesion: 0.10
Nodes (20): CustomerDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Address, Code, CreditDays, CreditLimit (+12 more)

### Community 85 - "AccountingPeriod"
Cohesion: 0.25
Nodes (8): AccountingPeriod, EndDate, IsClosed, Month, StartDate, DateTime, AccountingPeriodConfiguration, EntityTypeBuilder

### Community 86 - "UpdateAccountsReceivableDocumentCommand"
Cohesion: 0.12
Nodes (16): UpdateAccountsReceivableDocumentCommand, Amount, AppliesTo, ConceptId, CurrencyId, CustomerId, Date, DepartmentId (+8 more)

### Community 87 - "UpdateCustomerCommand"
Cohesion: 0.11
Nodes (19): UpdateCustomerCommand, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId, Email (+11 more)

### Community 88 - "UpdateRolePermissionsCommand"
Cohesion: 0.22
Nodes (9): UpdateRolePermissionsCommand, PermissionIds, RoleId, UpdateRolePermissionsCommandHandler, CancellationToken, IdentityRole, List, RoleManager (+1 more)

### Community 89 - "BaseEntity"
Cohesion: 0.09
Nodes (22): BaseEntity, Id, Guid, Currency, Code, ExchangeRate, IsActive, Name (+14 more)

### Community 90 - "GetJournalEntriesQuery"
Cohesion: 0.21
Nodes (11): GetJournalEntriesQuery, FromDate, Search, Status, ToDate, GetJournalEntriesQueryHandler, CancellationToken, DateTime (+3 more)

### Community 91 - ".Delete"
Cohesion: 0.28
Nodes (9): QualitiesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 92 - "RoleDto"
Cohesion: 0.24
Nodes (10): RoleDto, Id, Name, PermissionCount, GetRolesQuery, GetRolesQueryHandler, CancellationToken, IMapper (+2 more)

### Community 93 - ".Close"
Cohesion: 0.33
Nodes (8): AccountingPeriodsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, IActionResult, Task

### Community 94 - ".Up"
Cohesion: 0.33
Nodes (4): DateTime, DateTimeOffset, Guid, MigrationBuilder

### Community 95 - "Program.cs"
Cohesion: 0.17
Nodes (9): ApplicationServiceRegistration, IServiceCollection, Countify.Api.DependencyInjection, Countify.Application.DependencyInjection, Countify.Infrastructure.Extensions, Countify.Infrastructure.DependencyInjection, quick_autoinject_dependencyannotation, scalar_aspnetcore (+1 more)

### Community 96 - "DocumentType"
Cohesion: 0.25
Nodes (8): DocumentType, Code, IsDefault, Name, BasicDocumentTypes, Items, DocumentTypeConfiguration, EntityTypeBuilder

### Community 97 - ".AddApiServices"
Cohesion: 0.18
Nodes (12): Permisos (patrón de futuras fases también), CompanySettingsPolicies, AuthorizationOptions, DocumentTypePolicies, AuthorizationOptions, JournalEntryPolicies, AuthorizationOptions, ProjectGroupPolicies (+4 more)

### Community 98 - "YearEndClosingEntry"
Cohesion: 0.22
Nodes (9): YearEndClosingEntry, GeneratedBy, JournalEntryId, PeriodId, Guid, BasicYearEndClosingEntries, Items, YearEndClosingEntryConfiguration (+1 more)

### Community 99 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 100 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 101 - "DepartmentsController.cs"
Cohesion: 0.18
Nodes (8): CreateDepartmentCommandValidator, UpdateDepartmentCommandValidator, DepartmentProfile, Countify.Application.Features.Departments.Commands.UpdateDepartment, Countify.Application.Features.Departments.Profiles, Countify.Application.Features.Departments.Commands.CreateDepartment, Countify.Application.Features.Departments.Queries.GetDepartments, Countify.Application.Features.Departments.Commands.DeleteDepartment

### Community 102 - "GetAccountsQuery"
Cohesion: 0.36
Nodes (8): GetAccountsQuery, IsOperable, Search, GetAccountsQueryHandler, CancellationToken, IMapper, List, Task

### Community 103 - "AccountsReceivableConcept"
Cohesion: 0.12
Nodes (18): AccountsReceivableConcept, Account, AccountId, Description, GeneratePosting, IsInactive, IsReceipt, Observations (+10 more)

### Community 104 - "CreateAccountsReceivableDocumentCommand"
Cohesion: 0.14
Nodes (14): CreateAccountsReceivableDocumentCommand, Amount, AppliesTo, ConceptId, CurrencyId, CustomerId, Date, DepartmentId (+6 more)

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

### Community 109 - "IEntityTypeConfiguration"
Cohesion: 0.10
Nodes (18): AccountsReceivableDocumentLine, Amount, AppliedDocument, AppliedDocumentId, Document, DocumentId, Guid, AccountConfiguration (+10 more)

### Community 110 - "UpdateRoleCommand"
Cohesion: 0.25
Nodes (8): UpdateRoleCommand, Id, Name, UpdateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 111 - "AccountsReceivableDocumentsController"
Cohesion: 0.29
Nodes (10): AccountsReceivableDocumentsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+2 more)

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
Cohesion: 0.05
Nodes (34): AbstractValidator, CreateAccountingPeriodCommandValidator, ForgotPasswordCommandValidator, LoginCommandValidator, RefreshTokenCommandValidator, ResetPasswordCommandValidator, UpdateCompanySettingsCommandValidator, DeleteDocumentTypeCommandValidator (+26 more)

### Community 117 - "BankTransactionType"
Cohesion: 0.22
Nodes (9): BankTransactionType, Code, MovementType, TransactionType, BasicBanks, Accounts, TransactionTypes, BankTransactionTypeConfiguration (+1 more)

### Community 118 - ".Validate"
Cohesion: 0.36
Nodes (4): JournalEntryRules, EntryConceptType, Guid, IEnumerable

### Community 119 - "AccountsReceivableDocumentLineDto"
Cohesion: 0.14
Nodes (14): AccountsReceivableDocumentLineDto, Amount, AppliedAmount, AppliedConcept, AppliedCurrencyCode, AppliedDate, AppliedDocumentId, AppliedDocumentNo (+6 more)

### Community 120 - "AccountsReceivableConceptDto"
Cohesion: 0.14
Nodes (13): AccountsReceivableConceptDto, AccountCode, AccountId, AccountName, Description, GeneratePosting, Id, IsInactive (+5 more)

### Community 121 - "AssignRoleCommand"
Cohesion: 0.29
Nodes (7): AssignRoleCommand, RoleName, UserId, AssignRoleCommandHandler, CancellationToken, Task, UserManager

### Community 122 - "RequestParameter"
Cohesion: 0.25
Nodes (7): RequestParameter, All, Column, Order, PageNumber, PageSize, Parameter

### Community 123 - ".AddInfrastructureServices"
Cohesion: 0.14
Nodes (12): SeederOptions, Enabled, SeedConfiguration, SeedTransactions, IConfiguration, IdentityRole, IServiceCollection, ConfigurationSeeder (+4 more)

### Community 124 - ".OnModelCreating"
Cohesion: 0.25
Nodes (7): IdentityRole, IdentityUserRole, ModelBuilder, IdentityRoleClaim, IdentityUserClaim, IdentityUserLogin, IdentityUserToken

### Community 125 - "UpdateDocumentTypeCommand"
Cohesion: 0.20
Nodes (10): UpdateDocumentTypeCommand, Code, Id, IsDefault, Name, UpdateDocumentTypeCommandHandler, CancellationToken, Guid (+2 more)

### Community 126 - ".Delete"
Cohesion: 0.28
Nodes (9): CustomerTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 127 - "IEmailService"
Cohesion: 0.33
Nodes (4): IEmailService, Task, EmailService, Task

### Community 128 - "AccountsController.cs"
Cohesion: 0.13
Nodes (11): CreateAccountCommandValidator, DeleteAccountCommandValidator, UpdateAccountCommandValidator, AccountProfile, Countify.Application.Features.Accounts.Commands.CreateAccount, Countify.Application.Features.JournalEntries.Queries.GetAccountMovements, Countify.Application.Features.Accounts.Profiles, Countify.Application.Features.Accounts.Queries.GetAccounts (+3 more)

### Community 129 - "CreateCustomerTypeCommand"
Cohesion: 0.27
Nodes (9): CreateCustomerTypeCommand, AccountingAccountId, Code, Name, CreateCustomerTypeCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 130 - ".Handle"
Cohesion: 0.16
Nodes (11): BudgetAvailabilityValidator, CancellationToken, DateTime, Guid, IEnumerable, Task, UpdateJournalEntryCommandHandler, CancellationToken (+3 more)

### Community 131 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 132 - "UpdateCustomerTypeCommand"
Cohesion: 0.20
Nodes (10): UpdateCustomerTypeCommand, AccountingAccountId, Code, Id, Name, UpdateCustomerTypeCommandHandler, CancellationToken, Guid (+2 more)

### Community 133 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 134 - "Seeding — GENERALIZADO (base para futuras entidades/fases)"
Cohesion: 0.12
Nodes (16): Seeding — GENERALIZADO (base para futuras entidades/fases), ISeeder, CancellationToken, Task, BasicCompanySettings, Items, BasicRoles, Items (+8 more)

### Community 135 - "DeleteUserCommand"
Cohesion: 0.33
Nodes (6): DeleteUserCommand, Id, DeleteUserCommandHandler, CancellationToken, Task, UserManager

### Community 136 - "Currency"
Cohesion: 0.38
Nodes (5): Currency, BasicCurrencies, Items, CurrencyConfiguration, EntityTypeBuilder

### Community 137 - ".BuildModel"
Cohesion: 0.29
Nodes (6): CountifyDbContextModelSnapshot, DateTime, DateTimeOffset, Guid, ModelBuilder, ModelSnapshot

### Community 138 - "CreateDocumentTypeCommand"
Cohesion: 0.27
Nodes (9): CreateDocumentTypeCommand, Code, IsDefault, Name, CreateDocumentTypeCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 139 - "DeleteCustomerCommand"
Cohesion: 0.33
Nodes (6): DeleteCustomerCommand, Id, DeleteCustomerCommandHandler, CancellationToken, Guid, Task

### Community 140 - "JournalEntryStatus"
Cohesion: 0.33
Nodes (5): JournalEntryStatus, Approved, Draft, Posted, Voided

### Community 141 - ".ApplyOrder"
Cohesion: 0.46
Nodes (5): QueryableExtensions, Expression, Func, IQueryable, Dictionary

### Community 142 - "CustomerTypesController.cs"
Cohesion: 0.18
Nodes (8): CreateCustomerTypeCommandValidator, UpdateCustomerTypeCommandValidator, CustomerTypeProfile, Countify.Application.Features.CustomerTypes.Commands.DeleteCustomerType, Countify.Application.Features.CustomerTypes.Commands.UpdateCustomerType, Countify.Application.Features.CustomerTypes.Commands.CreateCustomerType, Countify.Application.Features.CustomerTypes.Profiles, Countify.Application.Features.CustomerTypes.Queries.GetCustomerTypes

### Community 143 - "UserRoleHasPermissionRequirement"
Cohesion: 0.20
Nodes (10): AuthorizationHandler, AuthorizationHandlerContext, PermissionAuthorizationHandler, Task, RolePolicies, AuthorizationOptions, UserRoleHasPermissionRequirement, Permission (+2 more)

### Community 144 - "BaseController"
Cohesion: 0.13
Nodes (15): ControllerBase, BaseController, Mediator, ReportsController, Authorize, HttpGet, IActionResult, Task (+7 more)

### Community 145 - "DeleteCustomerTypeCommand"
Cohesion: 0.33
Nodes (6): DeleteCustomerTypeCommand, Id, DeleteCustomerTypeCommandHandler, CancellationToken, Guid, Task

### Community 146 - ".ValidateAsync"
Cohesion: 0.29
Nodes (6): JournalEntryAuxValidator, CancellationToken, Guid, Task, IReadOnlyCollection, IReadOnlyDictionary

### Community 147 - "CreateProjectGroupCommand"
Cohesion: 0.31
Nodes (8): CreateProjectGroupCommand, Code, Name, CreateProjectGroupCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 148 - "AuthController"
Cohesion: 0.38
Nodes (6): AuthController, Authorize, HttpGet, HttpPost, IActionResult, Task

### Community 149 - "CreateQualityCommand"
Cohesion: 0.31
Nodes (8): CreateQualityCommand, Code, Name, CreateQualityCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 150 - "ChangePasswordCommand"
Cohesion: 0.25
Nodes (8): ChangePasswordCommand, CurrentPassword, Id, NewPassword, ChangePasswordCommandHandler, CancellationToken, Task, UserManager

### Community 151 - "Countify.Domain.Entities.Auth"
Cohesion: 0.08
Nodes (18): Countify.Infrastructure.Persistence.Services, Countify.Infrastructure.Services, Countify.Application.Common.Interfaces, Countify.Application.Features.Users.DTOs, Countify.Application.Features.Roles.DTOs, Countify.Domain.Entities.Auth, Countify.Application.Features.Roles.Profiles, microsoft_aspnetcore_authentication_jwtbearer (+10 more)

### Community 152 - "CreateAccountsReceivableDocumentLinesCommand"
Cohesion: 0.18
Nodes (12): CreateAccountsReceivableDocumentLinesCommand, DocumentId, Lines, CreateAccountsReceivableDocumentLinesCommandHandler, LineItem, Amount, AppliedDocumentId, CancellationToken (+4 more)

### Community 153 - "microsoft_aspnetcore_authorization"
Cohesion: 0.25
Nodes (7): Countify.Domain.Authorization, Countify.Api.Authorization.Handlers, Countify.Api.Authorization.Requirements, Countify.Api.Authorization.Policies, microsoft_aspnetcore_authorization, microsoft_extensions_options, system_security_claims

### Community 154 - "CloseAccountingPeriodCommand"
Cohesion: 0.29
Nodes (7): CloseAccountingPeriodCommand, Id, CloseAccountingPeriodCommandHandler, CancellationToken, Guid, Task, CloseAccountingPeriodCommandValidator

### Community 155 - "GetAccountByIdQuery"
Cohesion: 0.29
Nodes (7): GetAccountByIdQuery, Id, GetAccountByIdQueryHandler, CancellationToken, Guid, IMapper, Task

### Community 156 - ".CreateAsync"
Cohesion: 0.43
Nodes (4): AccountsReceivableDocumentDraftFactory, DraftCreationResult, CancellationToken, Task

### Community 157 - "DeleteQualityCommand"
Cohesion: 0.33
Nodes (6): DeleteQualityCommand, Id, DeleteQualityCommandHandler, CancellationToken, Guid, Task

### Community 158 - "GetUserInfoQueryHandler"
Cohesion: 0.29
Nodes (7): GetUserInfoQuery, GetUserInfoQueryHandler, CancellationToken, IdentityRole, RoleManager, Task, UserManager

### Community 159 - "ProductAccountRequest"
Cohesion: 0.25
Nodes (7): ProductAccountRequest, CostAccountId, IncomeAccountId, InventoryAccountId, ProductId, QualityId, Guid

### Community 160 - "TransactionSeeder"
Cohesion: 0.30
Nodes (7): CancellationToken, Task, TransactionSeeder, CancellationToken, ILogger, IOptions, Task

### Community 161 - "GetCustomersQueryHandler"
Cohesion: 0.43
Nodes (6): GetCustomersQuery, GetCustomersQueryHandler, CancellationToken, IMapper, List, Task

### Community 162 - "RolePermission"
Cohesion: 0.25
Nodes (8): RolePermission, Permission, PermissionId, Role, RoleId, IdentityRole, RolePermissionConfiguration, EntityTypeBuilder

### Community 163 - "DeleteProductCommand"
Cohesion: 0.33
Nodes (6): DeleteProductCommand, Id, DeleteProductCommandHandler, CancellationToken, Guid, Task

### Community 165 - "BudgetRequest"
Cohesion: 0.17
Nodes (11): BudgetLineRequest, BudgetLineResponse, BudgetResponse, BudgetLineResponse, BudgetRequest, FiscalYear, Lines, Name (+3 more)

### Community 166 - "CreateAccountingPeriodCommand"
Cohesion: 0.36
Nodes (7): CreateAccountingPeriodCommand, Month, CreateAccountingPeriodCommandHandler, CancellationToken, DateTime, Guid, Task

### Community 167 - "CountifyDbContextFactory"
Cohesion: 0.29
Nodes (6): CountifyDbContextFactory, DesignTimeCurrentUserService, Guid, UserId, UserName, IDesignTimeDbContextFactory

### Community 168 - "AccountsReceivableConceptsController.cs"
Cohesion: 0.18
Nodes (8): CreateAccountsReceivableConceptCommandValidator, UpdateAccountsReceivableConceptCommandValidator, AccountsReceivableConceptProfile, Countify.Application.Features.AccountsReceivableConcepts.Profiles, Countify.Application.Features.AccountsReceivableConcepts.Commands.DeleteAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Commands.CreateAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Commands.UpdateAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Queries.GetAccountsReceivableConcepts

### Community 169 - "GetAccountsReceivableConceptsQueryHandler"
Cohesion: 0.43
Nodes (6): GetAccountsReceivableConceptsQuery, GetAccountsReceivableConceptsQueryHandler, CancellationToken, IMapper, List, Task

### Community 170 - "UpdateProductAccountCommand"
Cohesion: 0.29
Nodes (7): UpdateProductAccountCommand, Id, UpdateProductAccountCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 171 - "GetPendingAccountsReceivableDocumentsQuery"
Cohesion: 0.27
Nodes (9): GetPendingAccountsReceivableDocumentsQuery, CustomerId, ExcludeDocumentIds, GetPendingAccountsReceivableDocumentsQueryHandler, CancellationToken, Guid, IMapper, List (+1 more)

### Community 173 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 174 - "EntryConceptType"
Cohesion: 0.40
Nodes (4): EntryConceptType, Credit, Debit, Other

### Community 175 - "Profile"
Cohesion: 0.10
Nodes (17): BankAccountProfile, CurrencyProfile, CreateDocumentTypeCommandValidator, UpdateDocumentTypeCommandValidator, DocumentTypeProfile, JournalEntryProfile, QualityProfile, RoleProfile (+9 more)

### Community 176 - "CreateRoleCommand"
Cohesion: 0.29
Nodes (7): CreateRoleCommand, Name, CreateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 177 - "CreateAccountsReceivableDocumentCommandHandler"
Cohesion: 0.48
Nodes (5): CreateAccountsReceivableDocumentCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 178 - "DeleteAccountsReceivableDocumentLineCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountsReceivableDocumentLineCommand, Id, DeleteAccountsReceivableDocumentLineCommandHandler, CancellationToken, Guid, Task

### Community 179 - ".SaveChangesAsync"
Cohesion: 0.29
Nodes (5): UpdateCompanySettingsCommandHandler, CancellationToken, Task, CancellationToken, Task

### Community 180 - "DeleteDepartmentCommand"
Cohesion: 0.33
Nodes (6): DeleteDepartmentCommand, Id, DeleteDepartmentCommandHandler, CancellationToken, Guid, Task

### Community 181 - "UpdateAccountsReceivableDocumentLineCommand"
Cohesion: 0.29
Nodes (7): UpdateAccountsReceivableDocumentLineCommand, Amount, Id, UpdateAccountsReceivableDocumentLineCommandHandler, CancellationToken, Guid, Task

### Community 182 - "GetAccountsReceivableDocumentByIdQuery"
Cohesion: 0.29
Nodes (7): GetAccountsReceivableDocumentByIdQuery, Id, GetAccountsReceivableDocumentByIdQueryHandler, CancellationToken, Guid, IMapper, Task

### Community 183 - "DeleteDocumentTypeCommand"
Cohesion: 0.33
Nodes (6): DeleteDocumentTypeCommand, Id, DeleteDocumentTypeCommandHandler, CancellationToken, Guid, Task

### Community 184 - ".Handle"
Cohesion: 0.43
Nodes (6): CreateProductAccountCommand, CreateProductAccountCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 185 - "ProductProfile.cs"
Cohesion: 0.29
Nodes (5): ProductProfile, Countify.Application.Features.Products.DTOs, Countify.Application.Features.Products.Commands.CreateProduct, Countify.Application.Features.Products.Commands.UpdateProduct, Countify.Application.Features.Products.Profiles

### Community 186 - "VoidAccountsReceivableDocumentCommand"
Cohesion: 0.33
Nodes (6): VoidAccountsReceivableDocumentCommand, Id, VoidAccountsReceivableDocumentCommandHandler, CancellationToken, Guid, Task

### Community 187 - "Product"
Cohesion: 0.33
Nodes (6): Product, Code, Name, BasicProducts, ProductConfiguration, EntityTypeBuilder

### Community 188 - "Department"
Cohesion: 0.40
Nodes (5): Department, BasicDepartments, Items, DepartmentConfiguration, EntityTypeBuilder

### Community 189 - "CustomerType"
Cohesion: 0.40
Nodes (5): CustomerType, BasicCustomerTypes, Items, CustomerTypeConfiguration, EntityTypeBuilder

### Community 190 - "DeleteAccountingPeriodCommand"
Cohesion: 0.29
Nodes (7): DeleteAccountingPeriodCommand, Id, DeleteAccountingPeriodCommandHandler, CancellationToken, Guid, Task, DeleteAccountingPeriodCommandValidator

### Community 191 - "ProjectGroupsController.cs"
Cohesion: 0.13
Nodes (11): CreateProjectCommandValidator, CreateProjectGroupCommandValidator, UpdateProjectCommandValidator, ProjectProfile, Countify.Application.Features.Projects.Commands.UpdateProject, Countify.Application.Features.Projects.Profiles, Countify.Application.Features.Projects.Commands.UpdateProjectGroup, Countify.Application.Features.Projects.Commands.DeleteProjectGroup (+3 more)

### Community 192 - "AccountingPeriodProfile.cs"
Cohesion: 0.40
Nodes (3): AccountingPeriodProfile, Countify.Application.Features.AccountingPeriods.Profiles, Countify.Application.Features.AccountingPeriods.DTOs

### Community 193 - ".ValidateAsync"
Cohesion: 0.60
Nodes (4): ProductAccountRules, CancellationToken, Guid, Task

### Community 194 - "ProductAccountProfile.cs"
Cohesion: 0.40
Nodes (4): ProductAccountProfile, Countify.Application.Features.ProductAccounts.Profiles, Countify.Application.Features.ProductAccounts.Commands.CreateProductAccount, Countify.Application.Features.ProductAccounts.Commands.UpdateProductAccount

### Community 195 - "IConfigureOptions"
Cohesion: 0.21
Nodes (9): AccountsReceivableConceptPolicies, AuthorizationOptions, BudgetPolicies, AuthorizationOptions, ProductAccountPolicies, AuthorizationOptions, UserPolicies, AuthorizationOptions (+1 more)

### Community 196 - "BasicAccountingPeriods"
Cohesion: 0.60
Nodes (3): BasicAccountingPeriods, Items, DateTime

### Community 197 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 199 - "GetAccountsReceivableDocumentsQueryHandler"
Cohesion: 0.43
Nodes (6): GetAccountsReceivableDocumentsQuery, GetAccountsReceivableDocumentsQueryHandler, CancellationToken, IMapper, List, Task

### Community 200 - "OrderColumns"
Cohesion: 0.50
Nodes (3): OrderColumns, Ascending, Descending

### Community 202 - "DeleteProductAccountCommand"
Cohesion: 0.33
Nodes (6): DeleteProductAccountCommand, Id, DeleteProductAccountCommandHandler, CancellationToken, Guid, Task

### Community 203 - "Countify — Convenciones del proyecto"
Cohesion: 0.33
Nodes (5): Arquitectura / capas, Contrato API (FASE 1), Countify — Convenciones del proyecto, Flujo de trabajo (obligatorio), Modelo contable (FASE 1 — corregido)

### Community 205 - "UpdateAccountsReceivableDocumentCommandHandler"
Cohesion: 0.53
Nodes (4): UpdateAccountsReceivableDocumentCommandHandler, CancellationToken, IMapper, Task

### Community 212 - "UsersController.cs"
Cohesion: 0.10
Nodes (14): AssignRoleCommandValidator, ChangePasswordCommandValidator, CreateUserCommandValidator, DeleteUserCommandValidator, UpdateUserCommandValidator, UserProfile, Countify.Application.Features.Users.Commands.UpdateUser, Countify.Application.Features.Users.Commands.DeleteUser (+6 more)

## Knowledge Gaps
- **1073 isolated node(s):** `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName`, `ApiKey`, `Permission` (+1068 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 1768 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **11 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Response` connect `Response` to `CreateCustomerTypeCommand`, `UpdateCompanySettingsCommand`, `.Handle`, `UpdateCustomerTypeCommand`, `UpdateDepartmentCommand`, `BudgetsController`, `UpdateProductCommand`, `DeleteUserCommand`, `CustomerTypeDto`, `CreateDocumentTypeCommand`, `DeleteCustomerCommand`, `UpdateAccountsReceivableConceptCommand`, `IRequest`, `UpdateProjectCommand`, `CurrencyFeatures.cs`, `.HandleResult`, `DeleteCustomerTypeCommand`, `CreateProjectGroupCommand`, `CreateQualityCommand`, `UpdateProjectGroupCommand`, `GetTrialBalanceQuery`, `CreateAccountsReceivableDocumentLinesCommand`, `AccountMovementsResponse`, `CloseAccountingPeriodCommand`, `GetAccountByIdQuery`, `HistoryDto`, `DeleteQualityCommand`, `GetUserInfoQueryHandler`, `AuthResponse`, `GetCustomersQueryHandler`, `DeleteProductCommand`, `CreateAccountingPeriodCommand`, `GetAccountsReceivableConceptsQueryHandler`, `CompanySettingsDto`, `GetPendingAccountsReceivableDocumentsQuery`, `CreateAccountCommand`, `UpdateJournalEntryCommand`, `UpdateProductAccountCommand`, `CreateJournalEntryCommand`, `CreateAccountsReceivableDocumentCommandHandler`, `DeleteAccountsReceivableDocumentLineCommand`, `.SaveChangesAsync`, `DeleteDepartmentCommand`, `UpdateAccountsReceivableDocumentLineCommand`, `GetAccountsReceivableDocumentByIdQuery`, `DeleteDocumentTypeCommand`, `.Handle`, `CreateRoleCommand`, `VoidAccountsReceivableDocumentCommand`, `CreateCustomerCommand`, `GetRoleByIdQueryHandler`, `PaginatedResponse`, `DeleteAccountingPeriodCommand`, `DocumentTypeDto`, `GetQualitiesQueryHandler`, `UpdateQualityCommand`, `UpdateUserCommand`, `GetAccountsReceivableDocumentsQueryHandler`, `AccountingPeriodDto`, `CreateAccountsReceivableConceptCommand`, `DeleteProductAccountCommand`, `GetUserByIdQueryHandler`, `UpdateAccountsReceivableDocumentCommandHandler`, `IRequestHandler`, `UpdateAccountsReceivableDocumentCommand`, `UpdateCustomerCommand`, `UpdateRolePermissionsCommand`, `CreateAccountsReceivableDocumentCommand`, `GetJournalEntryByIdQuery`, `UpdateRoleCommand`, `DeleteRoleCommandHandler`, `ChangePasswordCommand`, `AssignRoleCommand`, `ApplicationUser`, `UpdateDocumentTypeCommand`?**
  _High betweenness centrality (0.294) - this node is a cross-community bridge._
- **Why does `IUnitOfWork` connect `IUnitOfWork` to `UpdateDepartmentCommand`, `UpdateProductCommand`, `Response`, `CustomerTypeDto`, `UpdateAccountsReceivableConceptCommand`, `IRequest`, `History`, `UpdateProjectCommand`, `IRepository`, `CurrencyFeatures.cs`, `Permission`, `BankTransaction`, `GetTrialBalanceQuery`, `UpdateProjectGroupCommand`, `UnitOfWork`, `AccountMovementsResponse`, `HistoryDto`, `AuthResponse`, `JournalEntryLine`, `UserDto`, `ProductAccount`, `CompanySettingsDto`, `CreateAccountCommand`, `CreateJournalEntryCommand`, `BankAccount`, `ApplicationUser`, `BudgetsController`, `GetRoleByIdQueryHandler`, `ProjectGroup`, `CreateCustomerCommand`, `PaginatedResponse`, `Budget`, `DocumentTypeDto`, `GetQualitiesQueryHandler`, `UpdateQualityCommand`, `AccountingPeriodDto`, `CreateAccountsReceivableConceptCommand`, `BankReconciliation`, `AccountsReceivableDocument`, `GetProjectsQuery`, `IRequestHandler`, `AccountingPeriod`, `UpdateCustomerCommand`, `UpdateRolePermissionsCommand`, `GetJournalEntriesQuery`, `RoleDto`, `DocumentType`, `YearEndClosingEntry`, `GetAccountsQuery`, `AccountsReceivableConcept`, `GetJournalEntryByIdQuery`, `IEntityTypeConfiguration`, `BankTransactionType`, `UpdateDocumentTypeCommand`, `CreateCustomerTypeCommand`, `.Handle`, `UpdateCustomerTypeCommand`, `CreateDocumentTypeCommand`, `DeleteCustomerCommand`, `DeleteCustomerTypeCommand`, `.ValidateAsync`, `CreateProjectGroupCommand`, `CreateQualityCommand`, `Countify.Domain.Entities.Auth`, `CreateAccountsReceivableDocumentLinesCommand`, `CloseAccountingPeriodCommand`, `GetAccountByIdQuery`, `.CreateAsync`, `DeleteQualityCommand`, `GetUserInfoQueryHandler`, `GetCustomersQueryHandler`, `RolePermission`, `DeleteProductCommand`, `CreateAccountingPeriodCommand`, `GetAccountsReceivableConceptsQueryHandler`, `UpdateProductAccountCommand`, `GetPendingAccountsReceivableDocumentsQuery`, `CreateAccountsReceivableDocumentCommandHandler`, `DeleteAccountsReceivableDocumentLineCommand`, `.SaveChangesAsync`, `DeleteDepartmentCommand`, `UpdateAccountsReceivableDocumentLineCommand`, `GetAccountsReceivableDocumentByIdQuery`, `DeleteDocumentTypeCommand`, `.Handle`, `VoidAccountsReceivableDocumentCommand`, `Product`, `CustomerType`, `DeleteAccountingPeriodCommand`, `.ValidateAsync`, `GetAccountsReceivableDocumentsQueryHandler`, `DeleteProductAccountCommand`, `Countify — Convenciones del proyecto`, `UpdateAccountsReceivableDocumentCommandHandler`?**
  _High betweenness centrality (0.219) - this node is a cross-community bridge._
- **Why does `Countify.Domain.Entities.Accounting` connect `Countify.Domain.Entities.Accounting` to `Countify.Application.Wrappers`, `AccountsController.cs`, `Countify.Api.Controllers`, `AccountingPeriodProfile.cs`, `ProductAccountProfile.cs`, `DepartmentsController.cs`, `microsoft_entityframeworkcore`, `CompanySettingsDto`, `IRequest`, `Profile`, `CurrencyFeatures.cs`, `Countify.Domain.Enums`, `Countify.Domain.Entities.Auth`, `ProductProfile.cs`, `ProjectGroupsController.cs`?**
  _High betweenness centrality (0.065) - this node is a cross-community bridge._
- **What connects `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName` to the rest of the system?**
  _1073 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Countify.Application.Wrappers` be split into smaller, more focused modules?**
  _Cohesion score 0.08364197530864198 - nodes in this community are weakly interconnected._
- **Should `UpdateCompanySettingsCommand` be split into smaller, more focused modules?**
  _Cohesion score 0.10526315789473684 - nodes in this community are weakly interconnected._
- **Should `CountifyDbContext` be split into smaller, more focused modules?**
  _Cohesion score 0.04994192799070848 - nodes in this community are weakly interconnected._