using Bora.Inventory.Domain.Aggregates.StockItems;
using Microsoft.EntityFrameworkCore;

namespace Bora.Inventory.Infrastructure.Persistence.Context;

public class InventoryDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<StockItem> StockItems => Set<StockItem>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}