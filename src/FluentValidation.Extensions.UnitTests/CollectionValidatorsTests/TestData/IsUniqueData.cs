namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class IsUniqueData : TheoryData<List<string?>?, bool>
{
    public IsUniqueData()
    {
        Add(null, false);
        Add(new List<string?>(), false);
        Add(new List<string?> { null }, true);
        Add(new List<string?> { "foo", "bar" }, true);
        Add(new List<string?> { null, "foo", "bar" }, true);
        Add(new List<string?> { "foo", null, "bar" }, true);
        Add(new List<string?> { "foo", "bar", null }, true);
        Add(new List<string?> { "foo", null, "bar", null }, false);
        
        Add(new List<string?> { "foo", "bar", "qwerty" }, true);
        Add(new List<string?> { "foo", "bar", "foo" }, false);
        Add(new List<string?> { "foo", "bar", "bar" }, false);
        Add(new List<string?> { "foo", "bar", "foo", "bar" }, false);
    }
}