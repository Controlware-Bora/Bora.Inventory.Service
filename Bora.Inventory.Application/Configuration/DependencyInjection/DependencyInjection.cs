using Bora.Inventory.Application.Configuration.Options;
using Bora.Inventory.Application.Features.StockItems.Commands.CreateStockItem;
using Bora.Inventory.Application.Features.StockItems.Queries.GetStockItemById;
using Bora.Inventory.Application.Features.StockItems.Queries.SearchStockItems;
using Bora.Inventory.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Bora.Inventory.Application.Configuration.DependencyInjection;

public static class DependencyInjection
{
    private static void AddMapping(this IServiceCollection services, string autoMapperLicenseKey)
    {
        services.AddAutoMapper(cfg => { cfg.LicenseKey = autoMapperLicenseKey; }, typeof(StockItemProfile));
    }

    private static void AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<GetStockItemByIdHandler>();
        services.AddScoped<SearchStockItemsHandler>();
        services.AddScoped<CreateStockItemHandler>();
    }
    
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services, ApplicationOptions options)
    {
        services.AddMapping(options.AutoMapperLicenseKey);
        services.AddScopedServices();
        return services;
    }
}