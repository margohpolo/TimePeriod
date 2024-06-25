namespace TimePeriod.ClassLibrary;

public struct TimePeriod
{
    public DateTime Start;
    public DateTime End;

    public TimePeriod(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }

    public TimePeriod(DateTimeOffset start, DateTimeOffset end)
    {
        Start = start.DateTime;
        End = end.DateTime;
    }

    public bool IsValueWithin(DateTimeOffset value)
        => IsValueWithin(value.DateTime);

    public bool IsValueWithin(DateTime value)
        => value >= Start && value <= End;
}
