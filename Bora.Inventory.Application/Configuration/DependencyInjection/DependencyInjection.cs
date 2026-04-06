using Bora.Inventory.Application.Configuration.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Bora.Inventory.Application.Configuration.DependencyInjection;

public static class DependencyInjection
{
    private static void AddMapping(this IServiceCollection services, string autoMapperLicenseKey)
    {
        services.AddAutoMapper(cfg => { cfg.LicenseKey = autoMapperLicenseKey; });
    }
    
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services, ApplicationOptions options)
    {
        services.AddMapping(options.AutoMapperLicenseKey);
        return services;
    }
}