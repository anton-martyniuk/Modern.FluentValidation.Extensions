using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.UrlValidatorsTests;

public class AbsoluteUrlValidatorTests
{
    private readonly TestValidator _validator;

    public AbsoluteUrlValidatorTests()
    {
        _validator = new TestValidator
        {
            v => v.RuleFor(x => x.AbsoluteUrl).IsAbsoluteUrl()
        };
    }

    [Theory]
    [InlineData("https://www.google.com", true)]
    [InlineData("http://example.com", true)]
    [InlineData("http://example.com/caregory/products.html", true)]
    [InlineData("http://example.com/caregory?page=5", true)]
    [InlineData("http://example.com/caregory?page=5#anchor", true)]
    [InlineData("http://example.com/caregory#anchor", true)]
    [InlineData("ftp://files.com", true)]
    [InlineData("/path/to/resource", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    [InlineData(" ", false)]
    public void AbsoluteUrlValidator_ShouldValidate_WhenGivenInput(string input, bool expectedValidity)
    {
        var result = _validator.Validate(new TestClass
        {
            AbsoluteUrl = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void AbsoluteUrlValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var result = _validator.Validate(new TestClass
        {
            AbsoluteUrl = "/path/to/resource"
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Absolute Url' must be an absolute URL.");
    }
}