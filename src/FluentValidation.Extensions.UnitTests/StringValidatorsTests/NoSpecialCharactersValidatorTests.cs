using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.StringValidatorsTests;

public class NoSpecialCharactersValidatorTests
{
    [Theory]
    [InlineData(null, "", false)]
    [InlineData("", "", true)]
    [InlineData(" ", "", false)]
    [InlineData("def", "", true)]
    [InlineData("abdef.", "", false)]
    [InlineData(".abdef", "", false)]
    [InlineData(".", "", false)]
    [InlineData(".", ".", true)]
    [InlineData(".)", ".", false)]
    public void NoSpecialCharactersValidator_ShouldValidate_WhenGivenInput(string input, string allowedChars, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).NoSpecialCharacters(allowedChars)
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void NoSpecialCharactersValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).NoSpecialCharacters()
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = ".-)"
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'String Value' must not contain special characters.");
    }
}