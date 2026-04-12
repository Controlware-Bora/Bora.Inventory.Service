namespace Bora.Inventory.Domain.Common.Entities;

public abstract class Entity<TKey>
{
    public required TKey Id { get; init; }
}