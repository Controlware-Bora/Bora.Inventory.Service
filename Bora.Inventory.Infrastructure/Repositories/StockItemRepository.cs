using Bora.Inventory.Application.Common.Pagination;
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

    public async Task<PageResult<StockItem>> PageAsync(PageRequest request)
    {
        var query =  _stockItems.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).AsQueryable();
        var page = new PageResult<StockItem>
        {
            Items = await query.ToListAsync(),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalRecords =  query.Count()
        };
        return page;
    }

    public async Task CreateAsync(StockItem entity)
    {
        await _stockItems.AddAsync(entity);
    }
}