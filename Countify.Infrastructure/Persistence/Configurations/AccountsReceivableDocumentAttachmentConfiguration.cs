using Countify.Domain.Entities.AccountsReceivable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class AccountsReceivableDocumentAttachmentConfiguration
    : IEntityTypeConfiguration<AccountsReceivableDocumentAttachment>
{
    public void Configure(EntityTypeBuilder<AccountsReceivableDocumentAttachment> builder)
    {
        builder.ToTable("AccountsReceivableDocumentAttachments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileName)
            .HasMaxLength(260)
            .IsRequired();

        builder.Property(x => x.ContentType)
            .HasMaxLength(100);

        builder.Property(x => x.StoragePath)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.UploadedBy)
            .HasMaxLength(200);

        builder.HasOne(x => x.Document)
            .WithMany(d => d.Attachments)
            .HasForeignKey(x => x.DocumentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.DocumentId);
    }
}
