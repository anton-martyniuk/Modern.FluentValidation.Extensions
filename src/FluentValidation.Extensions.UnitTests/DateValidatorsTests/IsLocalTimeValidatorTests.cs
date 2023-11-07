using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;
using FluentValidation.Extensions.UnitTests.DateValidatorsTests.TestData;

namespace FluentValidation.Extensions.UnitTests.DateValidatorsTests;

public class IsLocalTimeValidator
{
    [Theory]
    [ClassData(typeof(IsLocalTimeData))]
    public void IsLocalTimeValidator_ShouldValidate_WhenGivenInput(DateTime? input, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).IsLocalTime()
        };

        var result = validator.Validate(new TestClass
        {
            DateTimeValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }

    [Fact]
    public void IsLocalTimeValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.DateTimeValue).IsLocalTime()
        };

        var result = validator.Validate(new TestClass
        {
            DateTimeValue = DateTime.UtcNow
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Date Time Value' must be in local time.");
    }
}