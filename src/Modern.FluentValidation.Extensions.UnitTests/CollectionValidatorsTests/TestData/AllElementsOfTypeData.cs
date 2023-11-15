namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class AllElementsOfTypeData : TheoryData<List<object?>?, Type, bool>
{
    public AllElementsOfTypeData()
    {
        Add(null, typeof(int), false);
        Add(null, typeof(string), false);
        Add(null, typeof(object), false);
        Add(null, typeof(TestType), false);
        
        Add(new List<object?>(), typeof(int), false);
        Add(new List<object?>(), typeof(string), false);
        Add(new List<object?>(), typeof(object), false);
        Add(new List<object?>(), typeof(TestType), false);
        
        Add(new List<object?> { "foo" }, typeof(string), true);
        Add(new List<object?> { "foo", "bar" }, typeof(string), true);
        Add(new List<object?> { "foo", 123 }, typeof(string), false);
        Add(new List<object?> { "foo", 123 }, typeof(int), false);
        Add(new List<object?> { "foo", 123 }, typeof(long), false);
        
        Add(new List<object?> { 123, 456 }, typeof(int), true);
        Add(new List<object?> { 123, 456 }, typeof(long), false);
        Add(new List<object?> { 123, 456 }, typeof(float), false);
        
        Add(new List<object?> { 123.00f, 456.00f }, typeof(float), true);
        Add(new List<object?> { 123.00, 456.00 }, typeof(double), true);
        Add(new List<object?> { 123.00m, 456.00m }, typeof(decimal), true);
        
        Add(new List<object?> { new TestType() }, typeof(string), false);
        Add(new List<object?> { new TestType() }, typeof(TestType), true);
    }

    private record TestType;
}