using Microsoft.AspNetCore.Mvc;

namespace Bora.Inventory.API.Common.Pagination;

public record PaginationParams(
    [FromQuery(Name = "pageNumber")] int PageNumber,
    [FromQuery(Name = "pageSize")] int PageSize);