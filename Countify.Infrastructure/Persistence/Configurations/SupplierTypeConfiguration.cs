using Countify.Domain.Entities.AccountsPayable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class SupplierTypeConfiguration : IEntityTypeConfiguration<SupplierType>
{
    public void Configure(EntityTypeBuilder<SupplierType> builder)
    {
        builder.ToTable("SupplierTypes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(x => x.AccountingAccount)
            .WithMany()
            .HasForeignKey(x => x.AccountingAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
