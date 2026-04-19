using AutoMapper;
using Bora.Inventory.Application.Common.Pagination;
using Bora.Inventory.Application.Features.StockItems.DTOs.Basic;
using Bora.Inventory.Application.Features.StockItems.DTOs.Detailed;
using Bora.Inventory.Domain.Aggregates.StockItems;

namespace Bora.Inventory.Application.Mapping;

public class StockItemProfile : Profile
{
    public StockItemProfile()
    {
        CreateMap<StockItem, DetailedStockItemDto>();
        CreateMap<StockItem, BasicStockItemDto>();
        CreateMap<PageResult<StockItem>, PageResult<BasicStockItemDto>>();
    }
}