using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.Audit;
using Countify.Domain.Entities.Auth;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Entities.Billing;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Quick.AutoInject.Services;

namespace Countify.Infrastructure.Persistence.Services;

[ScopeService]
public class UnitOfWork(CountifyDbContext context) : IUnitOfWork
{
    private IRepository<ApplicationUser>? _users;
    private IRepository<IdentityRole>? _roles;
    private IRepository<RolePermission>? _rolePermissions;
    private IRepository<Permission>? _permissions;
    private IRepository<History>? _histories;

    private IRepository<Account>? _accounts;
    private IRepository<DocumentType>? _documentTypes;
    private IRepository<AccountingPeriod>? _accountingPeriods;
    private IRepository<ProjectGroup>? _projectGroups;
    private IRepository<Project>? _projects;
    private IRepository<Product>? _products;
    private IRepository<Quality>? _qualities;
    private IRepository<ProductAccount>? _productAccounts;
    private IRepository<Department>? _departments;
    private IRepository<CompanySettings>? _companySettings;
    private IRepository<Budget>? _budgets;
    private IRepository<BudgetLine>? _budgetLines;
    private IRepository<JournalEntry>? _journalEntries;
    private IRepository<JournalEntryLine>? _journalEntryLines;
    private IRepository<YearEndClosingEntry>? _yearEndClosingEntries;
    private IRepository<BankAccount>? _bankAccounts;
    private IRepository<BankTransactionType>? _bankTransactionTypes;
    private IRepository<BankTransaction>? _bankTransactions;
    private IRepository<BankReconciliation>? _bankReconciliations;
    private IRepository<Currency>? _currencies;
    private IRepository<CustomerType>? _customerTypes;
    private IRepository<Customer>? _customers;
    private IRepository<AccountsReceivableConcept>? _accountsReceivableConcepts;
    private IRepository<AccountsReceivableDocument>? _accountsReceivableDocuments;
    private IRepository<AccountsReceivableDocumentLine>? _accountsReceivableDocumentLines;
    private IRepository<AccountsReceivableDocumentAttachment>? _accountsReceivableDocumentAttachments;
    private IRepository<FiscalControl>? _fiscalControls;
    private IRepository<SupplierType>? _supplierTypes;
    private IRepository<Supplier>? _suppliers;
    private IRepository<SupplierFiscalData>? _supplierFiscalData;
    private IRepository<PayableConcept>? _payableConcepts;
    private IRepository<PayableDocument>? _payableDocuments;
    private IRepository<PayableDocumentLine>? _payableDocumentLines;
    private IRepository<PayableDocumentAttachment>? _payableDocumentAttachments;
    private IRepository<PaymentMethod>? _paymentMethods;
    private IRepository<Invoice>? _invoices;
    private IRepository<InvoiceLine>? _invoiceLines;
    private IRepository<InvoicePayment>? _invoicePayments;
    private IRepository<SalesJournalBatch>? _salesJournalBatches;
    private IRepository<Warehouse>? _warehouses;
    private IRepository<Location>? _locations;
    private IRepository<InventoryMovementType>? _inventoryMovementTypes;

    public IRepository<ApplicationUser> Users =>
        _users ??= new Repository<ApplicationUser>(context);

    public IRepository<IdentityRole> Roles =>
        _roles ??= new Repository<IdentityRole>(context);

    public IRepository<RolePermission> RolePermissions =>
        _rolePermissions ??= new Repository<RolePermission>(context);

    public IRepository<Permission> Permissions =>
        _permissions ??= new Repository<Permission>(context);

    public IRepository<History> Histories =>
        _histories ??= new Repository<History>(context);

    public IRepository<Account> Accounts =>
        _accounts ??= new Repository<Account>(context);

    public IRepository<DocumentType> DocumentTypes =>
        _documentTypes ??= new Repository<DocumentType>(context);

    public IRepository<AccountingPeriod> AccountingPeriods =>
        _accountingPeriods ??= new Repository<AccountingPeriod>(context);

    public IRepository<ProjectGroup> ProjectGroups =>
        _projectGroups ??= new Repository<ProjectGroup>(context);

    public IRepository<Project> Projects =>
        _projects ??= new Repository<Project>(context);

    public IRepository<Product> Products =>
        _products ??= new Repository<Product>(context);

    public IRepository<Quality> Qualities =>
        _qualities ??= new Repository<Quality>(context);

    public IRepository<ProductAccount> ProductAccounts =>
        _productAccounts ??= new Repository<ProductAccount>(context);

    public IRepository<Department> Departments =>
        _departments ??= new Repository<Department>(context);

    public IRepository<CompanySettings> CompanySettings =>
        _companySettings ??= new Repository<CompanySettings>(context);

    public IRepository<Budget> Budgets => _budgets ??= new Repository<Budget>(context);
    public IRepository<BudgetLine> BudgetLines => _budgetLines ??= new Repository<BudgetLine>(context);

    public IRepository<JournalEntry> JournalEntries =>
        _journalEntries ??= new Repository<JournalEntry>(context);

    public IRepository<JournalEntryLine> JournalEntryLines =>
        _journalEntryLines ??= new Repository<JournalEntryLine>(context);

    public IRepository<YearEndClosingEntry> YearEndClosingEntries =>
        _yearEndClosingEntries ??= new Repository<YearEndClosingEntry>(context);
    public IRepository<BankAccount> BankAccounts => _bankAccounts ??= new Repository<BankAccount>(context);
    public IRepository<BankTransactionType> BankTransactionTypes => _bankTransactionTypes ??= new Repository<BankTransactionType>(context);
    public IRepository<BankTransaction> BankTransactions => _bankTransactions ??= new Repository<BankTransaction>(context);
    public IRepository<BankReconciliation> BankReconciliations => _bankReconciliations ??= new Repository<BankReconciliation>(context);
    public IRepository<Currency> Currencies => _currencies ??= new Repository<Currency>(context);
    public IRepository<CustomerType> CustomerTypes => _customerTypes ??= new Repository<CustomerType>(context);
    public IRepository<Customer> Customers => _customers ??= new Repository<Customer>(context);
    public IRepository<AccountsReceivableConcept> AccountsReceivableConcepts => _accountsReceivableConcepts ??= new Repository<AccountsReceivableConcept>(context);
    public IRepository<AccountsReceivableDocument> AccountsReceivableDocuments => _accountsReceivableDocuments ??= new Repository<AccountsReceivableDocument>(context);
    public IRepository<AccountsReceivableDocumentLine> AccountsReceivableDocumentLines => _accountsReceivableDocumentLines ??= new Repository<AccountsReceivableDocumentLine>(context);
    public IRepository<AccountsReceivableDocumentAttachment> AccountsReceivableDocumentAttachments => _accountsReceivableDocumentAttachments ??= new Repository<AccountsReceivableDocumentAttachment>(context);
    public IRepository<FiscalControl> FiscalControls => _fiscalControls ??= new Repository<FiscalControl>(context);
    public IRepository<SupplierType> SupplierTypes => _supplierTypes ??= new Repository<SupplierType>(context);
    public IRepository<Supplier> Suppliers => _suppliers ??= new Repository<Supplier>(context);
    public IRepository<SupplierFiscalData> SupplierFiscalData => _supplierFiscalData ??= new Repository<SupplierFiscalData>(context);
    public IRepository<PayableConcept> PayableConcepts => _payableConcepts ??= new Repository<PayableConcept>(context);
    public IRepository<PayableDocument> PayableDocuments => _payableDocuments ??= new Repository<PayableDocument>(context);
    public IRepository<PayableDocumentLine> PayableDocumentLines => _payableDocumentLines ??= new Repository<PayableDocumentLine>(context);
    public IRepository<PayableDocumentAttachment> PayableDocumentAttachments => _payableDocumentAttachments ??= new Repository<PayableDocumentAttachment>(context);
    public IRepository<PaymentMethod> PaymentMethods => _paymentMethods ??= new Repository<PaymentMethod>(context);
    public IRepository<Invoice> Invoices => _invoices ??= new Repository<Invoice>(context);
    public IRepository<InvoiceLine> InvoiceLines => _invoiceLines ??= new Repository<InvoiceLine>(context);
    public IRepository<InvoicePayment> InvoicePayments => _invoicePayments ??= new Repository<InvoicePayment>(context);
    public IRepository<SalesJournalBatch> SalesJournalBatches => _salesJournalBatches ??= new Repository<SalesJournalBatch>(context);
    public IRepository<Warehouse> Warehouses => _warehouses ??= new Repository<Warehouse>(context);
    public IRepository<Location> Locations => _locations ??= new Repository<Location>(context);
    public IRepository<InventoryMovementType> InventoryMovementTypes => _inventoryMovementTypes ??= new Repository<InventoryMovementType>(context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);
    
    public void Dispose() => context.Dispose();
}
