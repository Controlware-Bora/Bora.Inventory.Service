using Bora.Inventory.Application.Repositories;
using Bora.Inventory.Infrastructure.Persistence.Context;
using Bora.Inventory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bora.Inventory.Infrastructure.Configuration.DependencyInjection;

public static class DependencyInjection
{
    private static void DynamicDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var provider = Environment.GetEnvironmentVariable("DB_PROVIDER") ?? "";
        switch (provider)
        {
            case "oracle": 
                services.AddDbContext<InventoryDbContext>(options => options.UseOracle(configuration.GetConnectionString("OracleDbConnection")));
                break;
            case "postgres":
                services.AddDbContext<InventoryDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreDbConnection")));
                break;
            case "":
                services.AddDbContext<InventoryDbContext>(options => options.UseOracle(configuration.GetConnectionString("OracleDbConnection")));
                break;
            default:
                // By default, we use oracle connection.
                services.AddDbContext<InventoryDbContext>(options => options.UseOracle(configuration.GetConnectionString("OracleDbConnection")));
                break;
        }
        
        
    }

    private static void AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IStockItemRepository, StockItemRepository>();
    }

    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.DynamicDatabaseConnection(configuration);
        services.AddScopedServices();
        return services;
    }
    
}