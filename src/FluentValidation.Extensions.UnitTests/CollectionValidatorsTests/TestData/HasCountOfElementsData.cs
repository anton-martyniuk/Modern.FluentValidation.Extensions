namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class HasCountOfElementsData : TheoryData<List<int>?, int, bool>
{
    public HasCountOfElementsData()
    {
        Add(null, 0, true);
        Add(null, 1, false);
        
        Add(new List<int>(), 0, true);
        Add(new List<int>(), 1, false);
        
        Add(new List<int> { 0 }, 1, true);
        Add(new List<int> { 0 }, 0, false);
        Add(new List<int> { 0 }, 2, false);
        
        Add(Enumerable.Range(0, 10).ToList(), 10, true);
        Add(Enumerable.Range(0, 10).ToList(), 20, false);
    }
}