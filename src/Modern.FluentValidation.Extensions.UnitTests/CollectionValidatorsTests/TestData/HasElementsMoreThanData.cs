namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class HasElementsMoreThanData : TheoryData<List<int>?, int, bool>
{
    public HasElementsMoreThanData()
    {
        Add(null, 0, false);
        Add(null, 1, false);
        
        Add(new List<int>(), -1, true);
        Add(new List<int>(), 0, false);
        Add(new List<int>(), 1, false);
        
        Add(new List<int> { 0 }, 0, true);
        Add(new List<int> { 0 }, 1, false);
        Add(new List<int> { 0, 1 }, 1, true);
        Add(new List<int> { 0, 1, 2 }, 2, true);

        Add(Enumerable.Range(0, 10).ToList(), 8, true);
        Add(Enumerable.Range(0, 10).ToList(), 10, false);
    }
}