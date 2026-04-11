using Bora.Inventory.Infrastructure.Extensions;
using Xunit.Abstractions;

namespace Bora.Inventory.Unit.Testing.Infrastructure;

public class ExtensionTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ExtensionTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void TestStringExtension()
    {
        _testOutputHelper.WriteLine("HolaLeonardo".ToSnakeCase());
        Assert.Equal("test_string_extension","TestStringExtension".ToSnakeCase());
    }
    
    [Fact]
    public void TestStringExtensionEnum()
    {
        _testOutputHelper.WriteLine("HolaLeonardo".ToSnakeCase());
        Assert.Equal("test_string_extension","TestStringExtension".ToSnakeCase());
    }
}