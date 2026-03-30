namespace Bora.Inventory.Domain.Common.ValueObject;

public class Money
{
    public decimal Amount { get; private set; }
    public Currency Currency { get; private set; } = null!;
    
    // EF Core
    private Money()
    {
    }

    public Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }
}