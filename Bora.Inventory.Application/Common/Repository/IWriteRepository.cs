using Bora.Inventory.Domain.Common.Entities;

namespace Bora.Inventory.Application.Common.Repository;

public interface IWriteRepository<TEntity, TKey> where TEntity : Entity<TKey> 
{
    Task CreateAsync(TEntity entity);
}