namespace Bora.Inventory.Application.Configuration.Options;

public sealed class ApplicationOptions
{
    public string AutoMapperLicenseKey { get; set; } = string.Empty;
    
    public static ApplicationOptions Build(string autoMapperLicenseKey)
    {
        return new ApplicationOptions
        {
            AutoMapperLicenseKey = autoMapperLicenseKey
        };
    }
}