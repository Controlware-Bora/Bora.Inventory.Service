using Bora.Inventory.Application.Repositories;
using Bora.Inventory.Domain.Aggregates.StockItems;
using Bora.Inventory.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Bora.Inventory.Infrastructure.Repositories;

public class StockItemRepository : IStockItemRepository
{
    private DbSet<StockItem> _stockItems;

    public StockItemRepository(InventoryDbContext context)
    {
        _stockItems = context.StockItems;
    }

    public async Task<StockItem?> GetByIdAsync(Guid id)
    {
        return await _stockItems.Where(si => si.Id == id).FirstOrDefaultAsync();
    }
}