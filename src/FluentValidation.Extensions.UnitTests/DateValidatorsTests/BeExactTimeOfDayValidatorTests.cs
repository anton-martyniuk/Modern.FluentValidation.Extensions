using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;
using FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

namespace FluentValidation.Extensions.UnitTests.DateValidatorsTests;

public class BeExactTimeOfDayValidatorTests
{
    [Theory]
    [ClassData(typeof(BeExactTimeOfDayData))]
    public void BeExactTimeOfDayValidator_ShouldValidate_WhenGivenInput(DateTime? input, TimeSpan timeSpan, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeExactTimeOfDay(timeSpan)
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void BeExactTimeOfDayValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var timeSpan = new TimeSpan(9, 0, 0);
        
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeExactTimeOfDay(timeSpan)
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = new DateTime(2023, 11, 30, 10, 0, 0)
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be($"'Date Time Value' must have the exact time of {timeSpan}.");
    }
}