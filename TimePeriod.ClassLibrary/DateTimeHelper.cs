
namespace TimePeriod.ClassLibrary;

public static class DateTimeHelper
{
    public static DateOnly DateOfAnyNearestDay(this DateTimeOffset input, DayOfWeek dayOfWeek)
        => DateOfAnyNearestDay(DateOnly.FromDateTime(input.DateTime), dayOfWeek);
    public static DateOnly DateOfAnyNearestDay(this DateTime input, DayOfWeek dayOfWeek)
        => DateOfAnyNearestDay(DateOnly.FromDateTime(input), dayOfWeek);

    public static DateOnly DateOfAnyNearestDay(this DateOnly input, DayOfWeek dayOfWeek)
    {
        int diff = dayOfWeek - input.DayOfWeek;

        return diff switch
        {
            _ when diff.Equals(0) 
                => input,

            _ when (diff >= -3) && (diff <= 3) 
                => input.AddDays(diff),

            _ when diff > 0
                => input.AddDays(-7 + diff),

            _ when diff < 0
                => input.AddDays(7 + diff),

            //Should never hit
            _ => throw new NotImplementedException($"[GetNearestDateOfDay] diff of {diff} not implemented.")
        };
    }
}
