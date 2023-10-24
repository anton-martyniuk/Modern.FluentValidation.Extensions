namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class HasOddCountOfElementsData : TheoryData<List<int>?, bool>
{
    public HasOddCountOfElementsData()
    {
        Add(null, false);
        
        Add(new List<int>(), false);
        
        Add(new List<int> { 0 }, true);
        Add(new List<int> { 0, 1 }, false);
        
        Add(Enumerable.Range(0, 10).ToList(), false);
        Add(Enumerable.Range(0, 11).ToList(), true);
    }
}