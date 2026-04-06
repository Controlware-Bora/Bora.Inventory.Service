namespace Bora.Inventory.API.Configuration;

public static class ApplicationBuilder
{
    public static IServiceCollection BuildApi(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}