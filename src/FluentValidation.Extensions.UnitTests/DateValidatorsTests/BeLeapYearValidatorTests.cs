using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;
using FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

namespace FluentValidation.Extensions.UnitTests.DateValidatorsTests;

public class BeLeapYearValidatorTests
{
    [Theory]
    [ClassData(typeof(BeLeapYearData))]
    public void BeLeapYearValidator_ShouldValidate_WhenGivenInput(DateTime? input, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeLeapYear()
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void BeLeapYearValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeLeapYear()
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = new DateTime(2023, 11, 05)
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Date Time Value' must be in a leap year.");
    }
}