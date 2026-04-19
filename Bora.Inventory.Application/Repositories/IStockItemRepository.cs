using Bora.Inventory.Application.Common.Repository;
using Bora.Inventory.Domain.Aggregates.StockItems;

namespace Bora.Inventory.Application.Repositories;

public interface IStockItemRepository : IReadRepository<StockItem, Guid>, IWriteRepository<StockItem, Guid>
{
    
}