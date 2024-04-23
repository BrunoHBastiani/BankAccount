using BankAccount.Models;

namespace BankAccount.Repositories.Interfaces;

public interface IAccountRepository
{
    Task InitializeAccountAsync();
    Task<Account> RecoverAccountAsync();
    Task SaveChangesAsync();
    Task ResetAsync();
}
