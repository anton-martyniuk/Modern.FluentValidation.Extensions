using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.Common;
using Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

namespace Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests;

public class BeInPastValidatorTests
{
    [Theory]
    [ClassData(typeof(BeInPastData))]
    public void BeInPastValidator_ShouldValidate_WhenGivenInput(DateTime? input, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeInPast()
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void BeInPastValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeInPast()
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = DateTime.Now.AddHours(1)
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Date Time Value' must be in the past.");
    }
}