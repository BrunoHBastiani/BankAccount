using BankAccount.Models;
using BankAccount.Models.Enums;
using BankAccount.Repositories.Interfaces;
using BankAccount.Services.Interfaces;

namespace BankAccount.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository=accountRepository;
    }

    public async Task CalculateBalanceAsync(TransactionType type, decimal amount)
    {
        Account account = await RecoverAccountAsync();

        switch(type)
        {
            case TransactionType.Initialize:
                account.Balance = amount;
                break;

            case TransactionType.CashIn:
                account.Balance += amount;
                break;

            case TransactionType.CashOut:
                account.Balance -= amount;
                break;
        }

        await _accountRepository.SaveChangesAsync();
    }

    public async Task<Account> RecoverAccountAsync()
    {
        return await _accountRepository.RecoverAccountAsync();
    }

    public async Task InitializeAccountAsync()
    {
        await _accountRepository.InitializeAccountAsync();
    }

    public async Task ResetAsync()
    {
        await _accountRepository.ResetAsync();
    }
}
