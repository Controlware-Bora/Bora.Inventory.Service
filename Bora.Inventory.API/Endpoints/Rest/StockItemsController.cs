using Bora.Inventory.Application.Features.StockItems.Queries.GetStockItemById;
using Microsoft.AspNetCore.Mvc;

namespace Bora.Inventory.API.Endpoints.Rest;

[ApiController]
[Route("api/v1/[controller]")]
public class StockItemsController : ControllerBase
{
    private readonly GetStockItemByIdHandler _getStockItemByIdHandler;

    public StockItemsController(GetStockItemByIdHandler getStockItemByIdHandler)
    {
        _getStockItemByIdHandler = getStockItemByIdHandler;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStockItem([FromRoute(Name = "id")] Guid id)
    {
        var result = await _getStockItemByIdHandler.HandleAsync(new GetStockItemByIdQuery(id));
        return Ok(result);
    }
}