# Graph Report - Countify  (2026-09-22)

## Corpus Check
- 342 files · ~55,224 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 2 file(s) not represented in the graph (top: (none) 1, .user 1)

## Summary
- 2996 nodes · 6090 edges · 199 communities (167 shown, 32 thin omitted)
- Extraction: 96% EXTRACTED · 4% INFERRED · 0% AMBIGUOUS · INFERRED: 267 edges (avg confidence: 0.85)
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
- AbstractValidator
- microsoft_entityframeworkcore
- UpdateProductCommand
- Response
- UpdateCustomerTypeCommand
- JournalEntry
- CloseAccountingPeriodCommandValidator.cs
- Profile
- IRequest
- BaseEntity
- .Delete
- IRepository
- CurrencyFeatures.cs
- .HandleResult
- Permission
- BankTransaction
- GetTrialBalanceQuery
- .Delete
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
- DeleteJournalEntryCommandValidator.cs
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
- Countify.Domain.Entities.Auth
- AccountDto
- BankAccountDto
- CreateJournalEntryCommand
- BankAccount
- ApplicationUser
- BudgetsController
- ResetPasswordRequest
- Countify.Domain.Enums
- ProductAccountDto
- GetRoleByIdQueryHandler
- ProjectGroup
- JournalEntriesController
- Customer
- PaginatedResponse
- Budget
- GetUserInfoQueryHandler
- IRequestHandler
- Countify.Domain.Entities.Accounting
- AccountMovementDto
- http
- JournalEntryLineRequest
- CreateProjectGroupCommand
- UpdateUserCommand
- Countify.Infrastructure.Persistence
- PermissionAuthorizationHandler
- AccountsController
- AccountingPeriodDto
- CreateRoleCommandValidator.cs
- DocumentTypeDto
- GetUserByIdQueryHandler
- UsersController
- BankReconciliation
- Seeding — GENERALIZADO (base para futuras entidades/fases)
- GetProjectsQuery
- History
- UpdateAccountCommand
- RolesController
- .Handle
- CustomerDto
- fluentvalidation
- CreateDocumentTypeCommand
- UpdateCustomerCommand
- BasicAccountingPeriods
- DepartmentProfile.cs
- GetJournalEntriesQuery
- UpdateQualityCommand
- RoleDto
- .Close
- .Up
- DatabaseExtensions.cs
- DocumentType
- microsoft_aspnetcore_authorization
- YearEndClosingEntry
- .BuildTargetModel
- .Up
- ForgotPasswordCommandValidator.cs
- GetAccountsQuery
- CreateCustomerCommand
- Product
- BaseController
- .BuildTargetModel
- BudgetLineRequest
- CreateAccountingPeriodCommandValidator.cs
- IEntityTypeConfiguration
- UpdateRoleCommand
- ChangePasswordCommand
- SourceModule
- .Delete
- DeleteRoleCommandHandler
- ICurrentUserService
- GetAccountByIdQuery
- BankTransactionType
- .Validate
- GetJournalEntryByIdQuery
- CreateRoleCommand
- AssignRoleCommand
- RequestParameter
- .AddInfrastructureServices
- .OnModelCreating
- DocumentTypeProfile.cs
- IConfigureOptions
- IEmailService
- UpdateDocumentTypeCommand
- DeleteDepartmentCommand
- .ValidateAsync
- FixBankCurrencyForeignKeys
- UpdateProjectCommand
- RenameBankOpeningBalanceToBalance
- ISeeder
- DeleteUserCommand
- Currency
- .BuildModel
- CreateProductCommand.cs
- DeleteProjectGroupCommand
- JournalEntryStatus
- .ApplyOrder
- CreateQualityCommand.cs
- UserRoleHasPermissionRequirement
- Countify — Convenciones del proyecto
- CreateProjectCommand
- .SaveChangesAsync
- AccountPolicies
- AuthController
- GetProductAccountsQuery.cs
- HistoryPolicies
- Repository.cs
- UpdateRolePermissionsCommand
- .AddApiServices
- DeleteJournalEntryCommand
- CompanySettingsPolicies
- CustomerProfile.cs
- RolePermission
- .SaveChangesAsync
- VoidJournalEntryCommand
- TransactionSeeder
- JournalEntry
- BankPolicies
- RolePolicies
- Flujo bancario
- BudgetRequest
- CountifyDbContextFactory
- DeleteAccountingPeriodCommand
- JournalEntryPolicies
- LoginRequest
- RefreshTokenRequest
- DeleteCustomerCommand
- GetCustomersQueryHandler
- DeleteCustomerTypeCommand
- DeleteProductCommand
- GetAccountingPeriodsQuery.cs
- GetCompanySettingsQuery.cs
- GetEntityHistory.cs
- .BuildTargetModel
- .BuildTargetModel
- DocumentTypePolicies
- UserPolicies
- DeleteAccountingPeriodCommandValidator.cs
- Countify.Application.Features.Accounts.Commands.CreateAccount
- Countify.Application.Features.Accounts.Commands.UpdateAccount
- LoginCommandValidator.cs
- RefreshTokenCommandValidator.cs
- ResetPasswordCommandValidator.cs
- Countify.Application.Features.CustomerTypes.Commands.UpdateCustomerType
- DeleteDocumentTypeCommandValidator.cs
- VoidJournalEntryCommandValidator.cs
- Countify.Application.Features.Projects.Commands.CreateProject
- Countify.Application.Features.Projects.Commands.CreateProjectGroup
- DeleteProjectCommandValidator.cs
- Countify.Application.Features.Projects.Commands.UpdateProject
- DeleteRoleCommandValidator.cs
- UpdateRoleCommandValidator.cs
- UpdateRolePermissionsCommandValidator.cs
- AssignRoleCommandValidator.cs

## God Nodes (most connected - your core abstractions)
1. `Response` - 243 edges
2. `IUnitOfWork` - 128 edges
3. `Countify.Domain.Entities.Accounting` - 94 edges
4. `Countify.Application.Wrappers` - 80 edges
5. `Countify.Domain.Interfaces` - 78 edges
6. `CountifyDbContext` - 72 edges
7. `UnitOfWork` - 60 edges
8. `BankTransaction` - 46 edges
9. `JournalEntryLine` - 40 edges
10. `Countify.Api.Authorization.Policies` - 39 edges

## Surprising Connections (you probably didn't know these)
- `Modelo contable (FASE 1 — corregido)` --references--> `CompanySettings`  [INFERRED]
  AGENTS.md → Countify.Domain/Entities/Accounting/CompanySettings.cs
- `Permisos (patrón de futuras fases también)` --references--> `AccountPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/AccountPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `CompanySettingsPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/CompanySettingsPolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `DocumentTypePolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/DocumentTypePolicies.cs
- `Permisos (patrón de futuras fases también)` --references--> `JournalEntryPolicies`  [INFERRED]
  AGENTS.md → Countify.Api/Authorization/Policies/JournalEntryPolicies.cs

## Import Cycles
- None detected.

## Communities (199 total, 32 thin omitted)

### Community 0 - "Countify.Application.Wrappers"
Cohesion: 0.10
Nodes (13): automapper, automapper_queryableextensions, Countify.Application.Features.Accounts.DTOs, Countify.Application.Features.Qualities.Commands.UpdateQuality, Countify.Application.Features.Accounts.Profiles, Countify.Application.Features.ProductAccounts, Countify.Application.Extensions, Countify.Application.Wrappers (+5 more)

### Community 1 - "CatalogSeeder"
Cohesion: 0.38
Nodes (5): CatalogSeeder, CancellationToken, ILogger, IOptions, Task

### Community 2 - "UpdateCompanySettingsCommand"
Cohesion: 0.09
Nodes (22): UpdateCompanySettingsCommand, Address, CompanyName, DefaultDepartmentId, DefaultProjectId, Email, FiscalYear, Mobile (+14 more)

### Community 3 - "CountifyDbContext"
Cohesion: 0.06
Nodes (32): CountifyDbContext, AccountingPeriods, Accounts, BankAccounts, BankReconciliations, BankTransactions, BankTransactionTypes, BudgetLines (+24 more)

### Community 4 - "UpdateDepartmentCommand"
Cohesion: 0.06
Nodes (38): DepartmentsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+30 more)

### Community 5 - "AbstractValidator"
Cohesion: 0.18
Nodes (7): AbstractValidator, UpdateCompanySettingsCommandValidator, CreateUserCommandValidator, DeleteUserCommandValidator, UpdateUserCommandValidator, Countify.Application.Features.Users.Commands.DeleteUser, Countify.Application.Features.Configurations.Commands.UpdateCompanySettings

### Community 6 - "microsoft_entityframeworkcore"
Cohesion: 0.15
Nodes (6): Countify.Domain.Seeders, Countify.Infrastructure.Seeders, Countify.Infrastructure.Persistence.Configurations, microsoft_entityframeworkcore, microsoft_entityframeworkcore_metadata_builders, microsoft_extensions_logging

### Community 7 - "UpdateProductCommand"
Cohesion: 0.07
Nodes (37): ProductsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+29 more)

### Community 8 - "Response"
Cohesion: 0.05
Nodes (42): CloseAccountingPeriodCommand, Id, CloseAccountingPeriodCommandHandler, CancellationToken, Guid, Task, DeleteAccountCommand, Id (+34 more)

### Community 9 - "UpdateCustomerTypeCommand"
Cohesion: 0.06
Nodes (42): CustomerTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+34 more)

### Community 10 - "JournalEntry"
Cohesion: 0.09
Nodes (22): JournalEntry, Code, Concept, CreditTotal, DebitTotal, DifferenceAmount, EntryGid, EntryNumber (+14 more)

### Community 12 - "Profile"
Cohesion: 0.10
Nodes (15): AccountProfile, BankAccountProfile, CurrencyProfile, CustomerTypeProfile, RoleProfile, UserProfile, Countify.Application.Features.Users.Commands.UpdateUser, Countify.Application.Features.CustomerTypes.DTOs (+7 more)

### Community 13 - "IRequest"
Cohesion: 0.10
Nodes (52): BankHandler, BankReconciliationDto, BankAccountId, BankAccountName, BookBalance, Id, IsClosed, Notes (+44 more)

### Community 14 - "BaseEntity"
Cohesion: 0.12
Nodes (15): BaseEntity, Id, Guid, Currency, Code, ExchangeRate, IsActive, Name (+7 more)

### Community 15 - ".Delete"
Cohesion: 0.28
Nodes (9): ProjectsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 16 - "IRepository"
Cohesion: 0.12
Nodes (18): IRepository, CancellationToken, Expression, Func, Guid, IQueryable, List, Task (+10 more)

### Community 17 - "CurrencyFeatures.cs"
Cohesion: 0.12
Nodes (26): CurrenciesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+18 more)

### Community 18 - ".HandleResult"
Cohesion: 0.26
Nodes (11): BanksController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+3 more)

### Community 19 - "Permission"
Cohesion: 0.15
Nodes (11): CurrencyPolicies, AuthorizationOptions, Permissions, Items, Permission, Description, Id, Name (+3 more)

### Community 20 - "BankTransaction"
Cohesion: 0.07
Nodes (30): BankTransaction, Amount, BankAccount, BankAccountId, BankReconciliation, BankReconciliationId, Beneficiary, Concept (+22 more)

### Community 21 - "GetTrialBalanceQuery"
Cohesion: 0.10
Nodes (23): TrialBalanceDto, CreditTotal, DebitTotal, Difference, Lines, TrialBalanceLineDto, AccountCode, AccountId (+15 more)

### Community 22 - ".Delete"
Cohesion: 0.28
Nodes (9): DocumentTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 23 - "UnitOfWork"
Cohesion: 0.06
Nodes (31): UnitOfWork, AccountingPeriods, Accounts, BankAccounts, BankReconciliations, BankTransactions, BankTransactionTypes, BudgetLines (+23 more)

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
Cohesion: 0.06
Nodes (31): IUnitOfWork, AccountingPeriods, Accounts, BankAccounts, BankReconciliations, BankTransactions, BankTransactionTypes, BudgetLines (+23 more)

### Community 28 - "HistoryDto"
Cohesion: 0.08
Nodes (26): HistoryController, Authorize, HttpGet, IActionResult, Task, HistoryDto, Date, Entity (+18 more)

### Community 29 - "Account"
Cohesion: 0.10
Nodes (20): Account, BudgetControlled, Code, IsAuxAsset, IsAuxCxc, IsAuxCxp, IsAuxLoan, IsBankAccount (+12 more)

### Community 30 - "Countify.Infrastructure"
Cohesion: 0.08
Nodes (29): Countify.Api, net10.0, Countify.Application, net10.0, Microsoft.NET.Sdk, Countify.Domain, net10.0, Microsoft.NET.Sdk (+21 more)

### Community 31 - "AuthResponse"
Cohesion: 0.08
Nodes (28): IJwtService, IList, LoginCommand, LoginCommandHandler, CancellationToken, IdentityRole, RoleManager, Task (+20 more)

### Community 32 - "JournalEntryLine"
Cohesion: 0.08
Nodes (24): JournalEntryLine, Account, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName (+16 more)

### Community 34 - "Countify.Api.Controllers"
Cohesion: 0.05
Nodes (32): Countify.Application.Features.Customers.Commands.DeleteCustomer, Countify.Application.Features.Configurations.Queries.GetCompanySettings, Countify.Application.Features.AccountingPeriods.Queries.GetAccountingPeriods, Countify.Application.Features.Projects.Queries.GetProjects, Countify.Application.Features.CustomerTypes.Commands.DeleteCustomerType, Countify.Application.Features.Customers.Queries.GetCustomers, Countify.Application.Features.Roles.Queries.GetRoles, Countify.Application.Features.JournalEntries.Queries.GetAccountMovements (+24 more)

### Community 35 - "BankTransactionDto"
Cohesion: 0.09
Nodes (23): BankTransactionDto, Amount, BankAccountId, BankAccountName, BankReconciliationId, Beneficiary, Concept, CounterpartAccountId (+15 more)

### Community 36 - "UserDto"
Cohesion: 0.11
Nodes (22): UserDto, CreatedAt, Email, FirstName, FullName, Id, IsActive, LastName (+14 more)

### Community 37 - "ProductAccount"
Cohesion: 0.09
Nodes (20): ProductAccount, CostAccount, CostAccountId, IncomeAccount, IncomeAccountId, InventoryAccount, InventoryAccountId, Product (+12 more)

### Community 38 - "ApiKeyAuthenticationHandler"
Cohesion: 0.07
Nodes (25): AuthenticateResult, AuthenticationHandler, AuthenticationProperties, AuthenticationSchemeOptions, AuthorizeAttribute, ApiKeyAuthenticationDefaults, ApiKeyAuthenticationHandler, IOptions (+17 more)

### Community 39 - "JournalEntryDto"
Cohesion: 0.09
Nodes (22): JournalEntryDto, Code, Concept, CreditTotal, DebitTotal, DifferenceAmount, EntryNumber, Gid (+14 more)

### Community 40 - "CompanySettings"
Cohesion: 0.09
Nodes (23): CompanySettings, Address, CompanyName, DefaultDepartment, DefaultDepartmentId, DefaultProject, DefaultProjectId, Email (+15 more)

### Community 41 - "CompanySettingsDto"
Cohesion: 0.06
Nodes (35): CompanySettingsDto, Address, CompanyName, DefaultDepartmentId, DefaultProjectId, Email, FiscalYear, Id (+27 more)

### Community 42 - "UpdateJournalEntryCommand"
Cohesion: 0.12
Nodes (18): UpdateJournalEntryCommand, Code, Concept, Id, Lines, Observations, PeriodId, Reference (+10 more)

### Community 43 - "JournalEntryLineDto"
Cohesion: 0.10
Nodes (19): JournalEntryLineDto, AccountCode, AccountId, AccountName, AppliesToPayableId, AppliesToReceivableId, Concept, Credit (+11 more)

### Community 44 - "CreateAccountCommand"
Cohesion: 0.12
Nodes (18): CreateAccountCommand, BudgetControlled, BudgetLine, Code, IsAuxAsset, IsAuxCxc, IsAuxCxp, IsAuxLoan (+10 more)

### Community 45 - "Countify.Domain.Entities.Auth"
Cohesion: 0.10
Nodes (17): ForgotPasswordRequest, Email, Countify.Application.Features.Auth.DTOs, Countify.Infrastructure.Services, Countify.Application.Common.Interfaces, Countify.Domain.Entities.Audit, Countify.Domain.Entities.Auth, microsoft_aspnetcore_authentication_jwtbearer (+9 more)

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
Cohesion: 0.07
Nodes (31): CreateUserCommand, Email, FirstName, LastName, Password, Phone, RoleId, Username (+23 more)

### Community 51 - "BudgetsController"
Cohesion: 0.22
Nodes (13): BudgetRequest, BudgetResponse, BudgetLineResponse, BudgetsController, Authorize, CancellationToken, Guid, HttpDelete (+5 more)

### Community 52 - "ResetPasswordRequest"
Cohesion: 0.40
Nodes (4): ResetPasswordRequest, Email, NewPassword, Token

### Community 53 - "Countify.Domain.Enums"
Cohesion: 0.13
Nodes (11): JournalEntryProfile, EntryConceptType, Credit, Debit, Other, Countify.Application.Features.JournalEntries.Commands.CreateJournalEntry, Countify.Application.Features.JournalEntries.DTOs, Countify.Application.Features.JournalEntries.Profiles (+3 more)

### Community 54 - "ProductAccountDto"
Cohesion: 0.11
Nodes (17): ProductAccountDto, CostAccountCode, CostAccountId, CostAccountName, Id, IncomeAccountCode, IncomeAccountId, IncomeAccountName (+9 more)

### Community 55 - "GetRoleByIdQueryHandler"
Cohesion: 0.14
Nodes (13): PermissionDto, Description, Id, Name, RoleDetailDto, Permissions, IList, GetRoleByIdQueryHandler (+5 more)

### Community 56 - "ProjectGroup"
Cohesion: 0.10
Nodes (19): Project, Project, Code, Group, GroupId, Name, Guid, ProjectGroup (+11 more)

### Community 57 - "JournalEntriesController"
Cohesion: 0.33
Nodes (9): JournalEntriesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 58 - "Customer"
Cohesion: 0.10
Nodes (20): Customer, AccountingAccount, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerType (+12 more)

### Community 59 - "PaginatedResponse"
Cohesion: 0.15
Nodes (15): GetProductAccountsQuery, Search, GetProductAccountsQueryHandler, CancellationToken, IMapper, List, Task, PaginatedResponse (+7 more)

### Community 60 - "Budget"
Cohesion: 0.14
Nodes (13): BudgetLine, Budget, FiscalYear, Lines, Name, List, BasicBudgets, Items (+5 more)

### Community 61 - "GetUserInfoQueryHandler"
Cohesion: 0.14
Nodes (15): UserInfoResponse, Email, FullName, Permissions, Roles, UserId, UserName, IList (+7 more)

### Community 62 - "IRequestHandler"
Cohesion: 0.12
Nodes (17): CreateAccountingPeriodCommand, Month, CreateAccountingPeriodCommandHandler, CancellationToken, DateTime, Guid, Task, UpdateAccountCommandHandler (+9 more)

### Community 63 - "Countify.Domain.Entities.Accounting"
Cohesion: 0.10
Nodes (8): ProjectProfile, OrderColumns, Ascending, Descending, Countify.Application.Features.Projects.Profiles, Countify.Application.Features.Projects.Commands.UpdateProjectGroup, Countify.Domain.Common, Countify.Domain.Entities.Accounting

### Community 64 - "AccountMovementDto"
Cohesion: 0.18
Nodes (10): AccountMovementDto, Balance, Concept, Credit, Debit, EntryNumber, JournalEntryId, ReferenceDate (+2 more)

### Community 65 - "http"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 66 - "JournalEntryLineRequest"
Cohesion: 0.12
Nodes (15): JournalEntryLineRequest, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName, Debit (+7 more)

### Community 67 - "CreateProjectGroupCommand"
Cohesion: 0.07
Nodes (37): ProjectGroupsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+29 more)

### Community 68 - "UpdateUserCommand"
Cohesion: 0.13
Nodes (15): UpdateUserCommand, Email, FirstName, Id, IsActive, LastName, Phone, RoleId (+7 more)

### Community 69 - "Countify.Infrastructure.Persistence"
Cohesion: 0.14
Nodes (18): InitialCreate, DateTime, Guid, MigrationBuilder, AddAccountingModule, Guid, MigrationBuilder, AddBudgetsAndBudgetPermissions (+10 more)

### Community 70 - "PermissionAuthorizationHandler"
Cohesion: 0.15
Nodes (11): AuthorizationHandler, AuthorizationHandlerContext, PermissionAuthorizationHandler, Task, IPermissionService, HashSet, Task, PermissionService (+3 more)

### Community 71 - "AccountsController"
Cohesion: 0.32
Nodes (9): AccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 72 - "AccountingPeriodDto"
Cohesion: 0.18
Nodes (14): AccountingPeriodDto, EndDate, Id, IsClosed, Month, StartDate, DateTime, Guid (+6 more)

### Community 74 - "DocumentTypeDto"
Cohesion: 0.18
Nodes (13): DocumentTypeDto, Code, Id, IsDefault, Name, Guid, GetDocumentTypesQuery, GetDocumentTypesQueryHandler (+5 more)

### Community 75 - "GetUserByIdQueryHandler"
Cohesion: 0.16
Nodes (13): UserDetailDto, CreatedBy, LastActivity, DateTime, GetUserByIdQuery, Id, GetUserByIdQueryHandler, CancellationToken (+5 more)

### Community 76 - "UsersController"
Cohesion: 0.29
Nodes (9): UsersController, Authorize, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult, Task (+1 more)

### Community 77 - "BankReconciliation"
Cohesion: 0.14
Nodes (14): BankReconciliation, BankAccount, BankAccountId, BookBalance, IsClosed, Notes, ReconciliationDate, StatementBalance (+6 more)

### Community 78 - "Seeding — GENERALIZADO (base para futuras entidades/fases)"
Cohesion: 0.10
Nodes (15): Seeding — GENERALIZADO (base para futuras entidades/fases), BasicCompanySettings, Items, BasicDepartments, Items, BasicDocumentTypes, Items, BasicProjects (+7 more)

### Community 79 - "GetProjectsQuery"
Cohesion: 0.20
Nodes (13): ProjectDto, Code, GroupId, Id, Name, Guid, GetProjectsQuery, Search (+5 more)

### Community 80 - "History"
Cohesion: 0.13
Nodes (13): History, Date, Entity, EntityId, NewValue, OldValue, Property, UserId (+5 more)

### Community 81 - "UpdateAccountCommand"
Cohesion: 0.13
Nodes (15): UpdateAccountCommand, BudgetControlled, BudgetLine, Code, Id, IsAuxAsset, IsAuxCxc, IsAuxCxp (+7 more)

### Community 82 - "RolesController"
Cohesion: 0.33
Nodes (8): RolesController, Authorize, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult, Task

### Community 83 - ".Handle"
Cohesion: 0.07
Nodes (33): ProductAccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+25 more)

### Community 84 - "CustomerDto"
Cohesion: 0.10
Nodes (20): CustomerDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Address, Code, CreditDays, CreditLimit (+12 more)

### Community 85 - "fluentvalidation"
Cohesion: 0.17
Nodes (8): DeleteAccountCommandValidator, CreateCustomerTypeCommandValidator, ChangePasswordCommandValidator, Countify.Application.Features.Users.Commands.ChangePassword, Countify.Application.Features.CustomerTypes.Commands.CreateCustomerType, Countify.Application.Common.Behaviors, Countify.Application.Features.Accounts.Commands.DeleteAccount, fluentvalidation

### Community 86 - "CreateDocumentTypeCommand"
Cohesion: 0.27
Nodes (9): CreateDocumentTypeCommand, Code, IsDefault, Name, CreateDocumentTypeCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 87 - "UpdateCustomerCommand"
Cohesion: 0.11
Nodes (19): UpdateCustomerCommand, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId, Email (+11 more)

### Community 88 - "BasicAccountingPeriods"
Cohesion: 0.47
Nodes (3): BasicAccountingPeriods, Items, DateTime

### Community 89 - "DepartmentProfile.cs"
Cohesion: 0.22
Nodes (6): CreateDepartmentCommandValidator, UpdateDepartmentCommandValidator, DepartmentProfile, Countify.Application.Features.Departments.Commands.UpdateDepartment, Countify.Application.Features.Departments.Profiles, Countify.Application.Features.Departments.Commands.CreateDepartment

### Community 90 - "GetJournalEntriesQuery"
Cohesion: 0.21
Nodes (11): GetJournalEntriesQuery, FromDate, Search, Status, ToDate, GetJournalEntriesQueryHandler, CancellationToken, DateTime (+3 more)

### Community 91 - "UpdateQualityCommand"
Cohesion: 0.07
Nodes (37): QualitiesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+29 more)

### Community 92 - "RoleDto"
Cohesion: 0.24
Nodes (10): RoleDto, Id, Name, PermissionCount, GetRolesQuery, GetRolesQueryHandler, CancellationToken, IMapper (+2 more)

### Community 93 - ".Close"
Cohesion: 0.33
Nodes (8): AccountingPeriodsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, IActionResult, Task

### Community 94 - ".Up"
Cohesion: 0.33
Nodes (4): DateTime, DateTimeOffset, Guid, MigrationBuilder

### Community 95 - "DatabaseExtensions.cs"
Cohesion: 0.12
Nodes (13): ApiServiceRegistration, ApplicationServiceRegistration, IServiceCollection, Countify.Api.Authorization.Handlers, Countify.Api.DependencyInjection, Countify.Application.DependencyInjection, Countify.Infrastructure.Extensions, Countify.Infrastructure.DependencyInjection (+5 more)

### Community 96 - "DocumentType"
Cohesion: 0.33
Nodes (6): DocumentType, Code, IsDefault, Name, DocumentTypeConfiguration, EntityTypeBuilder

### Community 97 - "microsoft_aspnetcore_authorization"
Cohesion: 0.31
Nodes (5): Countify.Domain.Authorization, Countify.Api.Authorization.Requirements, Countify.Api.Authorization.Policies, microsoft_aspnetcore_authorization, microsoft_extensions_options

### Community 98 - "YearEndClosingEntry"
Cohesion: 0.20
Nodes (9): YearEndClosingEntry, GeneratedBy, JournalEntryId, PeriodId, Guid, BasicYearEndClosingEntries, Items, YearEndClosingEntryConfiguration (+1 more)

### Community 99 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 100 - ".Up"
Cohesion: 0.40
Nodes (3): DateTime, Guid, MigrationBuilder

### Community 102 - "GetAccountsQuery"
Cohesion: 0.36
Nodes (8): GetAccountsQuery, IsOperable, Search, GetAccountsQueryHandler, CancellationToken, IMapper, List, Task

### Community 103 - "CreateCustomerCommand"
Cohesion: 0.12
Nodes (18): CreateCustomerCommand, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId, Email (+10 more)

### Community 104 - "Product"
Cohesion: 0.29
Nodes (6): Product, Code, Name, BasicProducts, ProductConfiguration, EntityTypeBuilder

### Community 105 - "BaseController"
Cohesion: 0.13
Nodes (15): ControllerBase, BaseController, Mediator, ReportsController, Authorize, HttpGet, IActionResult, Task (+7 more)

### Community 106 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 107 - "BudgetLineRequest"
Cohesion: 0.11
Nodes (17): BudgetLineRequest, AccountId, April, August, December, DepartmentId, February, January (+9 more)

### Community 109 - "IEntityTypeConfiguration"
Cohesion: 0.11
Nodes (17): AccountingPeriod, EndDate, IsClosed, Month, StartDate, DateTime, AccountConfiguration, EntityTypeBuilder (+9 more)

### Community 110 - "UpdateRoleCommand"
Cohesion: 0.25
Nodes (8): UpdateRoleCommand, Id, Name, UpdateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 111 - "ChangePasswordCommand"
Cohesion: 0.25
Nodes (8): ChangePasswordCommand, CurrentPassword, Id, NewPassword, ChangePasswordCommandHandler, CancellationToken, Task, UserManager

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

### Community 116 - "GetAccountByIdQuery"
Cohesion: 0.29
Nodes (7): GetAccountByIdQuery, Id, GetAccountByIdQueryHandler, CancellationToken, Guid, IMapper, Task

### Community 117 - "BankTransactionType"
Cohesion: 0.20
Nodes (9): BankTransactionType, Code, MovementType, TransactionType, BasicBanks, Accounts, TransactionTypes, BankTransactionTypeConfiguration (+1 more)

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

### Community 123 - ".AddInfrastructureServices"
Cohesion: 0.18
Nodes (10): SeederOptions, Enabled, SeedConfiguration, SeedTransactions, IConfiguration, IdentityRole, IServiceCollection, ConfigurationSeeder (+2 more)

### Community 124 - ".OnModelCreating"
Cohesion: 0.25
Nodes (7): IdentityRole, IdentityUserRole, ModelBuilder, IdentityRoleClaim, IdentityUserClaim, IdentityUserLogin, IdentityUserToken

### Community 125 - "DocumentTypeProfile.cs"
Cohesion: 0.22
Nodes (6): CreateDocumentTypeCommandValidator, UpdateDocumentTypeCommandValidator, DocumentTypeProfile, Countify.Application.Features.DocumentTypes.Commands.CreateDocumentType, Countify.Application.Features.DocumentTypes.Profiles, Countify.Application.Features.DocumentTypes.Commands.UpdateDocumentType

### Community 126 - "IConfigureOptions"
Cohesion: 0.27
Nodes (7): BudgetPolicies, AuthorizationOptions, CustomerPolicies, AuthorizationOptions, ProductAccountPolicies, AuthorizationOptions, IConfigureOptions

### Community 127 - "IEmailService"
Cohesion: 0.33
Nodes (4): IEmailService, Task, EmailService, Task

### Community 128 - "UpdateDocumentTypeCommand"
Cohesion: 0.20
Nodes (10): UpdateDocumentTypeCommand, Code, Id, IsDefault, Name, UpdateDocumentTypeCommandHandler, CancellationToken, Guid (+2 more)

### Community 129 - "DeleteDepartmentCommand"
Cohesion: 0.33
Nodes (6): DeleteDepartmentCommand, Id, DeleteDepartmentCommandHandler, CancellationToken, Guid, Task

### Community 130 - ".ValidateAsync"
Cohesion: 0.29
Nodes (6): BudgetAvailabilityValidator, CancellationToken, DateTime, Guid, IEnumerable, Task

### Community 131 - "FixBankCurrencyForeignKeys"
Cohesion: 0.25
Nodes (6): MigrationBuilder, FixBankCurrencyForeignKeys, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 132 - "UpdateProjectCommand"
Cohesion: 0.20
Nodes (10): UpdateProjectCommand, Code, GroupId, Id, Name, UpdateProjectCommandHandler, CancellationToken, Guid (+2 more)

### Community 133 - "RenameBankOpeningBalanceToBalance"
Cohesion: 0.25
Nodes (6): MigrationBuilder, RenameBankOpeningBalanceToBalance, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 134 - "ISeeder"
Cohesion: 0.22
Nodes (7): ISeeder, CancellationToken, Task, DatabaseExtensions, IEnumerable, ILogger, IHost

### Community 135 - "DeleteUserCommand"
Cohesion: 0.33
Nodes (6): DeleteUserCommand, Id, DeleteUserCommandHandler, CancellationToken, Task, UserManager

### Community 136 - "Currency"
Cohesion: 0.32
Nodes (5): Currency, BasicCurrencies, Items, CurrencyConfiguration, EntityTypeBuilder

### Community 137 - ".BuildModel"
Cohesion: 0.29
Nodes (6): CountifyDbContextModelSnapshot, DateTime, DateTimeOffset, Guid, ModelBuilder, ModelSnapshot

### Community 138 - "CreateProductCommand.cs"
Cohesion: 0.25
Nodes (4): ProductProfile, Countify.Application.Features.Products.DTOs, Countify.Application.Features.Products.Commands.CreateProduct, Countify.Application.Features.Products.Profiles

### Community 139 - "DeleteProjectGroupCommand"
Cohesion: 0.33
Nodes (6): DeleteProjectGroupCommand, Id, DeleteProjectGroupCommandHandler, CancellationToken, Guid, Task

### Community 140 - "JournalEntryStatus"
Cohesion: 0.33
Nodes (5): JournalEntryStatus, Approved, Draft, Posted, Voided

### Community 141 - ".ApplyOrder"
Cohesion: 0.46
Nodes (5): QueryableExtensions, Expression, Func, IQueryable, Dictionary

### Community 142 - "CreateQualityCommand.cs"
Cohesion: 0.25
Nodes (4): QualityProfile, Countify.Application.Features.Qualities.DTOs, Countify.Application.Features.Qualities.Commands.CreateQuality, Countify.Application.Features.Qualities.Profiles

### Community 143 - "UserRoleHasPermissionRequirement"
Cohesion: 0.18
Nodes (13): Permisos (patrón de futuras fases también), AccountingPeriodPolicies, AuthorizationOptions, DepartmentPolicies, AuthorizationOptions, ProjectGroupPolicies, AuthorizationOptions, ProjectPolicies (+5 more)

### Community 144 - "Countify — Convenciones del proyecto"
Cohesion: 0.33
Nodes (5): Arquitectura / capas, Contrato API (FASE 1), Countify — Convenciones del proyecto, Flujo de trabajo (obligatorio), Modelo contable (FASE 1 — corregido)

### Community 145 - "CreateProjectCommand"
Cohesion: 0.27
Nodes (9): CreateProjectCommand, Code, GroupId, Name, CreateProjectCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 146 - ".SaveChangesAsync"
Cohesion: 0.22
Nodes (8): DeleteProjectCommand, Id, DeleteProjectCommandHandler, CancellationToken, Guid, Task, CancellationToken, Task

### Community 148 - "AuthController"
Cohesion: 0.38
Nodes (6): AuthController, Authorize, HttpGet, HttpPost, IActionResult, Task

### Community 149 - "GetProductAccountsQuery.cs"
Cohesion: 0.28
Nodes (5): ProductAccountProfile, Countify.Application.Features.ProductAccounts.Profiles, Countify.Application.Features.ProductAccounts.DTOs, Countify.Application.Features.ProductAccounts.Commands.CreateProductAccount, Countify.Application.Features.ProductAccounts.Commands.UpdateProductAccount

### Community 152 - "UpdateRolePermissionsCommand"
Cohesion: 0.22
Nodes (9): UpdateRolePermissionsCommand, PermissionIds, RoleId, UpdateRolePermissionsCommandHandler, CancellationToken, IdentityRole, List, RoleManager (+1 more)

### Community 153 - ".AddApiServices"
Cohesion: 0.28
Nodes (6): CustomerTypePolicies, AuthorizationOptions, ReportsPolicies, AuthorizationOptions, IServiceCollection, IAuthorizationHandler

### Community 154 - "DeleteJournalEntryCommand"
Cohesion: 0.33
Nodes (6): DeleteJournalEntryCommand, Id, DeleteJournalEntryCommandHandler, CancellationToken, Guid, Task

### Community 156 - "CustomerProfile.cs"
Cohesion: 0.22
Nodes (6): CreateCustomerCommandValidator, UpdateCustomerCommandValidator, CustomerProfile, Countify.Application.Features.Customers.Profiles, Countify.Application.Features.Customers.Commands.UpdateCustomer, Countify.Application.Features.Customers.Commands.CreateCustomer

### Community 157 - "RolePermission"
Cohesion: 0.25
Nodes (8): RolePermission, Permission, PermissionId, Role, RoleId, IdentityRole, RolePermissionConfiguration, EntityTypeBuilder

### Community 158 - ".SaveChangesAsync"
Cohesion: 0.22
Nodes (6): CancellationToken, Task, CancellationToken, Task, CancellationToken, Task

### Community 159 - "VoidJournalEntryCommand"
Cohesion: 0.33
Nodes (6): VoidJournalEntryCommand, Id, VoidJournalEntryCommandHandler, CancellationToken, Guid, Task

### Community 160 - "TransactionSeeder"
Cohesion: 0.47
Nodes (5): TransactionSeeder, CancellationToken, ILogger, IOptions, Task

### Community 161 - "JournalEntry"
Cohesion: 0.33
Nodes (5): JournalEntry, BasicJournalEntries, Items, JournalEntryConfiguration, EntityTypeBuilder

### Community 165 - "BudgetRequest"
Cohesion: 0.25
Nodes (8): BudgetLineRequest, BudgetLineResponse, BudgetRequest, FiscalYear, Lines, Name, BudgetResponse, List

### Community 166 - "CountifyDbContextFactory"
Cohesion: 0.29
Nodes (6): CountifyDbContextFactory, DesignTimeCurrentUserService, Guid, UserId, UserName, IDesignTimeDbContextFactory

### Community 167 - "DeleteAccountingPeriodCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountingPeriodCommand, Id, DeleteAccountingPeriodCommandHandler, CancellationToken, Guid, Task

### Community 169 - "LoginRequest"
Cohesion: 0.50
Nodes (3): LoginRequest, Password, Username

### Community 170 - "RefreshTokenRequest"
Cohesion: 0.50
Nodes (3): RefreshTokenRequest, AccessToken, RefreshToken

### Community 171 - "DeleteCustomerCommand"
Cohesion: 0.33
Nodes (6): DeleteCustomerCommand, Id, DeleteCustomerCommandHandler, CancellationToken, Guid, Task

### Community 172 - "GetCustomersQueryHandler"
Cohesion: 0.43
Nodes (6): GetCustomersQuery, GetCustomersQueryHandler, CancellationToken, IMapper, List, Task

### Community 173 - "DeleteCustomerTypeCommand"
Cohesion: 0.33
Nodes (6): DeleteCustomerTypeCommand, Id, DeleteCustomerTypeCommandHandler, CancellationToken, Guid, Task

### Community 174 - "DeleteProductCommand"
Cohesion: 0.33
Nodes (6): DeleteProductCommand, Id, DeleteProductCommandHandler, CancellationToken, Guid, Task

### Community 175 - "GetAccountingPeriodsQuery.cs"
Cohesion: 0.33
Nodes (3): AccountingPeriodProfile, Countify.Application.Features.AccountingPeriods.Profiles, Countify.Application.Features.AccountingPeriods.DTOs

### Community 176 - "GetCompanySettingsQuery.cs"
Cohesion: 0.33
Nodes (3): SettingsProfile, Countify.Application.Features.Configurations.DTOs, Countify.Application.Features.Configurations.Profiles

### Community 177 - "GetEntityHistory.cs"
Cohesion: 0.33
Nodes (3): HistoryProfile, Countify.Application.Features.Historie.Profiles, Countify.Application.Features.Historie.DTOs

### Community 178 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 179 - ".BuildTargetModel"
Cohesion: 0.40
Nodes (4): DateTime, DateTimeOffset, Guid, ModelBuilder

## Knowledge Gaps
- **907 isolated node(s):** `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName`, `ApiKey`, `Permission` (+902 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 1510 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **32 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Response` connect `Response` to `UpdateDocumentTypeCommand`, `DeleteDepartmentCommand`, `UpdateCompanySettingsCommand`, `UpdateDepartmentCommand`, `UpdateProjectCommand`, `UpdateProductCommand`, `DeleteUserCommand`, `UpdateCustomerTypeCommand`, `DeleteProjectGroupCommand`, `IRequest`, `CurrencyFeatures.cs`, `.HandleResult`, `CreateProjectCommand`, `.SaveChangesAsync`, `GetTrialBalanceQuery`, `UpdateRolePermissionsCommand`, `AccountMovementsResponse`, `DeleteJournalEntryCommand`, `HistoryDto`, `AuthResponse`, `VoidJournalEntryCommand`, `DeleteAccountingPeriodCommand`, `CompanySettingsDto`, `UpdateJournalEntryCommand`, `DeleteCustomerCommand`, `CreateAccountCommand`, `GetCustomersQueryHandler`, `DeleteCustomerTypeCommand`, `DeleteProductCommand`, `CreateJournalEntryCommand`, `ApplicationUser`, `BudgetsController`, `GetRoleByIdQueryHandler`, `PaginatedResponse`, `GetUserInfoQueryHandler`, `IRequestHandler`, `CreateProjectGroupCommand`, `UpdateUserCommand`, `AccountingPeriodDto`, `DocumentTypeDto`, `GetUserByIdQueryHandler`, `UpdateAccountCommand`, `.Handle`, `CreateDocumentTypeCommand`, `UpdateCustomerCommand`, `UpdateQualityCommand`, `CreateCustomerCommand`, `UpdateRoleCommand`, `ChangePasswordCommand`, `DeleteRoleCommandHandler`, `GetAccountByIdQuery`, `GetJournalEntryByIdQuery`, `CreateRoleCommand`, `AssignRoleCommand`?**
  _High betweenness centrality (0.239) - this node is a cross-community bridge._
- **Why does `IUnitOfWork` connect `IUnitOfWork` to `UpdateDocumentTypeCommand`, `DeleteDepartmentCommand`, `UpdateCompanySettingsCommand`, `.ValidateAsync`, `UpdateDepartmentCommand`, `UpdateProjectCommand`, `UpdateProductCommand`, `Response`, `UpdateCustomerTypeCommand`, `Currency`, `DeleteProjectGroupCommand`, `IRequest`, `Countify — Convenciones del proyecto`, `CurrencyFeatures.cs`, `CreateProjectCommand`, `.SaveChangesAsync`, `BankTransaction`, `GetTrialBalanceQuery`, `Permission`, `IRepository`, `UpdateRolePermissionsCommand`, `AccountMovementsResponse`, `DeleteJournalEntryCommand`, `BudgetLine`, `HistoryDto`, `Account`, `RolePermission`, `AuthResponse`, `VoidJournalEntryCommand`, `JournalEntry`, `JournalEntryLine`, `UserDto`, `ProductAccount`, `DeleteAccountingPeriodCommand`, `CompanySettingsDto`, `UpdateJournalEntryCommand`, `DeleteCustomerCommand`, `CreateAccountCommand`, `GetCustomersQueryHandler`, `DeleteCustomerTypeCommand`, `DeleteProductCommand`, `CreateJournalEntryCommand`, `Countify.Domain.Entities.Auth`, `BankAccount`, `BudgetsController`, `ApplicationUser`, `GetRoleByIdQueryHandler`, `ProjectGroup`, `Customer`, `PaginatedResponse`, `Budget`, `GetUserInfoQueryHandler`, `IRequestHandler`, `CreateProjectGroupCommand`, `AccountingPeriodDto`, `DocumentTypeDto`, `BankReconciliation`, `GetProjectsQuery`, `History`, `.Handle`, `CreateDocumentTypeCommand`, `UpdateCustomerCommand`, `GetJournalEntriesQuery`, `UpdateQualityCommand`, `RoleDto`, `DocumentType`, `YearEndClosingEntry`, `GetAccountsQuery`, `CreateCustomerCommand`, `Product`, `IEntityTypeConfiguration`, `GetAccountByIdQuery`, `BankTransactionType`, `UnitOfWork`, `GetJournalEntryByIdQuery`?**
  _High betweenness centrality (0.209) - this node is a cross-community bridge._
- **Why does `CountifyDbContext` connect `CountifyDbContext` to `CatalogSeeder`, `ISeeder`, `Currency`, `Permission`, `BankTransaction`, `BudgetLine`, `Account`, `RolePermission`, `.SaveChangesAsync`, `JournalEntryLine`, `JournalEntry`, `TransactionSeeder`, `ProductAccount`, `CountifyDbContextFactory`, `Countify.Domain.Entities.Auth`, `BankAccount`, `ApplicationUser`, `ProjectGroup`, `Customer`, `Budget`, `PermissionAuthorizationHandler`, `BankReconciliation`, `Seeding — GENERALIZADO (base para futuras entidades/fases)`, `History`, `DocumentType`, `YearEndClosingEntry`, `Product`, `IEntityTypeConfiguration`, `ICurrentUserService`, `BankTransactionType`, `.AddInfrastructureServices`, `.OnModelCreating`?**
  _High betweenness centrality (0.066) - this node is a cross-community bridge._
- **What connects `ApiKeyAuthenticationDefaults`, `HeaderName`, `ClaimName` to the rest of the system?**
  _907 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Countify.Application.Wrappers` be split into smaller, more focused modules?**
  _Cohesion score 0.10223835450695705 - nodes in this community are weakly interconnected._
- **Should `UpdateCompanySettingsCommand` be split into smaller, more focused modules?**
  _Cohesion score 0.09090909090909091 - nodes in this community are weakly interconnected._
- **Should `CountifyDbContext` be split into smaller, more focused modules?**
  _Cohesion score 0.06050420168067227 - nodes in this community are weakly interconnected._