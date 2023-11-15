using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.Common;
using Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

namespace Modern.FluentValidation.Extensions.UnitTests.DateValidatorsTests;

public class BeWithinRangeValidatorTests
{
    [Theory]
    [ClassData(typeof(BeWithinRangeData))]
    public void BeWithinRangeValidator_ShouldValidate_WhenGivenInput(DateTime? input, DateTime startDate, DateTime endDate, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeWithinRange(startDate, endDate)
        };

        var result = validator.Validate(new TestClass
        {
            DateTimeValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }

    [Fact]
    public void BeWithinRangeValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var startDate = new DateTime(2023, 01, 01);
        var endDate = new DateTime(2023, 12, 31);

        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).BeWithinRange(startDate, endDate)
        };

        var result = validator.Validate(new TestClass
        {
            DateTimeValue = new DateTime(2024, 01, 01)
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be($"'Date Time Value' must be between {startDate.ToShortDateString()} and {endDate.ToShortDateString()}.");
    }
}