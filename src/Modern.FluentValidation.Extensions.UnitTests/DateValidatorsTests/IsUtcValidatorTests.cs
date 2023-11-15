using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.Common;
using Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

namespace Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests;

public class IsUtcValidatorTests
{
    [Theory]
    [ClassData(typeof(IsUtcData))]
    public void IsUtcValidator_ShouldValidate_WhenGivenInput(DateTime? input, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).IsUtc()
        };

        var result = validator.Validate(new TestClass
        {
            DateTimeValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }

    [Fact]
    public void IsUtcValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).IsUtc()
        };

        var result = validator.Validate(new TestClass
        {
            DateTimeValue = DateTime.Now
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Date Time Value' must be in UTC.");
    }
}