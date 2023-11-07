using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;
using FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

namespace FluentValidation.Extensions.UnitTests.DateValidatorsTests;

public class BeSpecificMonthValidatorTests
{
    [Theory]
    [ClassData(typeof(BeSpecificMonthData))]
    public void BeSpecificMonthValidator_ShouldValidate_WhenGivenInput(DateTime? input, int month, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeSpecificMonth(month)
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void BeSpecificMonthValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeSpecificMonth(12)
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = new DateTime(2023, 11, 30)
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Date Time Value' must be in 12 month.");
    }
}