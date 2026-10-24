using Countify.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class ProductCostHistoryConfiguration : IEntityTypeConfiguration<ProductCostHistory>
{
    public void Configure(EntityTypeBuilder<ProductCostHistory> builder)
    {
        builder.ToTable("ProductCostHistories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProductCode).HasMaxLength(20).IsRequired();
        builder.Property(x => x.ProductName).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Cost).HasPrecision(18, 4);

        builder.HasOne(x => x.InventoryPeriod)
            .WithMany()
            .HasForeignKey(x => x.InventoryPeriodId)
            .OnDelete(DeleteBehavior.Cascade);

        // Un producto, una foto por período.
        builder.HasIndex(x => new { x.InventoryPeriodId, x.ProductId }).IsUnique();
    }
}
