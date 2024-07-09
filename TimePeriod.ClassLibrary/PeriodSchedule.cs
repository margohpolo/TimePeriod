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
            //&& value.IsWithinPeriod(this.RecurringSchedule))
        {
            //Not a good solution
            DateTime start = new DateTime(
                    date: value.DateOfPastNearestDay(this.RecurringSchedule.Start.Day),
                    time: this.RecurringSchedule.Start.Time);

            DateTime end = new DateTime(
                    date: value.DateOfUpcomingNearestDay(this.RecurringSchedule.End.Day),
                    time: this.RecurringSchedule.End.Time);

            //TODO: Refactor & use ScheduleHelper.
            //This should be handled earlier; not here.
            if (end - start <= TimeSpan.FromDays(7))
            {
                this.TimePeriod = new DateTimePeriod(start, end);
            }

            ////Original: Still cleaner
            //this.TimePeriod = new DateTimePeriod(
            //    start: new DateTime(
            //        date: value.DateOfPastNearestDay(this.RecurringSchedule.Start.Day),
            //        time: this.RecurringSchedule.Start.Time),
            //    end: new DateTime(
            //        date: value.DateOfUpcomingNearestDay(this.RecurringSchedule.End.Day),
            //        time: this.RecurringSchedule.End.Time));
        }
        //else...? Needed?
    }
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