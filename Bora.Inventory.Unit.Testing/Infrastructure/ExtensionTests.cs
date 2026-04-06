using Bora.Inventory.Infrastructure.Extensions;

namespace Bora.Inventory.Unit.Testing.Infrastructure;

public class ExtensionTests
{
    [Fact]
    public void TestStringExtension()
    {
        Console.WriteLine(nameof(TestStringExtension));
        Console.WriteLine("HolaLeonardo".ToSnakeCase());
        Assert.Equal("TestStringExtension", nameof(TestStringExtension));
    }
}