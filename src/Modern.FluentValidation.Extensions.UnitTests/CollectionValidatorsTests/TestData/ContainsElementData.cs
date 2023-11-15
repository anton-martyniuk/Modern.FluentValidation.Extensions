namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class ContainsElementData : TheoryData<List<string?>?, string, bool>
{
    public ContainsElementData()
    {
        const string containsValue = "foo";
        
        // Collection should contain "foo" element
        Add(null, containsValue, false);
        Add(new List<string?>(), containsValue, false);
        Add(new List<string?> { null }, containsValue, false);
        
        Add(new List<string?> { "foo" }, containsValue, true);
        Add(new List<string?> { "foo", "foo" }, containsValue, true);
        Add(new List<string?> { "foo", "bar" }, containsValue, true);
        
        Add(new List<string?> { "bar" }, containsValue, false);
        Add(new List<string?> { "bar", "bar" }, containsValue, false);
        
        Add(new List<string?> { null, "foo", "bar" }, containsValue, true);
        Add(new List<string?> { "foo", null, "bar" }, containsValue, true);
        Add(new List<string?> { "foo", "bar", null }, containsValue, true);
        Add(new List<string?> { "foo", null, "bar", null }, containsValue, true);
    }
}