using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.Common;
using Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

namespace Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests;

public class BeWeekendValidatorTests
{
    [Theory]
    [ClassData(typeof(BeWeekendData))]
    public void BeWeekendValidator_ShouldValidate_WhenGivenInput(DateTime? input, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeWeekend()
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void BeWeekendValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeWeekend()
        };
        
        var result = validator.Validate(new TestClass
        {
            DateTimeValue = new DateTime(2023, 11, 03)
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Date Time Value' must be a weekend day.");
    }
}