using Countify.Domain.Entities.AccountsPayable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class PayableDocumentLineConfiguration : IEntityTypeConfiguration<PayableDocumentLine>
{
    public void Configure(EntityTypeBuilder<PayableDocumentLine> builder)
    {
        builder.ToTable("PayableDocumentLines");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.DocumentId, x.AppliedDocumentId })
            .IsUnique();

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.HasOne(x => x.Document)
            .WithMany(d => d.Lines)
            .HasForeignKey(x => x.DocumentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.AppliedDocument)
            .WithMany()
            .HasForeignKey(x => x.AppliedDocumentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
