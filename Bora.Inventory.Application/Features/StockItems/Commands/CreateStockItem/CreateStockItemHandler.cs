using AutoMapper;
using Bora.Inventory.Application.Common.CQRS;
using Bora.Inventory.Application.Features.StockItems.DTOs.Detailed;
using Bora.Inventory.Application.Repositories;
using Bora.Inventory.Domain.Aggregates.StockItems;

namespace Bora.Inventory.Application.Features.StockItems.Commands.CreateStockItem;

public class CreateStockItemHandler : ICommandHandler<CreateStockItemCommand, DetailedStockItemDto>
{
    private readonly IStockItemRepository _stockItemRepository;
    private readonly IMapper _mapper;
    
    public CreateStockItemHandler(IStockItemRepository stockItemRepository, IMapper mapper)
    {
        _stockItemRepository = stockItemRepository;
        _mapper = mapper;
    }

    public async Task<DetailedStockItemDto> HandleAsync(CreateStockItemCommand command)
    {
        var newStockItem = StockItem.Create(command.Name, command.Quantity);
        await _stockItemRepository.CreateAsync(newStockItem);
        return _mapper.Map<DetailedStockItemDto>(newStockItem);
    }
}