using Countify.Domain.Entities.Billing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Countify.Infrastructure.Persistence.Configurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Number)
            .HasMaxLength(40);

        // El número fiscal es único cuando ya fue asignado (las facturas en memoria lo heredan null).
        builder.HasIndex(x => x.Number)
            .IsUnique()
            .HasFilter("[Number] IS NOT NULL");

        builder.Property(x => x.CustomerName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.CustomerTaxId).HasMaxLength(20);
        builder.Property(x => x.CustomerAddress).HasMaxLength(300);
        builder.Property(x => x.CustomerPhone).HasMaxLength(30);
        builder.Property(x => x.Reference).HasMaxLength(100);
        builder.Property(x => x.OrderNumber).HasMaxLength(50);
        builder.Property(x => x.Notes).HasMaxLength(500);
        builder.Property(x => x.VoidReason).HasMaxLength(500);
        builder.Property(x => x.CAI).HasMaxLength(100);
        builder.Property(x => x.RangeFrom).HasMaxLength(50);
        builder.Property(x => x.RangeTo).HasMaxLength(50);

        builder.Property(x => x.ExchangeRate).HasPrecision(18, 6).IsRequired();
        builder.Property(x => x.SubTotal).HasPrecision(18, 2);
        builder.Property(x => x.TaxAmount).HasPrecision(18, 2);
        builder.Property(x => x.DiscountTotal).HasPrecision(18, 2);
        builder.Property(x => x.SubTotalExempt).HasPrecision(18, 2);
        builder.Property(x => x.Total).HasPrecision(18, 2);
        builder.Property(x => x.TotalLocal).HasPrecision(18, 2);

        builder.Property(x => x.PaymentTerms).HasConversion<int>();

        builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Department).WithMany().HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Project).WithMany().HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Currency).WithMany().HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.FiscalControl).WithMany().HasForeignKey(x => x.FiscalControlId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ReceivableDocument).WithMany().HasForeignKey(x => x.ReceivableDocumentId).OnDelete(DeleteBehavior.SetNull);
    }
}
