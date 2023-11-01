namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class DoesNotContainElementData : TheoryData<List<string?>?, string, bool>
{
    public DoesNotContainElementData()
    {
        const string doesntContainValue = "foo";
        
        // Collection should not contain "foo" element
        Add(null, doesntContainValue, false);
        Add(new List<string?>(), doesntContainValue, true);
        Add(new List<string?> { null }, doesntContainValue, true);
        
        Add(new List<string?> { "foo" }, doesntContainValue, false);
        Add(new List<string?> { "foo", "foo" }, doesntContainValue, false);
        Add(new List<string?> { "foo", "bar" }, doesntContainValue, false);
        
        Add(new List<string?> { "bar" }, doesntContainValue, true);
        Add(new List<string?> { "bar", "bar" }, doesntContainValue, true);
        
        Add(new List<string?> { null, "foo", "bar" }, doesntContainValue, false);
        Add(new List<string?> { "foo", null, "bar" }, doesntContainValue, false);
        Add(new List<string?> { "foo", "bar", null }, doesntContainValue, false);
        Add(new List<string?> { "foo", null, "bar", null }, doesntContainValue, false);
        Add(new List<string?> { "qwerty", null, "bar", null }, doesntContainValue, true);
    }
}