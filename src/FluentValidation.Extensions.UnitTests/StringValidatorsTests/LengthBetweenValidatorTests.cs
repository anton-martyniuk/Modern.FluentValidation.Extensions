using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.StringValidatorsTests;

public class LengthBetweenValidatorTests
{
    [Theory]
    [InlineData(null, false)]
    [InlineData("", false)]
    [InlineData(" ", false)]
    [InlineData("abc", true)]
    [InlineData("abcd", true)]
    [InlineData("abcde", true)]
    [InlineData(".", false)]
    [InlineData("abcdef", false)]
    [InlineData("123456790", false)]
    public void LengthBetweenValidator_ShouldValidate_WhenGivenInput(string input, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).LengthBetween(3, 5)
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void LengthBetweenValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).LengthBetween(5, 10)
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = "abc"
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'String Value' must have a length between 5 and 10.");
    }
}