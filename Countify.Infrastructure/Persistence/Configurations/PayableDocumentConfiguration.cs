using Countify.Domain.Entities.AccountsPayable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class PayableDocumentConfiguration : IEntityTypeConfiguration<PayableDocument>
{
    public void Configure(EntityTypeBuilder<PayableDocument> builder)
    {
        builder.ToTable("PayableDocuments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DocumentNo)
            .ValueGeneratedOnAdd();

        builder.HasIndex(x => x.DocumentNo)
            .IsUnique();

        builder.Property(x => x.Date)
            .IsRequired();

        builder.Property(x => x.DueDate)
            .IsRequired();

        builder.Property(x => x.Reference)
            .HasMaxLength(100);

        builder.Property(x => x.AppliesTo)
            .HasMaxLength(50);

        builder.Property(x => x.ExchangeRate)
            .HasPrecision(18, 6)
            .IsRequired();

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Tax)
            .HasPrecision(18, 2);

        builder.Property(x => x.TaxLocal)
            .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
            .HasMaxLength(500);

        builder.Property(x => x.SupplierRegistration)
            .HasMaxLength(50);

        builder.Property(x => x.SupplierAddress)
            .HasMaxLength(300);

        builder.Property(x => x.CAI)
            .HasMaxLength(100);

        builder.Property(x => x.RangeFrom)
            .HasMaxLength(50);

        builder.Property(x => x.RangeTo)
            .HasMaxLength(50);

        builder.Property(x => x.Correlative)
            .HasMaxLength(50);

        builder.HasOne(x => x.Supplier)
            .WithMany()
            .HasForeignKey(x => x.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Concept)
            .WithMany()
            .HasForeignKey(x => x.ConceptId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Department)
            .WithMany()
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Project)
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Currency)
            .WithMany()
            .HasForeignKey(x => x.CurrencyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.JournalEntry)
            .WithMany()
            .HasForeignKey(x => x.JournalEntryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
