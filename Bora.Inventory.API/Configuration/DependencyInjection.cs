using Bora.Inventory.Application.Configuration.DependencyInjection;
using Bora.Inventory.Application.Configuration.Options;
using Bora.Inventory.Infrastructure.Configuration.DependencyInjection;

namespace Bora.Inventory.API.Configuration;

public static class DependencyInjection
{
    private static ApplicationOptions GenerateApplicationOption(IConfiguration configuration)
    {
        var autoMapperLicenseKey = configuration.GetSection("AutoMapper:LicenseKey").Value;

        if (string.IsNullOrEmpty(autoMapperLicenseKey)) throw new Exception("There is no license key for automapper.");
        
        return ApplicationOptions.Build(autoMapperLicenseKey);
    }


    public static IServiceCollection AddApiServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Creating Application Options
        var applicationOptions = GenerateApplicationOption(configuration);
        
        // Adding Infrastructure Layer
        services.AddInfrastructureLayer(configuration);
        
        // Adding Application Layer
        services.AddApplicationLayer(applicationOptions);
        return services;
    }
}