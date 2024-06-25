
namespace TimePeriod.Tests;

public class TimePeriodTests
{
    public static IEnumerable<object[]> TestData
        =>
        [
            [new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 1, 2, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 12, 31, 23, 59, 59, TimeSpan.Zero),
                false],
            [new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 1, 2, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
                true],
            [new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 1, 2, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 1, 1, 0, 0, 1, TimeSpan.Zero),
                true],
            [new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 1, 2, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 1, 2, 0, 0, 0, TimeSpan.Zero),
                true],
            [new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 1, 2, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 1, 2, 0, 0, 1, TimeSpan.Zero),
                false]
        ];

    [Theory]
    [MemberData(nameof(TestData))]
    public void Should_ReturnCorrectly_WhetherValueIsWithin(
        DateTimeOffset start,
        DateTimeOffset end,
        DateTimeOffset value,
        bool expectedResult)
    {
        //TODO: Fix naming clash issue
        TimePeriod.ClassLibrary.TimePeriod timePeriod = new(start, end);
        bool result = timePeriod.IsValueWithin(value);

        Assert.Equal(expectedResult, result);
    }
}
