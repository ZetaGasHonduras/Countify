# Countify — Convenciones del proyecto

Código limpio, ordenado por capas y pensado para generalizar a futuras entidades/fases.

## Flujo de trabajo (obligatorio)
- **No ejecutar** `dotnet build` ni correr la app: el usuario compila y reporta los errores.
- **No generar migraciones** con `dotnet ef` (compila internamente): el usuario las genera/aplica manualmente.
- **`ROADMAP.md` y `API-CONTRACT-FASE1.md`** (en OneDrive, carpeta del cliente) son **solo lectura** y la fuente de verdad. Desviaciones se **reportan**, no se editan.
- Al terminar una tarea, reportar para que el usuario compile y pase errores.

## Arquitectura / capas
- **Domain**: entidades, enums, interfaces (`IUnitOfWork`, `IRepository`), permisos y **datos de seed**.
- **Application**: CQRS por feature (`Commands/<Create|Update|Delete|<Accion>>/` + `Validator`, `Queries/<Get*>/`, `DTOs/`, `Profiles/`). AutoMapper per-feature, FluentValidation, wrapper `Response<T>` con `.Success(data, httpStatus)`, `.Failure(msg)`, `.NotFound(msg)`.
- **Infrastructure**: `Persistence/Configurations` (EF), `Persistence/Services` (UnitOfWork/Repository), `Migrations`, `Extensions` (arranque), `Seeders` (solo implementaciones).
- **Api**: `Controllers/` (heredan `BaseController`; GET → `Ok(await Mediator.Send(...))`, resto → `HandleResult`), `Authorization/Policies` (`IConfigureOptions<AuthorizationOptions>` con `UserRoleHasPermissionRequirement`), `DependencyInjection`.
- Convención de IDs de seed: prefijos estables por entidad (`20000000-…` CompanySettings, `30000000-…` DocumentType, `40000000-…` ProjectGroups/Projects, `50000000-…` Accounts, `60000000-…` Departments, `70000000-…` AccountingPeriods, `80000000-…` JournalEntries/Lines, `81000000-…` Histories, `82000000-…` YearEndClosingEntries).

## Seeding — GENERALIZADO (base para futuras entidades/fases)
- **Datos**: clases `static` en `Countify.Domain\Seeders` con campos nombrados + array `Items` (patrón `BasicUsers`, `BasicRoles`, `BasicDepartments`, `BasicProjects`, `BasicAccounts`, `BasicDocumentTypes`, `BasicCompanySettings`).
- **Contratos**: `ISeeder` (`Task SeedAsync(CancellationToken)`) y `SeederOptions` (`Enabled`, sección `Seeder`) viven en `Countify.Domain\Seeders`.
- **Implementaciones**: en `Countify.Infrastructure\Seeders` (p. ej. `CatalogSeeder`), dependen de `CountifyDbContext`; cada una lee su propio `IOptions<SeederOptions>`.
- **Registro**: `services.AddScoped<ISeeder, MiSeeder>()` y `services.Configure<SeederOptions>(configuration.GetSection(SeederOptions.SectionName))` en `InfrastructureServiceRegistration`.
- **Arranque**: `app.MigrateDatabase(); app.SeedDatabase();` — `SeedDatabase()` resuelve `IEnumerable<ISeeder>` y ejecuta todos. Futuras fases solo agregan un `ISeeder` + registro, nada más.
- **Regla**: si `Seeder:Enabled=false` (appsettings), los seeders no insertan nada. Cada seeder es **idempotente** (solo inserta si la tabla está vacía / no existe el "default").
- NOTA: los seeds de Auth (`Permissions.Items`, `BasicUsers`, `BasicRoles`, `RolePermission` para superadmin) sí viajan como `HasData` en las migraciones (no son FASE 1); los catálogos de FASE 1 ya NO usan `HasData` (los inserta el seeder).

## Permisos (patrón de futuras fases también)
- `Countify.Domain\Authorization\Permissions.cs`: campo `static readonly Permission` por permiso con `Permission.Create(id, name, descripción)`; `Items[]` se arma por reflexión (mantener ids consecutivos).
- Superadmin recibe todos los permisos automáticamente (seed `RolePermission` por reflexión sobre `Permissions.Items`).
- Una clase `XxxPolicies` **por entidad** (`DepartmentPolicies`, `ProjectGroupPolicies`, `ProjectPolicies`, `DocumentTypePolicies`, `AccountPolicies`, `AccountingPeriodPolicies`, `JournalEntryPolicies`, `CompanySettingsPolicies`) como `IConfigureOptions<AuthorizationOptions>`: constantes `internal const string` + `AddPolicy` con `UserRoleHasPermissionRequirement`. Cada una se registra con `services.ConfigureOptions<XxxPolicies>()` en `ApiServiceRegistration`. NO agrupar varias entidades en una sola clase.

## Modelo contable (FASE 1 — corregido)
- **Dimensiones = entidades con FK concreta** (NO existe catálogo de dimensiones):
  - `JournalEntryLine.AccountId` FK(Accounts), obligatoria (dimensión 1, siempre activa).
  - `DepartmentId?`, `ProjectId?` FKs con `DeleteBehavior.Restrict`.
  - `SubProjectId?` columna Guid nullable **sin FK** (entidad futura; era "Motorista").
  - `EntryConceptType?` enum → valores **1=Débito, 2=Crédito, 3=Otro** (se expone como `int?` en DTO, sin endpoint de catálogo).
- `CompanySettings` usa flags bool `Use*`/`Require*` (`Use*` activa la dimensión, `Require*` la obliga; Require implica Use). Seed: `UseDepartments=true`, `UseProjects=true`.
- Reglas de línea: `debit XOR credit` (>0), monto ≥0, `debitSum==creditSum` (Draft admite desbalance; Approved/Posted exigen cuadre), período abierto para crear/postear, `EntryNumber = max+1` del período. Flujo: `Draft → Approved → Posted | Voided` (void idempotente); edit/delete solo `Draft`.

## Contrato API (FASE 1)
- JSON camelCase, fechas ISO 8601, **paginación 0-based**, errores `{ statusCode, message }`.
- Permisos por operación (CRUD por entidad, ids 10-48 asignados en `Permissions.cs`), p. ej. GET→`CanView*`, POST→`CanCreate*`, PUT→`CanEdit*`, DELETE→`CanDelete*`; acciones: `/close`→`CanCloseAccountingPeriods`, `approve/post/void`→`CanApprove/Post/VoidJournalEntries`.