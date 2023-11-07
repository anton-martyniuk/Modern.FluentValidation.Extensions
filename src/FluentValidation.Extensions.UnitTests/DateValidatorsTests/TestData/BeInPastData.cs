namespace FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

internal class BeInPastData : TheoryData<DateTime?, bool>
{
    public BeInPastData()
    {
        Add(null, false);
        Add(DateTime.MinValue, true);
        Add(DateTime.MaxValue, false);
        
        Add(DateTime.Now, true);
        Add(DateTime.Now.AddSeconds(-1), true);
        Add(DateTime.Now.AddMinutes(-1), true);
        Add(DateTime.Now.AddMinutes(-32), true);
        Add(DateTime.Now.AddHours(-1), true);
        Add(DateTime.Now.AddDays(-1), true);
        
        Add(DateTime.Now.AddSeconds(1), false);
        Add(DateTime.Now.AddMinutes(1), false);
        Add(DateTime.Now.AddMinutes(32), false);
        Add(DateTime.Now.AddHours(1), false);
        Add(DateTime.Now.AddDays(1), false);
    }
}