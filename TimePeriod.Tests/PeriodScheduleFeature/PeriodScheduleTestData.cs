using TimePeriod.ClassLibrary;

namespace TimePeriod.Tests.PeriodScheduleFeature;

public class PeriodScheduleTestData
{
    #region ScheduleWithinWeek
    public static object[] ScheduleWithinWeek_BeforeSchedule
        =>
        [
            new RecurringSchedule(
                DayOfWeek.Sunday, new TimeOnly(0, 0, 0, 0),
                DayOfWeek.Monday, new TimeOnly(23, 59, 59, 999)),

            new DateTimeOffset(2024, 6, 29, 12, 0, 0, 0, TimeSpan.Zero)
        ];

    public static object[] ScheduleWithinWeek_OnStartOfSchedule
        =>
        [
            new RecurringSchedule(
                DayOfWeek.Sunday, new TimeOnly(0, 0, 0, 0),
                DayOfWeek.Monday, new TimeOnly(23, 59, 59, 999)),

            new DateTimeOffset(2024, 6, 30, 0, 0, 0, 0, TimeSpan.Zero),

            new DateTimePeriod(
                start: new DateTime(2024, 6, 30, 0, 0, 0, 0),
                end: new DateTime(2024, 7, 1, 23, 59, 59, 999))
        ];

    public static object[] ScheduleWithinWeek_WithinSchedule
        =>
        [
            new RecurringSchedule(
                DayOfWeek.Sunday, new TimeOnly(0, 0, 0, 0),
                DayOfWeek.Monday, new TimeOnly(23, 59, 59, 999)),

            new DateTimeOffset(2024, 6, 30, 12, 0, 0, 0, TimeSpan.Zero),

            new DateTimePeriod(
                start: new DateTime(2024, 6, 30, 0, 0, 0),
                end: new DateTime(2024, 7, 1, 23, 59, 59, 999))
        ];

    public static object[] ScheduleWithinWeek_OnEndOfSchedule
        =>
        [
            new RecurringSchedule(
                DayOfWeek.Sunday, new TimeOnly(0, 0, 0, 0),
                DayOfWeek.Monday, new TimeOnly(23, 59, 59, 999)),

            new DateTimeOffset(2024, 7, 1, 23, 59, 59, 999, TimeSpan.Zero),

            new DateTimePeriod(
                start: new DateTime(2024, 6, 30, 0, 0, 0),
                end: new DateTime(2024, 7, 1, 23, 59, 59, 999))
        ];

    public static object[] ScheduleWithinWeek_AfterSchedule
        =>
        [
            new RecurringSchedule(
                DayOfWeek.Sunday, new TimeOnly(0, 0, 0, 0),
                DayOfWeek.Monday, new TimeOnly(23, 59, 59, 999)),

            new DateTimeOffset(2024, 7, 2, 0, 0, 0, 0, TimeSpan.Zero)
        ];
    #endregion





    #region ScheduleAcrossWeek
    public static object[] ScheduleAcrossWeek_BeforeSchedule
        =>
        [
            new RecurringSchedule(
                DayOfWeek.Friday, new TimeOnly(12, 0, 0, 0),
                DayOfWeek.Monday, new TimeOnly(23, 59, 59, 999)),

            new DateTimeOffset(2024, 6, 27, 0, 0, 0, TimeSpan.Zero)
        ];

    public static object[] ScheduleAcrossWeek_OnStartOfSchedule
        =>
        [
            new RecurringSchedule(
                DayOfWeek.Friday, new TimeOnly(12, 0, 0, 0),
                DayOfWeek.Monday, new TimeOnly(23, 59, 59, 999)),

            new DateTimeOffset(2024, 6, 28, 12, 0, 0, 0, TimeSpan.Zero),

            new DateTimePeriod(
                start: new DateTime(2024, 6, 28, 12, 0, 0, 0),
                end: new DateTime(2024, 7, 1, 23, 59, 59, 999))
        ];

    public static object[] ScheduleAcrossWeek_WithinSchedule
        =>
        [
            new RecurringSchedule(
                DayOfWeek.Friday, new TimeOnly(12, 0, 0, 0),
                DayOfWeek.Monday, new TimeOnly(23, 59, 59, 999)),

            new DateTimeOffset(2024, 6, 30, 12, 0, 0, 0, TimeSpan.Zero),

            new DateTimePeriod(
                start: new DateTime(2024, 6, 28, 12, 0, 0, 0),
                end: new DateTime(2024, 7, 1, 23, 59, 59, 999))
        ];

    public static object[] ScheduleAcrossWeek_OnEndOfSchedule
        =>
        [
            new RecurringSchedule(
                DayOfWeek.Friday, new TimeOnly(12, 0, 0, 0),
                DayOfWeek.Monday, new TimeOnly(23, 59, 59, 999)),

            new DateTimeOffset(2024, 7, 1, 23, 59, 59, 999, TimeSpan.Zero),

            new DateTimePeriod(
                start: new DateTime(2024, 6, 28, 12, 0, 0, 0),
                end: new DateTime(2024, 7, 1, 23, 59, 59, 999))
        ];

    public static object[] ScheduleAcrossWeek_AfterSchedule
        =>
        [
            new RecurringSchedule(
                DayOfWeek.Friday, new TimeOnly(12, 0, 0, 0),
                DayOfWeek.Monday, new TimeOnly(23, 59, 59, 999)),

            new DateTimeOffset(2024, 7, 2, 0, 0, 0, 0, TimeSpan.Zero)
        ];
    #endregion

    public static IEnumerable<object[]> WithinWeekScenarios
        => 
        [
            ScheduleWithinWeek_BeforeSchedule,
            ScheduleWithinWeek_OnStartOfSchedule,
            ScheduleWithinWeek_WithinSchedule,
            ScheduleWithinWeek_OnEndOfSchedule,
            ScheduleWithinWeek_AfterSchedule
        ];

    public static IEnumerable<object[]> AcrossWeekScenarios
        =>
        [
            //ScheduleAcrossWeek_BeforeSchedule,
            //ScheduleAcrossWeek_OnStartOfSchedule,
            ScheduleAcrossWeek_WithinSchedule,
            //ScheduleAcrossWeek_OnEndOfSchedule,
            //ScheduleAcrossWeek_AfterSchedule
        ];
}
