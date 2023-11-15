using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.Common;

namespace Modern.FluentValidation.Extensions.UnitTests.StringValidatorsTests;

public class DoesNotStartWithValidatorTests
{
    [Theory]
    [InlineData(null, "abc", true)]
    [InlineData("", "abc", true)]
    [InlineData(" ", "abc", true)]
    [InlineData("def", "abc", true)]
    [InlineData("abdef", "abc", true)]
    [InlineData("abc", "abc", false)]
    [InlineData("abcdef", "abc", false)]
    [InlineData("aabc", "abc", true)]
    [InlineData("defabc", "abc", true)]
    public void DoesNotStartWithValidator_ShouldValidate_WhenGivenInput(string input, string unexpectedStart, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).DoesNotStartWith(unexpectedStart)
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void DoesNotStartWithValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).DoesNotStartWith("foo")
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = "foobar"
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'String Value' must not start with the 'foo' substring.");
    }
}