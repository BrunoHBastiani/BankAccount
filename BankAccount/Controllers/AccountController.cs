using BankAccount.Models;
using BankAccount.Models.Enums;
using BankAccount.Services;
using BankAccount.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace BankAccount.Controllers;
public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private readonly ITransactionService _transactionService;

    private Account? _account;

    public AccountController(IAccountService accountService, ITransactionService transactionService)
    {
        _accountService=accountService;
        _transactionService=transactionService;
    }

    public async Task<ActionResult> Index()
    {
        await _accountService.InitializeAccountAsync();

        _account = await _accountService.RecoverAccountAsync();

        ViewBag.Name = _account.Name;
        ViewBag.Balance = _account.Balance;
        ViewBag.CashInBalance = _account.Transactions.Where(x => x.Type == TransactionType.CashIn).Sum(x => x.Amount);
        ViewBag.CashOutBalance = _account.Transactions.Where(x => x.Type == TransactionType.CashOut).Sum(x => x.Amount);

        return View();
    }

    [HttpPost]
    public async Task<ActionResult> InitializeBalance(decimal amount)
    {
        _account = await _accountService.RecoverAccountAsync();

        await _accountService.CalculateBalanceAsync(TransactionType.Initialize, amount);
        await _transactionService.CreateTransactionAsync(_account.Id, TransactionType.Initialize, amount);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> CashIn(decimal addAmount)
    {
        _account = await _accountService.RecoverAccountAsync();

        await _accountService.CalculateBalanceAsync(TransactionType.CashIn, addAmount);
        await _transactionService.CreateTransactionAsync(_account.Id, TransactionType.CashIn, addAmount);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> CashOut(decimal removeAmount)
    {
        _account = await _accountService.RecoverAccountAsync();

        await _accountService.CalculateBalanceAsync(TransactionType.CashOut, removeAmount);
        await _transactionService.CreateTransactionAsync(_account.Id, TransactionType.CashOut, removeAmount);

        return RedirectToAction("Index");
    }


    [HttpPost]
    public async Task<ActionResult> Reset()
    {
        await _accountService.ResetAsync();

        return RedirectToAction("Index");
    }
}
