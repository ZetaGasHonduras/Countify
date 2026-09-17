using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class ProductAccountConfiguration : IEntityTypeConfiguration<ProductAccount>
{
    public void Configure(EntityTypeBuilder<ProductAccount> builder)
    {
        builder.ToTable("ProductAccounts");

        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Account)
            .WithMany()
            .HasForeignKey(p => p.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.AccountId);
    }
}