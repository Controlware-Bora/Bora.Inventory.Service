using Bora.Inventory.Domain.Aggregates.StockItems;
using Bora.Inventory.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Bora.Inventory.Infrastructure.Seeding;

public static class StockItemSeeding
{
    public static async Task SeedAsync(InventoryDbContext context, CancellationToken cancellationToken = default)
    {
        var stockItems = new List<StockItem>([
            new StockItem {
                Id =  Guid.NewGuid(),
                Name = "Gol",
                Quantity = 20
            },
            new StockItem
            {
                Id =  Guid.NewGuid(),
                Name = "Gol",
                Quantity = 20
            }
        ]);
        
        if (await context.StockItems.CountAsync(cancellationToken: cancellationToken) > 0)
        {
            return;
        }
        
        await context.StockItems.AddRangeAsync(stockItems, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
