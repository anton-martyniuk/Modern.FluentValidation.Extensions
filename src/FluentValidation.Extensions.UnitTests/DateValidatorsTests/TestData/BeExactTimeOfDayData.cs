namespace FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

internal class BeExactTimeOfDayData : TheoryData<DateTime?, TimeSpan, bool>
{
    public BeExactTimeOfDayData()
    {
        Add(null, new TimeSpan(9, 0, 0), false);
        Add(DateTime.MinValue, new TimeSpan(9, 0, 0), false);
        Add(DateTime.MaxValue, new TimeSpan(9, 0, 0), false);
        
        Add(new DateTime(2023, 11, 01, 10, 0, 0), new TimeSpan(9, 0, 0), false);
        Add(new DateTime(2023, 11, 01, 9, 0, 0), new TimeSpan(9, 0, 0), true);
        
        Add(new DateTime(2023, 11, 02, 23, 55, 46), new TimeSpan(23, 55, 30), false);
        Add(new DateTime(2023, 11, 02, 23, 55, 30), new TimeSpan(23, 55, 30), true);
    }
}