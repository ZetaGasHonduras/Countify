using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.Audit;
using Countify.Domain.Entities.Auth;
using Countify.Domain.Entities.AccountsPayable;
using Countify.Domain.Entities.AccountsReceivable;
using Countify.Domain.Entities.Billing;
using Countify.Domain.Entities.Inventory;
using Microsoft.AspNetCore.Identity;

namespace Countify.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<ApplicationUser> Users { get; }
    IRepository<IdentityRole> Roles { get; }
    IRepository<RolePermission> RolePermissions { get; }
    IRepository<Permission> Permissions { get; }
    IRepository<History> Histories { get; }

    IRepository<Account> Accounts { get; }
    IRepository<DocumentType> DocumentTypes { get; }
    IRepository<AccountingPeriod> AccountingPeriods { get; }
    IRepository<ProjectGroup> ProjectGroups { get; }
    IRepository<Project> Projects { get; }
    IRepository<Product> Products { get; }
    IRepository<Quality> Qualities { get; }
    IRepository<ProductAccount> ProductAccounts { get; }
    IRepository<Department> Departments { get; }
    IRepository<CompanySettings> CompanySettings { get; }
    IRepository<JournalEntry> JournalEntries { get; }
    IRepository<JournalEntryLine> JournalEntryLines { get; }
    IRepository<YearEndClosingEntry> YearEndClosingEntries { get; }
    IRepository<Budget> Budgets { get; }
    IRepository<BudgetLine> BudgetLines { get; }
    IRepository<BankAccount> BankAccounts { get; }
    IRepository<BankTransactionType> BankTransactionTypes { get; }
    IRepository<BankTransaction> BankTransactions { get; }
    IRepository<BankReconciliation> BankReconciliations { get; }
    IRepository<Currency> Currencies { get; }
    IRepository<CustomerType> CustomerTypes { get; }
    IRepository<Customer> Customers { get; }
    IRepository<AccountsReceivableConcept> AccountsReceivableConcepts { get; }
    IRepository<AccountsReceivableDocument> AccountsReceivableDocuments { get; }
    IRepository<AccountsReceivableDocumentLine> AccountsReceivableDocumentLines { get; }
    IRepository<AccountsReceivableDocumentAttachment> AccountsReceivableDocumentAttachments { get; }
    IRepository<FiscalControl> FiscalControls { get; }
    IRepository<SupplierType> SupplierTypes { get; }
    IRepository<Supplier> Suppliers { get; }
    IRepository<SupplierFiscalData> SupplierFiscalData { get; }
    IRepository<PayableConcept> PayableConcepts { get; }
    IRepository<PayableDocument> PayableDocuments { get; }
    IRepository<PayableDocumentLine> PayableDocumentLines { get; }
    IRepository<PayableDocumentAttachment> PayableDocumentAttachments { get; }
    IRepository<PaymentMethod> PaymentMethods { get; }
    IRepository<Invoice> Invoices { get; }
    IRepository<InvoiceLine> InvoiceLines { get; }
    IRepository<InvoicePayment> InvoicePayments { get; }
    IRepository<SalesJournalBatch> SalesJournalBatches { get; }
    IRepository<Warehouse> Warehouses { get; }
    IRepository<Location> Locations { get; }
    IRepository<InventoryMovementType> InventoryMovementTypes { get; }
    IRepository<InventoryMovement> InventoryMovements { get; }
    IRepository<InventoryMovementLine> InventoryMovementLines { get; }
    IRepository<InventoryPeriod> InventoryPeriods { get; }
    IRepository<ProductCostHistory> ProductCostHistories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
