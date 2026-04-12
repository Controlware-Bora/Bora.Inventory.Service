using Bora.Inventory.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bora.Inventory.Infrastructure.Factory;

public class InventoryDbContextFactory : IDesignTimeDbContextFactory<InventoryDbContext>
{
    public InventoryDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();


        var provider = args.Count() == 1 ? args[0] : null;

        foreach (var arg in args)
        {
            
            Console.WriteLine(arg);
        }

        optionsBuilder.UseOracle("User Id=BORA_MAIN_DEV;Password=012205$Wirachain;Data Source=localhost:1521/XEPDB1");

        return new InventoryDbContext(optionsBuilder.Options);
    }
}