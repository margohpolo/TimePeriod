using TimePeriod.ClassLibrary;

namespace TimePeriod.Tests.PeriodScheduleFeature;

public class PeriodScheduleTests
{
    [Theory]
    [MemberData(nameof(PeriodScheduleTestData.WithinWeekScenarios), MemberType = typeof(PeriodScheduleTestData))]
    public void Should_DeriveCorrectNearestTimePeriod_OrNone_WithinWeekScenarios(
        RecurringSchedule recurringSchedule,
        DateTimeOffset testDateTime,
        DateTimePeriod? expectedDateTimePeriod = null
        )
    {
        PeriodSchedule periodSchedule = new(recurringSchedule);
        periodSchedule.SetToNearest(testDateTime);

        Assert.Equal(expectedDateTimePeriod, periodSchedule.TimePeriod);
    }

    [Theory]
    [MemberData(nameof(PeriodScheduleTestData.AcrossWeekScenarios), MemberType = typeof(PeriodScheduleTestData))]
    public void Should_DeriveCorrectNearestTimePeriod_OrNone_AcrossWeekScenarios(
        RecurringSchedule recurringSchedule,
        DateTimeOffset testDateTime,
        DateTimePeriod? expectedDateTimePeriod = null
        )
    {
        PeriodSchedule periodSchedule = new(recurringSchedule);
        periodSchedule.SetToNearest(testDateTime);

        Assert.Equal(expectedDateTimePeriod, periodSchedule.TimePeriod);
    }
}
