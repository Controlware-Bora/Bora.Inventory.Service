using AutoMapper;
using Bora.Inventory.Application.Common.CQRS;
using Bora.Inventory.Application.Common.Pagination;
using Bora.Inventory.Application.Features.StockItems.DTOs.Basic;
using Bora.Inventory.Application.Repositories;
using Bora.Inventory.Domain.Aggregates.StockItems;

namespace Bora.Inventory.Application.Features.StockItems.Queries.SearchStockItems;

public class SearchStockItemsHandler : IQueryHandler<SearchStockItemsQuery, PageResult<BasicStockItemDto>>
{
    private readonly IStockItemRepository _stockItemRepository;
    private readonly IMapper _mapper;

    public SearchStockItemsHandler(IStockItemRepository stockItemRepository, IMapper mapper)
    {
        _stockItemRepository = stockItemRepository;
        _mapper = mapper;
    }

    public async Task<PageResult<BasicStockItemDto>> HandleAsync(SearchStockItemsQuery query)
    {
        return _mapper.Map<PageResult<BasicStockItemDto>>(await _stockItemRepository.PageAsync(query.Page));
    }
}