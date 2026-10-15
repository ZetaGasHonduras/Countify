using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class FiscalControlConfiguration : IEntityTypeConfiguration<FiscalControl>
{
    public void Configure(EntityTypeBuilder<FiscalControl> builder)
    {
        builder.ToTable("FiscalControls");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DocumentType)
            .IsRequired();

        builder.Property(x => x.Branch)
            .HasMaxLength(20);

        builder.Property(x => x.EmissionPoint)
            .HasMaxLength(20);

        builder.Property(x => x.DocumentCode)
            .HasMaxLength(4);

        builder.Property(x => x.CAI)
            .HasMaxLength(100);

        builder.Property(x => x.RangeFrom)
            .HasMaxLength(50);

        builder.Property(x => x.RangeTo)
            .HasMaxLength(50);

        builder.Property(x => x.Observations)
            .HasMaxLength(500);

        builder.HasIndex(x => x.DocumentType);
    }
}
