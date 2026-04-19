using Bora.Inventory.Domain.Common.Entities;

namespace Bora.Inventory.Domain.Aggregates.StockItems;

public class StockItem : AggregateRoot<Guid>
{
    #region Attributes

    public string Name { get; set; } = null!;
    public int Quantity { get; set; }

    #endregion

    #region Constructors

    public StockItem()
    {
    }

    public StockItem(string name, int quantity) : base()
    {
        Id = Guid.NewGuid();
        Name = name;
        Quantity = quantity;
    }

    #endregion


    #region Domain Methods

    public static StockItem Create(string name, int quantity)
    {
        var newId = Guid.NewGuid();
        return new StockItem(name, quantity) { Id = newId };
    }

    #endregion
}