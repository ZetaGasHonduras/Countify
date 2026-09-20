using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class BankTransactionConfiguration : IEntityTypeConfiguration<BankTransaction>
{
    public void Configure(EntityTypeBuilder<BankTransaction> builder)
    {
        builder.ToTable("BankTransactions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TransactionTypeValue).HasMaxLength(10).IsRequired();
        builder.Property(x => x.ExchangeRate).HasPrecision(18, 6);
        builder.Property(x => x.Amount).HasPrecision(18, 2);
        builder.Property(x => x.LocalAmount).HasPrecision(18, 2);
        builder.Property(x => x.Reference).HasMaxLength(100);
        builder.Property(x => x.Beneficiary).HasMaxLength(200);
        builder.Property(x => x.Concept).HasMaxLength(500);
        builder.HasOne(x => x.BankAccount).WithMany().HasForeignKey(x => x.BankAccountId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.TransactionType).WithMany().HasForeignKey(x => x.TransactionTypeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Currency).WithMany().HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Department).WithMany().HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Project).WithMany().HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.JournalEntry).WithMany().HasForeignKey(x => x.JournalEntryId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.CounterpartAccount).WithMany().HasForeignKey(x => x.CounterpartAccountId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.BankReconciliation).WithMany(x => x.Transactions).HasForeignKey(x => x.BankReconciliationId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => new { x.BankAccountId, x.Reference })
            .IsUnique()
            .HasFilter("[Reference] IS NOT NULL");
    }
}
