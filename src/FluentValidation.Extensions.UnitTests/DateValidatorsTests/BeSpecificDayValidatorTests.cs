using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;
using FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

namespace FluentValidation.Extensions.UnitTests.DateValidatorsTests;

public class BeSpecificDayValidatorTests
{
    [Theory]
    [ClassData(typeof(BeSpecificDayData))]
    public void BeSpecificDayValidator_ShouldValidate_WhenGivenInput(DateTime? input, int day, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeSpecificDay(day)
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void BeSpecificDayValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeSpecificDay(5)
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = new DateTime(2023, 11, 03)
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Date Time Value' must be on the 5th day of the month.");
    }
}