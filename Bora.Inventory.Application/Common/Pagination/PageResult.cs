using Bora.Inventory.Domain.Common.Entities;

namespace Bora.Inventory.Application.Common.Pagination;

public class PageResult<TEntity>
{
    public IReadOnlyCollection<TEntity> Items { get; set; } = Array.Empty<TEntity>();
    public int TotalRecords { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}