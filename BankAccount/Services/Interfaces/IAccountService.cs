using BankAccount.Models;
using BankAccount.Models.Enums;

namespace BankAccount.Services.Interfaces;

public interface IAccountService
{
    Task InitializeAccountAsync();
    Task<Account> RecoverAccountAsync();
    Task CalculateBalanceAsync(TransactionType type, decimal amount);
    Task ResetAsync();
}
