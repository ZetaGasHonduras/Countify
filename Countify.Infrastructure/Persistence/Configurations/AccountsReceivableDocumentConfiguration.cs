using Countify.Domain.Entities.AccountsReceivable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class AccountsReceivableDocumentConfiguration : IEntityTypeConfiguration<AccountsReceivableDocument>
{
    public void Configure(EntityTypeBuilder<AccountsReceivableDocument> builder)
    {
        builder.ToTable("AccountsReceivableDocuments");

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

        builder.Property(x => x.Notes)
            .HasMaxLength(500);

        builder.Property(x => x.ReceiptNumber)
            .ValueGeneratedNever();

        builder.HasIndex(x => x.ReceiptNumber)
            .IsUnique();

        builder.Property(x => x.NoteNumber)
            .HasMaxLength(50);

        builder.HasIndex(x => x.NoteNumber)
            .IsUnique()
            .HasFilter("[NoteNumber] IS NOT NULL");

        builder.Property(x => x.InvoiceCAI)
            .HasMaxLength(100);

        builder.Property(x => x.CAI)
            .HasMaxLength(100);

        builder.Property(x => x.RangeFrom)
            .HasMaxLength(50);

        builder.Property(x => x.RangeTo)
            .HasMaxLength(50);

        builder.Property(x => x.FiscalConcept)
            .HasMaxLength(200);

        builder.HasOne(x => x.FiscalControl)
            .WithMany()
            .HasForeignKey(x => x.FiscalControlId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
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