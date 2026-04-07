using Bora.Inventory.Application.Repositories;
using Bora.Inventory.Infrastructure.Persistence.Context;
using Bora.Inventory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bora.Inventory.Infrastructure.Configuration.DependencyInjection;

public static class DependencyInjection
{
    private static void ConnectDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("OracleDbConnecton");
        services.AddDbContext<InventoryDbContext>(options => options.UseOracle(connectionString));
    }

    private static void AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IStockItemRepository, StockItemRepository>();
    }

    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConnectDatabase(configuration);
        services.AddScopedServices();
        return services;
    }
    
}