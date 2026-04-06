using Bora.Inventory.Domain.Common.Entities;

namespace Bora.Inventory.Application.Common.Repository;

public interface IReadRepository<TEntity, TKey> where TEntity : Entity<TKey>
{
    Task <TEntity?> GetByIdAsync(TKey id);
}