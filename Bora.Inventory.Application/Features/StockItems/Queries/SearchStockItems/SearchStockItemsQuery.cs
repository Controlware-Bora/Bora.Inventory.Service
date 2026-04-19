using Bora.Inventory.Application.Common.CQRS;
using Bora.Inventory.Application.Common.Pagination;

namespace Bora.Inventory.Application.Features.StockItems.Queries.SearchStockItems;

public class SearchStockItemsQuery : IQuery
{

    public PageRequest Page { get; set; } = new();

    #region Constructors
    public SearchStockItemsQuery() {}
    public SearchStockItemsQuery(PageRequest page)
    {
        Page = page;
    }
    #endregion
}