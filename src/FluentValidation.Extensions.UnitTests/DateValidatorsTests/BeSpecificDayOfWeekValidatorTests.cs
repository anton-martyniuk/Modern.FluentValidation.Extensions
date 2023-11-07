using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;
using FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

namespace FluentValidation.Extensions.UnitTests.DateValidatorsTests;

public class BeSpecificDayOfWeekValidatorTests
{
    [Theory]
    [ClassData(typeof(BeSpecificDayOfWeekData))]
    public void BeSpecificDayOfWeekValidator_ShouldValidate_WhenGivenInput(DateTime? input, DayOfWeek day, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeSpecificDayOfWeek(day)
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void BeSpecificDayOfWeekValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeSpecificDayOfWeek(DayOfWeek.Saturday)
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = new DateTime(2023, 11, 03)
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Date Time Value' must be a Saturday day.");
    }
}