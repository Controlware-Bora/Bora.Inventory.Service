using AutoMapper;
using Bora.Inventory.Application.Common.Constants;
using Bora.Inventory.Application.Common.CQRS;
using Bora.Inventory.Application.Common.Exceptions;
using Bora.Inventory.Application.Features.StockItems.DTOs.Detailed;
using Bora.Inventory.Application.Repositories;

namespace Bora.Inventory.Application.Features.StockItems.Queries.GetStockItemById;

public class GetStockItemByIdHandler(IStockItemRepository stockItemRepository, IMapper mapper)
    : IQueryHandler<GetStockItemByIdQuery, DetailedStockItemDto>
{
    public async Task<DetailedStockItemDto> HandleAsync(GetStockItemByIdQuery query)
    {
        var stockItem = await stockItemRepository.GetByIdAsync(query.Id);
        if (stockItem == null)
            throw new ItemNotFoundException(EntityNames.StockItem, query.Id);
        return mapper.Map<DetailedStockItemDto>(stockItem);
    }
}