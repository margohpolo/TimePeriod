namespace TimePeriod.Tests.NearestDateOfDayFeature;

public class AnyNearestDateOfDayTestData
{
    public static object[] ScenarioSunday
        =>
        [
            new DateTimeOffset(2024, 6, 23, 1, 0, 0, TimeSpan.Zero),
            new DateOnly(2024, 6, 23),
            new DateOnly(2024, 6, 24),
            new DateOnly(2024, 6, 25),
            new DateOnly(2024, 6, 26),
            new DateOnly(2024, 6, 20),
            new DateOnly(2024, 6, 21),
            new DateOnly(2024, 6, 22)
        ];

    public static object[] ScenarioMonday
        =>
        [
            new DateTimeOffset(2024, 6, 24, 1, 0, 0, TimeSpan.Zero),
            new DateOnly(2024, 6, 23),
            new DateOnly(2024, 6, 24),
            new DateOnly(2024, 6, 25),
            new DateOnly(2024, 6, 26),
            new DateOnly(2024, 6, 27),
            new DateOnly(2024, 6, 21),
            new DateOnly(2024, 6, 22)
        ];

    public static object[] ScenarioTuesday
        =>
        [
            new DateTimeOffset(2024, 6, 25, 1, 0, 0, TimeSpan.Zero),
            new DateOnly(2024, 6, 23),
            new DateOnly(2024, 6, 24),
            new DateOnly(2024, 6, 25),
            new DateOnly(2024, 6, 26),
            new DateOnly(2024, 6, 27),
            new DateOnly(2024, 6, 28),
            new DateOnly(2024, 6, 22)
        ];

    public static object[] ScenarioWednesday
        =>
        [
            new DateTimeOffset(2024, 6, 26, 1, 0, 0, TimeSpan.Zero),
            new DateOnly(2024, 6, 23),
            new DateOnly(2024, 6, 24),
            new DateOnly(2024, 6, 25),
            new DateOnly(2024, 6, 26),
            new DateOnly(2024, 6, 27),
            new DateOnly(2024, 6, 28),
            new DateOnly(2024, 6, 29)
        ];

    public static object[] ScenarioThursday
        =>
        [
            new DateTimeOffset(2024, 6, 27, 1, 0, 0, TimeSpan.Zero),
            new DateOnly(2024, 6, 30),
            new DateOnly(2024, 6, 24),
            new DateOnly(2024, 6, 25),
            new DateOnly(2024, 6, 26),
            new DateOnly(2024, 6, 27),
            new DateOnly(2024, 6, 28),
            new DateOnly(2024, 6, 29)
        ];

    public static object[] ScenarioFriday
        =>
        [
            new DateTimeOffset(2024, 6, 28, 1, 0, 0, TimeSpan.Zero),
            new DateOnly(2024, 6, 30),
            new DateOnly(2024, 7, 1),
            new DateOnly(2024, 6, 25),
            new DateOnly(2024, 6, 26),
            new DateOnly(2024, 6, 27),
            new DateOnly(2024, 6, 28),
            new DateOnly(2024, 6, 29)
        ];

    public static object[] ScenarioSaturday
        =>
        [
            new DateTimeOffset(2024, 6, 29, 1, 0, 0, TimeSpan.Zero),
            new DateOnly(2024, 6, 30),
            new DateOnly(2024, 7, 1),
            new DateOnly(2024, 7, 2),
            new DateOnly(2024, 6, 26),
            new DateOnly(2024, 6, 27),
            new DateOnly(2024, 6, 28),
            new DateOnly(2024, 6, 29)
        ];

    public static IEnumerable<object[]> TestInputAllDays
        => [ScenarioSunday,
            ScenarioMonday,
            ScenarioTuesday,
            ScenarioWednesday,
            ScenarioThursday,
            ScenarioFriday,
            ScenarioSaturday];
}
