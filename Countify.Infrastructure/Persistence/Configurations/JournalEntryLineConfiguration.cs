using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class JournalEntryLineConfiguration : IEntityTypeConfiguration<JournalEntryLine>
{
    public void Configure(EntityTypeBuilder<JournalEntryLine> builder)
    {
        builder.ToTable("JournalEntryLines");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Concept)
            .HasMaxLength(4000);

        builder.Property(l => l.Debit)
            .HasPrecision(18, 2);

        builder.Property(l => l.Credit)
            .HasPrecision(18, 2);

        builder.Property(l => l.CustomerName)
            .HasMaxLength(200);

        builder.HasIndex(l => l.JournalEntryId);
        builder.HasIndex(l => l.AccountId);
        builder.HasIndex(l => l.DepartmentId);
        builder.HasIndex(l => l.ProjectId);

        builder.HasOne(l => l.JournalEntry)
            .WithMany(e => e.Lines)
            .HasForeignKey(l => l.JournalEntryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.Account)
            .WithMany()
            .HasForeignKey(l => l.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.Department)
            .WithMany()
            .HasForeignKey(l => l.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.Project)
            .WithMany()
            .HasForeignKey(l => l.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}