using BankAccount.Models;
using BankAccount.Models.Enums;

namespace BankAccount.Services.Interfaces;

public interface ITransactionService
{
    Task CreateTransactionAsync(Guid accountId, TransactionType type, decimal amount);
}
