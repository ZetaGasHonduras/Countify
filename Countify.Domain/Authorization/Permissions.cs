using System.Reflection;
using Countify.Domain.Entities.Auth;

namespace Countify.Domain.Authorization;

public class Permissions
{
    public static readonly Permission CanCreateUsers = Permission.Create(1, nameof(CanCreateUsers), "Crear usuarios.");
    public static readonly Permission CanEditUsers = Permission.Create(2, nameof(CanEditUsers),   "Editar usuarios.");
    public static readonly Permission CanDeleteUsers = Permission.Create(3, nameof(CanDeleteUsers), "Eliminar usuarios.");
    public static readonly Permission CanViewUsers = Permission.Create(4, nameof(CanViewUsers),   "Ver usuarios.");
    
    public static readonly Permission CanCreateRoles = Permission.Create(5,  nameof(CanCreateRoles), "Crear roles.");
    public static readonly Permission CanEditRoles = Permission.Create(6, nameof(CanEditRoles),   "Editar roles y sus permisos.");
    public static readonly Permission CanDeleteRoles = Permission.Create(7, nameof(CanDeleteRoles), "Eliminar roles.");
    public static readonly Permission CanViewRoles = Permission.Create(8, nameof(CanViewRoles),   "Ver roles.");
    
    public static readonly Permission CanViewHistorie   = Permission.Create(9, nameof(CanViewHistorie),   "Ver historial.");
    
    public static readonly Permission CanViewDepartments = Permission.Create(10, nameof(CanViewDepartments), "Ver departamentos.");
    public static readonly Permission CanCreateDepartments = Permission.Create(11, nameof(CanCreateDepartments), "Crear departamentos.");
    public static readonly Permission CanEditDepartments = Permission.Create(12, nameof(CanEditDepartments), "Editar departamentos.");
    public static readonly Permission CanDeleteDepartments = Permission.Create(13, nameof(CanDeleteDepartments), "Eliminar departamentos.");

    public static readonly Permission CanViewProjectGroups = Permission.Create(14, nameof(CanViewProjectGroups), "Ver grupos de proyectos.");
    public static readonly Permission CanCreateProjectGroups = Permission.Create(15, nameof(CanCreateProjectGroups), "Crear grupos de proyectos.");
    public static readonly Permission CanEditProjectGroups = Permission.Create(16, nameof(CanEditProjectGroups), "Editar grupos de proyectos.");
    public static readonly Permission CanDeleteProjectGroups = Permission.Create(17, nameof(CanDeleteProjectGroups), "Eliminar grupos de proyectos.");

    public static readonly Permission CanViewProjects = Permission.Create(18, nameof(CanViewProjects), "Ver proyectos.");
    public static readonly Permission CanCreateProjects = Permission.Create(19, nameof(CanCreateProjects), "Crear proyectos.");
    public static readonly Permission CanEditProjects = Permission.Create(20, nameof(CanEditProjects), "Editar proyectos.");
    public static readonly Permission CanDeleteProjects = Permission.Create(21, nameof(CanDeleteProjects), "Eliminar proyectos.");

    public static readonly Permission CanViewDocumentTypes = Permission.Create(22, nameof(CanViewDocumentTypes), "Ver tipos de documento.");
    public static readonly Permission CanCreateDocumentTypes = Permission.Create(23, nameof(CanCreateDocumentTypes), "Crear tipos de documento.");
    public static readonly Permission CanEditDocumentTypes = Permission.Create(24, nameof(CanEditDocumentTypes), "Editar tipos de documento.");
    public static readonly Permission CanDeleteDocumentTypes = Permission.Create(25, nameof(CanDeleteDocumentTypes), "Eliminar tipos de documento.");

    public static readonly Permission CanViewAccounts = Permission.Create(26, nameof(CanViewAccounts), "Ver cuentas contables.");
    public static readonly Permission CanCreateAccounts = Permission.Create(27, nameof(CanCreateAccounts), "Crear cuentas contables.");
    public static readonly Permission CanEditAccounts = Permission.Create(28, nameof(CanEditAccounts), "Editar cuentas contables.");
    public static readonly Permission CanDeleteAccounts = Permission.Create(29, nameof(CanDeleteAccounts), "Eliminar cuentas contables.");

    public static readonly Permission CanViewProductAccounts = Permission.Create(30, nameof(CanViewProductAccounts), "Ver cuentas por producto.");
    public static readonly Permission CanCreateProductAccounts = Permission.Create(31, nameof(CanCreateProductAccounts), "Crear cuentas por producto.");
    public static readonly Permission CanEditProductAccounts = Permission.Create(32, nameof(CanEditProductAccounts), "Editar cuentas por producto.");
    public static readonly Permission CanDeleteProductAccounts = Permission.Create(33, nameof(CanDeleteProductAccounts), "Eliminar cuentas por producto.");

    public static readonly Permission CanViewAccountingPeriods = Permission.Create(34, nameof(CanViewAccountingPeriods), "Ver períodos contables.");
    public static readonly Permission CanCreateAccountingPeriods = Permission.Create(35, nameof(CanCreateAccountingPeriods), "Crear períodos contables.");
    public static readonly Permission CanEditAccountingPeriods = Permission.Create(36, nameof(CanEditAccountingPeriods), "Editar períodos contables.");
    public static readonly Permission CanDeleteAccountingPeriods = Permission.Create(37, nameof(CanDeleteAccountingPeriods), "Eliminar períodos contables.");
    public static readonly Permission CanCloseAccountingPeriods = Permission.Create(38, nameof(CanCloseAccountingPeriods), "Cerrar períodos contables.");

    public static readonly Permission CanViewJournalEntries = Permission.Create(39, nameof(CanViewJournalEntries), "Ver partidas.");
    public static readonly Permission CanCreateJournalEntries = Permission.Create(40, nameof(CanCreateJournalEntries), "Crear partidas.");
    public static readonly Permission CanEditJournalEntries = Permission.Create(41, nameof(CanEditJournalEntries), "Editar partidas.");
    public static readonly Permission CanDeleteJournalEntries = Permission.Create(42, nameof(CanDeleteJournalEntries), "Eliminar partidas.");
    public static readonly Permission CanApproveJournalEntries = Permission.Create(43, nameof(CanApproveJournalEntries), "Aprobar partidas.");
    public static readonly Permission CanPostJournalEntries = Permission.Create(44, nameof(CanPostJournalEntries), "Contabilizar partidas.");
    public static readonly Permission CanVoidJournalEntries = Permission.Create(45, nameof(CanVoidJournalEntries), "Anular partidas.");

    public static readonly Permission CanViewCompanySettings = Permission.Create(46, nameof(CanViewCompanySettings), "Ver configuración contable.");
    public static readonly Permission CanEditCompanySettings = Permission.Create(47, nameof(CanEditCompanySettings), "Editar configuración contable.");

    public static readonly Permission CanViewReports = Permission.Create(48, nameof(CanViewReports), "Ver reportes contables.");

    public static readonly Permission CanViewBudgets = Permission.Create(49, nameof(CanViewBudgets), "Ver presupuestos.");
    public static readonly Permission CanCreateBudgets = Permission.Create(50, nameof(CanCreateBudgets), "Crear presupuestos.");
    public static readonly Permission CanEditBudgets = Permission.Create(51, nameof(CanEditBudgets), "Editar presupuestos.");
    public static readonly Permission CanDeleteBudgets = Permission.Create(52, nameof(CanDeleteBudgets), "Eliminar presupuestos.");
    public static readonly Permission CanViewBankAccounts = Permission.Create(53, nameof(CanViewBankAccounts), "Ver cuentas bancarias.");
    public static readonly Permission CanCreateBankAccounts = Permission.Create(54, nameof(CanCreateBankAccounts), "Crear cuentas bancarias.");
    public static readonly Permission CanEditBankAccounts = Permission.Create(55, nameof(CanEditBankAccounts), "Editar cuentas bancarias.");
    public static readonly Permission CanDeleteBankAccounts = Permission.Create(56, nameof(CanDeleteBankAccounts), "Eliminar cuentas bancarias.");
    public static readonly Permission CanViewBankTransactionTypes = Permission.Create(57, nameof(CanViewBankTransactionTypes), "Ver tipos de movimientos bancarios.");
    public static readonly Permission CanCreateBankTransactionTypes = Permission.Create(58, nameof(CanCreateBankTransactionTypes), "Crear tipos de movimientos bancarios.");
    public static readonly Permission CanEditBankTransactionTypes = Permission.Create(59, nameof(CanEditBankTransactionTypes), "Editar tipos de movimientos bancarios.");
    public static readonly Permission CanDeleteBankTransactionTypes = Permission.Create(60, nameof(CanDeleteBankTransactionTypes), "Eliminar tipos de movimientos bancarios.");
    public static readonly Permission CanViewBankTransactions = Permission.Create(61, nameof(CanViewBankTransactions), "Ver movimientos bancarios.");
    public static readonly Permission CanCreateBankTransactions = Permission.Create(62, nameof(CanCreateBankTransactions), "Crear movimientos bancarios.");
    public static readonly Permission CanEditBankTransactions = Permission.Create(63, nameof(CanEditBankTransactions), "Editar movimientos bancarios.");
    public static readonly Permission CanDeleteBankTransactions = Permission.Create(64, nameof(CanDeleteBankTransactions), "Eliminar movimientos bancarios.");
    public static readonly Permission CanViewBankReconciliations = Permission.Create(65, nameof(CanViewBankReconciliations), "Ver conciliaciones bancarias.");
    public static readonly Permission CanCreateBankReconciliations = Permission.Create(66, nameof(CanCreateBankReconciliations), "Crear conciliaciones bancarias.");
    public static readonly Permission CanEditBankReconciliations = Permission.Create(67, nameof(CanEditBankReconciliations), "Editar conciliaciones bancarias.");
    public static readonly Permission CanUnreconcileBankTransactions = Permission.Create(68, nameof(CanUnreconcileBankTransactions), "Desmarcar movimientos conciliados.");
    public static readonly Permission CanViewCurrencies = Permission.Create(69, nameof(CanViewCurrencies), "Ver monedas.");
    public static readonly Permission CanCreateCurrencies = Permission.Create(70, nameof(CanCreateCurrencies), "Crear monedas.");
    public static readonly Permission CanEditCurrencies = Permission.Create(71, nameof(CanEditCurrencies), "Editar monedas.");
    public static readonly Permission CanDeleteCurrencies = Permission.Create(72, nameof(CanDeleteCurrencies), "Eliminar monedas.");
    
    public static Permission[] Items { get; } = typeof(Permissions)
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .Where(fieldInfo => fieldInfo.FieldType == typeof(Permission))
        .Select(fieldInfo => (Permission)fieldInfo.GetValue(null)!)
        .ToArray();
}
