namespace Bora.Inventory.Infrastructure.Extensions;

public static class StringExtensions
{
    public static string ToSnakeCase(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return string.Empty;

        return string.Concat(str.Select(c =>
        {
            if (char.IsUpper(c))
                return $"_{char.ToLowerInvariant(c).ToString()}";
            return c.ToString();
        })).Substring(1);
    }

    public static string ToScreamingSnakeCase(this string str)
    {
        if(string.IsNullOrEmpty(str))
            return string.Empty;
        return string.Concat(str.Select(c =>
        {
            if(char.IsUpper(c))
                return $"_{c.ToString()}";
            return char.ToUpper(c).ToString();
        })).Substring(1);
    }

    public static string ToSnakeCaseEnum(this string str)
    {
        IEnumerable<Char> Convert(IEnumerator<char> enumerator)
        {
            if (!enumerator.MoveNext())
                yield break;
            while (enumerator.MoveNext())
            {
                if (char.IsUpper(enumerator.Current))
                {
                    yield return '_';
                    yield return char.ToLowerInvariant(enumerator.Current);
                    continue;
                }
                yield return enumerator.Current;
            }
        }

        using var strEnumerator = str.AsEnumerable().GetEnumerator();
        return string.Concat(Convert(strEnumerator));
    }
}