namespace TimePeriod.ClassLibrary;

/// <summary>
/// For handling scheduled TimePeriods, i.e. 
/// Start & End are not fixed DateTimes.
/// MVP; probably could be designed better...
/// </summary>
public record PeriodSchedule
{
    public RecurringSchedule RecurringSchedule;
    
    //If/When need to scale, change to IEnumerable
    public DateTimePeriod? TimePeriod = null;

    public bool HasTimePeriod
        => this.TimePeriod is not null;

    public PeriodSchedule(RecurringSchedule recurringSchedule)
    {
        RecurringSchedule = recurringSchedule;
    }

    public PeriodSchedule(
        ScheduleBoundary start,
        ScheduleBoundary end)
    {
        RecurringSchedule = new(start, end);
    }

    public PeriodSchedule(
        DayOfWeek startDay, TimeOnly startTime,
        DayOfWeek endDay, TimeOnly endTime)
    {
        RecurringSchedule = new(startDay, startTime, endDay, endTime);
    }

    public void SetToNearest(DateTimeOffset value)
        => SetToNearest(value.DateTime);

    public void SetToNearest(DateTime value)
    {
        //MVP; not the best design.
        if (!this.HasTimePeriod)
        {
            this.TimePeriod = GetPeriodOrNull(value);
        }
    }

    //Possible TODO: Maybe use a ScheduleHelper?
    private DateTimePeriod? GetPeriodOrNull(DateTime value)
    {
        DateTime start = GetNearestPastStart(value);

        DateTime end = GetNearestUpcomingEnd(value);

        return IsStartAndEndWithinAWeekApart(start, end)
            ? new DateTimePeriod(start, end)
            : null;
    }

    private DateTime GetNearestPastStart(DateTime value)
        => new(
            date: value.DateOfPastNearestDay(this.RecurringSchedule.Start.Day),
            time: this.RecurringSchedule.Start.Time);

    private DateTime GetNearestUpcomingEnd(DateTime value)
        => new(
            date: value.DateOfUpcomingNearestDay(this.RecurringSchedule.End.Day),
            time: this.RecurringSchedule.End.Time);

    private static bool IsStartAndEndWithinAWeekApart(DateTime start, DateTime end)
        => end - start <= TimeSpan.FromDays(7);
}

public record struct RecurringSchedule
{
    public ScheduleBoundary Start;
    public ScheduleBoundary End;

    public RecurringSchedule(
        ScheduleBoundary start,
        ScheduleBoundary end)
    {
        Start = start;
        End = end; 
    }

    public RecurringSchedule(
        DayOfWeek startDay, TimeOnly startTime,
        DayOfWeek endDay, TimeOnly endTime)
    {
        Start = new(startDay, startTime);
        End = new(endDay, endTime);
    }
}

public record struct ScheduleBoundary(DayOfWeek day, TimeOnly time)
{
    public DayOfWeek Day = day;
    public TimeOnly Time = time;
}