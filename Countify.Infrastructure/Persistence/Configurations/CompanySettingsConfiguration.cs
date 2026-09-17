using Countify.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class CompanySettingsConfiguration : IEntityTypeConfiguration<CompanySettings>
{
    public void Configure(EntityTypeBuilder<CompanySettings> builder)
    {
        builder.ToTable("CompanySettings");

        builder.HasKey(s => s.Id);

        builder.HasOne(s => s.DefaultProject)
            .WithMany()
            .HasForeignKey(s => s.DefaultProjectId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(s => s.DefaultDepartment)
            .WithMany()
            .HasForeignKey(s => s.DefaultDepartmentId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}