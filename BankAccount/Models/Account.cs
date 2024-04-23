namespace BankAccount.Models;

public class Account
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public decimal Balance { get; set; } = 0;

    // Relationship
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}
