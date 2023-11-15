namespace Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

internal class IsLocalTimeData : TheoryData<DateTime?, bool>
{
    public IsLocalTimeData()
    {
        Add(null, false);
        Add(DateTime.MinValue, false);
        Add(DateTime.MaxValue, false);
        
        Add(new DateTime(2023, 11, 01), false);
        Add(new DateTime(2023, 11, 01, 0, 0, 0, DateTimeKind.Local), true);
        Add(new DateTime(2023, 11, 01, 0, 0, 0, DateTimeKind.Unspecified), false);
        Add(new DateTime(2023, 11, 01, 0, 0, 0, DateTimeKind.Utc), false);

        Add(DateTime.Now, true);
        Add(DateTime.UtcNow, false);
    }
}