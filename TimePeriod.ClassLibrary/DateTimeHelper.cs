
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
                => input.AddDays(diff - 7),

            _ when diff < 0
                => input.AddDays(diff + 7),

            //Should never hit
            _ => throw new NotImplementedException($"[GetNearestDateOfDay] diff of {diff} not implemented.")
        };
    }

    public static DateOnly DateOfPastNearestDay(this DateTimeOffset input, DayOfWeek dayOfWeek)
        => DateOfPastNearestDay(DateOnly.FromDateTime(input.DateTime), dayOfWeek);
    public static DateOnly DateOfPastNearestDay(this DateTime input, DayOfWeek dayOfWeek)
        => DateOfPastNearestDay(DateOnly.FromDateTime(input), dayOfWeek);

    public static DateOnly DateOfPastNearestDay(this DateOnly input, DayOfWeek dayOfWeek)
    {
        int diff = dayOfWeek - input.DayOfWeek;

        return diff switch
        {
            _ when diff.Equals(0)
                => input,

            _ when diff > 0
                => input.AddDays(diff - 7),

            _ when diff < 0
                => input.AddDays(diff),

            //Should never hit
            _ => throw new NotImplementedException($"[DateOfPastNearestDay] diff of {diff} not implemented.")
        };
    }

    public static DateOnly DateOfUpcomingNearestDay(this DateTimeOffset input, DayOfWeek dayOfWeek)
        => DateOfUpcomingNearestDay(DateOnly.FromDateTime(input.DateTime), dayOfWeek);
    public static DateOnly DateOfUpcomingNearestDay(this DateTime input, DayOfWeek dayOfWeek)
        => DateOfUpcomingNearestDay(DateOnly.FromDateTime(input), dayOfWeek);

    public static DateOnly DateOfUpcomingNearestDay(this DateOnly input, DayOfWeek dayOfWeek)
    {
        int diff = dayOfWeek - input.DayOfWeek;

        return diff switch
        {
            _ when diff.Equals(0)
                => input,

            _ when diff > 0
                => input.AddDays(diff),

            _ when diff < 0
                => input.AddDays(7 + diff),

            //Should never hit
            _ => throw new NotImplementedException($"[DateOfUpcomingNearestDay] diff of {diff} not implemented.")
        };
    }

    public static bool IsWithinSchedule(
        this DateTime value,
        DayOfWeek startDay, TimeOnly startTime,
        DayOfWeek endDay, TimeOnly endTime)
        => value.IsWithinSchedule(
            new RecurringSchedule(
                startDay, startTime, 
                endDay, endTime));

    public static bool IsWithinSchedule(
        this DateTime value,
        ScheduleBoundary start,
        ScheduleBoundary end)
        => value.IsWithinSchedule(new RecurringSchedule(start, end));

    public static bool IsWithinSchedule(
        this DateTime value,
        RecurringSchedule recurringSchedule)
    {
        PeriodSchedule periodSchedule = new(recurringSchedule);
        periodSchedule.SetToNearest(value);

        return periodSchedule.HasTimePeriod;
    }
}
