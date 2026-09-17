using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class ProjectGroupConfiguration : IEntityTypeConfiguration<ProjectGroup>
{
    public void Configure(EntityTypeBuilder<ProjectGroup> builder)
    {
        builder.ToTable("ProjectGroups");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(g => g.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}