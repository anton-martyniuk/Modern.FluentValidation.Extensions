namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class HasEvenCountOfElementsData : TheoryData<List<int>?, bool>
{
    public HasEvenCountOfElementsData()
    {
        Add(null, false);
        
        Add(new List<int>(), true);
        
        Add(new List<int> { 0 }, false);
        Add(new List<int> { 0, 1 }, true);
        
        Add(Enumerable.Range(0, 10).ToList(), true);
        Add(Enumerable.Range(0, 11).ToList(), false);
    }
}