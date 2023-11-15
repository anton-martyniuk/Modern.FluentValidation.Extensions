using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.Common;

namespace Modern.FluentValidation.Extensions.UnitTests.StringValidatorsTests;

public class DoesNotEndWithValidatorTests
{
    [Theory]
    [InlineData(null, "abc", true)]
    [InlineData("", "abc", true)]
    [InlineData(" ", "abc", true)]
    [InlineData("def", "abc", true)]
    [InlineData("abdef", "abc", true)]
    [InlineData("abc", "abc", false)]
    [InlineData("abcdef", "abc", true)]
    [InlineData("defabc", "abc", false)]
    [InlineData("defcba", "abc", true)]
    [InlineData("defabcc", "abc", true)]
    public void DoesNotEndWithValidator_ShouldValidate_WhenGivenInput(string input, string unexpectedEnd, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).DoesNotEndWith(unexpectedEnd)
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void DoesNotEndWithValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).DoesNotEndWith("foo")
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = "barfoo"
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'String Value' must not end with the 'foo' substring.");
    }
}