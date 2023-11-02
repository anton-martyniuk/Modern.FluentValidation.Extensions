namespace FluentValidation.Extensions.UnitTests.Common;

public class TestClass
{
    public string AbsoluteUrl { get; set; } = default!;
    
    public string RelativeUrl { get; set; } = default!;
    
    public string StringValue { get; set; } = default!;

    public List<int>? IntItems { get; set; }

    public List<string?>? NullableStringItems { get; set; } = new();
    
    public List<object?>? NullableObjectItems { get; set; } = new();
    
    public List<Person> Persons { get; set; } = new();
    
    public bool Enabled { get; set; }
}