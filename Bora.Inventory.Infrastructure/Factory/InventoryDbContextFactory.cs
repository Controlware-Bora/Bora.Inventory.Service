using Bora.Inventory.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bora.Inventory.Infrastructure.Factory;

// Works with migrations.
public class InventoryDbContextFactory : IDesignTimeDbContextFactory<InventoryDbContext>
{
    private readonly IConfiguration _configuration;

    public InventoryDbContextFactory()
    {
        // Initialize builder configuration. (We are recreating a new one for migrations"
        Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), "Bora.Inventory.API"));
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile($"appsettings.Development.json", true)
            .AddEnvironmentVariables()
            .Build();
    }

    private bool ValidateArgumentPrefix(string arg, string prefix = "--")
    {
        return arg.Substring(0, 2) == prefix;
    }


    private Dictionary<string, string?> ConvertToDictionaryArguments(string[] args)
    {
        Dictionary<string, string> dargs = new Dictionary<string, string>();


        int realArgsCount = args.Length - args.Length % 2;

        for (int i = 0; i < realArgsCount; i += 2)
        {
            if (ValidateArgumentPrefix(args[i]))
                dargs.Add(args[i], args[i + 1]);
            else
                throw new ArgumentException("");
        }

        return dargs;
    }

    public InventoryDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();

        Dictionary<string, string?> dargs = ConvertToDictionaryArguments(args);

        var connectionString = _configuration.GetConnectionString("OracleDbConnection");

        if (dargs.TryGetValue("--db-provider", out string? dbProvider))
        {
            switch (dbProvider)
            {
                case "oracle":
                    optionsBuilder.UseOracle(connectionString);
                    break;
                case "postgre":
                    connectionString = _configuration.GetConnectionString("PostgreDbConnection");
                    optionsBuilder.UseNpgsql(connectionString);
                    break;
                default:
                    optionsBuilder.UseOracle(connectionString);
                    break;
            }
        }

        InventoryDbContext dbContext = new InventoryDbContext(optionsBuilder.Options);


        return dbContext;
    }
}