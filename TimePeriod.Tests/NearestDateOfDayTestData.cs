
namespace TimePeriod.Tests;

public class NearestDateOfDayTestData
{
    public static object[] TestInputSunday
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

    public static object[] TestInputMonday
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

    public static object[] TestInputTuesday
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

    public static object[] TestInputWednesday
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

    public static object[] TestInputThursday
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

    public static object[] TestInputFriday
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

    public static object[] TestInputSaturday
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
        => [TestInputSunday,
            TestInputMonday,
            TestInputTuesday,
            TestInputWednesday,
            TestInputThursday,
            TestInputFriday,
            TestInputSaturday];
}
