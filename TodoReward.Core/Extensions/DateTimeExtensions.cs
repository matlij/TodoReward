namespace TodoReward.Core.Extensions;

public static class DateTimeExtensions
{
    public static string? ToShortDateString(this DateTime? date)
    {
        if (!date.HasValue || date == DateTime.MinValue)
        {
            return null;
        }

        return date.Value.ToShortDateString();
    }
}