using BankAccount.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAccount.Repositories.Mappings;

public class AccountMapping : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasColumnName("name").IsRequired();
        builder.Property(x => x.Balance).HasColumnName("balance").IsRequired();

        builder.HasMany(x => x.Transactions).WithOne(x => x.Account).HasForeignKey(x => x.AccountId);
    }
}
