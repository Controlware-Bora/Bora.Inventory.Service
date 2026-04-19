using Bora.Inventory.Application.Common.CQRS;

namespace Bora.Inventory.Application.Features.StockItems.Commands.CreateStockItem;

public class CreateStockItemCommand : ICommand
{
    public string Name { get; init; } = string.Empty;
    public int Quantity { get; init; } = 0;
    public string Description { get; init; } = string.Empty;
}