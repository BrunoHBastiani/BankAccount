using BankAccount.Models;
using BankAccount.Models.Enums;
using BankAccount.Repositories.Interfaces;
using BankAccount.Services.Interfaces;

namespace BankAccount.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository=transactionRepository;
    }

    public async Task CreateTransactionAsync(Guid accountId, TransactionType type, decimal amount)
    {
        Transaction transaction = new Transaction
        {
            AccountId = accountId,
            Type = type,
            Amount = amount,
            CreatedAt = DateTime.UtcNow,
        };

        await _transactionRepository.CreateTransactionAsync(transaction);
    }
}
