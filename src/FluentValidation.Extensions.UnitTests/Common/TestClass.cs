namespace FluentValidation.Extensions.UnitTests.Common;

public class TestClass
{
    public string AbsoluteUrl { get; set; } = default!;
    
    public string RelativeUrl { get; set; } = default!;

    public List<int>? IntItems { get; set; }
}