namespace Bora.Inventory.Application.Common.Pagination;

public record PageRequest(int PageNumber = 1, int PageSize = 10, string SearchTerm = "");