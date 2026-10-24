using Countify.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class InventoryPeriodConfiguration : IEntityTypeConfiguration<InventoryPeriod>
{
    public void Configure(EntityTypeBuilder<InventoryPeriod> builder)
    {
        builder.ToTable("InventoryPeriods");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Month).IsRequired();
        builder.HasIndex(x => x.Month).IsUnique();

        builder.Property(x => x.Notes).HasMaxLength(500);
    }
}
