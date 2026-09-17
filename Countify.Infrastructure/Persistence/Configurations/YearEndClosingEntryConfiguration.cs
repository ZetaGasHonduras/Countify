using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class YearEndClosingEntryConfiguration : IEntityTypeConfiguration<YearEndClosingEntry>
{
    public void Configure(EntityTypeBuilder<YearEndClosingEntry> builder)
    {
        builder.ToTable("YearEndClosingEntries");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.GeneratedBy)
            .HasMaxLength(200);
    }
}