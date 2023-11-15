namespace Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

internal class BeWithinRangeData : TheoryData<DateTime?, DateTime, DateTime, bool>
{
    public BeWithinRangeData()
    {
        var startDate = new DateTime(2023, 01, 01);
        var endDate = new DateTime(2023, 12, 31);

        Add(null, startDate, endDate, false);
        Add(DateTime.MinValue, startDate, endDate, false);
        Add(DateTime.MaxValue, startDate, endDate, false);

        Add(new DateTime(2022, 12, 31), startDate, endDate, false);
        Add(new DateTime(2023, 01, 01), startDate, endDate, true);
        Add(new DateTime(2023, 06, 15), startDate, endDate, true);
        Add(new DateTime(2023, 12, 31), startDate, endDate, true);
        Add(new DateTime(2024, 01, 01), startDate, endDate, false);
    }
}