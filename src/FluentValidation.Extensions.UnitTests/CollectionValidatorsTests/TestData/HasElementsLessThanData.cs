namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class HasElementsLessThanData : TheoryData<List<int>?, int, bool>
{
    public HasElementsLessThanData()
    {
        Add(null, 0, false);
        Add(null, 1, false);
        
        Add(new List<int>(), -1, false);
        Add(new List<int>(), 0, false);
        Add(new List<int>(), 1, true);
        
        Add(new List<int> { 0 }, 0, false);
        Add(new List<int> { 0 }, 1, false);
        Add(new List<int> { 0 }, 2, true);
        
        Add(Enumerable.Range(0, 10).ToList(), 10, false);
        Add(Enumerable.Range(0, 10).ToList(), 20, true);
    }
}