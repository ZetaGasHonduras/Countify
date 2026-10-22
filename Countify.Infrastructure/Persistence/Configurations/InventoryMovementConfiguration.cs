using Countify.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class InventoryMovementConfiguration : IEntityTypeConfiguration<InventoryMovement>
{
    public void Configure(EntityTypeBuilder<InventoryMovement> builder)
    {
        builder.ToTable("InventoryMovements");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code).HasMaxLength(30);
        builder.HasIndex(x => x.Code).IsUnique().HasFilter("[Code] IS NOT NULL");

        builder.Property(x => x.Reference).HasMaxLength(100);
        builder.Property(x => x.Concept).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Observations).HasMaxLength(1000);
        builder.Property(x => x.VoidReason).HasMaxLength(500);

        builder.Property(x => x.SubTotal).HasPrecision(18, 2);
        builder.Property(x => x.TaxAmount).HasPrecision(18, 2);
        builder.Property(x => x.Total).HasPrecision(18, 2);

        builder.HasOne(x => x.Type).WithMany().HasForeignKey(x => x.TypeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Warehouse).WithMany().HasForeignKey(x => x.WarehouseId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ToWarehouse).WithMany().HasForeignKey(x => x.ToWarehouseId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Department).WithMany().HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.SourceRequest).WithMany().HasForeignKey(x => x.SourceRequestId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.JournalEntry).WithMany().HasForeignKey(x => x.JournalEntryId).OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(x => new { x.TypeId, x.Correlativo });
    }
}
