using Bora.Inventory.Application.Common.CQRS;

namespace Bora.Inventory.Application.Features.StockItems.Queries.GetStockItemById;

public record GetStockItemByIdQuery(Guid Id) : IQuery;