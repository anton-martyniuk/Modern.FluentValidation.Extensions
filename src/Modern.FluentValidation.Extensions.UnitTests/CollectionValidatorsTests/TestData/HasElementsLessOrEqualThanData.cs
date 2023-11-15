namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class HasElementsLessOrEqualThanData : TheoryData<List<int>?, int, bool>
{
    public HasElementsLessOrEqualThanData()
    {
        Add(null, 0, false);
        Add(null, 1, false);
        
        Add(new List<int>(), -1, false);
        Add(new List<int>(), 0, true);
        Add(new List<int>(), 1, true);
        
        Add(new List<int> { 0 }, 0, false);
        Add(new List<int> { 0 }, 1, true);
        Add(new List<int> { 0 }, 2, true);
        
        Add(Enumerable.Range(0, 10).ToList(), 9, false);
        Add(Enumerable.Range(0, 10).ToList(), 10, true);
        Add(Enumerable.Range(0, 10).ToList(), 20, true);
    }
}