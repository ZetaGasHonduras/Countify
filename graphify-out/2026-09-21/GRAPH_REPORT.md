# Graph Report - Countify  (2026-09-21)

## Corpus Check
- 315 files · ~49,548 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 2 file(s) not represented in the graph (top: (none) 1, .user 1)

## Summary
- 2724 nodes · 5546 edges · 173 communities (159 shown, 14 thin omitted)
- Extraction: 96% EXTRACTED · 4% INFERRED · 0% AMBIGUOUS · INFERRED: 243 edges (avg confidence: 0.86)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `68a4490d`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- Countify.Application.Wrappers
- CatalogSeeder
- .Delete
- CountifyDbContext
- GetDepartmentsQueryHandler
- fluentvalidation
- Countify.Domain.Entities.Accounting
- .Delete
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
- RolePermission
- BankTransaction
- GetTrialBalanceQuery
- mediatr
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
- JournalEntriesController
- .Update
- PaginatedResponse
- Budget
- .Delete
- UpdateDocumentTypeCommand
- ProjectGroupsController.cs
- BudgetsController
- http
- JournalEntryLineRequest
- CreateUserCommand
- UpdateUserCommand
- Countify.Infrastructure.Migrations
- PermissionService
- AccountsController
- AccountingPeriodDto
- RolesController.cs
- DocumentTypeDto
- GetUserByIdQueryHandler
- UsersController
- BankReconciliation
- GetProjectGroupsQueryHandler
- GetProjectsQuery
- History
- UpdateAccountCommand
- RolesController
- .Delete
- UpdateProductCommand
- DeleteAccountCommand
- CreateQualityCommand
- TransactionSeeder
- .SaveChangesAsync
- DepartmentsController.cs
- GetJournalEntriesQuery
- GetQualitiesQueryHandler
- RoleDto
- .Close
- InitialCreate
- Program.cs
- UsersController.cs
- ApiKeyAuthenticationHandler.cs
- YearEndClosingEntry
- AddAccountingModule
- AddBanksAndBankReconciliation
- JournalEntriesController.cs
- GetAccountsQuery
- BankReconciliationDto
- Product
- UpdateQualityCommand
- AddBudgetsAndBudgetPermissions
- IJwtService
- BaseController
- DeleteRoleCommandHandler
- UpdateRoleCommand
- ChangePasswordCommand
- SourceModule
- IRequestHandler
- UpdateDepartmentCommand
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
- AccountPolicies
- .AddApiServices
- IEmailService
- DepartmentPolicies
- ReportsPolicies
- .ValidateAsync
- CreateDocumentTypeCommand
- CreateProjectCommand
- RenameBankOpeningBalanceToBalance
- GetUsersQueryHandler
- DeleteUserCommand
- Currency
- .BuildModel
- DocumentType
- Department
- JournalEntryStatus
- .ApplyOrder
- ICurrentUserService
- UserRoleHasPermissionRequirement
- GetProductAccountsQuery.cs
- CurrencyPolicies
- CreateProjectGroupCommand
- IConfigureOptions
- AuthController
- UpdateProductAccountCommand
- CreateAccountingPeriodCommand
- GetProductAccountsQuery
- BankStatementPdfBuilder.cs
- DeleteDepartmentCommand
- DeleteJournalEntryCommand
- DeleteProjectCommand
- Countify — Convenciones del proyecto
- .Build
- .Build
- GetDepartmentsQuery.cs
- DeleteProductAccountCommand
- JournalEntry
- BankPolicies
- CompanySettingsPolicies
- Flujo bancario
- FixBankCurrencyForeignKeys
- EntryConceptType
- HistoryPolicies
- JournalEntryPolicies
- ProductAccountPolicies
- ProjectGroupPolicies
- RolePolicies
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
- `Permisos (patrón de futuras fases también)` --references--> `CompanySettingsPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/CompanySettingsPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `DepartmentPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/DepartmentPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `JournalEntryPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/JournalEntryPolicies.cs

## Import Cycles
- None detected.

## Communities (173 total, 14 thin omitted)

### Community 0 - "Countify.Application.Wrappers"
Cohesion: 0.07
Nodes (20): automapper, AccountProfile, ProductProfile, QualityProfile, Countify.Application.Features.Accounts.DTOs, Countify.Application.Features.Accounts.Commands.CreateAccount, Countify.Application.Features.Products.DTOs, Countify.Application.Features.Qualities.DTOs (+12 more)

### Community 1 - "CatalogSeeder"
Cohesion: 0.38
Nodes (5): CatalogSeeder, CancellationToken, ILogger, IOptions, Task

### Community 2 - ".Delete"
Cohesion: 0.28
Nodes (9): ProjectGroupsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 3 - "CountifyDbContext"
Cohesion: 0.06
Nodes (30): CountifyDbContext, AccountingPeriods, Accounts, BankAccounts, BankReconciliations, BankTransactions, BankTransactionTypes, BudgetLines (+22 more)

### Community 4 - "GetDepartmentsQueryHandler"
Cohesion: 0.13
Nodes (20): DepartmentsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+12 more)

### Community 5 - "fluentvalidation"
Cohesion: 0.06
Nodes (29): AbstractValidator, CloseAccountingPeriodCommandValidator, CreateAccountingPeriodCommandValidator, DeleteAccountingPeriodCommandValidator, CreateAccountCommandValidator, UpdateAccountCommandValidator, ForgotPasswordCommandValidator, LoginCommandValidator (+21 more)

### Community 6 - "Countify.Domain.Entities.Accounting"
Cohesion: 0.12
Nodes (5): Countify.Domain.Seeders, Countify.Infrastructure.Persistence.Configurations, Countify.Domain.Entities.Accounting, microsoft_entityframeworkcore, microsoft_entityframeworkcore_metadata_builders

### Community 7 - ".Delete"
Cohesion: 0.28
Nodes (9): ProductsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 8 - "Response"
Cohesion: 0.06
Nodes (39): ForgotPasswordCommand, ForgotPasswordCommandHandler, CancellationToken, Task, UserManager, ResetPasswordCommand, ResetPasswordCommandHandler, CancellationToken (+31 more)

### Community 9 - ".Handle"
Cohesion: 0.16
Nodes (13): CreateProductAccountCommand, CreateProductAccountCommandHandler, CancellationToken, Guid, IMapper, Task, ProductAccountRequest, CostAccountId (+5 more)

### Community 10 - "JournalEntry"
Cohesion: 0.05
Nodes (44): ProductDto, Code, Id, Name, Guid, GetProductsQuery, GetProductsQueryHandler, CancellationToken (+36 more)

### Community 11 - ".AddInfrastructureServices"
Cohesion: 0.14
Nodes (12): SeederOptions, Enabled, SeedConfiguration, SeedTransactions, IConfiguration, IdentityRole, IServiceCollection, ConfigurationSeeder (+4 more)

### Community 12 - "Profile"
Cohesion: 0.07
Nodes (16): AccountingPeriodProfile, BankAccountProfile, SettingsProfile, CurrencyProfile, DocumentTypeProfile, HistoryProfile, UserProfile, Countify.Application.Features.Historie.Profiles (+8 more)

### Community 13 - "IRequest"
Cohesion: 0.13
Nodes (42): BankHandler, BankStatementDto, BankAccountId, BankAccountName, ClosingBalance, CreditTotal, DebitTotal, FromDate (+34 more)

### Community 14 - "BaseEntity"
Cohesion: 0.06
Nodes (25): BaseEntity, Id, Guid, OrderColumns, Ascending, Descending, Currency, Code (+17 more)

### Community 15 - "UpdateProjectCommand"
Cohesion: 0.12
Nodes (19): ProjectsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+11 more)

### Community 16 - "IRepository"
Cohesion: 0.12
Nodes (18): IRepository, CancellationToken, Expression, Func, Guid, IQueryable, List, Task (+10 more)

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
Cohesion: 0.07
Nodes (30): BankTransaction, Amount, BankAccount, BankAccountId, BankReconciliation, BankReconciliationId, Beneficiary, Concept (+22 more)

### Community 21 - "GetTrialBalanceQuery"
Cohesion: 0.10
Nodes (23): TrialBalanceDto, CreditTotal, DebitTotal, Difference, Lines, TrialBalanceLineDto, AccountCode, AccountId (+15 more)

### Community 22 - "mediatr"
Cohesion: 0.10
Nodes (15): automapper_queryableextensions, RoleProfile, Countify.Infrastructure.Services, Countify.Application.Common.Interfaces, Countify.Application.Features.Users.DTOs, Countify.Application.Features.Roles.DTOs, Countify.Application.Features.ProductAccounts, Countify.Domain.Entities.Audit (+7 more)

### Community 23 - "UnitOfWork"
Cohesion: 0.07
Nodes (29): UnitOfWork, AccountingPeriods, Accounts, BankAccounts, BankReconciliations, BankTransactions, BankTransactionTypes, BudgetLines (+21 more)

### Community 24 - "ValidationException"
Cohesion: 0.08
Nodes (24): ExceptionHandlerMiddleware, Exception, ILogger, Task, ValidationBehavior, CancellationToken, IEnumerable, Task (+16 more)

### Community 25 - "AccountMovementsResponse"
Cohesion: 0.08
Nodes (26): AccountMovementDto, Balance, Concept, Credit, Debit, EntryNumber, JournalEntryId, ReferenceDate (+18 more)

### Community 26 - "BudgetLine"
Cohesion: 0.07
Nodes (28): Project, BudgetLine, Account, AccountId, April, August, Budget, BudgetId (+20 more)

### Community 27 - "IUnitOfWork"
Cohesion: 0.07
Nodes (33): ProductAccountRules, CancellationToken, Guid, Task, IUnitOfWork, AccountingPeriods, Accounts, BankAccounts (+25 more)

### Community 28 - "HistoryDto"
Cohesion: 0.08
Nodes (26): HistoryController, Authorize, HttpGet, IActionResult, Task, HistoryDto, Date, Entity (+18 more)

### Community 29 - "Account"
Cohesion: 0.09
Nodes (23): Account, BudgetControlled, Code, IsAuxAsset, IsAuxCxc, IsAuxCxp, IsAuxLoan, IsBankAccount (+15 more)

### Community 30 - "Countify.Infrastructure"
Cohesion: 0.08
Nodes (29): Countify.Api, net10.0, Countify.Application, net10.0, Microsoft.NET.Sdk, Countify.Domain, net10.0, Microsoft.NET.Sdk (+21 more)

### Community 31 - "AuthResponse"
Cohesion: 0.10
Nodes (23): LoginCommand, LoginCommandHandler, CancellationToken, IdentityRole, RoleManager, Task, UserManager, RefreshTokenCommand (+15 more)

### Community 32 - "JournalEntryLine"
Cohesion: 0.08
Nodes (24): JournalEntryLine, Account, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName (+16 more)

### Community 33 - "Countify.Api.Controllers"
Cohesion: 0.11
Nodes (14): Countify.Application.Features.Configurations.Queries.GetCompanySettings, Countify.Application.Features.AccountingPeriods.Queries.GetAccountingPeriods, Countify.Application.Features.Projects.Queries.GetProjects, Countify.Api.Controllers, Countify.Application.Features.Reports.Queries.GetTrialBalance, Countify.Application.Features.Products.Queries.GetProducts, Countify.Application.Features.Qualities.Commands.DeleteQuality, Countify.Application.Features.ProductAccounts.Queries.GetProductAccounts (+6 more)

### Community 34 - "microsoft_aspnetcore_authorization"
Cohesion: 0.29
Nodes (6): Countify.Domain.Authorization, Countify.Api.Authorization.Handlers, Countify.Api.Authorization.Requirements, Countify.Api.Authorization.Policies, microsoft_aspnetcore_authorization, microsoft_extensions_options

### Community 35 - "BankTransactionDto"
Cohesion: 0.09
Nodes (23): BankTransactionDto, Amount, BankAccountId, BankAccountName, BankReconciliationId, Beneficiary, Concept, CounterpartAccountId (+15 more)

### Community 36 - "UserDto"
Cohesion: 0.15
Nodes (13): UserDto, CreatedAt, Email, FirstName, FullName, Id, IsActive, LastName (+5 more)

### Community 37 - "ProductAccount"
Cohesion: 0.10
Nodes (20): ProductAccount, CostAccount, CostAccountId, IncomeAccount, IncomeAccountId, InventoryAccount, InventoryAccountId, Product (+12 more)

### Community 38 - "ApiKeyAuthenticationHandler"
Cohesion: 0.10
Nodes (17): AuthenticateResult, AuthenticationHandler, AuthenticationProperties, AuthenticationSchemeOptions, ApiKeyAuthenticationHandler, IOptions, Task, ApiKeyAuthenticationOptions (+9 more)

### Community 39 - "JournalEntryDto"
Cohesion: 0.09
Nodes (22): JournalEntryDto, Code, Concept, CreditTotal, DebitTotal, DifferenceAmount, EntryNumber, Gid (+14 more)

### Community 40 - "CompanySettings"
Cohesion: 0.11
Nodes (19): CompanySettings, DefaultDepartment, DefaultDepartmentId, DefaultProject, DefaultProjectId, FiscalYear, RequireConceptTypes, RequireDepartments (+11 more)

### Community 41 - "UpdateCompanySettingsCommand"
Cohesion: 0.05
Nodes (41): SettingsController, Authorize, HttpGet, HttpPut, IActionResult, Task, UpdateCompanySettingsCommand, DefaultDepartmentId (+33 more)

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
Cohesion: 0.12
Nodes (14): Countify.Infrastructure.Persistence.Services, Countify.Infrastructure.Seeders, Countify.Infrastructure.Persistence, microsoft_aspnetcore_authentication_jwtbearer, microsoft_entityframeworkcore_design, microsoft_extensions_configuration, microsoft_extensions_dependencyinjection, microsoft_extensions_hosting (+6 more)

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
Cohesion: 0.07
Nodes (27): BankAccount, AccountingAccount, AccountingAccountId, AccountNumber, Balance, CheckNumber, Code, CurrencyId (+19 more)

### Community 50 - "ApplicationUser"
Cohesion: 0.11
Nodes (18): ApplicationUser, CreatedAt, CreatedBy, FirstName, FullName, IsActive, LastActivity, LastName (+10 more)

### Community 51 - "BudgetLineRequest"
Cohesion: 0.11
Nodes (17): BudgetLineRequest, AccountId, April, August, December, DepartmentId, February, January (+9 more)

### Community 52 - "Countify.Application.Features.Auth.DTOs"
Cohesion: 0.11
Nodes (13): ForgotPasswordRequest, Email, LoginRequest, Password, Username, RefreshTokenRequest, AccessToken, RefreshToken (+5 more)

### Community 53 - "Countify.Domain.Enums"
Cohesion: 0.16
Nodes (7): JournalEntryProfile, Countify.Application.Features.JournalEntries.Commands.CreateJournalEntry, Countify.Application.Features.JournalEntries.DTOs, Countify.Application.Features.JournalEntries.Profiles, Countify.Application.Features.JournalEntries, Countify.Domain.Enums, Countify.Application.Features.JournalEntries.Commands.UpdateJournalEntry

### Community 54 - "ProductAccountDto"
Cohesion: 0.11
Nodes (17): ProductAccountDto, CostAccountCode, CostAccountId, CostAccountName, Id, IncomeAccountCode, IncomeAccountId, IncomeAccountName (+9 more)

### Community 55 - "GetRoleByIdQueryHandler"
Cohesion: 0.14
Nodes (15): PermissionDto, Description, Id, Name, RoleDetailDto, Permissions, IList, GetRoleByIdQuery (+7 more)

### Community 56 - "ProjectGroup"
Cohesion: 0.18
Nodes (10): ProjectGroup, Code, Name, Projects, List, BasicProjectGroups, Items, Guid (+2 more)

### Community 57 - "JournalEntriesController"
Cohesion: 0.33
Nodes (9): JournalEntriesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 58 - ".Update"
Cohesion: 0.28
Nodes (9): BudgetRequest, Authorize, CancellationToken, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 59 - "PaginatedResponse"
Cohesion: 0.22
Nodes (8): PaginatedResponse, Data, HasNextPage, HasPreviousPage, PageNumber, PageSize, TotalCount, TotalPages

### Community 60 - "Budget"
Cohesion: 0.14
Nodes (13): BudgetLine, Budget, FiscalYear, Lines, Name, List, BasicBudgets, Items (+5 more)

### Community 61 - ".Delete"
Cohesion: 0.28
Nodes (9): DocumentTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 62 - "UpdateDocumentTypeCommand"
Cohesion: 0.20
Nodes (10): UpdateDocumentTypeCommand, Code, Id, IsDefault, Name, UpdateDocumentTypeCommandHandler, CancellationToken, Guid (+2 more)

### Community 63 - "ProjectGroupsController.cs"
Cohesion: 0.13
Nodes (11): CreateProjectCommandValidator, CreateProjectGroupCommandValidator, UpdateProjectCommandValidator, ProjectProfile, Countify.Application.Features.Projects.Commands.UpdateProject, Countify.Application.Features.Projects.Profiles, Countify.Application.Features.Projects.Commands.UpdateProjectGroup, Countify.Application.Features.Projects.Commands.DeleteProjectGroup (+3 more)

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
Cohesion: 0.13
Nodes (15): CreateUserCommand, Email, FirstName, LastName, Password, Phone, RoleId, Username (+7 more)

### Community 68 - "UpdateUserCommand"
Cohesion: 0.13
Nodes (15): UpdateUserCommand, Email, FirstName, Id, IsActive, LastName, Phone, RoleId (+7 more)

### Community 69 - "Countify.Infrastructure.Migrations"
Cohesion: 0.37
Nodes (6): Countify.Infrastructure.Migrations, microsoft_entityframeworkcore_infrastructure, microsoft_entityframeworkcore_metadata, microsoft_entityframeworkcore_migrations, microsoft_entityframeworkcore_storage_valueconversion, system

### Community 70 - "PermissionService"
Cohesion: 0.22
Nodes (7): IPermissionService, HashSet, Task, PermissionService, HashSet, Task, UserManager

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
Cohesion: 0.22
Nodes (12): DocumentTypeDto, Code, Id, IsDefault, Name, Guid, GetDocumentTypesQuery, GetDocumentTypesQueryHandler (+4 more)

### Community 75 - "GetUserByIdQueryHandler"
Cohesion: 0.16
Nodes (13): UserDetailDto, CreatedBy, LastActivity, DateTime, GetUserByIdQuery, Id, GetUserByIdQueryHandler, CancellationToken (+5 more)

### Community 76 - "UsersController"
Cohesion: 0.29
Nodes (9): UsersController, Authorize, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult, Task (+1 more)

### Community 77 - "BankReconciliation"
Cohesion: 0.14
Nodes (14): BankReconciliation, BankAccount, BankAccountId, BookBalance, IsClosed, Notes, ReconciliationDate, StatementBalance (+6 more)

### Community 78 - "GetProjectGroupsQueryHandler"
Cohesion: 0.18
Nodes (12): ProjectGroupDto, Code, Id, Name, Guid, GetProjectGroupsQuery, GetProjectGroupsQueryHandler, CancellationToken (+4 more)

### Community 79 - "GetProjectsQuery"
Cohesion: 0.20
Nodes (13): ProjectDto, Code, GroupId, Id, Name, Guid, GetProjectsQuery, Search (+5 more)

### Community 80 - "History"
Cohesion: 0.14
Nodes (13): History, Date, Entity, EntityId, NewValue, OldValue, Property, UserId (+5 more)

### Community 81 - "UpdateAccountCommand"
Cohesion: 0.13
Nodes (15): UpdateAccountCommand, BudgetControlled, BudgetLine, Code, Id, IsAuxAsset, IsAuxCxc, IsAuxCxp (+7 more)

### Community 82 - "RolesController"
Cohesion: 0.33
Nodes (8): RolesController, Authorize, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult, Task

### Community 83 - ".Delete"
Cohesion: 0.28
Nodes (9): ProductAccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 84 - "UpdateProductCommand"
Cohesion: 0.22
Nodes (9): UpdateProductCommand, Code, Id, Name, UpdateProductCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 85 - "DeleteAccountCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountCommand, Id, DeleteAccountCommandHandler, CancellationToken, Guid, Task

### Community 86 - "CreateQualityCommand"
Cohesion: 0.31
Nodes (8): CreateQualityCommand, Code, Name, CreateQualityCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 87 - "TransactionSeeder"
Cohesion: 0.22
Nodes (9): CancellationToken, Task, CancellationToken, Task, TransactionSeeder, CancellationToken, ILogger, IOptions (+1 more)

### Community 88 - ".SaveChangesAsync"
Cohesion: 0.17
Nodes (11): UpdateProjectGroupCommand, Code, Id, Name, UpdateProjectGroupCommandHandler, CancellationToken, Guid, IMapper (+3 more)

### Community 89 - "DepartmentsController.cs"
Cohesion: 0.22
Nodes (6): CreateDepartmentCommandValidator, UpdateDepartmentCommandValidator, Countify.Application.Features.Departments.Commands.UpdateDepartment, Countify.Application.Features.Departments.Commands.CreateDepartment, Countify.Application.Features.Departments.Queries.GetDepartments, Countify.Application.Features.Departments.Commands.DeleteDepartment

### Community 90 - "GetJournalEntriesQuery"
Cohesion: 0.21
Nodes (11): GetJournalEntriesQuery, FromDate, Search, Status, ToDate, GetJournalEntriesQueryHandler, CancellationToken, DateTime (+3 more)

### Community 91 - "GetQualitiesQueryHandler"
Cohesion: 0.13
Nodes (20): QualitiesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+12 more)

### Community 92 - "RoleDto"
Cohesion: 0.24
Nodes (10): RoleDto, Id, Name, PermissionCount, GetRolesQuery, GetRolesQueryHandler, CancellationToken, IMapper (+2 more)

### Community 93 - ".Close"
Cohesion: 0.33
Nodes (8): AccountingPeriodsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, IActionResult, Task

### Community 94 - "InitialCreate"
Cohesion: 0.18
Nodes (9): DateTime, DateTimeOffset, Guid, MigrationBuilder, InitialCreate, DateTime, DateTimeOffset, Guid (+1 more)

### Community 95 - "Program.cs"
Cohesion: 0.17
Nodes (9): ApplicationServiceRegistration, IServiceCollection, Countify.Api.DependencyInjection, Countify.Application.DependencyInjection, Countify.Infrastructure.Extensions, Countify.Infrastructure.DependencyInjection, quick_autoinject_dependencyannotation, scalar_aspnetcore (+1 more)

### Community 96 - "UsersController.cs"
Cohesion: 0.11
Nodes (12): AssignRoleCommandValidator, ChangePasswordCommandValidator, CreateUserCommandValidator, DeleteUserCommandValidator, UpdateUserCommandValidator, Countify.Application.Features.Users.Commands.UpdateUser, Countify.Application.Features.Users.Commands.DeleteUser, Countify.Application.Features.Users.Commands.CreateUser (+4 more)

### Community 97 - "ApiKeyAuthenticationHandler.cs"
Cohesion: 0.18
Nodes (8): AuthorizeAttribute, ApiKeyAuthenticationDefaults, ApiKeyAttribute, Countify.Api.ApiKeyAuthentication, microsoft_aspnetcore_authentication, microsoft_extensions_primitives, system_security_claims, system_text_encodings_web

### Community 98 - "YearEndClosingEntry"
Cohesion: 0.20
Nodes (9): YearEndClosingEntry, GeneratedBy, JournalEntryId, PeriodId, Guid, BasicYearEndClosingEntries, Items, YearEndClosingEntryConfiguration (+1 more)

### Community 99 - "AddAccountingModule"
Cohesion: 0.20
Nodes (8): DateTime, Guid, MigrationBuilder, AddAccountingModule, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 100 - "AddBanksAndBankReconciliation"
Cohesion: 0.20
Nodes (8): DateTime, Guid, MigrationBuilder, AddBanksAndBankReconciliation, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 101 - "JournalEntriesController.cs"
Cohesion: 0.12
Nodes (11): DeleteAccountCommandValidator, DeleteJournalEntryCommandValidator, VoidJournalEntryCommandValidator, Countify.Application.Features.JournalEntries.Commands.DeleteJournalEntry, Countify.Application.Features.JournalEntries.Queries.GetAccountMovements, Countify.Application.Features.JournalEntries.Queries.GetJournalEntries, Countify.Application.Features.Accounts.Queries.GetAccounts, Countify.Application.Features.JournalEntries.Commands.VoidJournalEntry (+3 more)

### Community 102 - "GetAccountsQuery"
Cohesion: 0.36
Nodes (8): GetAccountsQuery, IsOperable, Search, GetAccountsQueryHandler, CancellationToken, IMapper, List, Task

### Community 103 - "BankReconciliationDto"
Cohesion: 0.20
Nodes (10): BankReconciliationDto, BankAccountId, BankAccountName, BookBalance, Id, IsClosed, Notes, ReconciliationDate (+2 more)

### Community 104 - "Product"
Cohesion: 0.15
Nodes (14): CreateProductCommand, Code, Name, CreateProductCommandHandler, CancellationToken, Guid, IMapper, Task (+6 more)

### Community 105 - "UpdateQualityCommand"
Cohesion: 0.22
Nodes (9): UpdateQualityCommand, Code, Id, Name, UpdateQualityCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 106 - "AddBudgetsAndBudgetPermissions"
Cohesion: 0.20
Nodes (8): Guid, MigrationBuilder, AddBudgetsAndBudgetPermissions, DateTime, DateTimeOffset, Guid, ModelBuilder, Migration

### Community 107 - "IJwtService"
Cohesion: 0.24
Nodes (5): IJwtService, IList, JwtService, IConfiguration, IList

### Community 108 - "BaseController"
Cohesion: 0.20
Nodes (9): ControllerBase, BaseController, Mediator, ReportsController, Authorize, HttpGet, IActionResult, Task (+1 more)

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

### Community 113 - "IRequestHandler"
Cohesion: 0.11
Nodes (17): CloseAccountingPeriodCommand, Id, CloseAccountingPeriodCommandHandler, CancellationToken, Guid, Task, UpdateAccountCommandHandler, CancellationToken (+9 more)

### Community 114 - "UpdateDepartmentCommand"
Cohesion: 0.22
Nodes (9): UpdateDepartmentCommand, Code, Id, Name, UpdateDepartmentCommandHandler, CancellationToken, Guid, IMapper (+1 more)

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
Cohesion: 0.21
Nodes (10): Permisos (patrón de futuras fases también), AccountingPeriodPolicies, AuthorizationOptions, DocumentTypePolicies, AuthorizationOptions, ProjectPolicies, AuthorizationOptions, ApiServiceRegistration (+2 more)

### Community 127 - "IEmailService"
Cohesion: 0.33
Nodes (4): IEmailService, Task, EmailService, Task

### Community 130 - ".ValidateAsync"
Cohesion: 0.29
Nodes (6): BudgetAvailabilityValidator, CancellationToken, DateTime, Guid, IEnumerable, Task

### Community 131 - "CreateDocumentTypeCommand"
Cohesion: 0.27
Nodes (9): CreateDocumentTypeCommand, Code, IsDefault, Name, CreateDocumentTypeCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 132 - "CreateProjectCommand"
Cohesion: 0.27
Nodes (9): CreateProjectCommand, Code, GroupId, Name, CreateProjectCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 133 - "RenameBankOpeningBalanceToBalance"
Cohesion: 0.22
Nodes (6): MigrationBuilder, RenameBankOpeningBalanceToBalance, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 134 - "GetUsersQueryHandler"
Cohesion: 0.27
Nodes (9): GetUsersQuery, GetUsersQueryHandler, CancellationToken, IdentityRole, IMapper, List, RoleManager, Task (+1 more)

### Community 135 - "DeleteUserCommand"
Cohesion: 0.33
Nodes (6): DeleteUserCommand, Id, DeleteUserCommandHandler, CancellationToken, Task, UserManager

### Community 136 - "Currency"
Cohesion: 0.38
Nodes (5): Currency, BasicCurrencies, Items, CurrencyConfiguration, EntityTypeBuilder

### Community 137 - ".BuildModel"
Cohesion: 0.29
Nodes (6): CountifyDbContextModelSnapshot, DateTime, DateTimeOffset, Guid, ModelBuilder, ModelSnapshot

### Community 138 - "DocumentType"
Cohesion: 0.22
Nodes (8): DocumentType, Code, IsDefault, Name, BasicDocumentTypes, Items, DocumentTypeConfiguration, EntityTypeBuilder

### Community 139 - "Department"
Cohesion: 0.21
Nodes (11): CreateDepartmentCommand, Code, Name, CreateDepartmentCommandHandler, CancellationToken, Guid, IMapper, Task (+3 more)

### Community 140 - "JournalEntryStatus"
Cohesion: 0.33
Nodes (5): JournalEntryStatus, Approved, Draft, Posted, Voided

### Community 141 - ".ApplyOrder"
Cohesion: 0.46
Nodes (5): QueryableExtensions, Expression, Func, IQueryable, Dictionary

### Community 142 - "ICurrentUserService"
Cohesion: 0.17
Nodes (9): ICurrentUserService, Guid, UserId, UserName, CurrentUserService, Guid, UserId, UserName (+1 more)

### Community 143 - "UserRoleHasPermissionRequirement"
Cohesion: 0.25
Nodes (8): AuthorizationHandler, AuthorizationHandlerContext, PermissionAuthorizationHandler, Task, UserRoleHasPermissionRequirement, Permission, Permission, IAuthorizationRequirement

### Community 144 - "GetProductAccountsQuery.cs"
Cohesion: 0.28
Nodes (5): ProductAccountProfile, Countify.Application.Features.ProductAccounts.Profiles, Countify.Application.Features.ProductAccounts.DTOs, Countify.Application.Features.ProductAccounts.Commands.CreateProductAccount, Countify.Application.Features.ProductAccounts.Commands.UpdateProductAccount

### Community 146 - "CreateProjectGroupCommand"
Cohesion: 0.31
Nodes (8): CreateProjectGroupCommand, Code, Name, CreateProjectGroupCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 147 - "IConfigureOptions"
Cohesion: 0.38
Nodes (5): BudgetPolicies, AuthorizationOptions, UserPolicies, AuthorizationOptions, IConfigureOptions

### Community 148 - "AuthController"
Cohesion: 0.57
Nodes (4): AuthController, HttpPost, IActionResult, Task

### Community 149 - "UpdateProductAccountCommand"
Cohesion: 0.29
Nodes (7): UpdateProductAccountCommand, Id, UpdateProductAccountCommandHandler, CancellationToken, Guid, IMapper, Task

### Community 150 - "CreateAccountingPeriodCommand"
Cohesion: 0.36
Nodes (7): CreateAccountingPeriodCommand, Month, CreateAccountingPeriodCommandHandler, CancellationToken, DateTime, Guid, Task

### Community 151 - "GetProductAccountsQuery"
Cohesion: 0.36
Nodes (7): GetProductAccountsQuery, Search, GetProductAccountsQueryHandler, CancellationToken, IMapper, List, Task

### Community 152 - "BankStatementPdfBuilder.cs"
Cohesion: 0.43
Nodes (5): Countify.Application.Features.Banks, questpdf_fluent, questpdf_helpers, questpdf_infrastructure, system_globalization

### Community 153 - "DeleteDepartmentCommand"
Cohesion: 0.33
Nodes (6): DeleteDepartmentCommand, Id, DeleteDepartmentCommandHandler, CancellationToken, Guid, Task

### Community 154 - "DeleteJournalEntryCommand"
Cohesion: 0.33
Nodes (6): DeleteJournalEntryCommand, Id, DeleteJournalEntryCommandHandler, CancellationToken, Guid, Task

### Community 155 - "DeleteProjectCommand"
Cohesion: 0.33
Nodes (6): DeleteProjectCommand, Id, DeleteProjectCommandHandler, CancellationToken, Guid, Task

### Community 156 - "Countify — Convenciones del proyecto"
Cohesion: 0.33
Nodes (5): Arquitectura / capas, Contrato API (FASE 1), Countify — Convenciones del proyecto, Flujo de trabajo (obligatorio), Modelo contable (FASE 1 — corregido)

### Community 159 - "GetDepartmentsQuery.cs"
Cohesion: 0.33
Nodes (3): DepartmentProfile, Countify.Application.Features.Departments.Profiles, Countify.Application.Features.Departments.DTOs

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
Cohesion: 0.13
Nodes (14): Seeding — GENERALIZADO (base para futuras entidades/fases), ISeeder, CancellationToken, Task, BasicDepartments, Items, BasicRoles, Items (+6 more)

## Knowledge Gaps
- **801 isolated node(s):** `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName`, `ApiKey`, `Permission` (+796 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 1352 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **14 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Response` connect `Response` to `CreateDocumentTypeCommand`, `GetDepartmentsQueryHandler`, `CreateProjectCommand`, `DeleteUserCommand`, `.Handle`, `JournalEntry`, `Department`, `IRequest`, `UpdateProjectCommand`, `CurrencyFeatures.cs`, `.HandleResult`, `CreateProjectGroupCommand`, `UpdateProductAccountCommand`, `CreateAccountingPeriodCommand`, `GetTrialBalanceQuery`, `DeleteDepartmentCommand`, `DeleteJournalEntryCommand`, `AccountMovementsResponse`, `HistoryDto`, `DeleteProjectCommand`, `AuthResponse`, `DeleteProductAccountCommand`, `UpdateCompanySettingsCommand`, `UpdateJournalEntryCommand`, `CreateAccountCommand`, `CreateJournalEntryCommand`, `GetRoleByIdQueryHandler`, `.Update`, `PaginatedResponse`, `UpdateDocumentTypeCommand`, `CreateUserCommand`, `UpdateUserCommand`, `AccountingPeriodDto`, `DocumentTypeDto`, `GetUserByIdQueryHandler`, `GetProjectGroupsQueryHandler`, `UpdateAccountCommand`, `UpdateProductCommand`, `DeleteAccountCommand`, `CreateQualityCommand`, `.SaveChangesAsync`, `GetQualitiesQueryHandler`, `Product`, `UpdateQualityCommand`, `DeleteRoleCommandHandler`, `UpdateRoleCommand`, `ChangePasswordCommand`, `IRequestHandler`, `UpdateDepartmentCommand`, `GetAccountByIdQuery`, `UpdateRolePermissionsCommand`, `GetJournalEntryByIdQuery`, `CreateRoleCommand`, `AssignRoleCommand`, `DeleteAccountingPeriodCommand`?**
  _High betweenness centrality (0.258) - this node is a cross-community bridge._
- **Why does `IUnitOfWork` connect `IUnitOfWork` to `.ValidateAsync`, `CreateDocumentTypeCommand`, `GetDepartmentsQueryHandler`, `CreateProjectCommand`, `GetUsersQueryHandler`, `Response`, `.Handle`, `JournalEntry`, `Department`, `Currency`, `IRequest`, `DocumentType`, `UpdateProjectCommand`, `IRepository`, `CurrencyFeatures.cs`, `CreateProjectGroupCommand`, `RolePermission`, `BankTransaction`, `UpdateProductAccountCommand`, `CreateAccountingPeriodCommand`, `GetProductAccountsQuery`, `GetTrialBalanceQuery`, `DeleteDepartmentCommand`, `DeleteJournalEntryCommand`, `AccountMovementsResponse`, `Countify — Convenciones del proyecto`, `HistoryDto`, `DeleteProjectCommand`, `AuthResponse`, `DeleteProductAccountCommand`, `Account`, `BudgetLine`, `JournalEntry`, `JournalEntryLine`, `ProductAccount`, `UpdateCompanySettingsCommand`, `UpdateJournalEntryCommand`, `CreateAccountCommand`, `CreateJournalEntryCommand`, `BankAccount`, `ApplicationUser`, `GetRoleByIdQueryHandler`, `ProjectGroup`, `Budget`, `UpdateDocumentTypeCommand`, `BudgetsController`, `AccountingPeriodDto`, `DocumentTypeDto`, `BankReconciliation`, `GetProjectGroupsQueryHandler`, `GetProjectsQuery`, `History`, `UpdateProductCommand`, `DeleteAccountCommand`, `CreateQualityCommand`, `.SaveChangesAsync`, `GetJournalEntriesQuery`, `GetQualitiesQueryHandler`, `RoleDto`, `YearEndClosingEntry`, `GetAccountsQuery`, `Product`, `UpdateQualityCommand`, `mediatr`, `IRequestHandler`, `UpdateDepartmentCommand`, `GetAccountByIdQuery`, `UpdateRolePermissionsCommand`, `UnitOfWork`, `GetJournalEntryByIdQuery`, `DeleteAccountingPeriodCommand`?**
  _High betweenness centrality (0.215) - this node is a cross-community bridge._
- **Why does `CountifyDbContext` connect `CountifyDbContext` to `CatalogSeeder`, `Currency`, `JournalEntry`, `.AddInfrastructureServices`, `Department`, `DocumentType`, `ICurrentUserService`, `RolePermission`, `BankTransaction`, `mediatr`, `BudgetLine`, `Account`, `JournalEntryLine`, `JournalEntry`, `ProductAccount`, `Seeding — GENERALIZADO (base para futuras entidades/fases)`, `BankAccount`, `ApplicationUser`, `ProjectGroup`, `Budget`, `PermissionService`, `BankReconciliation`, `History`, `TransactionSeeder`, `YearEndClosingEntry`, `Product`, `CountifyDbContextFactory`, `.OnModelCreating`?**
  _High betweenness centrality (0.054) - this node is a cross-community bridge._
- **What connects `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName` to the rest of the system?**
  _801 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Countify.Application.Wrappers` be split into smaller, more focused modules?**
  _Cohesion score 0.0711864406779661 - nodes in this community are weakly interconnected._
- **Should `CountifyDbContext` be split into smaller, more focused modules?**
  _Cohesion score 0.06439393939393939 - nodes in this community are weakly interconnected._
- **Should `GetDepartmentsQueryHandler` be split into smaller, more focused modules?**
  _Cohesion score 0.13 - nodes in this community are weakly interconnected._