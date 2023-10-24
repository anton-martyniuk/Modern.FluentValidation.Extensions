namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class HasNoElementsData : TheoryData<List<int>?, bool>
{
    public HasNoElementsData()
    {
        Add(null, true);
        Add(new List<int>(), true);
        Add(new List<int> { 0 }, false);
        Add(Enumerable.Range(0, 10).ToList(), false);
    }
}