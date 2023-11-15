using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.Common;
using Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

namespace Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests;

public class BeWeekdayValidatorTests
{
    [Theory]
    [ClassData(typeof(BeWeekdayData))]
    public void BeWeekdayValidator_ShouldValidate_WhenGivenInput(DateTime? input, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeWeekday()
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void BeWeekdayValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeWeekday()
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = new DateTime(2023, 11, 05)
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Date Time Value' must be a weekday.");
    }
}