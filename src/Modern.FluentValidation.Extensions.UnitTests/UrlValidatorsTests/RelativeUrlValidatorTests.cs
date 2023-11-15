using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.Common;

namespace Modern.FluentValidation.Extensions.UnitTests.UrlValidatorsTests;

public class RelativeUrlValidatorTests
{
    [Theory]
    [InlineData("path/to/resource", true)]
    [InlineData("/path/to/resource", true)]
    [InlineData("https://www.google.com", false)]
    [InlineData("http://example.com", false)]
    [InlineData("http://example.com/caregory/products.html", false)]
    [InlineData("http://example.com/caregory?page=5", false)]
    [InlineData("http://example.com/caregory?page=5#anchor", false)]
    [InlineData("http://example.com/caregory#anchor", false)]
    [InlineData("ftp://files.com", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    [InlineData(" ", false)]
    public void RelativeUrlValidator_ShouldValidate_WhenGivenInput(string input, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.RelativeUrl).IsRelativeUrl()
        };
        
        var result = validator.Validate(new TestClass
        {
            RelativeUrl = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void RelativeUrlValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.RelativeUrl).IsRelativeUrl()
        };
        
        var result = validator.Validate(new TestClass
        {
            RelativeUrl = "https://www.google.com"
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Relative Url' must be a relative URL.");
    }
}