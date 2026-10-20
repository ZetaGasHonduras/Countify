using Countify.Domain.Entities.AccountsPayable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class SupplierFiscalDataConfiguration : IEntityTypeConfiguration<SupplierFiscalData>
{
    public void Configure(EntityTypeBuilder<SupplierFiscalData> builder)
    {
        builder.ToTable("SupplierFiscalData");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Branch).HasMaxLength(100);
        builder.Property(x => x.CAI).HasMaxLength(100);
        builder.Property(x => x.RangeFrom).HasMaxLength(50);
        builder.Property(x => x.RangeTo).HasMaxLength(50);
        builder.Property(x => x.Correlative).HasMaxLength(50);

        builder.HasOne(x => x.Supplier)
            .WithMany(x => x.FiscalData)
            .HasForeignKey(x => x.SupplierId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
