# Graph Report - Countify  (2026-10-15)

## Corpus Check
- 415 files · ~75,967 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 2, .user 1)

## Summary
- 4050 nodes · 7853 edges · 264 communities (225 shown, 39 thin omitted)
- Extraction: 95% EXTRACTED · 5% INFERRED · 0% AMBIGUOUS · INFERRED: 360 edges (avg confidence: 0.86)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `e2e286a0`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- Countify.Domain.Interfaces
- CatalogSeeder
- UpdateCompanySettingsCommand
- CountifyDbContext
- UpdateDepartmentCommand
- PaginatedResponse
- Countify.Domain.Entities.Accounting
- UpdateProductCommand
- Response
- CustomerTypeDto
- JournalEntry
- JournalEntriesController
- UpdateAccountsReceivableConceptCommand
- IRequest
- .AddApiServices
- UpdateProjectCommand
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
- IContainer
- UpdateJournalEntryCommand
- JournalEntryLineDto
- CreateAccountCommand
- Countify.Domain.Entities.AccountsReceivable
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
- CustomerType
- .Delete
- CreateCustomerCommand
- .SaveChangesAsync
- Budget
- Countify.Domain.Enums
- DocumentTypeDto
- CustomerMovementDto
- GetProjectGroupsQueryHandler
- http
- JournalEntryLineRequest
- .CreateOrUpdatePostingAsync
- UsersController
- Countify.Infrastructure.Persistence
- PermissionService
- AccountsController
- AccountingPeriodDto
- CreateAccountsReceivableConceptCommand
- AccountsReceivableDocumentDto
- GetUserByIdQueryHandler
- GetAccountsReceivableDocumentAttachmentQuery
- BankReconciliation
- AccountsReceivableDocument
- GetProjectsQuery
- GetIncomeStatementQuery
- UpdateAccountCommand
- UpdateRolePermissionsCommand
- UploadAccountsReceivableDocumentAttachmentCommand
- CustomerDto
- AccountsReceivableDocumentAttachment
- UpdateAccountsReceivableDocumentCommand
- UpdateCustomerCommand
- FiscalControlDto
- Countify.Domain.Common
- GetJournalEntriesQuery
- UpdateQualityCommand
- RoleDto
- RolesController.cs
- InitialCreate
- Program.cs
- Countify.Domain.Seeders
- Permisos (patrón de futuras fases también)
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
- .GetCurrentUser
- fluentvalidation
- ProjectGroup
- .Validate
- AccountsReceivableDocumentLineDto
- AccountsReceivableConceptDto
- AssignRoleCommand
- RequestParameter
- SeederOptions
- .OnModelCreating
- .Delete
- .Delete
- IEmailService
- ApiKeyAuthenticationHandler.cs
- .Close
- .Handle
- Migration
- .BuildSection
- CreateFiscalControlCommand
- Seeding — GENERALIZADO (base para futuras entidades/fases)
- IncomeStatementLineDto
- Currency
- .BuildModel
- CustomerMovementApplicationDto
- IncomeStatementDto
- JournalEntryStatus
- DocumentType
- CustomerTypesController.cs
- CustomerAgingDto
- BaseController
- BankTransactionType
- UpdateDocumentTypeCommand
- CreateProjectGroupCommand
- AuthController
- UserRoleHasPermissionRequirement
- AccountingPeriodsController.cs
- microsoft_aspnetcore_identity
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
- .AddInfrastructureServices
- Flujo bancario
- BudgetRequest
- DeleteJournalEntryCommand
- UpdateCustomerTypeCommand
- AccountsReceivableConceptsController.cs
- CreateDocumentTypeCommand
- DeleteFiscalControlCommand
- GetPendingAccountsReceivableDocumentsQuery
- .Delete
- IEntityTypeConfiguration
- EntryConceptType
- AccountsReceivableDocumentsController.cs
- CreateRoleCommand
- Profile
- .Delete
- AccountsReceivableDocumentAttachmentDto
- UpdateProjectGroupCommand
- DeleteAccountingPeriodCommand
- GetAccountsReceivableDocumentByIdQuery
- AccountMovementDto
- GetCustomersQueryHandler
- ISeeder
- RenameBankOpeningBalanceToBalance
- Cuentas por Cobrar (FASE 3 del roadmap maestro) — plan de cierre
- RolePermission
- FixBankCurrencyForeignKeys
- IRequestHandler
- ProjectGroupsController.cs
- UpdateAccountsReceivableDocumentLineCommand
- .ValidateAsync
- DeleteAccountsReceivableConceptCommand
- IConfigureOptions
- GetFiscalControlsQuery.cs
- .SaveChangesAsync
- CustomersController.cs
- GetAccountsReceivableDocumentsQueryHandler
- IFileStorage
- ChangePasswordCommand
- DeleteProjectGroupCommand
- Product
- LocalFileStorage
- .CreateAsync
- .ApplyOrder
- DeleteAccountsReceivableDocumentLineCommand
- GetUserInfoQueryHandler
- CompanySettingsPolicies
- DeleteAccountsReceivableDocumentAttachmentCommand
- GetFiscalControlsQueryHandler
- DeleteDocumentTypeCommand
- DeleteCustomerTypeCommand
- DeleteDepartmentCommand
- ResetPasswordRequest
- DeleteCustomerCommand
- DeleteProductCommand
- .ValidateAsync
- BudgetPolicies
- DeleteProductAccountCommand
- Countify — Convenciones del proyecto
- DeleteQualityCommand
- DeleteUserCommand
- FiscalDocumentType
- AddReceivableFiscalNotesAndAttachments
- CurrencyPolicies
- AccountingPeriodPolicies
- DepartmentPolicies
- JournalEntry
- Permissions.cs
- LocalFileStorage.cs
- ProjectPolicies
- ReportsPolicies
- FiscalControlPolicies
- HistoryPolicies
- Account
- Currency
- UserPolicies
- Department
- JournalEntry
- Project
- Account
- CompanySettings
- Currency
- Department
- JournalEntry
- Project
- IConfiguration
- MigrationBuilder
- Account
- CompanySettings
- Currency
- DbSet
- Department
- HashSet
- IdentityUserRole
- JournalEntry
- Project
- Account
- Currency
- Department
- JournalEntry
- Project

## God Nodes (most connected - your core abstractions)
1. `Response` - 270 edges
2. `IUnitOfWork` - 165 edges
3. `Countify.Domain.Interfaces` - 105 edges
4. `Countify.Domain.Entities.Accounting` - 104 edges
5. `Countify.Application.Wrappers` - 89 edges
6. `CountifyDbContext` - 81 edges
7. `UnitOfWork` - 70 edges
8. `AccountsReceivableDocument` - 62 edges
9. `AccountsReceivableDocumentDto` - 56 edges
10. `BankTransaction` - 46 edges

## Surprising Connections (you probably didn't know these)
- `4.6 Adjuntos` --references--> `AccountsReceivableDocumentAttachment`  [INFERRED]
  AccountsReceivable-Fase3-Plan.md → Countify.Domain/Entities/AccountsReceivable/AccountsReceivableDocumentAttachment.cs
- `4.8 Migración EF` --references--> `AddReceivableFiscalNotesAndAttachments`  [INFERRED]
  AccountsReceivable-Fase3-Plan.md → Countify.Infrastructure/Migrations/20261014195831_AddReceivableFiscalNotesAndAttachments.Designer.cs
- `Modelo contable (FASE 1 — corregido)` --references--> `CompanySettings`  [INFERRED]
  AGENTS.md → Countify.Domain/Entities/Accounting/CompanySettings.cs
- `1. Estado actual en Countify` --references--> `AccountsReceivablePostingFactory`  [INFERRED]
  AccountsReceivable-Fase3-Plan.md → Countify.Application/Features/AccountsReceivableDocuments/AccountsReceivablePostingFactory.cs
- `1. Estado actual en Countify` --references--> `AccountsReceivableConcept`  [INFERRED]
  AccountsReceivable-Fase3-Plan.md → Countify.Domain/Entities/AccountsReceivable/AccountsReceivableConcept.cs

## Import Cycles
- None detected.

## Communities (264 total, 39 thin omitted)

### Community 0 - "Countify.Domain.Interfaces"
Cohesion: 0.08
Nodes (12): automapper, automapper_queryableextensions, Countify.Application.Features.ProductAccounts.DTOs, Countify.Application.Features.ProductAccounts, Countify.Application.Features.AccountsReceivableDocuments.Commands.UpdateAccountsReceivableDocumentLine, Countify.Application.Extensions, Countify.Application.Wrappers, Countify.Domain.Interfaces (+4 more)

### Community 1 - "CatalogSeeder"
Cohesion: 0.35
Nodes (5): CatalogSeeder, CancellationToken, ILogger, IOptions, Task

### Community 2 - "UpdateCompanySettingsCommand"
Cohesion: 0.09
Nodes (22): UpdateCompanySettingsCommand, Address, CompanyName, DefaultDepartmentId, DefaultProjectId, Email, FiscalYear, Mobile (+14 more)

### Community 3 - "CountifyDbContext"
Cohesion: 0.04
Nodes (54): CountifyDbContext, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentAttachments, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts (+46 more)

### Community 4 - "UpdateDepartmentCommand"
Cohesion: 0.07
Nodes (37): DepartmentsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+29 more)

### Community 5 - "PaginatedResponse"
Cohesion: 0.13
Nodes (17): GetUsersQuery, GetUsersQueryHandler, CancellationToken, IdentityRole, IMapper, List, RoleManager, Task (+9 more)

### Community 6 - "Countify.Domain.Entities.Accounting"
Cohesion: 0.17
Nodes (5): Countify.Application.Features.AccountsReceivableDocuments.Commands.VoidAccountsReceivableDocument, Countify.Infrastructure.Persistence.Configurations, Countify.Domain.Entities.Accounting, microsoft_entityframeworkcore, microsoft_entityframeworkcore_metadata_builders

### Community 7 - "UpdateProductCommand"
Cohesion: 0.08
Nodes (29): ProductsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+21 more)

### Community 8 - "Response"
Cohesion: 0.05
Nodes (46): CloseAccountingPeriodCommand, Id, CloseAccountingPeriodCommandHandler, CancellationToken, Guid, Task, DeleteAccountCommand, Id (+38 more)

### Community 9 - "CustomerTypeDto"
Cohesion: 0.18
Nodes (14): CustomerTypeDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Code, Id, Name, Guid (+6 more)

### Community 10 - "JournalEntry"
Cohesion: 0.05
Nodes (40): CreateAccountingPeriodCommand, Month, CreateAccountingPeriodCommandHandler, CancellationToken, DateTime, Guid, Task, AccountingPeriod (+32 more)

### Community 11 - "JournalEntriesController"
Cohesion: 0.33
Nodes (9): JournalEntriesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 12 - "UpdateAccountsReceivableConceptCommand"
Cohesion: 0.14
Nodes (16): UpdateAccountsReceivableConceptCommand, AccountId, Description, GeneratePosting, Id, IsFiscalNote, IsInactive, IsReceipt (+8 more)

### Community 13 - "IRequest"
Cohesion: 0.10
Nodes (52): BankHandler, BankReconciliationDto, BankAccountId, BankAccountName, BookBalance, Id, IsClosed, Notes (+44 more)

### Community 14 - ".AddApiServices"
Cohesion: 0.08
Nodes (24): AccountingPeriodPolicies, AccountPolicies, AccountsReceivableConceptPolicies, BankPolicies, BudgetPolicies, CompanySettingsPolicies, AccountsReceivableDocumentPolicies, AuthorizationOptions (+16 more)

### Community 15 - "UpdateProjectCommand"
Cohesion: 0.08
Nodes (28): ProjectsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+20 more)

### Community 16 - "Repository"
Cohesion: 0.11
Nodes (20): IRepository, CancellationToken, Expression, Func, Guid, IEnumerable, IQueryable, List (+12 more)

### Community 17 - "CurrencyFeatures.cs"
Cohesion: 0.12
Nodes (26): CurrenciesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+18 more)

### Community 18 - ".HandleResult"
Cohesion: 0.26
Nodes (11): BanksController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+3 more)

### Community 19 - "Permission"
Cohesion: 0.21
Nodes (8): BankPolicies, AuthorizationOptions, Permission, Description, Id, Name, PermissionConfiguration, EntityTypeBuilder

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
Cohesion: 0.03
Nodes (57): UnitOfWork, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentAttachments, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts (+49 more)

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
Nodes (56): IUnitOfWork, AccountingPeriods, Accounts, AccountsReceivableConcepts, AccountsReceivableDocumentAttachments, AccountsReceivableDocumentLines, AccountsReceivableDocuments, BankAccounts (+48 more)

### Community 28 - "HistoryDto"
Cohesion: 0.05
Nodes (43): HistoryController, Authorize, HttpGet, IActionResult, Task, HistoryDto, Date, Entity (+35 more)

### Community 29 - "Account"
Cohesion: 0.12
Nodes (16): Account, BudgetControlled, Code, IsAuxAsset, IsAuxCxc, IsAuxCxp, IsAuxLoan, IsBankAccount (+8 more)

### Community 30 - "Countify.Infrastructure"
Cohesion: 0.08
Nodes (29): Countify.Api, net10.0, Countify.Application, net10.0, Microsoft.NET.Sdk, Countify.Domain, net10.0, Microsoft.NET.Sdk (+21 more)

### Community 31 - "AuthResponse"
Cohesion: 0.08
Nodes (28): IJwtService, IList, LoginCommand, LoginCommandHandler, CancellationToken, IdentityRole, RoleManager, Task (+20 more)

### Community 32 - "JournalEntryLine"
Cohesion: 0.08
Nodes (24): JournalEntryLine, Account, AccountId, AppliesToPayableId, AppliesToReceivableId, Concept, Credit, CustomerName (+16 more)

### Community 33 - "AccountsReceivableDocumentDraftRequest"
Cohesion: 0.12
Nodes (15): AccountsReceivableDocumentDraftRequest, Amount, AppliesTo, ConceptId, CurrencyId, CustomerId, Date, DepartmentId (+7 more)

### Community 34 - "Countify.Api.Controllers"
Cohesion: 0.08
Nodes (21): DeleteJournalEntryCommandValidator, VoidJournalEntryCommandValidator, Countify.Application.Features.Configurations.Queries.GetCompanySettings, Countify.Application.Features.JournalEntries.Commands.DeleteJournalEntry, Countify.Application.Features.JournalEntries.Queries.GetAccountMovements, Countify.Application.Features.JournalEntries.Queries.GetJournalEntries, Countify.Api.Controllers, Countify.Application.Features.Reports.Queries.GetTrialBalance (+13 more)

### Community 35 - "BankTransactionDto"
Cohesion: 0.08
Nodes (25): BankTransactionDto, Amount, AppliesToReceivableId, BankAccountId, BankAccountName, BankReconciliationId, Beneficiary, Concept (+17 more)

### Community 36 - "UserDto"
Cohesion: 0.15
Nodes (13): UserDto, CreatedAt, Email, FirstName, FullName, Id, IsActive, LastName (+5 more)

### Community 37 - "ProductAccount"
Cohesion: 0.09
Nodes (20): ProductAccount, CostAccount, CostAccountId, IncomeAccount, IncomeAccountId, InventoryAccount, InventoryAccountId, Product (+12 more)

### Community 38 - "ApiKeyAuthenticationHandler"
Cohesion: 0.10
Nodes (17): AuthenticateResult, AuthenticationHandler, AuthenticationProperties, AuthenticationSchemeOptions, ApiKeyAuthenticationHandler, IOptions, Task, ApiKeyAuthenticationOptions (+9 more)

### Community 39 - "JournalEntryDto"
Cohesion: 0.09
Nodes (22): JournalEntryDto, Code, Concept, CreditTotal, DebitTotal, DifferenceAmount, EntryNumber, Gid (+14 more)

### Community 40 - "CompanySettings"
Cohesion: 0.09
Nodes (23): CompanySettings, Address, CompanyName, DefaultDepartment, DefaultDepartmentId, DefaultProject, DefaultProjectId, Email (+15 more)

### Community 42 - "UpdateJournalEntryCommand"
Cohesion: 0.15
Nodes (13): UpdateJournalEntryCommand, Code, Concept, Id, Lines, Observations, PeriodId, Reference (+5 more)

### Community 43 - "JournalEntryLineDto"
Cohesion: 0.10
Nodes (19): JournalEntryLineDto, AccountCode, AccountId, AccountName, AppliesToPayableId, AppliesToReceivableId, Concept, Credit (+11 more)

### Community 44 - "CreateAccountCommand"
Cohesion: 0.12
Nodes (18): CreateAccountCommand, BudgetControlled, BudgetLine, Code, IsAuxAsset, IsAuxCxc, IsAuxCxp, IsAuxLoan (+10 more)

### Community 45 - "Countify.Domain.Entities.AccountsReceivable"
Cohesion: 0.08
Nodes (16): AccountsReceivableConceptProfile, CustomerProfile, CustomerTypeProfile, countify_domain_common, countify_domain_entities_audit, countify_domain_entities_auth, Countify.Infrastructure.Persistence.Services, Countify.Application.Features.CustomerTypes.DTOs (+8 more)

### Community 46 - "AccountDto"
Cohesion: 0.08
Nodes (25): AccountDto, Balance, BudgetControlled, BudgetLine, Code, Id, IsAuxAsset, IsAuxCxc (+17 more)

### Community 47 - "BankAccountDto"
Cohesion: 0.11
Nodes (19): BankAccountDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, AccountNumber, Balance, CheckNumber, Code (+11 more)

### Community 48 - "CreateJournalEntryCommand"
Cohesion: 0.14
Nodes (17): CreateJournalEntryCommand, Code, Concept, Lines, Observations, PeriodId, Reference, ReferenceDate (+9 more)

### Community 49 - "BankAccount"
Cohesion: 0.09
Nodes (21): BankAccount, AccountingAccount, AccountingAccountId, AccountNumber, Balance, CheckNumber, Code, CurrencyId (+13 more)

### Community 50 - "ApplicationUser"
Cohesion: 0.07
Nodes (31): CreateUserCommand, Email, FirstName, LastName, Password, Phone, RoleId, Username (+23 more)

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
Cohesion: 0.09
Nodes (24): ProductAccountDto, CostAccountCode, CostAccountId, CostAccountName, Id, IncomeAccountCode, IncomeAccountId, IncomeAccountName (+16 more)

### Community 55 - "GetRoleByIdQueryHandler"
Cohesion: 0.14
Nodes (15): PermissionDto, Description, Id, Name, RoleDetailDto, Permissions, IList, GetRoleByIdQuery (+7 more)

### Community 56 - "CustomerType"
Cohesion: 0.33
Nodes (5): CustomerType, BasicCustomerTypes, Items, CustomerTypeConfiguration, EntityTypeBuilder

### Community 57 - ".Delete"
Cohesion: 0.28
Nodes (9): AccountsReceivableConceptsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 58 - "CreateCustomerCommand"
Cohesion: 0.12
Nodes (18): CreateCustomerCommand, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId, Email (+10 more)

### Community 59 - ".SaveChangesAsync"
Cohesion: 0.18
Nodes (7): BaseEntity, CancellationToken, History, List, Task, CancellationToken, Task

### Community 60 - "Budget"
Cohesion: 0.13
Nodes (13): BudgetLine, Budget, FiscalYear, Lines, Name, List, BasicBudgets, Items (+5 more)

### Community 61 - "Countify.Domain.Enums"
Cohesion: 0.14
Nodes (8): JournalEntryProfile, Countify.Application.Features.JournalEntries.Commands.CreateJournalEntry, Countify.Application.Features.JournalEntries.DTOs, Countify.Application.Features.JournalEntries.Profiles, Countify.Application.Features.AccountsReceivableDocuments, Countify.Application.Features.JournalEntries, Countify.Domain.Enums, Countify.Application.Features.JournalEntries.Commands.UpdateJournalEntry

### Community 62 - "DocumentTypeDto"
Cohesion: 0.22
Nodes (12): DocumentTypeDto, Code, Id, IsDefault, Name, Guid, GetDocumentTypesQuery, GetDocumentTypesQueryHandler (+4 more)

### Community 63 - "CustomerMovementDto"
Cohesion: 0.10
Nodes (21): CustomerMovementDto, AgingBucket, Amount, AmountLocal, Applications, AppliedAmount, ConceptDescription, Credit (+13 more)

### Community 64 - "GetProjectGroupsQueryHandler"
Cohesion: 0.18
Nodes (12): ProjectGroupDto, Code, Id, Name, Guid, GetProjectGroupsQuery, GetProjectGroupsQueryHandler, CancellationToken (+4 more)

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
Cohesion: 0.37
Nodes (7): Countify.Infrastructure.Migrations, Countify.Infrastructure.Persistence, microsoft_entityframeworkcore_infrastructure, microsoft_entityframeworkcore_metadata, microsoft_entityframeworkcore_migrations, microsoft_entityframeworkcore_storage_valueconversion, system

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
Cohesion: 0.17
Nodes (15): CreateAccountsReceivableConceptCommand, AccountId, Description, GeneratePosting, IsFiscalNote, IsInactive, IsReceipt, Observations (+7 more)

### Community 74 - "AccountsReceivableDocumentDto"
Cohesion: 0.05
Nodes (43): AccountsReceivableDocumentDto, Amount, AmountLocal, AppliesTo, Attachments, CAI, ConceptDescription, ConceptId (+35 more)

### Community 75 - "GetUserByIdQueryHandler"
Cohesion: 0.18
Nodes (13): UserDetailDto, CreatedBy, LastActivity, DateTime, GetUserByIdQuery, Id, GetUserByIdQueryHandler, CancellationToken (+5 more)

### Community 76 - "GetAccountsReceivableDocumentAttachmentQuery"
Cohesion: 0.20
Nodes (12): AccountsReceivableDocumentAttachmentContentDto, Content, ContentType, FileName, Stream, GetAccountsReceivableDocumentAttachmentQuery, Id, GetAccountsReceivableDocumentAttachmentQueryHandler (+4 more)

### Community 77 - "BankReconciliation"
Cohesion: 0.13
Nodes (14): BankReconciliation, BankAccount, BankAccountId, BookBalance, IsClosed, Notes, ReconciliationDate, StatementBalance (+6 more)

### Community 78 - "AccountsReceivableDocument"
Cohesion: 0.04
Nodes (46): 2. Decisión de modelado (validada contra el legacy), Mapeo campo a campo (CXCDocumentos → AccountsReceivableDocument), AccountsReceivableDocument, Amount, AppliesTo, Attachments, CAI, Concept (+38 more)

### Community 79 - "GetProjectsQuery"
Cohesion: 0.20
Nodes (13): ProjectDto, Code, GroupId, Id, Name, Guid, GetProjectsQuery, Search (+5 more)

### Community 80 - "GetIncomeStatementQuery"
Cohesion: 0.19
Nodes (11): GetIncomeStatementQuery, Date, DepartmentId, ProjectId, GetIncomeStatementQueryHandler, CancellationToken, DateTime, Guid (+3 more)

### Community 81 - "UpdateAccountCommand"
Cohesion: 0.13
Nodes (15): UpdateAccountCommand, BudgetControlled, BudgetLine, Code, Id, IsAuxAsset, IsAuxCxc, IsAuxCxp (+7 more)

### Community 82 - "UpdateRolePermissionsCommand"
Cohesion: 0.15
Nodes (17): RolesController, Authorize, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult, Task (+9 more)

### Community 83 - "UploadAccountsReceivableDocumentAttachmentCommand"
Cohesion: 0.20
Nodes (13): UploadAccountsReceivableDocumentAttachmentCommand, Content, ContentType, DocumentId, FileName, Size, UploadedBy, UploadAccountsReceivableDocumentAttachmentCommandHandler (+5 more)

### Community 84 - "CustomerDto"
Cohesion: 0.11
Nodes (19): CustomerDto, AccountingAccountCode, AccountingAccountId, AccountingAccountName, Address, Code, CreditDays, CreditLimit (+11 more)

### Community 85 - "AccountsReceivableDocumentAttachment"
Cohesion: 0.14
Nodes (14): BaseEntity, AccountsReceivableDocumentAttachment, ContentType, Document, DocumentId, FileName, Size, StoragePath (+6 more)

### Community 86 - "UpdateAccountsReceivableDocumentCommand"
Cohesion: 0.09
Nodes (24): UpdateAccountsReceivableDocumentCommand, Amount, AppliesTo, ConceptId, CreditNoteReason, CurrencyId, CustomerId, Date (+16 more)

### Community 87 - "UpdateCustomerCommand"
Cohesion: 0.11
Nodes (19): UpdateCustomerCommand, AccountingAccountId, Address, Code, CreditDays, CreditLimit, CustomerTypeId, Email (+11 more)

### Community 88 - "FiscalControlDto"
Cohesion: 0.11
Nodes (18): FiscalControlDto, Branch, CAI, DocumentCode, DocumentType, DocumentTypeName, EmissionDate, EmissionLimitDate (+10 more)

### Community 89 - "Countify.Domain.Common"
Cohesion: 0.07
Nodes (19): BaseEntity, Id, Guid, OrderColumns, Ascending, Descending, Currency, Code (+11 more)

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
Cohesion: 0.17
Nodes (8): CreateRoleCommandValidator, DeleteRoleCommandValidator, UpdateRoleCommandValidator, Countify.Application.Features.Roles.Commands.UpdateRole, Countify.Application.Features.Roles.Queries.GetRoles, Countify.Application.Features.Roles.Commands.DeleteRole, Countify.Application.Features.Roles.Queries.GetRoleById, Countify.Application.Features.Roles.Commands.CreateRole

### Community 94 - "InitialCreate"
Cohesion: 0.18
Nodes (9): DateTime, DateTimeOffset, Guid, MigrationBuilder, InitialCreate, DateTime, DateTimeOffset, Guid (+1 more)

### Community 95 - "Program.cs"
Cohesion: 0.17
Nodes (9): ApplicationServiceRegistration, IServiceCollection, Countify.Application.DependencyInjection, Countify.Infrastructure.Extensions, Countify.Infrastructure.DependencyInjection, microsoft_extensions_dependencyinjection, quick_autoinject_dependencyannotation, scalar_aspnetcore (+1 more)

### Community 96 - "Countify.Domain.Seeders"
Cohesion: 0.20
Nodes (8): BasicProjectGroups, Items, Guid, Countify.Domain.Seeders, Countify.Infrastructure.Seeders, microsoft_extensions_hosting, microsoft_extensions_logging, system_linq

### Community 97 - "Permisos (patrón de futuras fases también)"
Cohesion: 0.15
Nodes (12): Permisos (patrón de futuras fases también), countify_api_authorization_handlers, AccountPolicies, AuthorizationOptions, DocumentTypePolicies, AuthorizationOptions, JournalEntryPolicies, AuthorizationOptions (+4 more)

### Community 98 - "YearEndClosingEntry"
Cohesion: 0.18
Nodes (9): YearEndClosingEntry, GeneratedBy, JournalEntryId, PeriodId, Guid, BasicYearEndClosingEntries, Items, YearEndClosingEntryConfiguration (+1 more)

### Community 99 - "AddAccountingModule"
Cohesion: 0.20
Nodes (8): DateTime, Guid, MigrationBuilder, AddAccountingModule, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 100 - "AddBanksAndBankReconciliation"
Cohesion: 0.20
Nodes (8): DateTime, Guid, MigrationBuilder, AddBanksAndBankReconciliation, DateTime, DateTimeOffset, Guid, ModelBuilder

### Community 101 - "DepartmentsController.cs"
Cohesion: 0.22
Nodes (6): CreateDepartmentCommandValidator, UpdateDepartmentCommandValidator, Countify.Application.Features.Departments.Commands.UpdateDepartment, Countify.Application.Features.Departments.Commands.CreateDepartment, Countify.Application.Features.Departments.Queries.GetDepartments, Countify.Application.Features.Departments.Commands.DeleteDepartment

### Community 102 - "GetAccountsQuery"
Cohesion: 0.36
Nodes (8): GetAccountsQuery, IsOperable, Search, GetAccountsQueryHandler, CancellationToken, IMapper, List, Task

### Community 103 - "AccountsReceivableConcept"
Cohesion: 0.11
Nodes (18): AccountsReceivableConcept, Account, AccountId, Description, GeneratePosting, IsFiscalNote, IsInactive, IsReceipt (+10 more)

### Community 104 - "CreateAccountsReceivableDocumentCommand"
Cohesion: 0.10
Nodes (23): CreateAccountsReceivableDocumentCommand, Amount, AppliesTo, ConceptId, CreditNoteReason, CurrencyId, CustomerId, Date (+15 more)

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
Nodes (22): UpdateFiscalControlCommand, Branch, CAI, DocumentCode, DocumentType, EmissionDate, EmissionLimitDate, EmissionPoint (+14 more)

### Community 110 - "UpdateRoleCommand"
Cohesion: 0.25
Nodes (8): UpdateRoleCommand, Id, Name, UpdateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 111 - "AccountsReceivableDocumentsController"
Cohesion: 0.22
Nodes (13): AccountsReceivableDocumentsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+5 more)

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
Cohesion: 0.04
Nodes (41): AbstractValidator, CreateAccountCommandValidator, DeleteAccountCommandValidator, UpdateAccountCommandValidator, CreateAccountsReceivableDocumentCommandValidator, UpdateAccountsReceivableDocumentCommandValidator, CreateAccountsReceivableDocumentLinesCommandValidator, ForgotPasswordCommandValidator (+33 more)

### Community 117 - "ProjectGroup"
Cohesion: 0.11
Nodes (16): Project, Project, Code, Group, GroupId, Name, Guid, ProjectGroup (+8 more)

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

### Community 123 - "SeederOptions"
Cohesion: 0.18
Nodes (9): SeederOptions, Enabled, SeedConfiguration, SeedTransactions, ConfigurationSeeder, CancellationToken, ILogger, IOptions (+1 more)

### Community 124 - ".OnModelCreating"
Cohesion: 0.22
Nodes (8): ApplicationUser, IdentityRole, ModelBuilder, IdentityRoleClaim, IdentityUserClaim, IdentityUserLogin, IdentityUserRole, IdentityUserToken

### Community 125 - ".Delete"
Cohesion: 0.28
Nodes (9): ProjectGroupsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 126 - ".Delete"
Cohesion: 0.28
Nodes (9): DocumentTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 127 - "IEmailService"
Cohesion: 0.33
Nodes (4): IEmailService, Task, EmailService, Task

### Community 128 - "ApiKeyAuthenticationHandler.cs"
Cohesion: 0.15
Nodes (9): AuthorizeAttribute, ApiKeyAuthenticationDefaults, ApiKeyAttribute, Countify.Api.Authorization.Handlers, Countify.Api.ApiKeyAuthentication, microsoft_aspnetcore_authentication, microsoft_extensions_primitives, system_security_claims (+1 more)

### Community 129 - ".Close"
Cohesion: 0.33
Nodes (8): AccountingPeriodsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, IActionResult, Task

### Community 130 - ".Handle"
Cohesion: 0.16
Nodes (11): UpdateJournalEntryCommandHandler, CancellationToken, IMapper, List, Task, JournalEntryAuxValidator, CancellationToken, Guid (+3 more)

### Community 131 - "Migration"
Cohesion: 0.20
Nodes (8): Guid, MigrationBuilder, AddBudgetsAndBudgetPermissions, DateTime, DateTimeOffset, Guid, ModelBuilder, Migration

### Community 132 - ".BuildSection"
Cohesion: 0.22
Nodes (9): IncomeStatementSectionDto, Code, Lines, Name, Total, List, Dictionary, List (+1 more)

### Community 133 - "CreateFiscalControlCommand"
Cohesion: 0.11
Nodes (21): CreateFiscalControlCommand, Branch, CAI, DocumentCode, DocumentType, EmissionDate, EmissionLimitDate, EmissionPoint (+13 more)

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

### Community 141 - "DocumentType"
Cohesion: 0.18
Nodes (9): 4.2 Nueva entidad `FiscalControl` (← `ControlesFiscales`), DocumentType, Code, IsDefault, Name, BasicDocumentTypes, Items, DocumentTypeConfiguration (+1 more)

### Community 142 - "CustomerTypesController.cs"
Cohesion: 0.22
Nodes (6): CreateCustomerTypeCommandValidator, UpdateCustomerTypeCommandValidator, Countify.Application.Features.CustomerTypes.Commands.DeleteCustomerType, Countify.Application.Features.CustomerTypes.Commands.UpdateCustomerType, Countify.Application.Features.CustomerTypes.Commands.CreateCustomerType, Countify.Application.Features.CustomerTypes.Queries.GetCustomerTypes

### Community 143 - "CustomerAgingDto"
Cohesion: 0.18
Nodes (11): CustomerAgingBucketDto, Amount, Key, Label, CustomerAgingDto, AsOfDate, Buckets, Details (+3 more)

### Community 144 - "BaseController"
Cohesion: 0.15
Nodes (15): ControllerBase, BaseController, Mediator, ReportsController, Authorize, HttpGet, IActionResult, Task (+7 more)

### Community 145 - "BankTransactionType"
Cohesion: 0.18
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

### Community 149 - "UserRoleHasPermissionRequirement"
Cohesion: 0.20
Nodes (10): AuthorizationHandler, AuthorizationHandlerContext, PermissionAuthorizationHandler, Task, CustomerPolicies, AuthorizationOptions, UserRoleHasPermissionRequirement, Permission (+2 more)

### Community 150 - "AccountingPeriodsController.cs"
Cohesion: 0.18
Nodes (7): CloseAccountingPeriodCommandValidator, CreateAccountingPeriodCommandValidator, DeleteAccountingPeriodCommandValidator, Countify.Application.Features.AccountingPeriods.Commands.DeleteAccountingPeriod, Countify.Application.Features.AccountingPeriods.Queries.GetAccountingPeriods, Countify.Application.Features.AccountingPeriods.Commands.CloseAccountingPeriod, Countify.Application.Features.AccountingPeriods.Commands.CreateAccountingPeriod

### Community 151 - "microsoft_aspnetcore_identity"
Cohesion: 0.06
Nodes (29): ForgotPasswordRequest, Email, LoginRequest, Password, Username, RefreshTokenRequest, AccessToken, RefreshToken (+21 more)

### Community 152 - "CreateAccountsReceivableDocumentLinesCommand"
Cohesion: 0.18
Nodes (12): CreateAccountsReceivableDocumentLinesCommand, DocumentId, Lines, CreateAccountsReceivableDocumentLinesCommandHandler, LineItem, Amount, AppliedDocumentId, CancellationToken (+4 more)

### Community 153 - "microsoft_aspnetcore_authorization"
Cohesion: 0.28
Nodes (6): countify_api_authorization_requirements, Countify.Domain.Authorization, Countify.Api.Authorization.Requirements, Countify.Api.Authorization.Policies, microsoft_aspnetcore_authorization, microsoft_extensions_options

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
Cohesion: 0.10
Nodes (23): ProductAccountsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+15 more)

### Community 160 - "TransactionSeeder"
Cohesion: 0.47
Nodes (5): TransactionSeeder, CancellationToken, ILogger, IOptions, Task

### Community 161 - "CustomerMovementsDto"
Cohesion: 0.18
Nodes (11): CustomerMovementsDto, Aging, CustomerCode, CustomerId, CustomerName, FromDate, Movements, Saldo (+3 more)

### Community 162 - "GetCustomerMovementsQuery"
Cohesion: 0.27
Nodes (10): GetCustomerMovementsQuery, CustomerId, FromDate, ToDate, GetCustomerMovementsQueryHandler, CancellationToken, DateTime, Guid (+2 more)

### Community 163 - ".AddInfrastructureServices"
Cohesion: 0.20
Nodes (9): CatalogSeeder, ConfigurationSeeder, ApplicationUser, IdentityRole, IServiceCollection, IConfiguration, ISeeder, SeederOptions (+1 more)

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
Cohesion: 0.22
Nodes (6): CreateAccountsReceivableConceptCommandValidator, UpdateAccountsReceivableConceptCommandValidator, Countify.Application.Features.AccountsReceivableConcepts.Commands.DeleteAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Commands.CreateAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Commands.UpdateAccountsReceivableConcept, Countify.Application.Features.AccountsReceivableConcepts.Queries.GetAccountsReceivableConcepts

### Community 169 - "CreateDocumentTypeCommand"
Cohesion: 0.27
Nodes (9): CreateDocumentTypeCommand, Code, IsDefault, Name, CreateDocumentTypeCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 170 - "DeleteFiscalControlCommand"
Cohesion: 0.29
Nodes (8): DeleteFiscalControlCommand, Id, DeleteFiscalControlCommandHandler, CancellationToken, Guid, Response, Task, Countify.Application.Features.FiscalControls.Commands.DeleteFiscalControl

### Community 171 - "GetPendingAccountsReceivableDocumentsQuery"
Cohesion: 0.27
Nodes (9): GetPendingAccountsReceivableDocumentsQuery, CustomerId, ExcludeDocumentIds, GetPendingAccountsReceivableDocumentsQueryHandler, CancellationToken, Guid, IMapper, List (+1 more)

### Community 172 - ".Delete"
Cohesion: 0.28
Nodes (9): CustomerTypesController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut, IActionResult (+1 more)

### Community 173 - "IEntityTypeConfiguration"
Cohesion: 0.12
Nodes (16): AccountsReceivableDocumentLine, Amount, AppliedDocument, AppliedDocumentId, Document, DocumentId, Guid, AccountsReceivableDocumentLineConfiguration (+8 more)

### Community 174 - "EntryConceptType"
Cohesion: 0.40
Nodes (4): EntryConceptType, Credit, Debit, Other

### Community 175 - "AccountsReceivableDocumentsController.cs"
Cohesion: 0.09
Nodes (18): countify_application_features_accountsreceivabledocuments_commands_createaccountsreceivabledocumentlines, countify_application_features_accountsreceivabledocuments_commands_deleteaccountsreceivabledocumentline, countify_application_features_accountsreceivabledocuments_commands_updateaccountsreceivabledocumentline, countify_application_features_accountsreceivabledocuments_commands_voidaccountsreceivabledocument, AccountsReceivableDocumentProfile, countify_application_features_accountsreceivabledocuments_queries_getaccountsreceivabledocuments, countify_application_features_accountsreceivabledocuments_queries_getpendingaccountsreceivabledocuments, countify_application_wrappers (+10 more)

### Community 176 - "CreateRoleCommand"
Cohesion: 0.29
Nodes (7): CreateRoleCommand, Name, CreateRoleCommandHandler, CancellationToken, IdentityRole, RoleManager, Task

### Community 177 - "Profile"
Cohesion: 0.04
Nodes (34): AccountingPeriodProfile, AccountProfile, BankAccountProfile, SettingsProfile, CurrencyProfile, DepartmentProfile, DocumentTypeProfile, ProductAccountProfile (+26 more)

### Community 178 - ".Delete"
Cohesion: 0.25
Nodes (10): BaseController, FiscalControlsController, Authorize, Guid, HttpDelete, HttpGet, HttpPost, HttpPut (+2 more)

### Community 179 - "AccountsReceivableDocumentAttachmentDto"
Cohesion: 0.18
Nodes (10): AccountsReceivableDocumentAttachmentDto, ContentType, DocumentId, FileName, Id, Size, UploadedBy, UploadedOn (+2 more)

### Community 180 - "UpdateProjectGroupCommand"
Cohesion: 0.22
Nodes (9): UpdateProjectGroupCommand, Code, Id, Name, UpdateProjectGroupCommandHandler, CancellationToken, Guid, IMapper (+1 more)

### Community 181 - "DeleteAccountingPeriodCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountingPeriodCommand, Id, DeleteAccountingPeriodCommandHandler, CancellationToken, Guid, Task

### Community 182 - "GetAccountsReceivableDocumentByIdQuery"
Cohesion: 0.31
Nodes (8): GetAccountsReceivableDocumentByIdQuery, Id, GetAccountsReceivableDocumentByIdQueryHandler, CancellationToken, Guid, IMapper, Response, Task

### Community 183 - "AccountMovementDto"
Cohesion: 0.18
Nodes (10): AccountMovementDto, Balance, Concept, Credit, Debit, EntryNumber, JournalEntryId, ReferenceDate (+2 more)

### Community 184 - "GetCustomersQueryHandler"
Cohesion: 0.43
Nodes (6): GetCustomersQuery, GetCustomersQueryHandler, CancellationToken, IMapper, List, Task

### Community 185 - "ISeeder"
Cohesion: 0.22
Nodes (7): ISeeder, CancellationToken, Task, DatabaseExtensions, IEnumerable, ILogger, IHost

### Community 186 - "RenameBankOpeningBalanceToBalance"
Cohesion: 0.22
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
Cohesion: 0.11
Nodes (18): UpdateAccountCommandHandler, CancellationToken, IMapper, Task, ForgotPasswordCommand, ForgotPasswordCommandHandler, CancellationToken, Task (+10 more)

### Community 191 - "ProjectGroupsController.cs"
Cohesion: 0.11
Nodes (13): CreateProjectCommandValidator, CreateProjectGroupCommandValidator, DeleteProjectCommandValidator, UpdateProjectCommandValidator, ProjectProfile, Countify.Application.Features.Projects.Queries.GetProjects, Countify.Application.Features.Projects.Commands.UpdateProject, Countify.Application.Features.Projects.Profiles (+5 more)

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
Cohesion: 0.21
Nodes (9): AccountsReceivableConceptPolicies, AuthorizationOptions, CustomerTypePolicies, AuthorizationOptions, ProductAccountPolicies, AuthorizationOptions, RolePolicies, AuthorizationOptions (+1 more)

### Community 196 - "GetFiscalControlsQuery.cs"
Cohesion: 0.33
Nodes (3): FiscalControlProfile, Countify.Application.Features.FiscalControls.Profiles, Countify.Application.Features.FiscalControls.DTOs

### Community 197 - ".SaveChangesAsync"
Cohesion: 0.21
Nodes (10): UpdateReceiptNumberCommand, Id, ReceiptNumber, UpdateReceiptNumberCommandHandler, CancellationToken, Guid, Response, Task (+2 more)

### Community 198 - "CustomersController.cs"
Cohesion: 0.22
Nodes (6): CreateCustomerCommandValidator, UpdateCustomerCommandValidator, Countify.Application.Features.Customers.Commands.DeleteCustomer, Countify.Application.Features.Customers.Queries.GetCustomers, Countify.Application.Features.Customers.Commands.UpdateCustomer, Countify.Application.Features.Customers.Commands.CreateCustomer

### Community 199 - "GetAccountsReceivableDocumentsQueryHandler"
Cohesion: 0.43
Nodes (6): GetAccountsReceivableDocumentsQuery, GetAccountsReceivableDocumentsQueryHandler, CancellationToken, IMapper, List, Task

### Community 200 - "IFileStorage"
Cohesion: 0.36
Nodes (4): IFileStorage, CancellationToken, Stream, Task

### Community 201 - "ChangePasswordCommand"
Cohesion: 0.25
Nodes (8): ChangePasswordCommand, CurrentPassword, Id, NewPassword, ChangePasswordCommandHandler, CancellationToken, Task, UserManager

### Community 202 - "DeleteProjectGroupCommand"
Cohesion: 0.28
Nodes (7): DeleteProjectGroupCommand, Id, DeleteProjectGroupCommandHandler, CancellationToken, Guid, Task, Countify.Application.Features.Projects.Commands.DeleteProjectGroup

### Community 203 - "Product"
Cohesion: 0.25
Nodes (6): Product, Code, Name, BasicProducts, ProductConfiguration, EntityTypeBuilder

### Community 204 - "LocalFileStorage"
Cohesion: 0.44
Nodes (4): LocalFileStorage, CancellationToken, Stream, Task

### Community 205 - ".CreateAsync"
Cohesion: 0.19
Nodes (8): AccountsReceivableDocumentDraftRequest, DraftCreationResult, CancellationToken, Task, FiscalNoteNumberingFactory, CancellationToken, FiscalControl, Task

### Community 206 - ".ApplyOrder"
Cohesion: 0.46
Nodes (5): QueryableExtensions, Dictionary, Expression, Func, IQueryable

### Community 207 - "DeleteAccountsReceivableDocumentLineCommand"
Cohesion: 0.33
Nodes (6): DeleteAccountsReceivableDocumentLineCommand, Id, DeleteAccountsReceivableDocumentLineCommandHandler, CancellationToken, Guid, Task

### Community 208 - "GetUserInfoQueryHandler"
Cohesion: 0.14
Nodes (15): UserInfoResponse, Email, FullName, Permissions, Roles, UserId, UserName, IList (+7 more)

### Community 210 - "DeleteAccountsReceivableDocumentAttachmentCommand"
Cohesion: 0.36
Nodes (7): DeleteAccountsReceivableDocumentAttachmentCommand, Id, DeleteAccountsReceivableDocumentAttachmentCommandHandler, CancellationToken, Guid, Response, Task

### Community 211 - "GetFiscalControlsQueryHandler"
Cohesion: 0.43
Nodes (7): GetFiscalControlsQuery, GetFiscalControlsQueryHandler, CancellationToken, IMapper, List, Response, Task

### Community 212 - "DeleteDocumentTypeCommand"
Cohesion: 0.33
Nodes (6): DeleteDocumentTypeCommand, Id, DeleteDocumentTypeCommandHandler, CancellationToken, Guid, Task

### Community 213 - "DeleteCustomerTypeCommand"
Cohesion: 0.33
Nodes (6): DeleteCustomerTypeCommand, Id, DeleteCustomerTypeCommandHandler, CancellationToken, Guid, Task

### Community 214 - "DeleteDepartmentCommand"
Cohesion: 0.33
Nodes (6): DeleteDepartmentCommand, Id, DeleteDepartmentCommandHandler, CancellationToken, Guid, Task

### Community 215 - "ResetPasswordRequest"
Cohesion: 0.40
Nodes (4): ResetPasswordRequest, Email, NewPassword, Token

### Community 216 - "DeleteCustomerCommand"
Cohesion: 0.33
Nodes (6): DeleteCustomerCommand, Id, DeleteCustomerCommandHandler, CancellationToken, Guid, Task

### Community 217 - "DeleteProductCommand"
Cohesion: 0.28
Nodes (7): DeleteProductCommand, Id, DeleteProductCommandHandler, CancellationToken, Guid, Task, Countify.Application.Features.Products.Commands.DeleteProduct

### Community 218 - ".ValidateAsync"
Cohesion: 0.29
Nodes (6): BudgetAvailabilityValidator, CancellationToken, DateTime, Guid, IEnumerable, Task

### Community 220 - "DeleteProductAccountCommand"
Cohesion: 0.33
Nodes (6): DeleteProductAccountCommand, Id, DeleteProductAccountCommandHandler, CancellationToken, Guid, Task

### Community 221 - "Countify — Convenciones del proyecto"
Cohesion: 0.33
Nodes (5): Arquitectura / capas, Contrato API (FASE 1), Countify — Convenciones del proyecto, Flujo de trabajo (obligatorio), Modelo contable (FASE 1 — corregido)

### Community 222 - "DeleteQualityCommand"
Cohesion: 0.33
Nodes (6): DeleteQualityCommand, Id, DeleteQualityCommandHandler, CancellationToken, Guid, Task

### Community 223 - "DeleteUserCommand"
Cohesion: 0.33
Nodes (6): DeleteUserCommand, Id, DeleteUserCommandHandler, CancellationToken, Task, UserManager

### Community 224 - "FiscalDocumentType"
Cohesion: 0.29
Nodes (6): FiscalDocumentType, CreditNote, DebitNote, DispatchGuide, Invoicing, Retention

### Community 225 - "AddReceivableFiscalNotesAndAttachments"
Cohesion: 0.20
Nodes (8): DateTime, Guid, AddReceivableFiscalNotesAndAttachments, DateTime, DateTimeOffset, Guid, ModelBuilder, MigrationBuilder

### Community 229 - "JournalEntry"
Cohesion: 0.40
Nodes (5): JournalEntry, BasicJournalEntries, Items, JournalEntryConfiguration, EntityTypeBuilder

### Community 230 - "Permissions.cs"
Cohesion: 0.40
Nodes (4): Permissions, Items, Permission, system_reflection

### Community 231 - "LocalFileStorage.cs"
Cohesion: 0.40
Nodes (3): FileStorageOptions, RootPath, Countify.Infrastructure.Storage

## Knowledge Gaps
- **1297 isolated node(s):** `3. Decisiones tomadas`, `4.5 Conceptos (seeder)`, `4.7 Permisos`, `5. Frontend (Angular, `Countify-PanelUser`)`, `7. Consultas/Reportes` (+1292 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 2163 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **39 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Response` connect `Response` to `UpdateCompanySettingsCommand`, `.Handle`, `UpdateDepartmentCommand`, `PaginatedResponse`, `UpdateProductCommand`, `CustomerTypeDto`, `JournalEntry`, `IRequest`, `UpdateProjectCommand`, `CurrencyFeatures.cs`, `.HandleResult`, `UpdateDocumentTypeCommand`, `CreateProjectGroupCommand`, `GetTrialBalanceQuery`, `CompanySettingsDto`, `CreateAccountsReceivableDocumentLinesCommand`, `AccountMovementsResponse`, `HistoryDto`, `CreateCustomerTypeCommand`, `AuthResponse`, `UpdateProductAccountCommand`, `DeleteJournalEntryCommand`, `UpdateCustomerTypeCommand`, `CreateDocumentTypeCommand`, `UpdateJournalEntryCommand`, `GetPendingAccountsReceivableDocumentsQuery`, `CreateAccountCommand`, `AccountDto`, `CreateJournalEntryCommand`, `CreateRoleCommand`, `ApplicationUser`, `BudgetsController`, `CreateProductCommand`, `DeleteAccountingPeriodCommand`, `UpdateProjectGroupCommand`, `GetRoleByIdQueryHandler`, `GetCustomersQueryHandler`, `UpdateUserCommand`, `CreateCustomerCommand`, `IRequestHandler`, `DocumentTypeDto`, `UpdateAccountsReceivableDocumentLineCommand`, `GetProjectGroupsQueryHandler`, `DeleteAccountsReceivableConceptCommand`, `GetAccountsReceivableDocumentsQueryHandler`, `AccountingPeriodDto`, `ChangePasswordCommand`, `DeleteProjectGroupCommand`, `GetUserByIdQueryHandler`, `DeleteAccountsReceivableDocumentLineCommand`, `GetUserInfoQueryHandler`, `UpdateAccountCommand`, `GetIncomeStatementQuery`, `UpdateRolePermissionsCommand`, `DeleteDocumentTypeCommand`, `DeleteCustomerTypeCommand`, `DeleteDepartmentCommand`, `UpdateCustomerCommand`, `DeleteCustomerCommand`, `DeleteProductCommand`, `UpdateQualityCommand`, `DeleteProductAccountCommand`, `DeleteQualityCommand`, `DeleteUserCommand`, `GetJournalEntryByIdQuery`, `UpdateRoleCommand`, `DeleteRoleCommandHandler`, `AccountsReceivableConceptDto`, `AssignRoleCommand`?**
  _High betweenness centrality (0.218) - this node is a cross-community bridge._
- **Why does `IUnitOfWork` connect `IUnitOfWork` to `UpdateCompanySettingsCommand`, `UpdateDepartmentCommand`, `PaginatedResponse`, `UpdateProductCommand`, `Response`, `CustomerTypeDto`, `JournalEntry`, `UpdateAccountsReceivableConceptCommand`, `IRequest`, `UpdateProjectCommand`, `CurrencyFeatures.cs`, `GetTrialBalanceQuery`, `CompanySettingsDto`, `UnitOfWork`, `AccountMovementsResponse`, `HistoryDto`, `AuthResponse`, `CreateAccountCommand`, `Countify.Domain.Entities.AccountsReceivable`, `AccountDto`, `CreateJournalEntryCommand`, `BudgetsController`, `CreateProductCommand`, `ProductAccountDto`, `GetRoleByIdQueryHandler`, `CreateCustomerCommand`, `DocumentTypeDto`, `GetProjectGroupsQueryHandler`, `.CreateOrUpdatePostingAsync`, `AccountingPeriodDto`, `CreateAccountsReceivableConceptCommand`, `GetAccountsReceivableDocumentAttachmentQuery`, `AccountsReceivableDocument`, `GetProjectsQuery`, `GetIncomeStatementQuery`, `UpdateRolePermissionsCommand`, `UploadAccountsReceivableDocumentAttachmentCommand`, `AccountsReceivableDocumentAttachment`, `UpdateAccountsReceivableDocumentCommand`, `UpdateCustomerCommand`, `GetJournalEntriesQuery`, `UpdateQualityCommand`, `RoleDto`, `GetAccountsQuery`, `AccountsReceivableConcept`, `CreateAccountsReceivableDocumentCommand`, `GetJournalEntryByIdQuery`, `UpdateFiscalControlCommand`, `AccountsReceivableConceptDto`, `.Handle`, `CreateFiscalControlCommand`, `UpdateDocumentTypeCommand`, `CreateProjectGroupCommand`, `CreateAccountsReceivableDocumentLinesCommand`, `FiscalControl`, `CreateCustomerTypeCommand`, `UpdateProductAccountCommand`, `GetCustomerMovementsQuery`, `DeleteJournalEntryCommand`, `UpdateCustomerTypeCommand`, `CreateDocumentTypeCommand`, `DeleteFiscalControlCommand`, `GetPendingAccountsReceivableDocumentsQuery`, `UpdateProjectGroupCommand`, `DeleteAccountingPeriodCommand`, `GetAccountsReceivableDocumentByIdQuery`, `GetCustomersQueryHandler`, `IRequestHandler`, `UpdateAccountsReceivableDocumentLineCommand`, `.ValidateAsync`, `DeleteAccountsReceivableConceptCommand`, `.SaveChangesAsync`, `GetAccountsReceivableDocumentsQueryHandler`, `DeleteProjectGroupCommand`, `.CreateAsync`, `DeleteAccountsReceivableDocumentLineCommand`, `GetUserInfoQueryHandler`, `DeleteAccountsReceivableDocumentAttachmentCommand`, `GetFiscalControlsQueryHandler`, `DeleteDocumentTypeCommand`, `DeleteCustomerTypeCommand`, `DeleteDepartmentCommand`, `DeleteCustomerCommand`, `DeleteProductCommand`, `.ValidateAsync`, `DeleteProductAccountCommand`, `Countify — Convenciones del proyecto`, `DeleteQualityCommand`?**
  _High betweenness centrality (0.172) - this node is a cross-community bridge._
- **Why does `Countify.Domain.Entities.Accounting` connect `Countify.Domain.Entities.Accounting` to `Countify.Domain.Interfaces`, `Seeding — GENERALIZADO (base para futuras entidades/fases)`, `Currency`, `JournalEntry`, `IRequest`, `DocumentType`, `CurrencyFeatures.cs`, `BankTransactionType`, `Countify.Api.Controllers`, `ProductAccount`, `Countify.Domain.Entities.AccountsReceivable`, `AccountsReceivableDocumentsController.cs`, `Profile`, `Budget`, `Countify.Domain.Enums`, `ProjectGroupsController.cs`, `GetFiscalControlsQuery.cs`, `Product`, `BankReconciliation`, `Countify.Domain.Common`, `Countify.Domain.Seeders`, `YearEndClosingEntry`, `ProjectGroup`?**
  _High betweenness centrality (0.063) - this node is a cross-community bridge._
- **What connects `3. Decisiones tomadas`, `4.5 Conceptos (seeder)`, `4.7 Permisos` to the rest of the system?**
  _1297 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Countify.Domain.Interfaces` be split into smaller, more focused modules?**
  _Cohesion score 0.083089905874716 - nodes in this community are weakly interconnected._
- **Should `UpdateCompanySettingsCommand` be split into smaller, more focused modules?**
  _Cohesion score 0.09090909090909091 - nodes in this community are weakly interconnected._
- **Should `CountifyDbContext` be split into smaller, more focused modules?**
  _Cohesion score 0.037037037037037035 - nodes in this community are weakly interconnected._