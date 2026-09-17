using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(a => a.Code)
            .IsUnique();

        builder.Property(a => a.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(a => a.ParentCode)
            .HasMaxLength(20);

        builder.Property(a => a.BudgetLine)
            .HasMaxLength(255);
    }
}