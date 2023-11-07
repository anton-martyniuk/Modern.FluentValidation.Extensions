namespace FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

internal class IsUtcData : TheoryData<DateTime?, bool>
{
    public IsUtcData()
    {
        Add(null, false);
        Add(DateTime.MinValue, false);
        Add(DateTime.MaxValue, false);
        
        Add(new DateTime(2023, 11, 01), false);
        Add(new DateTime(2023, 11, 01, 0, 0, 0, DateTimeKind.Local), false);
        Add(new DateTime(2023, 11, 01, 0, 0, 0, DateTimeKind.Unspecified), false);
        Add(new DateTime(2023, 11, 01, 0, 0, 0, DateTimeKind.Utc), true);

        Add(DateTime.Now, false);
        Add(DateTime.UtcNow, true);
    }
}