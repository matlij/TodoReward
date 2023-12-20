namespace TodoReward.Core.Extensions;

public static class StringExtensions
{
    public static DateTime ToDateTime(this string source)
    {
        if (!DateTime.TryParse(source, out var result))
        {
            throw new CustomMapperException<string, DateTime>(source);
        }

        return result;
    }
}