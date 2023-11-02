using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.StringValidatorsTests;

public class EndsWithValidatorTests
{
    [Theory]
    [InlineData(null, "abc", false)]
    [InlineData("", "abc", false)]
    [InlineData(" ", "abc", false)]
    [InlineData("def", "abc", false)]
    [InlineData("abdef", "abc", false)]
    [InlineData("abc", "abc", true)]
    [InlineData("abcdef", "abc", false)]
    [InlineData("defabc", "abc", true)]
    [InlineData("defcba", "abc", false)]
    [InlineData("defabcc", "abc", false)]
    public void EndsWithValidator_ShouldValidate_WhenGivenInput(string input, string expectedEnd, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).EndsWith(expectedEnd)
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void EndsWithValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).EndsWith("foo")
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = "bar"
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'String Value' must end with the 'foo' substring.");
    }
}