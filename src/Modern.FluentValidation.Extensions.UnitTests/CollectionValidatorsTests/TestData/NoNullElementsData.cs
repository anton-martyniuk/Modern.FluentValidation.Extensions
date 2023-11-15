namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class NoNullElementsData : TheoryData<List<string?>?, bool>
{
    public NoNullElementsData()
    {
        Add(null, false);
        Add(new List<string?>(), true);
        Add(new List<string?> { null }, false);
        Add(new List<string?> { "foo", "bar" }, true);
        Add(new List<string?> { null, "foo", "bar" }, false);
        Add(new List<string?> { "foo", null, "bar" }, false);
        Add(new List<string?> { "foo", "bar", null }, false);
        Add(new List<string?> { "foo", null, "bar", null }, false);
    }
}