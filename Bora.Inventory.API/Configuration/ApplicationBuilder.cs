using Bora.Inventory.Infrastructure.Persistence.Context;
using Bora.Inventory.Infrastructure.Seeding;

namespace Bora.Inventory.API.Configuration;

public static class ApplicationBuilder
{
    public static async void BuildApp(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();
        
        await StockItemSeeding.SeedAsync(dbContext);
    }
}