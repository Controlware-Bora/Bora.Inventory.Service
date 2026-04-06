namespace Bora.Inventory.Infrastructure.Extensions;

public static class StringExtensions
{
    public static string ToSnakeCase(this string str)
    {
        if(string.IsNullOrEmpty(str))
            return string.Empty;
        return str.AsEnumerable().Select(c => c).ToString()!;
    }
}