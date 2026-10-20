using Countify.Domain.Entities.AccountsPayable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class PayableConceptConfiguration : IEntityTypeConfiguration<PayableConcept>
{
    public void Configure(EntityTypeBuilder<PayableConcept> builder)
    {
        builder.ToTable("PayableConcepts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.Observations)
            .HasMaxLength(500);

        builder.HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
