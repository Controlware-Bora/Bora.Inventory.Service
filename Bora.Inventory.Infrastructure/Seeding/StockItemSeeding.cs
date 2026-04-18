using Bora.Inventory.Domain.Aggregates.StockItems;
using Bora.Inventory.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Bogus;

namespace Bora.Inventory.Infrastructure.Seeding;

public static class StockItemSeeding
{
    private static readonly Faker<StockItem>? Faker =  default;

    static StockItemSeeding()
    {
        Faker = new Faker<StockItem>()
            .RuleFor(s => s.Id, f => Guid.NewGuid())
            .RuleFor(s => s.Name, f => f.Commerce.ProductName())
            .RuleFor(s => s.Quantity, f => f.Random.Number(1, 100));
        
        Randomizer.Seed = new Random(123);
    }

    public static async Task SeedAsync(InventoryDbContext context, CancellationToken cancellationToken = default)
    {
        if(Faker == null) throw new InvalidOperationException("Seed is null");
        
        var count = await context.StockItems.CountAsync(cancellationToken: cancellationToken);
        Console.WriteLine($"There are already {count} items");
        if (count > 0)
            return;
        
        var stockItems = Faker.Generate(10000);
        await context.StockItems.AddRangeAsync(stockItems, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
