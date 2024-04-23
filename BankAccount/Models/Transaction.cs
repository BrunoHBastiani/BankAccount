using BankAccount.Models.Enums;

namespace BankAccount.Models;

public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Amount { get; set; } = 0;
    public TransactionType Type { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Relationship
    public Account? Account { get; set; }
    public Guid? AccountId { get; set; }
}
