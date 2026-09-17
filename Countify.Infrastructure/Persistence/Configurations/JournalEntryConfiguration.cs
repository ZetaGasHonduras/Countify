using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class JournalEntryConfiguration : IEntityTypeConfiguration<JournalEntry>
{
    public void Configure(EntityTypeBuilder<JournalEntry> builder)
    {
        builder.ToTable("JournalEntries");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code)
            .HasMaxLength(20);

        builder.Property(e => e.Reference)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Concept)
            .HasMaxLength(4000)
            .IsRequired();

        builder.Property(e => e.Observations)
            .HasMaxLength(4000);

        builder.Property(e => e.DebitTotal)
            .HasPrecision(18, 2);

        builder.Property(e => e.CreditTotal)
            .HasPrecision(18, 2);

        builder.Property(e => e.DifferenceAmount)
            .HasPrecision(18, 2);

        builder.Property(e => e.Status)
            .HasConversion<int>();

        builder.Property(e => e.SourceModule)
            .HasConversion<int>();

        builder.HasIndex(e => e.PeriodId);

        builder.HasOne(e => e.Type)
            .WithMany()
            .HasForeignKey(e => e.TypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Period)
            .WithMany()
            .HasForeignKey(e => e.PeriodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}