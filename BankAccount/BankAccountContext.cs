using BankAccount.Models;

using Microsoft.EntityFrameworkCore;

namespace BankAccount;

public class BankAccountContext : DbContext
{
    public BankAccountContext() : base() { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=defaultdb;User Id=admin;Password=admin;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankAccountContext).Assembly);
    }
}
