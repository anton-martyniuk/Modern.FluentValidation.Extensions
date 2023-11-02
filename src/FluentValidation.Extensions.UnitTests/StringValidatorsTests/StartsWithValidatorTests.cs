using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.StringValidatorsTests;

public class StartsWithValidatorTests
{
    [Theory]
    [InlineData(null, "abc", false)]
    [InlineData("", "abc", false)]
    [InlineData(" ", "abc", false)]
    [InlineData("def", "abc", false)]
    [InlineData("abdef", "abc", false)]
    [InlineData("abc", "abc", true)]
    [InlineData("abcdef", "abc", true)]
    [InlineData("aabc", "abc", false)]
    public void StartsWithValidator_ShouldValidate_WhenGivenInput(string input, string expectedStart, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).StartsWith(expectedStart)
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void StartsWithValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).StartsWith("foo")
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = "bar"
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'String Value' must start with the 'foo' substring.");
    }
}