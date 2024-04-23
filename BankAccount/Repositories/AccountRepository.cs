using BankAccount.Models;
using BankAccount.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BankAccount.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly BankAccountContext _context;

    public AccountRepository(BankAccountContext context)
    {
        _context=context;
    }

    public async Task InitializeAccountAsync()
    {
        if (!_context.Accounts.Any())
        {
            Account account = new Account
            {
                Id = Guid.NewGuid(),
                Name = "Bruno",
                Balance = 0,
                Transactions = new List<Transaction>(),
            };

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Account> RecoverAccountAsync()
    {
        return await _context
            .Accounts
            .Include(x => x.Transactions)
            .FirstOrDefaultAsync() ??
            new Account();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task ResetAsync()
    {
        string deleteTransactions = "DELETE FROM transactions;";
        string deleteAccounts = "DELETE FROM accounts;";

        await _context.Database.ExecuteSqlRawAsync(deleteTransactions);
        await _context.Database.ExecuteSqlRawAsync(deleteAccounts);
    }
}
