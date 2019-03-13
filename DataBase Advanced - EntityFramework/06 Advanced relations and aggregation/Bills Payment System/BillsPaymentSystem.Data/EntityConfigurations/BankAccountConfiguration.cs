namespace BillsPaymentSystem.Data.EntityConfigurations
{
    using BillsPaymentSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(x => x.BankAccountId);

            builder.Property(x => x.BankName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.SWIFT)
                .IsUnicode(false)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(x => x.PaymentMethod)
              .WithOne(x => x.BankAccount);
        }
    }
}

