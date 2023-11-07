namespace FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

internal class BeSpecificDayData : TheoryData<DateTime?, int, bool>
{
    public BeSpecificDayData()
    {
        Add(null, 1, false);
        Add(DateTime.MinValue, 1, false);
        Add(DateTime.MaxValue, 31, false);
        
        Add(new DateTime(2023, 11, 01), 2, false);
        Add(new DateTime(2023, 11, 01), 1, true);
        Add(new DateTime(2023, 11, 05), 6, false);
        Add(new DateTime(2023, 11, 05), 5, true);
        Add(new DateTime(2023, 11, 30), 31, false);
        Add(new DateTime(2023, 11, 30), 30, true);
    }
}