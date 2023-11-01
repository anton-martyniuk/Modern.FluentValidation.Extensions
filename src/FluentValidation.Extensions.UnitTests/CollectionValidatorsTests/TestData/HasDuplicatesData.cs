namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class HasDuplicatesData : TheoryData<List<string?>?, bool>
{
    public HasDuplicatesData()
    {
        Add(null, false);
        Add(new List<string?>(), false);
        Add(new List<string?> { null }, false);
        Add(new List<string?> { "foo", "bar" }, false);
        Add(new List<string?> { null, "foo", "bar" }, false);
        Add(new List<string?> { "foo", null, "bar" }, false);
        Add(new List<string?> { "foo", "bar", null }, false);
        Add(new List<string?> { "foo", null, "bar", null }, true);
        
        Add(new List<string?> { "foo", "bar", "foo" }, true);
        Add(new List<string?> { "foo", "bar", "bar" }, true);
        Add(new List<string?> { "foo", "bar", "foo", "bar" }, true);
    }
}