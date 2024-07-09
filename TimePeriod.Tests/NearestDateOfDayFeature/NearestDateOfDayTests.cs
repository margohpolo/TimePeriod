using TimePeriod.ClassLibrary;

namespace TimePeriod.Tests.NearestDateOfDayFeature;

//Interesting Reference - Andrew Lock's Blog: https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/
public class NearestDateOfDayTests
{
    [Theory]
    [MemberData(nameof(AnyNearestDateOfDayTestData.TestInputAllDays), MemberType = typeof(AnyNearestDateOfDayTestData))]
    public void Should_Return_CorrectNearestDates_Any(
        DateTimeOffset testDate,
        DateOnly expectedSunday,
        DateOnly expectedMonday,
        DateOnly expectedTuesday,
        DateOnly expectedWednesday,
        DateOnly expectedThursday,
        DateOnly expectedFriday,
        DateOnly expectedSaturday)
    {
        Assert.Equal(expectedSunday, testDate.DateOfAnyNearestDay(DayOfWeek.Sunday));

        Assert.Equal(expectedMonday, testDate.DateOfAnyNearestDay(DayOfWeek.Monday));

        Assert.Equal(expectedTuesday, testDate.DateOfAnyNearestDay(DayOfWeek.Tuesday));

        Assert.Equal(expectedWednesday, testDate.DateOfAnyNearestDay(DayOfWeek.Wednesday));

        Assert.Equal(expectedThursday, testDate.DateOfAnyNearestDay(DayOfWeek.Thursday));

        Assert.Equal(expectedFriday, testDate.DateOfAnyNearestDay(DayOfWeek.Friday));

        Assert.Equal(expectedSaturday, testDate.DateOfAnyNearestDay(DayOfWeek.Saturday));
    }

    [Theory]
    [MemberData(nameof(PastNearestDateOfDayTestData.TestInputAllDays), MemberType = typeof(PastNearestDateOfDayTestData))]
    public void Should_Return_CorrectNearestDates_Past(
        DateTimeOffset testDate,
        DateOnly expectedSunday,
        DateOnly expectedMonday,
        DateOnly expectedTuesday,
        DateOnly expectedWednesday,
        DateOnly expectedThursday,
        DateOnly expectedFriday,
        DateOnly expectedSaturday)
    {
        Assert.Equal(expectedSunday, testDate.DateOfPastNearestDay(DayOfWeek.Sunday));

        Assert.Equal(expectedMonday, testDate.DateOfPastNearestDay(DayOfWeek.Monday));

        Assert.Equal(expectedTuesday, testDate.DateOfPastNearestDay(DayOfWeek.Tuesday));

        Assert.Equal(expectedWednesday, testDate.DateOfPastNearestDay(DayOfWeek.Wednesday));

        Assert.Equal(expectedThursday, testDate.DateOfPastNearestDay(DayOfWeek.Thursday));

        Assert.Equal(expectedFriday, testDate.DateOfPastNearestDay(DayOfWeek.Friday));

        Assert.Equal(expectedSaturday, testDate.DateOfPastNearestDay(DayOfWeek.Saturday));
    }

    [Theory]
    [MemberData(nameof(UpcomingNearestDateOfDayTestData.TestInputAllDays), MemberType = typeof(UpcomingNearestDateOfDayTestData))]
    public void Should_Return_CorrectNearestDates_Upcoming(
        DateTimeOffset testDate,
        DateOnly expectedSunday,
        DateOnly expectedMonday,
        DateOnly expectedTuesday,
        DateOnly expectedWednesday,
        DateOnly expectedThursday,
        DateOnly expectedFriday,
        DateOnly expectedSaturday)
    {
        Assert.Equal(expectedSunday, testDate.DateOfUpcomingNearestDay(DayOfWeek.Sunday));

        Assert.Equal(expectedMonday, testDate.DateOfUpcomingNearestDay(DayOfWeek.Monday));

        Assert.Equal(expectedTuesday, testDate.DateOfUpcomingNearestDay(DayOfWeek.Tuesday));

        Assert.Equal(expectedWednesday, testDate.DateOfUpcomingNearestDay(DayOfWeek.Wednesday));

        Assert.Equal(expectedThursday, testDate.DateOfUpcomingNearestDay(DayOfWeek.Thursday));

        Assert.Equal(expectedFriday, testDate.DateOfUpcomingNearestDay(DayOfWeek.Friday));

        Assert.Equal(expectedSaturday, testDate.DateOfUpcomingNearestDay(DayOfWeek.Saturday));
    }
}