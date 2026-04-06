namespace Bora.Inventory.Application.Common.Exceptions;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException(string? entity, object key) : base($"Item of type '{entity}' with id '{key}' not found")
    {
    }
}