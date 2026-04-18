using Bora.Inventory.Domain.Aggregates.StockItems;
using Bora.Inventory.Infrastructure.Extensions;
using Bora.Inventory.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;

namespace Bora.Inventory.Infrastructure.Persistence.Context;

public class InventoryDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<StockItem> StockItems => Set<StockItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryDbContext).Assembly);

        if (Database.IsOracle()) modelBuilder.ConvertAllToScreamingSnakeCase();
        else if(Database.IsNpgsql()) modelBuilder.ConvertAllToSnakeCase();
        
        base.OnModelCreating(modelBuilder);
    }
}