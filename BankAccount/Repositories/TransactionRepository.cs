using BankAccount.Models;
using BankAccount.Repositories.Interfaces;

namespace BankAccount.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly BankAccountContext _context;

    public TransactionRepository(BankAccountContext context)
    {
        _context=context;
    }

    public async Task CreateTransactionAsync(Transaction transaction)
    {
        await _context.AddAsync(transaction);
        await _context.SaveChangesAsync();
    }
}
