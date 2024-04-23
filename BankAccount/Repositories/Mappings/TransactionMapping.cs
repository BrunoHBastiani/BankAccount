using BankAccount.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAccount.Repositories.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Amount).HasColumnName("amount").IsRequired();
        builder.Property(x => x.Type).HasColumnName("type").HasConversion(typeof(string)).IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();

        builder.HasOne(x => x.Account).WithMany(x => x.Transactions).HasForeignKey(x => x.AccountId);
    }
}
