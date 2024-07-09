namespace TimePeriod.ClassLibrary;

public record DateTimePeriod
{
    public DateTime Start;
    public DateTime End;

    public DateTimePeriod(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }

    public DateTimePeriod(DateTimeOffset start, DateTimeOffset end)
    {
        Start = start.DateTime;
        End = end.DateTime;
    }

    public bool IsValueWithin(DateTimeOffset value)
        => IsValueWithin(value.DateTime);

    public bool IsValueWithin(DateTime value)
        => value >= Start && value <= End;
}
