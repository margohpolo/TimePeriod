using TimePeriod.ClassLibrary;

namespace TimePeriod.Tests;

//Interesting Reference - Andrew Lock's Blog: https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/
public class NearestDateOfDayTests
{
    [Theory]
    [MemberData(nameof(NearestDateOfDayTestData.TestInputAllDays), MemberType = typeof(NearestDateOfDayTestData))]
    public void Should_Return_CorrectNearestDates(
        DateTimeOffset testDate,
        DateOnly expectedSunday,
        DateOnly expectedMonday,
        DateOnly expectedTuesday,
        DateOnly expectedWednesday,
        DateOnly expectedThursday,
        DateOnly expectedFriday,
        DateOnly expectedSaturday)
    {
        var resultSunday = testDate.DateOfAnyNearestDay(DayOfWeek.Sunday);
        Assert.Equal(expectedSunday, resultSunday);

        var resultMonday = testDate.DateOfAnyNearestDay(DayOfWeek.Monday);
        Assert.Equal(expectedMonday, resultMonday);

        var resultTuesday = testDate.DateOfAnyNearestDay(DayOfWeek.Tuesday);
        Assert.Equal(expectedTuesday, resultTuesday);

        var resultWednesday = testDate.DateOfAnyNearestDay(DayOfWeek.Wednesday);
        Assert.Equal(expectedWednesday, resultWednesday);

        var resultThursday = testDate.DateOfAnyNearestDay(DayOfWeek.Thursday);
        Assert.Equal(expectedThursday, resultThursday);

        var resultFriday = testDate.DateOfAnyNearestDay(DayOfWeek.Friday);
        Assert.Equal(expectedFriday, resultFriday);

        var resultSaturday = testDate.DateOfAnyNearestDay(DayOfWeek.Saturday);
        Assert.Equal(expectedSaturday, resultSaturday);
    }
}