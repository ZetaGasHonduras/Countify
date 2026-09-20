using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class QualityConfiguration : IEntityTypeConfiguration<Quality>
{
    public void Configure(EntityTypeBuilder<Quality> builder)
    {
        builder.ToTable("Qualities");

        builder.HasKey(q => q.Id);

        builder.Property(q => q.Code)
            .HasMaxLength(20);

        builder.Property(q => q.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}