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
            },
            new StockItem
            {
                Id =  Guid.NewGuid(),
            }
        ]);
        
        if (await context.StockItems.AnyAsync(cancellationToken))
        {
            return;
        }
        
        await context.StockItems.AddRangeAsync(stockItems, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
