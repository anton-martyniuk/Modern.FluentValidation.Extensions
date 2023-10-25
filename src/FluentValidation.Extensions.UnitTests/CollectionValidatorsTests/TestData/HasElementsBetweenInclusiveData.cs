namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class HasElementsBetweenInclusiveData : TheoryData<List<int>?, int, int, bool>
{
    public HasElementsBetweenInclusiveData()
    {
        Add(null, 0, 5, true);
        Add(null, 1, 5, false);
        
        Add(new List<int>(), 0, 5, true);
        Add(new List<int>(), 1, 5, false);
        
        Add(new List<int> { 0 }, 0, 5, true);
        Add(new List<int> { 0 }, 1, 5, true);
        Add(new List<int> { 0 }, 2, 5, false);
        
        Add(new List<int> { 0, 1, 2, 3, 4 }, 1, 5, true);
        Add(new List<int> { 0, 1, 2, 3, 4 }, 1, 6, true);
        Add(new List<int> { 0, 1, 2, 3, 4 }, 1, 4, false);
        
        Add(Enumerable.Range(0, 10).ToList(), 9, 20, true);
        Add(Enumerable.Range(0, 20).ToList(), 9, 20, true);
        Add(Enumerable.Range(0, 21).ToList(), 10, 20, false);
    }
}