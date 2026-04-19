using Bora.Inventory.Application.Common.Pagination;
using Bora.Inventory.Domain.Common.Entities;

namespace Bora.Inventory.Application.Common.Repository;

public interface IReadRepository<TEntity, in TKey> where TEntity : Entity<TKey>
{
    Task <TEntity?> GetByIdAsync(TKey id);
    Task<PageResult<TEntity>> PageAsync(PageRequest request);
}