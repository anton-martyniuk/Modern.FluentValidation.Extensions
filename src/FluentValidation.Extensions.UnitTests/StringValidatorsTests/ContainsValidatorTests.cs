using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.StringValidatorsTests;

public class ContainsValidatorTests
{
    [Theory]
    [InlineData(null, "abc", false)]
    [InlineData("", "abc", false)]
    [InlineData(" ", "abc", false)]
    [InlineData("def", "abc", false)]
    [InlineData("abdef", "abc", false)]
    [InlineData("abc", "abc", true)]
    [InlineData("abcdef", "abc", true)]
    [InlineData("defabc", "abc", true)]
    [InlineData("defcba", "abc", false)]
    [InlineData("defabcc", "abc", true)]
    public void ContainsValidator_ShouldValidate_WhenGivenInput(string input, string expectedSubstring, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).Contains(expectedSubstring)
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void ContainsValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).Contains("foo")
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = "fbar"
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'String Value' must contain the 'foo' substring.");
    }
}