using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable("Budgets");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).HasMaxLength(200).IsRequired();
        builder.HasIndex(b => new { b.FiscalYear, b.Name }).IsUnique();
        builder.HasMany(b => b.Lines)
            .WithOne(line => line.Budget)
            .HasForeignKey(line => line.BudgetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
