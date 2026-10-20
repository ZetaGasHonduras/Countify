using Countify.Domain.Entities.AccountsPayable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.TaxId).HasMaxLength(20);
        builder.Property(x => x.IdentityDocument).HasMaxLength(20);
        builder.Property(x => x.Registration).HasMaxLength(50);
        builder.Property(x => x.Email).HasMaxLength(100);
        builder.Property(x => x.Phone).HasMaxLength(30);
        builder.Property(x => x.Fax).HasMaxLength(30);
        builder.Property(x => x.Address).HasMaxLength(300);
        builder.Property(x => x.City).HasMaxLength(100);
        builder.Property(x => x.ContactName).HasMaxLength(150);
        builder.Property(x => x.ContactPosition).HasMaxLength(100);
        builder.Property(x => x.ContactPhone).HasMaxLength(30);
        builder.Property(x => x.ContactEmail).HasMaxLength(100);
        builder.Property(x => x.CreditLimit).HasPrecision(18, 2);

        builder.HasOne(x => x.SupplierType)
            .WithMany()
            .HasForeignKey(x => x.SupplierTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.AccountingAccount)
            .WithMany()
            .HasForeignKey(x => x.AccountingAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
