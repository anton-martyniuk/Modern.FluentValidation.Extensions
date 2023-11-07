namespace FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

internal class BeSpecificDayOfWeekData : TheoryData<DateTime?, DayOfWeek, bool>
{
    public BeSpecificDayOfWeekData()
    {
        Add(null, DayOfWeek.Monday, false);
        Add(DateTime.MinValue, DayOfWeek.Monday, false);
        Add(DateTime.MaxValue, DayOfWeek.Monday, false);
        
        Add(new DateTime(2023, 11, 01), DayOfWeek.Saturday, false);
        Add(new DateTime(2023, 11, 01), DayOfWeek.Wednesday, true);
        Add(new DateTime(2023, 11, 05), DayOfWeek.Monday, false);
        Add(new DateTime(2023, 11, 05), DayOfWeek.Sunday, true);
        Add(new DateTime(2023, 11, 30), DayOfWeek.Friday, false);
        Add(new DateTime(2023, 11, 30), DayOfWeek.Thursday, true);
    }
}