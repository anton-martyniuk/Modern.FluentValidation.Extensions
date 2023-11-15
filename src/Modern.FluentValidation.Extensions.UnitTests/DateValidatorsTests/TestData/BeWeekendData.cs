namespace Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

internal class BeWeekendData : TheoryData<DateTime?, bool>
{
    public BeWeekendData()
    {
        Add(null, false);
        Add(DateTime.MinValue, false);
        Add(DateTime.MaxValue, false);
        
        Add(new DateTime(2023, 11, 05), true);
        Add(new DateTime(2023, 11, 01), false);
        Add(new DateTime(2023, 11, 30), false);
        Add(new DateTime(2023, 01, 01), true);
        Add(new DateTime(2023, 12, 31), true);
        
        Add(new DateTime(2024, 11, 05), false);
        Add(new DateTime(2024, 11, 01), false);
        Add(new DateTime(2024, 11, 30), true);
        Add(new DateTime(2024, 01, 01), false);
        Add(new DateTime(2024, 12, 31), false);
    }
}