using Bora.Inventory.Domain.Common.Entities;

namespace Bora.Inventory.Domain.Aggregates.StockItems;

public class StockItem : AggregateRoot<Guid>
{
    #region Attributes

    public string Name { get; private set; }
    public int Quantity { get; private set; }
    
    #endregion

    #region Constructors
    
    public StockItem(Guid id, string name, int quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }
    
    #endregion
}