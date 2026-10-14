# Graph Report - Countify  (2026-09-23)

## Corpus Check
- 385 files · ~68,439 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 2 file(s) not represented in the graph (top: (none) 1, .user 1)

## Summary
- 3511 nodes · 7100 edges · 217 communities (201 shown, 16 thin omitted)
- Extraction: 96% EXTRACTED · 4% INFERRED · 0% AMBIGUOUS · INFERRED: 305 edges (avg confidence: 0.85)
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
- IRequestHandler
- Countify.Domain.Enums
- ProductAccountDto
- GetRoleByIdQueryHandler
- ProjectGroup
- .Delete
- CreateCustomerCommand
- .SaveChangesAsync
- Budget
- GetUserInfoQueryHandler
- UpdateDocumentTypeCommand
- CustomerMovementDto
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
- CreateUserCommand
- UpdateAccountCommand
- RolesController
- .Delete
- CustomerDto
- AccountingPeriod
- UpdateAccountsReceivableDocumentCommand
- UpdateCustomerCommand
- UpdateRolePermissionsCommand
- BaseEntity
- PaginatedResponse
- GetQualitiesQueryHandler
- RoleDto
- RolesController.cs
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
- .Delete
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
- CustomerMovementApplicationDto
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
- .SaveChangesAsync
- microsoft_aspnetcore_authorization
- GetProductsQueryHandler
- GetAccountByIdQuery
- .CreateAsync
- DeleteQualityCommand
- IJwtService
- UpdateProductAccountCommand
- TransactionSeeder
- CustomerMovementsDto
- GetCustomerMovementsQuery
- DeleteProductCommand
- Flujo bancario
- BudgetRequest
- DeleteJournalEntryCommand
- UpdateProductCommand
- AccountsReceivableConceptsController.cs
- UpdateProjectGroupCommand
- AccountsReceivableDocumentLine
- GetPendingAccountsReceivableDocumentsQuery
- CurrencyPolicies
- .BuildTargetModel
- EntryConceptType
- Profile
- CreateRoleCommand
- DocumentTypeProfile.cs
- DeleteAccountCommand
- DeleteAccountsReceivableConceptCommand
- DeleteDepartmentCommand
- UpdateAccountsReceivableDocumentLineCommand
- GetAccountsReceivableDocumentByIdQuery
- VoidJournalEntryCommand
- .Handle
- ProductProfile.cs
- VoidAccountsReceivableDocumentCommand
- Product
- DeleteProjectGroupCommand
- CustomerType
- DeleteAccountingPeriodCommand
- ProjectGroupsController.cs
- Guid
- .ValidateAsync
- Countify.Application.Features.AccountsReceivableDocuments.DTOs
- IConfigureOptions
- ResetPasswordRequest
- .BuildTargetModel
- BankPolicies
- GetAccountsReceivableDocumentsQueryHandler
- OrderColumns
- AccountingPeriodPolicies
- Repository.cs
- Permisos (patrón de futuras fases también)
- LoginRequest
- UpdateAccountsReceivableDocumentCommandHandler
- RefreshTokenRequest
- CustomerTypePolicies
- HistoryPolicies
- CompanySettingsPolicies
- DocumentTypePolicies
- JournalEntryPolicies
- ProductAccountPolicies
- ProjectGroupPolicies
- UserPolicies
- DepartmentPolicies
- ProjectPolicies

## God Nodes (most connected - your core abstractions)
1. `Response` - 285 edges
2. `IUnitOfWork` - 153 edges
3. `Countify.Domain.Entities.Accounting` - 97 edges
4. `Countify.Application.Wrappers` - 94 edges
5. `Countify.Domain.Interfaces` - 94 edges
6. `CountifyDbContext` - 78 edges
7. `UnitOfWork` - 66 edges
8. `BankTransaction` - 49 edges
9. `Countify.Api.Authorization.Policies` - 43 edges
10. `AccountsReceivableDocumentDto` - 41 edges

## Surprising Connections (you probably didn't know these)
- `Modelo contable (FASE 1 — corregido)` --references--> `CompanySettings`  [INFERRED]
  AGENTS.md → Countify.Domain/Entities/Accounting/CompanySettings.cs
- `Permisos (patrón de futuras fases también)` --references--> `AccountingPeriodPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/AccountingPeriodPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `CompanySettingsPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/CompanySettingsPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `DepartmentPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/DepartmentPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `DocumentTypePolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/DocumentTypePolicies.cs

## Import Cycles
- None detected.

## Communities (217 total, 16 thin omitted)

### Community 0 - "Countify.Application.Wrappers"
Cohesion: 0.08
Nodes (9): automapper, automapper_queryableextensions, Countify.Application.Features.Accounts.DTOs, Countify.Application.Features.ProductAccounts.DTOs, Countify.Application.Features.ProductAccounts, Countify.Application.Extensions, Countify.Application.Wrappers, Countify.Domain.Interfaces (+1 more)

### Community 1 - "CatalogSeeder"
Cohesion: 0.35
Nodes (5): CatalogSeeder, CancellationToken, ILogger, IOptions, Task

### Community 2 - "UpdateCompanySettingsCommand"
Cohesion: 0.09
Nodes (22): UpdateCompanySettingsCommand, Address, CompanyName, DefaultDepartmentId, DefaultProjectId, Email, FiscalYear, Mobile (+14 more)

### Community 3 - "CountifyDbContext"
Cohesion: 0.05
Nodes (38): CountifyDbContext, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts, BankReconciliations (+30 more)

### Community 4 - "UpdateDepartmentCommand"
Cohesion: 0.06
Nodes (38): DepartmentsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+30 more)

### Community 5 - "AccountsReceivableDocumentsController.cs"
Cohesion: 0.13
Nodes (12): CreateAccountsReceivableDocumentCommandValidator, CreateAccountsReceivableDocumentLinesCommandValidator, Countify.Application.Features.AccountsReceivableDocuments.Queries.GetAccountsReceivableDocumentById, Countify.Application.Features.AccountsReceivableDocuments.Validators, Countify.Application.Features.AccountsReceivableDocuments.Queries.GetCustomerMovements, Countify.Application.Features.AccountsReceivableDocuments.Commands.VoidAccountsReceivableDocument, Countify.Application.Features.AccountsReceivableDocuments.Commands.CreateAccountsReceivableDocumentLines, Countify.Application.Features.AccountsReceivableDocuments.Commands.UpdateAccountsReceivableDocumentLine (+4 more)

### Community 6 - "microsoft_entityframeworkcore"
Cohesion: 0.17
Nodes (3): Countify.Infrastructure.Persistence.Configurations, microsoft_entityframeworkcore, microsoft_entityframeworkcore_metadata_builders

### Community 7 - ".Delete"
Cohesion: 0.28
Nodes (9): ProductsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 8 - "Response"
Cohesion: 0.05
Nodes (40): CloseAccountingPeriodCommand, Id, CloseAccountingPeriodCommandHandler, CancellationToken, Guid, Task, DeleteAccountsReceivableDocumentLineCommand, Id (+32 more)

### Community 9 - "CustomerTypeDto"
Cohesion: 0.18
Nodes (14): CustomerTypeDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Code, Id, Name, Guid (+6 more)

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
Cohesion: 0.06
Nodes (36): ProjectsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+28 more)

### Community 16 - "IRepository"
Cohesion: 0.11
Nodes (20): IRepository, CancellationToken, Expression, Func, Guid, IEnumerable, IQueryable, List (+12 more)

### Community 17 - "CurrencyFeatures.cs"
Cohesion: 0.12
Nodes (26): CurrenciesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+18 more)

### Community 18 - ".HandleResult"
Cohesion: 0.26
Nodes (11): BanksController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+3 more)

### Community 19 - "RolePermission"
Cohesion: 0.10
Nodes (17): Permissions, Items, Permission, Description, Id, Name, RolePermission, Permission (+9 more)

### Community 20 - "BankTransaction"
Cohesion: 0.06
Nodes (32): BankTransaction, Amount, AppliesToReceivableId, BankAccount, BankAccountId, BankReconciliation, BankReconciliationId, Beneficiary (+24 more)

### Community 21 - "GetTrialBalanceQuery"
Cohesion: 0.10
Nodes (23): TrialBalanceDto, CreditTotal, DebitTotal, Difference, Lines, TrialBalanceLineDto, AccountCode, AccountId (+15 more)

### Community 22 - "GetProjectGroupsQueryHandler"
Cohesion: 0.18
Nodes (12): ProjectGroupDto, Code, Id, Name, Guid, GetProjectGroupsQuery, GetProjectGroupsQueryHandler, CancellationToken (+4 more)

### Community 23 - "UnitOfWork"
Cohesion: 0.05
Nodes (38): UnitOfWork, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts, BankReconciliations (+30 more)

### Community 24 - "ValidationException"
Cohesion: 0.08
Nodes (24): ExceptionHandlerMiddleware, Exception, ILogger, Task, ValidationBehavior, CancellationToken, IEnumerable, Task (+16 more)

### Community 25 - "AccountMovementsResponse"
Cohesion: 0.08
Nodes (26): AccountMovementDto, Balance, Concept, Credit, Debit, EntryNumber, JournalEntryId, ReferenceDate (+18 more)

### Community 26 - "BudgetLine"
Cohesion: 0.07
Nodes (28): Department, BudgetLine, Account, AccountId, April, August, Budget, BudgetId (+20 more)

### Community 27 - "IUnitOfWork"
Cohesion: 0.05
Nodes (38): IUnitOfWork, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts, BankReconciliations (+30 more)

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
Cohesion: 0.11
Nodes (17): LoginCommandHandler, CancellationToken, IdentityRole, RoleManager, Task, UserManager, AuthResponse, AccessToken (+9 more)

### Community 32 - "JournalEntryLine"
Cohesion: 0.08
Nodes (26): JournalEntryLine, Account, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName (+18 more)

### Community 33 - "AccountsReceivableDocumentDraftRequest"
Cohesion: 0.13
Nodes (15): AccountsReceivableDocumentDraftRequest, Amount, AppliesTo, ConceptId, CurrencyId, CustomerId, Date, DepartmentId (+7 more)

### Community 34 - "Countify.Api.Controllers"
Cohesion: 0.09
Nodes (17): Countify.Application.Features.Configurations.Queries.GetCompanySettings, Countify.Application.Features.AccountingPeriods.Queries.GetAccountingPeriods, Countify.Application.Features.Projects.Queries.GetProjects, Countify.Application.Features.JournalEntries.Queries.GetJournalEntries, Countify.Api.Controllers, Countify.Application.Features.Reports.Queries.GetTrialBalance, Countify.Application.Features.Products.Queries.GetProducts, Countify.Application.Features.Auth.Queries.GetUserInfo (+9 more)

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
Cohesion: 0.11
Nodes (18): ApplicationUser, CreatedAt, CreatedBy, FirstName, FullName, IsActive, LastActivity, LastName (+10 more)

### Community 51 - "BudgetsController"
Cohesion: 0.29
Nodes (10): BudgetRequest, BudgetsController, Authorize, CancellationToken, HttpDelete, HttpGet, HttpPost, HttpPut (+2 more)

### Community 52 - "IRequestHandler"
Cohesion: 0.11
Nodes (18): UpdateAccountCommandHandler, CancellationToken, IMapper, Task, ForgotPasswordCommand, ForgotPasswordCommandHandler, CancellationToken, Task (+10 more)

### Community 53 - "Countify.Domain.Enums"
Cohesion: 0.24
Nodes (7): Countify.Application.Features.JournalEntries.Commands.CreateJournalEntry, Countify.Application.Features.JournalEntries.DTOs, Countify.Application.Features.JournalEntries.Profiles, Countify.Application.Features.AccountsReceivableDocuments, Countify.Application.Features.JournalEntries, Countify.Domain.Enums, Countify.Application.Features.JournalEntries.Commands.UpdateJournalEntry

### Community 54 - "ProductAccountDto"
Cohesion: 0.09
Nodes (24): ProductAccountDto, CostAccountCode, CostAccountId, CostAccountName, Id, IncomeAccountCode, IncomeAccountId, IncomeAccountName (+16 more)

### Community 55 - "GetRoleByIdQueryHandler"
Cohesion: 0.14
Nodes (15): PermissionDto, Description, Id, Name, RoleDetailDto, Permissions, IList, GetRoleByIdQuery (+7 more)

### Community 56 - "ProjectGroup"
Cohesion: 0.09
Nodes (21): Project, Project, Code, Group, GroupId, Name, Guid, ProjectGroup (+13 more)

### Community 57 - ".Delete"
Cohesion: 0.28
Nodes (9): AccountsReceivableConceptsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 58 - "CreateCustomerCommand"
Cohesion: 0.09
Nodes (24): CreateCustomerCommand, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId, Email (+16 more)

### Community 59 - ".SaveChangesAsync"
Cohesion: 0.12
Nodes (10): Guid, UserId, UserName, CancellationToken, List, Task, CancellationToken, Task (+2 more)

### Community 60 - "Budget"
Cohesion: 0.15
Nodes (13): BudgetLine, Budget, FiscalYear, Lines, Name, List, BasicBudgets, Items (+5 more)

### Community 61 - "GetUserInfoQueryHandler"
Cohesion: 0.14
Nodes (15): UserInfoResponse, Email, FullName, Permissions, Roles, UserId, UserName, IList (+7 more)

### Community 62 - "UpdateDocumentTypeCommand"
Cohesion: 0.06
Nodes (41): DocumentTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+33 more)

### Community 63 - "CustomerMovementDto"
Cohesion: 0.12
Nodes (16): CustomerMovementDto, Amount, AmountLocal, Applications, AppliedAmount, ConceptDescription, CurrencyCode, Date (+8 more)

### Community 64 - "CustomersController.cs"
Cohesion: 0.22
Nodes (6): CreateCustomerCommandValidator, UpdateCustomerCommandValidator, Countify.Application.Features.Customers.Commands.DeleteCustomer, Countify.Application.Features.Customers.Queries.GetCustomers, Countify.Application.Features.Customers.Commands.UpdateCustomer, Countify.Application.Features.Customers.Commands.CreateCustomer

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
Cohesion: 0.07
Nodes (32): InitialCreate, DateTime, Guid, MigrationBuilder, AddAccountingModule, Guid, MigrationBuilder, AddBudgetsAndBudgetPermissions (+24 more)

### Community 70 - "PermissionService"
Cohesion: 0.22
Nodes (7): IPermissionService, HashSet, Task, PermissionService, HashSet, Task, UserManager

### Community 71 - "AccountsController"
Cohesion: 0.32
Nodes (9): AccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 72 - "AccountingPeriodDto"
Cohesion: 0.09
Nodes (29): AccountingPeriodsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, IActionResult, Task (+21 more)

### Community 73 - "CreateAccountsReceivableConceptCommand"
Cohesion: 0.19
Nodes (12): CreateAccountsReceivableConceptCommand, AccountId, Description, GeneratePosting, IsInactive, Observations, Type, CreateAccountsReceivableConceptCommandHandler (+4 more)

### Community 74 - "AccountsReceivableDocumentDto"
Cohesion: 0.07
Nodes (29): AccountsReceivableDocumentDto, Amount, AmountLocal, AppliesTo, ConceptDescription, ConceptId, CurrencyCode, CurrencyId (+21 more)

### Community 75 - "GetUserByIdQueryHandler"
Cohesion: 0.16
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
Cohesion: 0.20
Nodes (13): ProjectDto, Code, GroupId, Id, Name, Guid, GetProjectsQuery, Search (+5 more)

### Community 80 - "CreateUserCommand"
Cohesion: 0.13
Nodes (15): CreateUserCommand, Email, FirstName, LastName, Password, Phone, RoleId, Username (+7 more)

### Community 81 - "UpdateAccountCommand"
Cohesion: 0.13
Nodes (15): UpdateAccountCommand, BudgetControlled, BudgetLine, Code, Id, IsAuxAsset, IsAuxCxc, IsAuxCxp (+7 more)

### Community 82 - "RolesController"
Cohesion: 0.33
Nodes (8): RolesController, Authorize, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult, Task

### Community 83 - ".Delete"
Cohesion: 0.28
Nodes (9): ProductAccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 84 - "CustomerDto"
Cohesion: 0.09
Nodes (25): CustomerDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Address, Code, CreditDays, CreditLimit (+17 more)

### Community 85 - "AccountingPeriod"
Cohesion: 0.18
Nodes (11): AccountingPeriod, EndDate, IsClosed, Month, StartDate, DateTime, BasicAccountingPeriods, Items (+3 more)

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

### Community 90 - "PaginatedResponse"
Cohesion: 0.12
Nodes (19): GetJournalEntriesQuery, FromDate, Search, Status, ToDate, GetJournalEntriesQueryHandler, CancellationToken, DateTime (+11 more)

### Community 91 - "GetQualitiesQueryHandler"
Cohesion: 0.13
Nodes (20): QualitiesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+12 more)

### Community 92 - "RoleDto"
Cohesion: 0.24
Nodes (10): RoleDto, Id, Name, PermissionCount, GetRolesQuery, GetRolesQueryHandler, CancellationToken, IMapper (+2 more)

### Community 93 - "RolesController.cs"
Cohesion: 0.13
Nodes (10): CreateRoleCommandValidator, DeleteRoleCommandValidator, UpdateRoleCommandValidator, UpdateRolePermissionsCommandValidator, Countify.Application.Features.Roles.Commands.UpdateRole, Countify.Application.Features.Roles.Queries.GetRoles, Countify.Application.Features.Roles.Commands.DeleteRole, Countify.Application.Features.Roles.Commands.UpdateRolePermissions (+2 more)

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
Cohesion: 0.28
Nodes (6): BudgetPolicies, AuthorizationOptions, RolePolicies, AuthorizationOptions, IServiceCollection, IAuthorizationHandler

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
Cohesion: 0.12
Nodes (19): CreateAccountsReceivableDocumentCommand, Amount, AppliesTo, ConceptId, CurrencyId, CustomerId, Date, DepartmentId (+11 more)

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
Cohesion: 0.20
Nodes (9): AccountConfiguration, EntityTypeBuilder, RoleConfiguration, EntityTypeBuilder, IdentityRole, UserRoleConfiguration, EntityTypeBuilder, IdentityUserRole (+1 more)

### Community 110 - "UpdateRoleCommand"
Cohesion: 0.25
Nodes (8): UpdateRoleCommand, Id, Name, UpdateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 111 - "AccountsReceivableDocumentsController"
Cohesion: 0.26
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
Cohesion: 0.13
Nodes (12): ICurrentUserService, CountifyDbContextFactory, DesignTimeCurrentUserService, Guid, UserId, UserName, CurrentUserService, Guid (+4 more)

### Community 116 - "fluentvalidation"
Cohesion: 0.05
Nodes (37): AbstractValidator, CloseAccountingPeriodCommandValidator, CreateAccountingPeriodCommandValidator, DeleteAccountingPeriodCommandValidator, UpdateAccountsReceivableDocumentCommandValidator, ForgotPasswordCommandValidator, LoginCommandValidator, RefreshTokenCommandValidator (+29 more)

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
Cohesion: 0.13
Nodes (18): AccountsReceivableConceptDto, AccountCode, AccountId, AccountName, Description, GeneratePosting, Id, IsInactive (+10 more)

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
Nodes (9): CustomerTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 127 - "IEmailService"
Cohesion: 0.33
Nodes (4): IEmailService, Task, EmailService, Task

### Community 128 - "AccountsController.cs"
Cohesion: 0.15
Nodes (9): CreateAccountCommandValidator, DeleteAccountCommandValidator, UpdateAccountCommandValidator, Countify.Application.Features.Accounts.Commands.CreateAccount, Countify.Application.Features.JournalEntries.Queries.GetAccountMovements, Countify.Application.Features.Accounts.Queries.GetAccounts, Countify.Application.Features.Accounts.Commands.UpdateAccount, Countify.Application.Features.Accounts.Commands.DeleteAccount (+1 more)

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
Cohesion: 0.13
Nodes (14): Seeding — GENERALIZADO (base para futuras entidades/fases), ISeeder, CancellationToken, Task, BasicCompanySettings, Items, BasicRoles, Items (+6 more)

### Community 135 - "DeleteUserCommand"
Cohesion: 0.33
Nodes (6): DeleteUserCommand, Id, DeleteUserCommandHandler, CancellationToken, Task, UserManager

### Community 136 - "Currency"
Cohesion: 0.38
Nodes (5): Currency, BasicCurrencies, Items, CurrencyConfiguration, EntityTypeBuilder

### Community 137 - ".BuildModel"
Cohesion: 0.29
Nodes (6): CountifyDbContextModelSnapshot, DateTime, DateTimeOffset, Guid, ModelBuilder, ModelSnapshot

### Community 138 - "CustomerMovementApplicationDto"
Cohesion: 0.17
Nodes (12): CustomerMovementApplicationDto, Amount, Id, RelatedConcept, RelatedDate, RelatedDocumentId, RelatedDocumentNo, RelatedIsCredit (+4 more)

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
Cohesion: 0.22
Nodes (6): CreateCustomerTypeCommandValidator, UpdateCustomerTypeCommandValidator, Countify.Application.Features.CustomerTypes.Commands.DeleteCustomerType, Countify.Application.Features.CustomerTypes.Commands.UpdateCustomerType, Countify.Application.Features.CustomerTypes.Commands.CreateCustomerType, Countify.Application.Features.CustomerTypes.Queries.GetCustomerTypes

### Community 143 - "UserRoleHasPermissionRequirement"
Cohesion: 0.20
Nodes (10): AuthorizationHandler, AuthorizationHandlerContext, PermissionAuthorizationHandler, Task, CustomerPolicies, AuthorizationOptions, UserRoleHasPermissionRequirement, Permission (+2 more)

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
Cohesion: 0.07
Nodes (23): ForgotPasswordRequest, Email, RoleProfile, UserProfile, Countify.Infrastructure.Persistence.Services, Countify.Application.Features.Auth.DTOs, Countify.Infrastructure.Services, Countify.Application.Common.Interfaces (+15 more)

### Community 152 - ".SaveChangesAsync"
Cohesion: 0.14
Nodes (14): CreateAccountsReceivableDocumentLinesCommand, DocumentId, Lines, CreateAccountsReceivableDocumentLinesCommandHandler, LineItem, Amount, AppliedDocumentId, CancellationToken (+6 more)

### Community 153 - "microsoft_aspnetcore_authorization"
Cohesion: 0.25
Nodes (7): Countify.Domain.Authorization, Countify.Api.Authorization.Handlers, Countify.Api.Authorization.Requirements, Countify.Api.Authorization.Policies, microsoft_aspnetcore_authorization, microsoft_extensions_options, system_security_claims

### Community 154 - "GetProductsQueryHandler"
Cohesion: 0.24
Nodes (11): ProductDto, Code, Id, Name, Guid, GetProductsQuery, GetProductsQueryHandler, CancellationToken (+3 more)

### Community 155 - "GetAccountByIdQuery"
Cohesion: 0.29
Nodes (7): GetAccountByIdQuery, Id, GetAccountByIdQueryHandler, CancellationToken, Guid, IMapper, Task

### Community 156 - ".CreateAsync"
Cohesion: 0.43
Nodes (4): AccountsReceivableDocumentDraftFactory, DraftCreationResult, CancellationToken, Task

### Community 157 - "DeleteQualityCommand"
Cohesion: 0.33
Nodes (6): DeleteQualityCommand, Id, DeleteQualityCommandHandler, CancellationToken, Guid, Task

### Community 158 - "IJwtService"
Cohesion: 0.24
Nodes (5): IJwtService, IList, JwtService, IConfiguration, IList

### Community 159 - "UpdateProductAccountCommand"
Cohesion: 0.13
Nodes (14): UpdateProductAccountCommand, Id, UpdateProductAccountCommandHandler, CancellationToken, Guid, IMapper, Task, ProductAccountRequest (+6 more)

### Community 160 - "TransactionSeeder"
Cohesion: 0.47
Nodes (5): TransactionSeeder, CancellationToken, ILogger, IOptions, Task

### Community 161 - "CustomerMovementsDto"
Cohesion: 0.18
Nodes (11): CustomerMovementsDto, CustomerCode, CustomerId, CustomerName, FromDate, Movements, Saldo, ToDate (+3 more)

### Community 162 - "GetCustomerMovementsQuery"
Cohesion: 0.22
Nodes (9): GetCustomerMovementsQuery, CustomerId, FromDate, ToDate, GetCustomerMovementsQueryHandler, CancellationToken, DateTime, Guid (+1 more)

### Community 163 - "DeleteProductCommand"
Cohesion: 0.33
Nodes (6): DeleteProductCommand, Id, DeleteProductCommandHandler, CancellationToken, Guid, Task

### Community 165 - "BudgetRequest"
Cohesion: 0.33
Nodes (6): BudgetLineRequest, BudgetRequest, FiscalYear, Lines, Name, List

### Community 166 - "DeleteJournalEntryCommand"
Cohesion: 0.22
Nodes (8): DeleteJournalEntryCommand, Id, DeleteJournalEntryCommandHandler, CancellationToken, Guid, Task, DeleteJournalEntryCommandValidator, Countify.Application.Features.JournalEntries.Commands.DeleteJournalEntry

### Community 167 - "UpdateProductCommand"
Cohesion: 0.22
Nodes (9): UpdateProductCommand, Code, Id, Name, UpdateProductCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 168 - "AccountsReceivableConceptsController.cs"
Cohesion: 0.22
Nodes (6): CreateAccountsReceivableConceptCommandValidator, UpdateAccountsReceivableConceptCommandValidator, Countify.Application.Features.AccountsReceivableConcepts.Commands.DeleteAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Commands.CreateAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Commands.UpdateAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Queries.GetAccountsReceivableConcepts

### Community 169 - "UpdateProjectGroupCommand"
Cohesion: 0.22
Nodes (9): UpdateProjectGroupCommand, Code, Id, Name, UpdateProjectGroupCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 170 - "AccountsReceivableDocumentLine"
Cohesion: 0.22
Nodes (9): AccountsReceivableDocumentLine, Amount, AppliedDocument, AppliedDocumentId, Document, DocumentId, Guid, AccountsReceivableDocumentLineConfiguration (+1 more)

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
Cohesion: 0.04
Nodes (34): AccountingPeriodProfile, AccountProfile, AccountsReceivableConceptProfile, AccountsReceivableDocumentProfile, BankAccountProfile, SettingsProfile, CurrencyProfile, CustomerProfile (+26 more)

### Community 176 - "CreateRoleCommand"
Cohesion: 0.29
Nodes (7): CreateRoleCommand, Name, CreateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 177 - "DocumentTypeProfile.cs"
Cohesion: 0.22
Nodes (6): CreateDocumentTypeCommandValidator, UpdateDocumentTypeCommandValidator, DocumentTypeProfile, Countify.Application.Features.DocumentTypes.Commands.CreateDocumentType, Countify.Application.Features.DocumentTypes.Profiles, Countify.Application.Features.DocumentTypes.Commands.UpdateDocumentType

### Community 178 - "DeleteAccountCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountCommand, Id, DeleteAccountCommandHandler, CancellationToken, Guid, Task

### Community 179 - "DeleteAccountsReceivableConceptCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountsReceivableConceptCommand, Id, DeleteAccountsReceivableConceptCommandHandler, CancellationToken, Guid, Task

### Community 180 - "DeleteDepartmentCommand"
Cohesion: 0.33
Nodes (6): DeleteDepartmentCommand, Id, DeleteDepartmentCommandHandler, CancellationToken, Guid, Task

### Community 181 - "UpdateAccountsReceivableDocumentLineCommand"
Cohesion: 0.29
Nodes (7): UpdateAccountsReceivableDocumentLineCommand, Amount, Id, UpdateAccountsReceivableDocumentLineCommandHandler, CancellationToken, Guid, Task

### Community 182 - "GetAccountsReceivableDocumentByIdQuery"
Cohesion: 0.29
Nodes (7): GetAccountsReceivableDocumentByIdQuery, Id, GetAccountsReceivableDocumentByIdQueryHandler, CancellationToken, Guid, IMapper, Task

### Community 183 - "VoidJournalEntryCommand"
Cohesion: 0.33
Nodes (6): VoidJournalEntryCommand, Id, VoidJournalEntryCommandHandler, CancellationToken, Guid, Task

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

### Community 188 - "DeleteProjectGroupCommand"
Cohesion: 0.33
Nodes (6): DeleteProjectGroupCommand, Id, DeleteProjectGroupCommandHandler, CancellationToken, Guid, Task

### Community 189 - "CustomerType"
Cohesion: 0.40
Nodes (5): CustomerType, BasicCustomerTypes, Items, CustomerTypeConfiguration, EntityTypeBuilder

### Community 190 - "DeleteAccountingPeriodCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountingPeriodCommand, Id, DeleteAccountingPeriodCommandHandler, CancellationToken, Guid, Task

### Community 191 - "ProjectGroupsController.cs"
Cohesion: 0.13
Nodes (11): CreateProjectCommandValidator, CreateProjectGroupCommandValidator, UpdateProjectCommandValidator, ProjectProfile, Countify.Application.Features.Projects.Commands.UpdateProject, Countify.Application.Features.Projects.Profiles, Countify.Application.Features.Projects.Commands.UpdateProjectGroup, Countify.Application.Features.Projects.Commands.DeleteProjectGroup (+3 more)

### Community 192 - "Guid"
Cohesion: 0.33
Nodes (5): BudgetLineResponse, BudgetResponse, BudgetLineResponse, BudgetResponse, Guid

### Community 193 - ".ValidateAsync"
Cohesion: 0.60
Nodes (4): ProductAccountRules, CancellationToken, Guid, Task

### Community 195 - "IConfigureOptions"
Cohesion: 0.27
Nodes (7): AccountsReceivableConceptPolicies, AuthorizationOptions, AccountsReceivableDocumentPolicies, AuthorizationOptions, ReportsPolicies, AuthorizationOptions, IConfigureOptions

### Community 196 - "ResetPasswordRequest"
Cohesion: 0.40
Nodes (4): ResetPasswordRequest, Email, NewPassword, Token

### Community 197 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 199 - "GetAccountsReceivableDocumentsQueryHandler"
Cohesion: 0.43
Nodes (6): GetAccountsReceivableDocumentsQuery, GetAccountsReceivableDocumentsQueryHandler, CancellationToken, IMapper, List, Task

### Community 200 - "OrderColumns"
Cohesion: 0.50
Nodes (3): OrderColumns, Ascending, Descending

### Community 203 - "Permisos (patrón de futuras fases también)"
Cohesion: 0.20
Nodes (9): Arquitectura / capas, Contrato API (FASE 1), Countify — Convenciones del proyecto, Flujo de trabajo (obligatorio), Modelo contable (FASE 1 — corregido), Permisos (patrón de futuras fases también), AccountPolicies, AuthorizationOptions (+1 more)

### Community 204 - "LoginRequest"
Cohesion: 0.50
Nodes (3): LoginRequest, Password, Username

### Community 205 - "UpdateAccountsReceivableDocumentCommandHandler"
Cohesion: 0.53
Nodes (4): UpdateAccountsReceivableDocumentCommandHandler, CancellationToken, IMapper, Task

### Community 206 - "RefreshTokenRequest"
Cohesion: 0.50
Nodes (3): RefreshTokenRequest, AccessToken, RefreshToken

## Knowledge Gaps
- **1109 isolated node(s):** `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName`, `ApiKey`, `Permission` (+1104 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 1808 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **16 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Response` connect `Response` to `CreateCustomerTypeCommand`, `UpdateCompanySettingsCommand`, `.Handle`, `UpdateCustomerTypeCommand`, `UpdateDepartmentCommand`, `BudgetsController`, `DeleteUserCommand`, `CustomerTypeDto`, `DeleteCustomerCommand`, `UpdateAccountsReceivableConceptCommand`, `IRequest`, `UpdateProjectCommand`, `CurrencyFeatures.cs`, `.HandleResult`, `DeleteCustomerTypeCommand`, `CreateProjectGroupCommand`, `CreateQualityCommand`, `GetProjectGroupsQueryHandler`, `GetTrialBalanceQuery`, `.SaveChangesAsync`, `AccountMovementsResponse`, `GetProductsQueryHandler`, `GetAccountByIdQuery`, `HistoryDto`, `DeleteQualityCommand`, `ChangePasswordCommand`, `AuthResponse`, `UpdateProductAccountCommand`, `GetCustomerMovementsQuery`, `DeleteProductCommand`, `DeleteJournalEntryCommand`, `UpdateProductCommand`, `CompanySettingsDto`, `UpdateJournalEntryCommand`, `GetPendingAccountsReceivableDocumentsQuery`, `CreateAccountCommand`, `UpdateProjectGroupCommand`, `CreateJournalEntryCommand`, `CreateRoleCommand`, `DeleteAccountCommand`, `DeleteAccountsReceivableConceptCommand`, `IRequestHandler`, `UpdateAccountsReceivableDocumentLineCommand`, `GetAccountsReceivableDocumentByIdQuery`, `DeleteDepartmentCommand`, `VoidJournalEntryCommand`, `.Handle`, `VoidAccountsReceivableDocumentCommand`, `CreateCustomerCommand`, `DeleteProjectGroupCommand`, `GetUserInfoQueryHandler`, `DeleteAccountingPeriodCommand`, `UpdateDocumentTypeCommand`, `GetRoleByIdQueryHandler`, `UpdateQualityCommand`, `UpdateUserCommand`, `GetAccountsReceivableDocumentsQueryHandler`, `AccountingPeriodDto`, `CreateAccountsReceivableConceptCommand`, `GetUserByIdQueryHandler`, `UpdateAccountsReceivableDocumentCommandHandler`, `CreateUserCommand`, `UpdateAccountCommand`, `CustomerDto`, `UpdateAccountsReceivableDocumentCommand`, `UpdateCustomerCommand`, `UpdateRolePermissionsCommand`, `PaginatedResponse`, `GetQualitiesQueryHandler`, `CreateAccountsReceivableDocumentCommand`, `GetJournalEntryByIdQuery`, `UpdateRoleCommand`, `DeleteRoleCommandHandler`, `AccountsReceivableConceptDto`, `AssignRoleCommand`?**
  _High betweenness centrality (0.311) - this node is a cross-community bridge._
- **Why does `IUnitOfWork` connect `IUnitOfWork` to `UpdateCompanySettingsCommand`, `UpdateDepartmentCommand`, `Response`, `CustomerTypeDto`, `UpdateAccountsReceivableConceptCommand`, `IRequest`, `History`, `UpdateProjectCommand`, `IRepository`, `CurrencyFeatures.cs`, `RolePermission`, `BankTransaction`, `GetTrialBalanceQuery`, `GetProjectGroupsQueryHandler`, `UnitOfWork`, `AccountMovementsResponse`, `HistoryDto`, `AuthResponse`, `JournalEntryLine`, `UserDto`, `ProductAccount`, `CompanySettingsDto`, `CreateAccountCommand`, `Countify.Domain.Entities.Accounting`, `CreateJournalEntryCommand`, `BankAccount`, `ApplicationUser`, `BudgetsController`, `IRequestHandler`, `ProductAccountDto`, `GetRoleByIdQueryHandler`, `ProjectGroup`, `CreateCustomerCommand`, `Budget`, `GetUserInfoQueryHandler`, `UpdateDocumentTypeCommand`, `UpdateQualityCommand`, `AccountingPeriodDto`, `CreateAccountsReceivableConceptCommand`, `BankReconciliation`, `AccountsReceivableDocument`, `GetProjectsQuery`, `CustomerDto`, `AccountingPeriod`, `UpdateCustomerCommand`, `UpdateRolePermissionsCommand`, `PaginatedResponse`, `GetQualitiesQueryHandler`, `RoleDto`, `DocumentType`, `YearEndClosingEntry`, `GetAccountsQuery`, `AccountsReceivableConcept`, `CreateAccountsReceivableDocumentCommand`, `GetJournalEntryByIdQuery`, `BankTransactionType`, `AccountsReceivableConceptDto`, `CreateCustomerTypeCommand`, `.Handle`, `UpdateCustomerTypeCommand`, `DeleteCustomerCommand`, `DeleteCustomerTypeCommand`, `.ValidateAsync`, `CreateProjectGroupCommand`, `CreateQualityCommand`, `.SaveChangesAsync`, `GetProductsQueryHandler`, `GetAccountByIdQuery`, `.CreateAsync`, `DeleteQualityCommand`, `UpdateProductAccountCommand`, `GetCustomerMovementsQuery`, `DeleteProductCommand`, `DeleteJournalEntryCommand`, `UpdateProductCommand`, `UpdateProjectGroupCommand`, `AccountsReceivableDocumentLine`, `GetPendingAccountsReceivableDocumentsQuery`, `DeleteAccountCommand`, `DeleteAccountsReceivableConceptCommand`, `DeleteDepartmentCommand`, `UpdateAccountsReceivableDocumentLineCommand`, `GetAccountsReceivableDocumentByIdQuery`, `VoidJournalEntryCommand`, `.Handle`, `VoidAccountsReceivableDocumentCommand`, `Product`, `DeleteProjectGroupCommand`, `CustomerType`, `DeleteAccountingPeriodCommand`, `.ValidateAsync`, `GetAccountsReceivableDocumentsQueryHandler`, `Permisos (patrón de futuras fases también)`, `UpdateAccountsReceivableDocumentCommandHandler`?**
  _High betweenness centrality (0.226) - this node is a cross-community bridge._
- **Why does `CountifyDbContext` connect `CountifyDbContext` to `CatalogSeeder`, `Seeding — GENERALIZADO (base para futuras entidades/fases)`, `History`, `RolePermission`, `BankTransaction`, `JournalEntryLine`, `TransactionSeeder`, `ProductAccount`, `AccountsReceivableDocumentLine`, `Countify.Domain.Entities.Accounting`, `CreateJournalEntryCommand`, `BankAccount`, `ApplicationUser`, `ProjectGroup`, `CreateCustomerCommand`, `Product`, `Budget`, `CustomerType`, `.SaveChangesAsync`, `PermissionService`, `BankReconciliation`, `AccountsReceivableDocument`, `AccountingPeriod`, `DocumentType`, `YearEndClosingEntry`, `AccountsReceivableConcept`, `ICurrentUserService`, `BankTransactionType`, `.AddInfrastructureServices`, `.OnModelCreating`?**
  _High betweenness centrality (0.050) - this node is a cross-community bridge._
- **What connects `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName` to the rest of the system?**
  _1109 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Countify.Application.Wrappers` be split into smaller, more focused modules?**
  _Cohesion score 0.08060814687320711 - nodes in this community are weakly interconnected._
- **Should `UpdateCompanySettingsCommand` be split into smaller, more focused modules?**
  _Cohesion score 0.09090909090909091 - nodes in this community are weakly interconnected._
- **Should `CountifyDbContext` be split into smaller, more focused modules?**
  _Cohesion score 0.05263157894736842 - nodes in this community are weakly interconnected._