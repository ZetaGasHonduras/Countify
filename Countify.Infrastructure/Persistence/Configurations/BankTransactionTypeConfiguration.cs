using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class BankTransactionTypeConfiguration : IEntityTypeConfiguration<BankTransactionType>
{
    public void Configure(EntityTypeBuilder<BankTransactionType> builder)
    {
        builder.ToTable("BankTransactionTypes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Code).HasMaxLength(20).IsRequired();
        builder.HasIndex(x => x.Code).IsUnique();
        builder.Property(x => x.MovementType).HasMaxLength(30).IsRequired();
        builder.Property(x => x.TransactionType).HasMaxLength(10).IsRequired();
        builder.HasCheckConstraint("CK_BankTransactionTypes_TransactionType", "[TransactionType] IN ('DEBITO', 'CREDITO')");
    }
}
