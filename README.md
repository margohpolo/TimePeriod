## TimePeriod

Some code snippets (with unit tests) to help on working with DateTimes.

<br />

#### DateOfAnyNearestDay (extension)
- Gets the DateOnly of the nearest day to a given date. Requires a DayOfWeek input.

#### DateTimePeriod (record; could also be a struct)
- Strongly-typed for a cleaner approach to checking whether a DateTime falls within a range of DateTimes.

### PeriodSchedule
- Given a fixed schedule that runs weekly (i.e. defined by start/end day & time), if a given DateTime falls within this schedule, the relevant DateTimePeriod will be derived, else null.
- Assumes week starts on Sunday. (to test other scenarios later)
<b><u>Example usage:</b></u>
```
bool isTestDateWithinSchedule = testDate.IsWithinSchedule(startDay, startTime, endDay, endTime);
```
