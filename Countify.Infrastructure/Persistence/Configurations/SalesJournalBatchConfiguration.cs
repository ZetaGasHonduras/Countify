using Countify.Domain.Entities.Billing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class SalesJournalBatchConfiguration : IEntityTypeConfiguration<SalesJournalBatch>
{
    public void Configure(EntityTypeBuilder<SalesJournalBatch> builder)
    {
        builder.ToTable("SalesJournalBatches");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Notes).HasMaxLength(500);

        builder.HasOne(x => x.JournalEntry)
            .WithMany()
            .HasForeignKey(x => x.JournalEntryId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
