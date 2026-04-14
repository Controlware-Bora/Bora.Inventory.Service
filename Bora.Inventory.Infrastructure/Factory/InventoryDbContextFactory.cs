using Bora.Inventory.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bora.Inventory.Infrastructure.Factory;

// Works with migrations.
public class InventoryDbContextFactory : IDesignTimeDbContextFactory<InventoryDbContext>
{
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

        if (dargs.TryGetValue("--db-provider", out string? dbProvider))
        {
            switch (dbProvider)
            {
                case "oracle":
                    optionsBuilder.UseOracle(
                        "User Id=BORA_MAIN_DEV;Password=012205$Wirachain;Data Source=localhost:1521/XEPDB1");
                    break;
                case "postgre":
                    optionsBuilder.UseNpgsql(
                        "Host=localhost;Port=5432;Database=bora_inventory;Username=postgres;Password=012205;");
                    break;
                default:
                    optionsBuilder.UseOracle(
                        "User Id=BORA_MAIN_DEV;Password=012205$Wirachain;Data Source=localhost:1521/XEPDB1");
                    break;
            }
        }
        InventoryDbContext dbContext = new InventoryDbContext(optionsBuilder.Options);
        
        
        
        return dbContext;
    }
}