using Countify.Domain.Entities.Billing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class CashierConfiguration : IEntityTypeConfiguration<Cashier>
{
    public void Configure(EntityTypeBuilder<Cashier> builder)
    {
        builder.ToTable("Cashiers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code).HasMaxLength(20).IsRequired();
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();

        builder.Property(x => x.UserId).HasMaxLength(450);
    }
}
