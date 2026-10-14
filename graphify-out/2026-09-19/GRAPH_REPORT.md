# Graph Report - Countify  (2026-09-19)

## Corpus Check
- 314 files · ~49,299 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 2 file(s) not represented in the graph (top: (none) 1, .user 1)

## Summary
- 2716 nodes · 5520 edges · 157 communities (150 shown, 7 thin omitted)
- Extraction: 96% EXTRACTED · 4% INFERRED · 0% AMBIGUOUS · INFERRED: 241 edges (avg confidence: 0.86)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `830b394a`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- Countify.Application.Wrappers
- CatalogSeeder
- CreateProjectGroupCommand
- CountifyDbContext
- UpdateDepartmentCommand
- fluentvalidation
- Countify.Domain.Entities.Accounting
- CreateProductCommand
- Response
- .Handle
- JournalEntry
- .AddInfrastructureServices
- Profile
- IRequest
- BaseEntity
- UpdateProjectCommand
- IRepository
- CurrencyFeatures.cs
- .HandleResult
- Permission
- BankTransaction
- GetTrialBalanceQuery
- Countify.Domain.Entities.Auth
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
- Countify.Api.Controllers
- microsoft_aspnetcore_authorization
- BankTransactionDto
- UserDto
- ProductAccount
- ApiKeyAuthenticationHandler
- JournalEntryDto
- CompanySettings
- UpdateCompanySettingsCommand
- UpdateJournalEntryCommand
- JournalEntryLineDto
- CreateAccountCommand
- InfrastructureServiceRegistration.cs
- AccountDto
- BankAccountDto
- CreateJournalEntryCommand
- BankAccount
- ApplicationUser
- BudgetLineRequest
- Countify.Application.Features.Auth.DTOs
- Countify.Domain.Enums
- ProductAccountDto
- GetRoleByIdQueryHandler
- ProjectGroup
- ApiKeyAuthenticationOptions
- .Update
- PaginatedResponse
- Budget
- DocumentTypesController.cs
- .SaveChangesAsync
- ProjectGroupsController.cs
- BudgetsController
- http
- JournalEntryLineRequest
- CreateUserCommand
- UpdateUserCommand
- Countify.Infrastructure.Migrations
- UserRoleHasPermissionRequirement
- AccountsController
- AccountingPeriodDto
- RolesController.cs
- DocumentTypeDto
- GetUserByIdQueryHandler
- AccountingPeriod
- BankReconciliation
- QualitiesController.cs
- GetProjectsQuery
- History
- UpdateAccountCommand
- DocumentTypeProfile.cs
- BankStatementDto
- UpdateProductCommand
- DeleteAccountCommand
- CreateQualityCommand
- TransactionSeeder
- ProjectsController.cs
- DepartmentsController.cs
- GetJournalEntriesQuery
- GetQualitiesQueryHandler
- RoleDto
- BankTransactionType
- InitialCreate
- Program.cs
- UsersController.cs
- Countify.Domain.Authorization
- YearEndClosingEntry
- AddAccountingModule
- AddBanksAndBankReconciliation
- AccountsController.cs
- GetAccountsQuery
- BankReconciliationDto
- Product
- UpdateQualityCommand
- AddBudgetsAndBudgetPermissions
- ProductsController.cs
- CreateUserCommandHandler
- DeleteRoleCommandHandler
- UpdateRoleCommand
- ChangePasswordCommand
- SourceModule
- CloseAccountingPeriodCommand
- UpdateUserCommandHandler
- CountifyDbContextFactory
- GetAccountByIdQuery
- UpdateRolePermissionsCommand
- .Validate
- GetJournalEntryByIdQuery
- CreateRoleCommand
- AssignRoleCommand
- RequestParameter
- DeleteAccountingPeriodCommand
- .OnModelCreating
- AccountPolicies.cs
- .AddApiServices
- IEmailService
- DepartmentPolicies.cs
- ReportsPolicies.cs
- .ValidateAsync
- VoidJournalEntryCommand
- Repository.cs
- RenameBankOpeningBalanceToBalance
- DeleteUserCommand
- Currency
- .BuildModel
- IEntityTypeConfiguration
- JournalEntryStatus
- .ApplyOrder
- ICurrentUserService
- RolePermission
- CurrencyPolicies.cs
- .SaveChangesAsync
- IConfigureOptions
- CreateAccountingPeriodCommand
- AccountingPeriodsController.cs
- DeleteDocumentTypeCommand
- BasicAccountingPeriods
- .SeedDatabase
- DeleteProductAccountCommand
- JournalEntry
- Flujo bancario
- FixBankCurrencyForeignKeys
- EntryConceptType
- AccountingPeriodPolicies.cs
- Seeding — GENERALIZADO (base para futuras entidades/fases)

## God Nodes (most connected - your core abstractions)
1. `Response` - 216 edges
2. `IUnitOfWork` - 115 edges
3. `Countify.Domain.Entities.Accounting` - 92 edges
4. `Countify.Application.Wrappers` - 71 edges
5. `Countify.Domain.Interfaces` - 69 edges
6. `CountifyDbContext` - 68 edges
7. `UnitOfWork` - 56 edges
8. `BankTransaction` - 46 edges
9. `JournalEntryLine` - 40 edges
10. `ApplicationUser` - 38 edges

## Surprising Connections (you probably didn't know these)
- `Modelo contable (FASE 1 — corregido)` --references--> `CompanySettings`  [INFERRED]
  AGENTS.md → Countify.Domain/Entities/Accounting/CompanySettings.cs
- `Permisos (patrón de futuras fases también)` --references--> `AccountPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/AccountPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `AccountingPeriodPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/AccountingPeriodPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `DepartmentPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/DepartmentPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `ProjectGroupPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/ProjectGroupPolicies.cs

## Import Cycles
- None detected.

## Communities (157 total, 7 thin omitted)

### Community 0 - "Countify.Application.Wrappers"
Cohesion: 0.11
Nodes (10): automapper, automapper_queryableextensions, Countify.Application.Features.ProductAccounts.DTOs, Countify.Application.Features.Users.DTOs, Countify.Application.Features.Roles.DTOs, Countify.Application.Features.ProductAccounts, Countify.Application.Extensions, Countify.Application.Wrappers (+2 more)

### Community 1 - "CatalogSeeder"
Cohesion: 0.38
Nodes (5): CatalogSeeder, CancellationToken, ILogger, IOptions, Task

### Community 2 - "CreateProjectGroupCommand"
Cohesion: 0.07
Nodes (37): ProjectGroupsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+29 more)

### Community 3 - "CountifyDbContext"
Cohesion: 0.06
Nodes (30): CountifyDbContext, AccountingPeriods, Accounts, BankAccounts, BankReconciliations, BankTransactions, BankTransactionTypes, BudgetLines (+22 more)

### Community 4 - "UpdateDepartmentCommand"
Cohesion: 0.06
Nodes (38): DepartmentsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+30 more)

### Community 5 - "fluentvalidation"
Cohesion: 0.08
Nodes (21): AbstractValidator, CreateAccountCommandValidator, UpdateAccountCommandValidator, ForgotPasswordCommandValidator, LoginCommandValidator, RefreshTokenCommandValidator, ResetPasswordCommandValidator, UpdateCompanySettingsCommandValidator (+13 more)

### Community 6 - "Countify.Domain.Entities.Accounting"
Cohesion: 0.13
Nodes (5): Countify.Domain.Seeders, Countify.Infrastructure.Persistence.Configurations, Countify.Domain.Entities.Accounting, microsoft_entityframeworkcore, microsoft_entityframeworkcore_metadata_builders

### Community 7 - "CreateProductCommand"
Cohesion: 0.09
Nodes (28): ProductsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+20 more)

### Community 8 - "Response"
Cohesion: 0.04
Nodes (54): UpdateAccountCommandHandler, CancellationToken, IMapper, Task, ForgotPasswordCommand, ForgotPasswordCommandHandler, CancellationToken, Task (+46 more)

### Community 9 - ".Handle"
Cohesion: 0.07
Nodes (33): ProductAccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+25 more)

### Community 10 - "JournalEntry"
Cohesion: 0.05
Nodes (39): CreateDocumentTypeCommand, Code, IsDefault, Name, CreateDocumentTypeCommandHandler, CancellationToken, Guid, IMapper (+31 more)

### Community 11 - ".AddInfrastructureServices"
Cohesion: 0.13
Nodes (13): ISeeder, CancellationToken, Task, SeederOptions, Enabled, SeedConfiguration, SeedTransactions, IConfiguration (+5 more)

### Community 12 - "Profile"
Cohesion: 0.07
Nodes (22): AccountingPeriodProfile, BankAccountProfile, SettingsProfile, CurrencyProfile, HistoryProfile, JournalEntryProfile, ProductAccountProfile, RoleProfile (+14 more)

### Community 13 - "IRequest"
Cohesion: 0.18
Nodes (32): BankHandler, BankTransactionTypeDto, Code, Id, MovementType, TransactionType, CloseBankReconciliationCommand, CreateBankAccountCommand (+24 more)

### Community 14 - "BaseEntity"
Cohesion: 0.06
Nodes (25): BaseEntity, Id, Guid, OrderColumns, Ascending, Descending, Currency, Code (+17 more)

### Community 15 - "UpdateProjectCommand"
Cohesion: 0.08
Nodes (28): ProjectsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+20 more)

### Community 16 - "IRepository"
Cohesion: 0.12
Nodes (18): IRepository, CancellationToken, Expression, Func, Guid, IQueryable, List, Task (+10 more)

### Community 17 - "CurrencyFeatures.cs"
Cohesion: 0.12
Nodes (26): CurrenciesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+18 more)

### Community 18 - ".HandleResult"
Cohesion: 0.05
Nodes (60): Arquitectura / capas, Contrato API (FASE 1), Countify — Convenciones del proyecto, Flujo de trabajo (obligatorio), Modelo contable (FASE 1 — corregido), ControllerBase, AccountingPeriodsController, Authorize (+52 more)

### Community 19 - "Permission"
Cohesion: 0.19
Nodes (8): BankPolicies, AuthorizationOptions, Permission, Description, Id, Name, PermissionConfiguration, EntityTypeBuilder

### Community 20 - "BankTransaction"
Cohesion: 0.07
Nodes (30): BankTransaction, Amount, BankAccount, BankAccountId, BankReconciliation, BankReconciliationId, Beneficiary, Concept (+22 more)

### Community 21 - "GetTrialBalanceQuery"
Cohesion: 0.08
Nodes (27): Authorize, HttpGet, IActionResult, Task, TrialBalanceDto, CreditTotal, DebitTotal, Difference (+19 more)

### Community 22 - "Countify.Domain.Entities.Auth"
Cohesion: 0.10
Nodes (12): Countify.Application.Features.Users.Commands.UpdateUser, Countify.Infrastructure.Persistence.Services, Countify.Application.Features.Users.Commands.CreateUser, Countify.Infrastructure.Services, Countify.Application.Common.Interfaces, Countify.Application.Features.Users.Profiles, Countify.Domain.Entities.Audit, Countify.Domain.Entities.Auth (+4 more)

### Community 23 - "UnitOfWork"
Cohesion: 0.07
Nodes (29): UnitOfWork, AccountingPeriods, Accounts, BankAccounts, BankReconciliations, BankTransactions, BankTransactionTypes, BudgetLines (+21 more)

### Community 24 - "ValidationException"
Cohesion: 0.08
Nodes (24): ExceptionHandlerMiddleware, Exception, ILogger, Task, ValidationBehavior, CancellationToken, IEnumerable, Task (+16 more)

### Community 25 - "AccountMovementsResponse"
Cohesion: 0.06
Nodes (43): JournalEntriesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+35 more)

### Community 26 - "BudgetLine"
Cohesion: 0.09
Nodes (23): BudgetLine, Account, AccountId, April, August, Budget, BudgetId, December (+15 more)

### Community 27 - "IUnitOfWork"
Cohesion: 0.07
Nodes (29): IUnitOfWork, AccountingPeriods, Accounts, BankAccounts, BankReconciliations, BankTransactions, BankTransactionTypes, BudgetLines (+21 more)

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
Cohesion: 0.08
Nodes (24): JournalEntryLine, Account, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName (+16 more)

### Community 33 - "Countify.Api.Controllers"
Cohesion: 0.16
Nodes (11): ReportsController, SettingsController, Countify.Application.Features.Configurations.Queries.GetCompanySettings, Countify.Api.Controllers, Countify.Application.Features.Reports.Queries.GetTrialBalance, Countify.Application.Features.Banks, microsoft_aspnetcore_mvc, questpdf_fluent (+3 more)

### Community 34 - "microsoft_aspnetcore_authorization"
Cohesion: 0.13
Nodes (14): HistoryPolicies, AuthorizationOptions, ProductAccountPolicies, AuthorizationOptions, ProjectGroupPolicies, AuthorizationOptions, UserPolicies, AuthorizationOptions (+6 more)

### Community 35 - "BankTransactionDto"
Cohesion: 0.09
Nodes (23): BankTransactionDto, Amount, BankAccountId, BankAccountName, BankReconciliationId, Beneficiary, Concept, CounterpartAccountId (+15 more)

### Community 36 - "UserDto"
Cohesion: 0.11
Nodes (22): UserDto, CreatedAt, Email, FirstName, FullName, Id, IsActive, LastName (+14 more)

### Community 37 - "ProductAccount"
Cohesion: 0.10
Nodes (20): ProductAccount, CostAccount, CostAccountId, IncomeAccount, IncomeAccountId, InventoryAccount, InventoryAccountId, Product (+12 more)

### Community 38 - "ApiKeyAuthenticationHandler"
Cohesion: 0.10
Nodes (17): AuthenticateResult, AuthenticationHandler, AuthenticationProperties, AuthenticationSchemeOptions, AuthorizeAttribute, ApiKeyAuthenticationDefaults, ApiKeyAuthenticationHandler, IOptions (+9 more)

### Community 39 - "JournalEntryDto"
Cohesion: 0.09
Nodes (22): JournalEntryDto, Code, Concept, CreditTotal, DebitTotal, DifferenceAmount, EntryNumber, Gid (+14 more)

### Community 40 - "CompanySettings"
Cohesion: 0.11
Nodes (19): CompanySettings, DefaultDepartment, DefaultDepartmentId, DefaultProject, DefaultProjectId, FiscalYear, RequireConceptTypes, RequireDepartments (+11 more)

### Community 41 - "UpdateCompanySettingsCommand"
Cohesion: 0.05
Nodes (40): Authorize, HttpGet, HttpPut, IActionResult, Task, UpdateCompanySettingsCommand, DefaultDepartmentId, DefaultProjectId (+32 more)

### Community 42 - "UpdateJournalEntryCommand"
Cohesion: 0.12
Nodes (18): UpdateJournalEntryCommand, Code, Concept, Id, Lines, Observations, PeriodId, Reference (+10 more)

### Community 43 - "JournalEntryLineDto"
Cohesion: 0.10
Nodes (19): JournalEntryLineDto, AccountCode, AccountId, AccountName, AppliesToPayableId, AppliesToReceivableId, Concept, Credit (+11 more)

### Community 44 - "CreateAccountCommand"
Cohesion: 0.12
Nodes (18): CreateAccountCommand, BudgetControlled, BudgetLine, Code, IsAuxAsset, IsAuxCxc, IsAuxCxp, IsAuxLoan (+10 more)

### Community 45 - "InfrastructureServiceRegistration.cs"
Cohesion: 0.15
Nodes (13): Countify.Infrastructure.Seeders, Countify.Infrastructure.Persistence, microsoft_aspnetcore_authentication_jwtbearer, microsoft_entityframeworkcore_design, microsoft_extensions_configuration, microsoft_extensions_dependencyinjection, microsoft_extensions_hosting, microsoft_extensions_logging (+5 more)

### Community 46 - "AccountDto"
Cohesion: 0.11
Nodes (18): AccountDto, Balance, BudgetControlled, BudgetLine, Code, Id, IsAuxAsset, IsAuxCxc (+10 more)

### Community 47 - "BankAccountDto"
Cohesion: 0.11
Nodes (19): BankAccountDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, AccountNumber, Balance, CheckNumber, Code (+11 more)

### Community 48 - "CreateJournalEntryCommand"
Cohesion: 0.14
Nodes (17): CreateJournalEntryCommand, Code, Concept, Lines, Observations, PeriodId, Reference, ReferenceDate (+9 more)

### Community 49 - "BankAccount"
Cohesion: 0.11
Nodes (18): BankAccount, AccountingAccount, AccountingAccountId, AccountNumber, Balance, CheckNumber, Code, CurrencyId (+10 more)

### Community 50 - "ApplicationUser"
Cohesion: 0.12
Nodes (16): ApplicationUser, CreatedAt, CreatedBy, FirstName, FullName, IsActive, LastActivity, LastName (+8 more)

### Community 51 - "BudgetLineRequest"
Cohesion: 0.11
Nodes (17): BudgetLineRequest, AccountId, April, August, December, DepartmentId, February, January (+9 more)

### Community 52 - "Countify.Application.Features.Auth.DTOs"
Cohesion: 0.11
Nodes (13): ForgotPasswordRequest, Email, LoginRequest, Password, Username, RefreshTokenRequest, AccessToken, RefreshToken (+5 more)

### Community 53 - "Countify.Domain.Enums"
Cohesion: 0.18
Nodes (9): Countify.Application.Features.JournalEntries.Commands.CreateJournalEntry, Countify.Application.Features.JournalEntries.DTOs, Countify.Application.Features.JournalEntries.Queries.GetAccountMovements, Countify.Application.Features.JournalEntries.Queries.GetJournalEntries, Countify.Application.Features.JournalEntries.Queries.GetJournalEntryById, Countify.Application.Features.JournalEntries.Profiles, Countify.Application.Features.JournalEntries, Countify.Domain.Enums (+1 more)

### Community 54 - "ProductAccountDto"
Cohesion: 0.11
Nodes (17): ProductAccountDto, CostAccountCode, CostAccountId, CostAccountName, Id, IncomeAccountCode, IncomeAccountId, IncomeAccountName (+9 more)

### Community 55 - "GetRoleByIdQueryHandler"
Cohesion: 0.14
Nodes (13): PermissionDto, Description, Id, Name, RoleDetailDto, Permissions, IList, GetRoleByIdQueryHandler (+5 more)

### Community 56 - "ProjectGroup"
Cohesion: 0.14
Nodes (13): Project, ProjectGroup, Code, Name, Projects, List, BasicProjectGroups, Items (+5 more)

### Community 57 - "ApiKeyAuthenticationOptions"
Cohesion: 0.24
Nodes (7): ApiKeyAuthenticationOptions, ApiKey, ClaimName, HeaderName, ApiKeyAuthenticationOptionsSetup, IConfiguration, Countify.Api.ApiKeyAuthentication.Options

### Community 58 - ".Update"
Cohesion: 0.28
Nodes (9): BudgetRequest, Authorize, CancellationToken, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 59 - "PaginatedResponse"
Cohesion: 0.15
Nodes (15): GetProductAccountsQuery, Search, GetProductAccountsQueryHandler, CancellationToken, IMapper, List, Task, PaginatedResponse (+7 more)

### Community 60 - "Budget"
Cohesion: 0.14
Nodes (13): BudgetLine, Budget, FiscalYear, Lines, Name, List, BasicBudgets, Items (+5 more)

### Community 61 - "DocumentTypesController.cs"
Cohesion: 0.23
Nodes (10): DocumentTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+2 more)

### Community 62 - ".SaveChangesAsync"
Cohesion: 0.15
Nodes (12): UpdateDocumentTypeCommand, Code, Id, IsDefault, Name, UpdateDocumentTypeCommandHandler, CancellationToken, Guid (+4 more)

### Community 63 - "ProjectGroupsController.cs"
Cohesion: 0.17
Nodes (8): CreateProjectGroupCommandValidator, ProjectProfile, Countify.Application.Features.Projects.Profiles, Countify.Application.Features.Projects.DTOs, Countify.Application.Features.Projects.Commands.UpdateProjectGroup, Countify.Application.Features.Projects.Commands.DeleteProjectGroup, Countify.Application.Features.Projects.Queries.GetProjectGroups, Countify.Application.Features.Projects.Commands.CreateProjectGroup

### Community 64 - "BudgetsController"
Cohesion: 0.19
Nodes (12): BudgetLineRequest, BudgetLineResponse, BudgetResponse, BudgetLineResponse, BudgetRequest, FiscalYear, Lines, Name (+4 more)

### Community 65 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 66 - "JournalEntryLineRequest"
Cohesion: 0.12
Nodes (15): JournalEntryLineRequest, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName, Debit (+7 more)

### Community 67 - "CreateUserCommand"
Cohesion: 0.25
Nodes (8): CreateUserCommand, Email, FirstName, LastName, Password, Phone, RoleId, Username

### Community 68 - "UpdateUserCommand"
Cohesion: 0.25
Nodes (8): UpdateUserCommand, Email, FirstName, Id, IsActive, LastName, Phone, RoleId

### Community 69 - "Countify.Infrastructure.Migrations"
Cohesion: 0.37
Nodes (6): Countify.Infrastructure.Migrations, microsoft_entityframeworkcore_infrastructure, microsoft_entityframeworkcore_metadata, microsoft_entityframeworkcore_migrations, microsoft_entityframeworkcore_storage_valueconversion, system

### Community 70 - "UserRoleHasPermissionRequirement"
Cohesion: 0.12
Nodes (15): AuthorizationHandler, AuthorizationHandlerContext, PermissionAuthorizationHandler, Task, UserRoleHasPermissionRequirement, Permission, Permission, IPermissionService (+7 more)

### Community 71 - "AccountsController"
Cohesion: 0.32
Nodes (9): AccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 72 - "AccountingPeriodDto"
Cohesion: 0.18
Nodes (14): AccountingPeriodDto, EndDate, Id, IsClosed, Month, StartDate, DateTime, Guid (+6 more)

### Community 73 - "RolesController.cs"
Cohesion: 0.13
Nodes (10): CreateRoleCommandValidator, DeleteRoleCommandValidator, UpdateRoleCommandValidator, UpdateRolePermissionsCommandValidator, Countify.Application.Features.Roles.Commands.UpdateRole, Countify.Application.Features.Roles.Queries.GetRoles, Countify.Application.Features.Roles.Commands.DeleteRole, Countify.Application.Features.Roles.Commands.UpdateRolePermissions (+2 more)

### Community 74 - "DocumentTypeDto"
Cohesion: 0.18
Nodes (13): DocumentTypeDto, Code, Id, IsDefault, Name, Guid, GetDocumentTypesQuery, GetDocumentTypesQueryHandler (+5 more)

### Community 75 - "GetUserByIdQueryHandler"
Cohesion: 0.17
Nodes (11): UserDetailDto, CreatedBy, LastActivity, DateTime, GetUserByIdQueryHandler, CancellationToken, IdentityRole, IMapper (+3 more)

### Community 76 - "AccountingPeriod"
Cohesion: 0.22
Nodes (8): AccountingPeriod, EndDate, IsClosed, Month, StartDate, DateTime, AccountingPeriodConfiguration, EntityTypeBuilder

### Community 77 - "BankReconciliation"
Cohesion: 0.13
Nodes (14): BankReconciliation, BankAccount, BankAccountId, BookBalance, IsClosed, Notes, ReconciliationDate, StatementBalance (+6 more)

### Community 78 - "QualitiesController.cs"
Cohesion: 0.22
Nodes (7): QualityProfile, Countify.Application.Features.Qualities.DTOs, Countify.Application.Features.Qualities.Commands.UpdateQuality, Countify.Application.Features.Qualities.Commands.CreateQuality, Countify.Application.Features.Qualities.Commands.DeleteQuality, Countify.Application.Features.Qualities.Queries.GetQualities, Countify.Application.Features.Qualities.Profiles

### Community 79 - "GetProjectsQuery"
Cohesion: 0.20
Nodes (13): ProjectDto, Code, GroupId, Id, Name, Guid, GetProjectsQuery, Search (+5 more)

### Community 80 - "History"
Cohesion: 0.14
Nodes (13): History, Date, Entity, EntityId, NewValue, OldValue, Property, UserId (+5 more)

### Community 81 - "UpdateAccountCommand"
Cohesion: 0.13
Nodes (15): UpdateAccountCommand, BudgetControlled, BudgetLine, Code, Id, IsAuxAsset, IsAuxCxc, IsAuxCxp (+7 more)

### Community 82 - "DocumentTypeProfile.cs"
Cohesion: 0.22
Nodes (6): CreateDocumentTypeCommandValidator, UpdateDocumentTypeCommandValidator, DocumentTypeProfile, Countify.Application.Features.DocumentTypes.Commands.CreateDocumentType, Countify.Application.Features.DocumentTypes.Profiles, Countify.Application.Features.DocumentTypes.Commands.UpdateDocumentType

### Community 83 - "BankStatementDto"
Cohesion: 0.20
Nodes (10): BankStatementDto, BankAccountId, BankAccountName, ClosingBalance, CreditTotal, DebitTotal, FromDate, OpeningBalance (+2 more)

### Community 84 - "UpdateProductCommand"
Cohesion: 0.22
Nodes (9): UpdateProductCommand, Code, Id, Name, UpdateProductCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 85 - "DeleteAccountCommand"
Cohesion: 0.25
Nodes (7): DeleteAccountCommand, Id, DeleteAccountCommandHandler, CancellationToken, Guid, Task, DeleteAccountCommandValidator

### Community 86 - "CreateQualityCommand"
Cohesion: 0.31
Nodes (8): CreateQualityCommand, Code, Name, CreateQualityCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 87 - "TransactionSeeder"
Cohesion: 0.47
Nodes (5): TransactionSeeder, CancellationToken, ILogger, IOptions, Task

### Community 88 - "ProjectsController.cs"
Cohesion: 0.18
Nodes (7): CreateProjectCommandValidator, DeleteProjectCommandValidator, UpdateProjectCommandValidator, Countify.Application.Features.Projects.Queries.GetProjects, Countify.Application.Features.Projects.Commands.UpdateProject, Countify.Application.Features.Projects.Commands.DeleteProject, Countify.Application.Features.Projects.Commands.CreateProject

### Community 89 - "DepartmentsController.cs"
Cohesion: 0.18
Nodes (8): CreateDepartmentCommandValidator, UpdateDepartmentCommandValidator, DepartmentProfile, Countify.Application.Features.Departments.Commands.UpdateDepartment, Countify.Application.Features.Departments.Profiles, Countify.Application.Features.Departments.Commands.CreateDepartment, Countify.Application.Features.Departments.Queries.GetDepartments, Countify.Application.Features.Departments.Commands.DeleteDepartment

### Community 90 - "GetJournalEntriesQuery"
Cohesion: 0.21
Nodes (11): GetJournalEntriesQuery, FromDate, Search, Status, ToDate, GetJournalEntriesQueryHandler, CancellationToken, DateTime (+3 more)

### Community 91 - "GetQualitiesQueryHandler"
Cohesion: 0.24
Nodes (11): QualityDto, Code, Id, Name, Guid, GetQualitiesQuery, GetQualitiesQueryHandler, CancellationToken (+3 more)

### Community 92 - "RoleDto"
Cohesion: 0.24
Nodes (10): RoleDto, Id, Name, PermissionCount, GetRolesQuery, GetRolesQueryHandler, CancellationToken, IMapper (+2 more)

### Community 93 - "BankTransactionType"
Cohesion: 0.20
Nodes (9): BankTransactionType, Code, MovementType, TransactionType, BasicBanks, Accounts, TransactionTypes, BankTransactionTypeConfiguration (+1 more)

### Community 94 - "InitialCreate"
Cohesion: 0.18
Nodes (9): DateTime, DateTimeOffset, Guid, MigrationBuilder, InitialCreate, DateTime, DateTimeOffset, Guid (+1 more)

### Community 95 - "Program.cs"
Cohesion: 0.17
Nodes (9): ApplicationServiceRegistration, IServiceCollection, Countify.Api.DependencyInjection, Countify.Application.DependencyInjection, Countify.Infrastructure.Extensions, Countify.Infrastructure.DependencyInjection, quick_autoinject_dependencyannotation, scalar_aspnetcore (+1 more)

### Community 96 - "UsersController.cs"
Cohesion: 0.17
Nodes (8): AssignRoleCommandValidator, ChangePasswordCommandValidator, DeleteUserCommandValidator, Countify.Application.Features.Users.Commands.DeleteUser, Countify.Application.Features.Users.Queries.GetUsers, Countify.Application.Features.Users.Queries.GetUserById, Countify.Application.Features.Users.Commands.ChangePassword, Countify.Application.Features.Users.Commands.AssignRole

### Community 97 - "Countify.Domain.Authorization"
Cohesion: 0.25
Nodes (6): ProjectPolicies, AuthorizationOptions, Permissions, Items, Countify.Domain.Authorization, system_reflection

### Community 98 - "YearEndClosingEntry"
Cohesion: 0.20
Nodes (9): YearEndClosingEntry, GeneratedBy, JournalEntryId, PeriodId, Guid, BasicYearEndClosingEntries, Items, YearEndClosingEntryConfiguration (+1 more)

### Community 99 - "AddAccountingModule"
Cohesion: 0.20
Nodes (8): DateTime, Guid, MigrationBuilder, AddAccountingModule, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 100 - "AddBanksAndBankReconciliation"
Cohesion: 0.20
Nodes (8): DateTime, Guid, MigrationBuilder, AddBanksAndBankReconciliation, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 101 - "AccountsController.cs"
Cohesion: 0.22
Nodes (8): AccountProfile, Countify.Application.Features.Accounts.DTOs, Countify.Application.Features.Accounts.Commands.CreateAccount, Countify.Application.Features.Accounts.Profiles, Countify.Application.Features.Accounts.Queries.GetAccounts, Countify.Application.Features.Accounts.Commands.UpdateAccount, Countify.Application.Features.Accounts.Commands.DeleteAccount, Countify.Application.Features.Accounts.Queries.GetAccountById

### Community 102 - "GetAccountsQuery"
Cohesion: 0.36
Nodes (8): GetAccountsQuery, IsOperable, Search, GetAccountsQueryHandler, CancellationToken, IMapper, List, Task

### Community 103 - "BankReconciliationDto"
Cohesion: 0.20
Nodes (10): BankReconciliationDto, BankAccountId, BankAccountName, BookBalance, Id, IsClosed, Notes, ReconciliationDate (+2 more)

### Community 104 - "Product"
Cohesion: 0.29
Nodes (6): Product, Code, Name, BasicProducts, ProductConfiguration, EntityTypeBuilder

### Community 105 - "UpdateQualityCommand"
Cohesion: 0.22
Nodes (9): UpdateQualityCommand, Code, Id, Name, UpdateQualityCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 106 - "AddBudgetsAndBudgetPermissions"
Cohesion: 0.20
Nodes (8): Guid, MigrationBuilder, AddBudgetsAndBudgetPermissions, DateTime, DateTimeOffset, Guid, ModelBuilder, Migration

### Community 107 - "ProductsController.cs"
Cohesion: 0.22
Nodes (7): ProductProfile, Countify.Application.Features.Products.DTOs, Countify.Application.Features.Products.Queries.GetProducts, Countify.Application.Features.Products.Commands.CreateProduct, Countify.Application.Features.Products.Commands.DeleteProduct, Countify.Application.Features.Products.Commands.UpdateProduct, Countify.Application.Features.Products.Profiles

### Community 108 - "CreateUserCommandHandler"
Cohesion: 0.25
Nodes (7): CreateUserCommandHandler, CancellationToken, IdentityRole, IMapper, RoleManager, Task, UserManager

### Community 109 - "DeleteRoleCommandHandler"
Cohesion: 0.25
Nodes (8): DeleteRoleCommand, Id, DeleteRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task, UserManager

### Community 110 - "UpdateRoleCommand"
Cohesion: 0.25
Nodes (8): UpdateRoleCommand, Id, Name, UpdateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 111 - "ChangePasswordCommand"
Cohesion: 0.25
Nodes (8): ChangePasswordCommand, CurrentPassword, Id, NewPassword, ChangePasswordCommandHandler, CancellationToken, Task, UserManager

### Community 112 - "SourceModule"
Cohesion: 0.22
Nodes (8): SourceModule, Bank, Closing, Invoice, Manually, Payable, Payroll, Receivable

### Community 113 - "CloseAccountingPeriodCommand"
Cohesion: 0.29
Nodes (7): CloseAccountingPeriodCommand, Id, CloseAccountingPeriodCommandHandler, CancellationToken, Guid, Task, CloseAccountingPeriodCommandValidator

### Community 114 - "UpdateUserCommandHandler"
Cohesion: 0.25
Nodes (7): UpdateUserCommandHandler, CancellationToken, IdentityRole, IMapper, RoleManager, Task, UserManager

### Community 115 - "CountifyDbContextFactory"
Cohesion: 0.29
Nodes (6): CountifyDbContextFactory, DesignTimeCurrentUserService, Guid, UserId, UserName, IDesignTimeDbContextFactory

### Community 116 - "GetAccountByIdQuery"
Cohesion: 0.29
Nodes (7): GetAccountByIdQuery, Id, GetAccountByIdQueryHandler, CancellationToken, Guid, IMapper, Task

### Community 117 - "UpdateRolePermissionsCommand"
Cohesion: 0.22
Nodes (9): UpdateRolePermissionsCommand, PermissionIds, RoleId, UpdateRolePermissionsCommandHandler, CancellationToken, IdentityRole, List, RoleManager (+1 more)

### Community 118 - ".Validate"
Cohesion: 0.36
Nodes (4): JournalEntryRules, EntryConceptType, Guid, IEnumerable

### Community 119 - "GetJournalEntryByIdQuery"
Cohesion: 0.29
Nodes (7): GetJournalEntryByIdQuery, Id, GetJournalEntryByIdQueryHandler, CancellationToken, Guid, IMapper, Task

### Community 120 - "CreateRoleCommand"
Cohesion: 0.29
Nodes (7): CreateRoleCommand, Name, CreateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 121 - "AssignRoleCommand"
Cohesion: 0.29
Nodes (7): AssignRoleCommand, RoleName, UserId, AssignRoleCommandHandler, CancellationToken, Task, UserManager

### Community 122 - "RequestParameter"
Cohesion: 0.25
Nodes (7): RequestParameter, All, Column, Order, PageNumber, PageSize, Parameter

### Community 123 - "DeleteAccountingPeriodCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountingPeriodCommand, Id, DeleteAccountingPeriodCommandHandler, CancellationToken, Guid, Task

### Community 124 - ".OnModelCreating"
Cohesion: 0.25
Nodes (7): IdentityRole, IdentityUserRole, ModelBuilder, IdentityRoleClaim, IdentityUserClaim, IdentityUserLogin, IdentityUserToken

### Community 126 - ".AddApiServices"
Cohesion: 0.16
Nodes (10): Permisos (patrón de futuras fases también), CompanySettingsPolicies, AuthorizationOptions, DocumentTypePolicies, AuthorizationOptions, JournalEntryPolicies, AuthorizationOptions, ApiServiceRegistration (+2 more)

### Community 127 - "IEmailService"
Cohesion: 0.33
Nodes (4): IEmailService, Task, EmailService, Task

### Community 130 - ".ValidateAsync"
Cohesion: 0.29
Nodes (6): BudgetAvailabilityValidator, CancellationToken, DateTime, Guid, IEnumerable, Task

### Community 131 - "VoidJournalEntryCommand"
Cohesion: 0.33
Nodes (6): VoidJournalEntryCommand, Id, VoidJournalEntryCommandHandler, CancellationToken, Guid, Task

### Community 133 - "RenameBankOpeningBalanceToBalance"
Cohesion: 0.22
Nodes (6): MigrationBuilder, RenameBankOpeningBalanceToBalance, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 135 - "DeleteUserCommand"
Cohesion: 0.33
Nodes (6): DeleteUserCommand, Id, DeleteUserCommandHandler, CancellationToken, Task, UserManager

### Community 136 - "Currency"
Cohesion: 0.38
Nodes (5): Currency, BasicCurrencies, Items, CurrencyConfiguration, EntityTypeBuilder

### Community 137 - ".BuildModel"
Cohesion: 0.29
Nodes (6): CountifyDbContextModelSnapshot, DateTime, DateTimeOffset, Guid, ModelBuilder, ModelSnapshot

### Community 139 - "IEntityTypeConfiguration"
Cohesion: 0.15
Nodes (12): Department, AccountConfiguration, EntityTypeBuilder, DepartmentConfiguration, EntityTypeBuilder, RoleConfiguration, EntityTypeBuilder, IdentityRole (+4 more)

### Community 140 - "JournalEntryStatus"
Cohesion: 0.33
Nodes (5): JournalEntryStatus, Approved, Draft, Posted, Voided

### Community 141 - ".ApplyOrder"
Cohesion: 0.46
Nodes (5): QueryableExtensions, Expression, Func, IQueryable, Dictionary

### Community 142 - "ICurrentUserService"
Cohesion: 0.17
Nodes (9): ICurrentUserService, Guid, UserId, UserName, CurrentUserService, Guid, UserId, UserName (+1 more)

### Community 143 - "RolePermission"
Cohesion: 0.25
Nodes (8): RolePermission, Permission, PermissionId, Role, RoleId, IdentityRole, RolePermissionConfiguration, EntityTypeBuilder

### Community 146 - ".SaveChangesAsync"
Cohesion: 0.22
Nodes (6): CancellationToken, Task, CancellationToken, Task, CancellationToken, Task

### Community 147 - "IConfigureOptions"
Cohesion: 0.32
Nodes (5): BudgetPolicies, AuthorizationOptions, RolePolicies, AuthorizationOptions, IConfigureOptions

### Community 150 - "CreateAccountingPeriodCommand"
Cohesion: 0.36
Nodes (7): CreateAccountingPeriodCommand, Month, CreateAccountingPeriodCommandHandler, CancellationToken, DateTime, Guid, Task

### Community 155 - "AccountingPeriodsController.cs"
Cohesion: 0.20
Nodes (6): CreateAccountingPeriodCommandValidator, DeleteAccountingPeriodCommandValidator, Countify.Application.Features.AccountingPeriods.Commands.DeleteAccountingPeriod, Countify.Application.Features.AccountingPeriods.Queries.GetAccountingPeriods, Countify.Application.Features.AccountingPeriods.Commands.CloseAccountingPeriod, Countify.Application.Features.AccountingPeriods.Commands.CreateAccountingPeriod

### Community 157 - "DeleteDocumentTypeCommand"
Cohesion: 0.33
Nodes (6): DeleteDocumentTypeCommand, Id, DeleteDocumentTypeCommandHandler, CancellationToken, Guid, Task

### Community 158 - "BasicAccountingPeriods"
Cohesion: 0.60
Nodes (3): BasicAccountingPeriods, Items, DateTime

### Community 159 - ".SeedDatabase"
Cohesion: 0.47
Nodes (4): DatabaseExtensions, IEnumerable, ILogger, IHost

### Community 160 - "DeleteProductAccountCommand"
Cohesion: 0.33
Nodes (6): DeleteProductAccountCommand, Id, DeleteProductAccountCommandHandler, CancellationToken, Guid, Task

### Community 161 - "JournalEntry"
Cohesion: 0.40
Nodes (5): JournalEntry, BasicJournalEntries, Items, JournalEntryConfiguration, EntityTypeBuilder

### Community 165 - "FixBankCurrencyForeignKeys"
Cohesion: 0.60
Nodes (3): FixBankCurrencyForeignKeys, Guid, MigrationBuilder

### Community 166 - "EntryConceptType"
Cohesion: 0.40
Nodes (4): EntryConceptType, Credit, Debit, Other

### Community 173 - "Seeding — GENERALIZADO (base para futuras entidades/fases)"
Cohesion: 0.18
Nodes (11): Seeding — GENERALIZADO (base para futuras entidades/fases), BasicDepartments, Items, BasicProjects, Items, BasicRoles, Items, IdentityRole (+3 more)

## Knowledge Gaps
- **801 isolated node(s):** `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName`, `ApiKey`, `Permission` (+796 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 1355 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **7 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Response` connect `Response` to `CreateProjectGroupCommand`, `VoidJournalEntryCommand`, `UpdateDepartmentCommand`, `CreateProductCommand`, `DeleteUserCommand`, `.Handle`, `JournalEntry`, `IRequest`, `UpdateProjectCommand`, `CurrencyFeatures.cs`, `.HandleResult`, `GetTrialBalanceQuery`, `CreateAccountingPeriodCommand`, `AccountMovementsResponse`, `HistoryDto`, `DeleteDocumentTypeCommand`, `AuthResponse`, `DeleteProductAccountCommand`, `UpdateCompanySettingsCommand`, `UpdateJournalEntryCommand`, `CreateAccountCommand`, `CreateJournalEntryCommand`, `GetRoleByIdQueryHandler`, `.Update`, `PaginatedResponse`, `.SaveChangesAsync`, `CreateUserCommand`, `UpdateUserCommand`, `AccountingPeriodDto`, `DocumentTypeDto`, `GetUserByIdQueryHandler`, `UpdateAccountCommand`, `UpdateProductCommand`, `DeleteAccountCommand`, `CreateQualityCommand`, `GetQualitiesQueryHandler`, `UpdateQualityCommand`, `CreateUserCommandHandler`, `DeleteRoleCommandHandler`, `UpdateRoleCommand`, `ChangePasswordCommand`, `CloseAccountingPeriodCommand`, `UpdateUserCommandHandler`, `GetAccountByIdQuery`, `UpdateRolePermissionsCommand`, `GetJournalEntryByIdQuery`, `CreateRoleCommand`, `AssignRoleCommand`, `DeleteAccountingPeriodCommand`?**
  _High betweenness centrality (0.258) - this node is a cross-community bridge._
- **Why does `IUnitOfWork` connect `IUnitOfWork` to `.ValidateAsync`, `VoidJournalEntryCommand`, `UpdateDepartmentCommand`, `CreateProjectGroupCommand`, `CreateProductCommand`, `Response`, `.Handle`, `JournalEntry`, `Currency`, `IEntityTypeConfiguration`, `IRequest`, `UpdateProjectCommand`, `RolePermission`, `CurrencyFeatures.cs`, `.HandleResult`, `Permission`, `BankTransaction`, `GetTrialBalanceQuery`, `CreateAccountingPeriodCommand`, `Countify.Domain.Entities.Auth`, `IRepository`, `AccountMovementsResponse`, `UnitOfWork`, `HistoryDto`, `DeleteDocumentTypeCommand`, `Account`, `AuthResponse`, `DeleteProductAccountCommand`, `JournalEntry`, `JournalEntryLine`, `UserDto`, `ProductAccount`, `UpdateCompanySettingsCommand`, `UpdateJournalEntryCommand`, `CreateAccountCommand`, `CreateJournalEntryCommand`, `BankAccount`, `ApplicationUser`, `GetRoleByIdQueryHandler`, `ProjectGroup`, `PaginatedResponse`, `Budget`, `.SaveChangesAsync`, `BudgetsController`, `AccountingPeriodDto`, `DocumentTypeDto`, `AccountingPeriod`, `BankReconciliation`, `GetProjectsQuery`, `History`, `UpdateProductCommand`, `DeleteAccountCommand`, `CreateQualityCommand`, `GetJournalEntriesQuery`, `GetQualitiesQueryHandler`, `RoleDto`, `BankTransactionType`, `YearEndClosingEntry`, `GetAccountsQuery`, `Product`, `UpdateQualityCommand`, `CloseAccountingPeriodCommand`, `GetAccountByIdQuery`, `UpdateRolePermissionsCommand`, `GetJournalEntryByIdQuery`, `DeleteAccountingPeriodCommand`?**
  _High betweenness centrality (0.219) - this node is a cross-community bridge._
- **Why does `CountifyDbContext` connect `CountifyDbContext` to `CatalogSeeder`, `Currency`, `JournalEntry`, `.AddInfrastructureServices`, `IEntityTypeConfiguration`, `ICurrentUserService`, `RolePermission`, `.SaveChangesAsync`, `Permission`, `BankTransaction`, `Countify.Domain.Entities.Auth`, `Account`, `.SeedDatabase`, `JournalEntryLine`, `JournalEntry`, `ProductAccount`, `Seeding — GENERALIZADO (base para futuras entidades/fases)`, `BankAccount`, `ApplicationUser`, `ProjectGroup`, `Budget`, `UserRoleHasPermissionRequirement`, `AccountingPeriod`, `BankReconciliation`, `History`, `TransactionSeeder`, `BankTransactionType`, `YearEndClosingEntry`, `Product`, `CountifyDbContextFactory`, `.OnModelCreating`?**
  _High betweenness centrality (0.067) - this node is a cross-community bridge._
- **What connects `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName` to the rest of the system?**
  _801 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Countify.Application.Wrappers` be split into smaller, more focused modules?**
  _Cohesion score 0.10787942887361185 - nodes in this community are weakly interconnected._
- **Should `CreateProjectGroupCommand` be split into smaller, more focused modules?**
  _Cohesion score 0.06553911205073996 - nodes in this community are weakly interconnected._
- **Should `CountifyDbContext` be split into smaller, more focused modules?**
  _Cohesion score 0.06439393939393939 - nodes in this community are weakly interconnected._