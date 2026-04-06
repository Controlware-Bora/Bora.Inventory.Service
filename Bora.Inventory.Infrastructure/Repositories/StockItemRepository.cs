using Bora.Inventory.Application.Repositories;
using Bora.Inventory.Domain.Aggregates.StockItems;
using Microsoft.EntityFrameworkCore;

namespace Bora.Inventory.Infrastructure.Repositories;

public class StockItemRepository(DbSet<StockItem> stockItems) : IStockItemRepository
{
    public async Task<StockItem?> GetByIdAsync(Guid id)
    {
        return await stockItems.Where(si => si.Id == id).FirstOrDefaultAsync();
    }
}