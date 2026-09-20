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

        builder.HasOne(p => p.Product)
            .WithMany()
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Quality)
            .WithMany()
            .HasForeignKey(p => p.QualityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.InventoryAccount)
            .WithMany()
            .HasForeignKey(p => p.InventoryAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.IncomeAccount)
            .WithMany()
            .HasForeignKey(p => p.IncomeAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.CostAccount)
            .WithMany()
            .HasForeignKey(p => p.CostAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.ProductId);
        builder.HasIndex(p => p.QualityId);
        builder.HasIndex(p => new { p.ProductId, p.QualityId })
            .IsUnique()
            .HasDatabaseName("IX_ProductAccounts_ProductId_QualityId");
        builder.HasIndex(p => p.InventoryAccountId);
        builder.HasIndex(p => p.IncomeAccountId);
        builder.HasIndex(p => p.CostAccountId);
    }
}