using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.Common;

namespace Modern.FluentValidation.Extensions.UnitTests.StringValidatorsTests;

public class BeLatinLettersValidatorTests
{
    [Theory]
    [InlineData(null, false)]
    [InlineData("", false)]
    [InlineData(" ", false)]
    [InlineData("def", true)]
    [InlineData("abdef.", false)]
    [InlineData(".abdef", false)]
    [InlineData(".", false)]
    [InlineData("123", false)]
    [InlineData("abc123", false)]
    public void BeLatinLettersValidator_ShouldValidate_WhenGivenInput(string input, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).BeLatinLetters()
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void BeLatinLettersValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).BeLatinLetters()
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = "abc123"
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'String Value' must contain only Latin letters.");
    }
}