using Countify.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class InventoryMovementLineConfiguration : IEntityTypeConfiguration<InventoryMovementLine>
{
    public void Configure(EntityTypeBuilder<InventoryMovementLine> builder)
    {
        builder.ToTable("InventoryMovementLines");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description).HasMaxLength(300).IsRequired();
        builder.Property(x => x.Unit).HasMaxLength(30);

        builder.Property(x => x.Quantity).HasPrecision(18, 3).IsRequired();
        builder.Property(x => x.UnitCost).HasPrecision(18, 4).IsRequired();
        builder.Property(x => x.TaxRate).HasPrecision(9, 4);
        builder.Property(x => x.TaxAmount).HasPrecision(18, 2);
        builder.Property(x => x.LineTotal).HasPrecision(18, 2);

        builder.HasOne(x => x.Movement)
            .WithMany(m => m.Lines)
            .HasForeignKey(x => x.MovementId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.MovementId, x.Order });

        builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Location).WithMany().HasForeignKey(x => x.LocationId).OnDelete(DeleteBehavior.Restrict);
    }
}
