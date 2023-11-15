namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class HasElementsData : TheoryData<List<int>?, bool>
{
    public HasElementsData()
    {
        Add(null, false);
        Add(new List<int>(), false);
        Add(new List<int> { 0 }, true);
        Add(Enumerable.Range(0, 10).ToList(), true);
    }
}