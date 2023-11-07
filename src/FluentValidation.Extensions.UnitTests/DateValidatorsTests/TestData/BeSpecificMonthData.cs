namespace FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

internal class BeSpecificMonthData : TheoryData<DateTime?, int, bool>
{
    public BeSpecificMonthData()
    {
        Add(null, 1, false);
        Add(DateTime.MinValue, 1, false);
        Add(DateTime.MaxValue, 12, false);
        
        Add(new DateTime(2023, 11, 01), 10, false);
        Add(new DateTime(2023, 11, 01), 11, true);
        
        Add(new DateTime(2023, 12, 31), 01, false);
        Add(new DateTime(2023, 12, 31), 12, true);
        
        Add(new DateTime(2024, 01, 01), 12, false);
        Add(new DateTime(2024, 01, 01), 01, true);
    }
}