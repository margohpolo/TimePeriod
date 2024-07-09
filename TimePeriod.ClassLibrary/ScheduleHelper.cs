
namespace TimePeriod.ClassLibrary;

public static class ScheduleHelper
{
    public static bool IsWithinPeriod(
        this DateTimeOffset value,
        RecurringSchedule schedule)
        => IsWithinPeriod(value.DateTime, schedule);

    public static bool IsWithinPeriod(
        this DateTime value, 
        RecurringSchedule schedule)
        => IsWithinPeriod(value, schedule.Start, schedule.End);

    public static bool IsWithinPeriod(
        this DateTimeOffset value,
        ScheduleBoundary start,
        ScheduleBoundary end)
        => IsWithinPeriod(value.DateTime, start, end);

    public static bool IsWithinPeriod(
        this DateTime value,
        ScheduleBoundary start,
        ScheduleBoundary end)
    //=> value.IsOnOrAfterStart(start)
    //    && value.IsOnOrBeforeEnd(end);
    => value.DayOfWeek.IsBetweenDaysOfWeek(start.Day, end.Day)
        && value.IsOnOrAfterStartTime(start) 
        && value.IsOnOrBeforeEndTime(end);
    //{
    //    if (value.DayOfWeek.IsBetweenDaysOfWeek(start.Day, end.Day))
    //    {
    //        return value.IsOnOrAfterStart(start) && value.IsOnOrBeforeEnd(end);
    //    }

    //    return false;
    //}

    //Handles Cross-week scenario


    public static bool IsBetweenDaysOfWeek(
        this DayOfWeek value,
        DayOfWeek startDay,
        DayOfWeek endDay)
        => endDay < startDay
            ? value <= startDay && value >= endDay
            : value >= startDay && value <= endDay;

    ////Relook & refactor
    //private static bool IsPeriodCrossWeek(
    //    DayOfWeek startDay,
    //    DayOfWeek endDay)
    //    => endDay < startDay;


    #region Private Methods
    //IDE0075 simplification compiles to the same C#
    //Going with this (for now) for better readability
    private static bool IsOnOrAfterStartTime(
        this DateTime value,
        ScheduleBoundary start)
        => value.DayOfWeek == start.Day
            ? TimeOnly.FromDateTime(value) >= start.Time
            : true;

    //IDE0075 simplification compiles to the same C#
    //Going with this (for now) for better readability
    private static bool IsOnOrBeforeEndTime(
        this DateTime value,
        ScheduleBoundary end)
        => value.DayOfWeek == end.Day
            ? TimeOnly.FromDateTime(value) <= end.Time
            : true;


    //private static bool IsOnOrAfterStart(
    //    this DateTime value,
    //    ScheduleBoundary start)
    //{
    //    if (value.DayOfWeek >= start.Day)
    //    {
    //        //IDE0075 simplification compiles to the same C#
    //        //Going with this (for now) for better readability
    //        return value.DayOfWeek == start.Day
    //            ? TimeOnly.FromDateTime(value) >= start.Time
    //            : true;
    //    }
    //    return false;
    //}

    //private static bool IsOnOrBeforeEnd(
    //    this DateTime value,
    //    ScheduleBoundary end)
    //{
    //    if (value.DayOfWeek <= end.Day)
    //    {
    //        //IDE0075 simplification compiles to the same C#
    //        //Going with this (for now) for better readability
    //        return value.DayOfWeek == end.Day
    //            ? TimeOnly.FromDateTime(value) <= end.Time
    //            : true;
    //    }
    //    return false;
    //}
    #endregion
}
