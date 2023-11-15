namespace Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

internal class BeInFutureData : TheoryData<DateTime?, bool>
{
    public BeInFutureData()
    {
        Add(null, false);
        Add(DateTime.MinValue, false);
        Add(DateTime.MaxValue, true);
        
        Add(DateTime.Now, false);
        Add(DateTime.Now.AddSeconds(-1), false);
        Add(DateTime.Now.AddMinutes(-1), false);
        Add(DateTime.Now.AddMinutes(-32), false);
        Add(DateTime.Now.AddHours(-1), false);
        Add(DateTime.Now.AddDays(-1), false);
        
        Add(DateTime.Now.AddSeconds(1), true);
        Add(DateTime.Now.AddMinutes(1), true);
        Add(DateTime.Now.AddMinutes(32), true);
        Add(DateTime.Now.AddHours(1), true);
        Add(DateTime.Now.AddDays(1), true);
    }
}