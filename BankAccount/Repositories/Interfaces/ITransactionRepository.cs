using BankAccount.Models;

namespace BankAccount.Repositories.Interfaces;

public interface ITransactionRepository
{
    Task CreateTransactionAsync(Transaction transaction);
}
