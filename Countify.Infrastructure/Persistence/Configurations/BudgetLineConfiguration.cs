using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class BudgetLineConfiguration : IEntityTypeConfiguration<BudgetLine>
{
    public void Configure(EntityTypeBuilder<BudgetLine> builder)
    {
        builder.ToTable("BudgetLines");
        builder.HasKey(line => line.Id);

        foreach (var property in new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" })
            builder.Property<decimal>(property).HasPrecision(18, 2);

        builder.HasOne(line => line.Account).WithMany().HasForeignKey(line => line.AccountId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(line => line.Department).WithMany().HasForeignKey(line => line.DepartmentId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(line => line.Project).WithMany().HasForeignKey(line => line.ProjectId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(line => new { line.BudgetId, line.AccountId, line.DepartmentId, line.ProjectId }).IsUnique();
    }
}
