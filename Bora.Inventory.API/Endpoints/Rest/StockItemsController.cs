using Bora.Inventory.API.Common.Pagination;
using Bora.Inventory.API.Requests.StockItems;
using Bora.Inventory.Application.Common.Pagination;
using Bora.Inventory.Application.Features.StockItems.Queries.GetStockItemById;
using Bora.Inventory.Application.Features.StockItems.Queries.SearchStockItems;
using Microsoft.AspNetCore.Mvc;

namespace Bora.Inventory.API.Endpoints.Rest;

[ApiController]
[Route("api/v1/[controller]")]
public class StockItemsController : ControllerBase
{
    private readonly GetStockItemByIdHandler _getStockItemByIdHandler;
    private readonly SearchStockItemsHandler _searchStockItemsHandler;

    public StockItemsController(GetStockItemByIdHandler getStockItemByIdHandler, SearchStockItemsHandler searchStockItemsHandler)
    {
        _getStockItemByIdHandler = getStockItemByIdHandler;
        _searchStockItemsHandler = searchStockItemsHandler;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStockItem([FromRoute(Name = "id")] Guid id)
    {
        var result = await _getStockItemByIdHandler.HandleAsync(new GetStockItemByIdQuery(id));
        return Ok(result);
    }
    
    [HttpGet("search")]
    public async Task<IActionResult> SearchStockItems([FromQuery] PaginationParams @params)
    {
        var pageRequest = new PageRequest(@params.PageNumber, @params.PageSize);
        var result = await _searchStockItemsHandler.HandleAsync(new SearchStockItemsQuery(pageRequest));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStockItem([FromBody] CreateStockItemRequest request)
    {
        throw new NotImplementedException();
    }

}