using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.Common;

namespace Modern.FluentValidation.Extensions.UnitTests.BooleanValidatorsTests;

public class BeFalseValidatorTests
{
    private readonly TestValidator _validator;

    public BeFalseValidatorTests()
    {
        _validator = new TestValidator
        {
            v => v.RuleFor(x => x.Enabled).BeFalse()
        };
    }

    [Theory]
    [InlineData(false, true)]
    [InlineData(true, false)]
    public void BeFalseValidator_ShouldValidate_WhenGivenInput(bool input, bool expectedValidity)
    {
        var result = _validator.Validate(new TestClass
        {
            Enabled = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void BeFalseValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var result = _validator.Validate(new TestClass
        {
            Enabled = true
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Enabled' must be false.");
    }
}