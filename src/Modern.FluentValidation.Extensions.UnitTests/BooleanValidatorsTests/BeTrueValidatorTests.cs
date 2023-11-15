using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.Common;

namespace Modern.FluentValidation.Extensions.UnitTests.BooleanValidatorsTests;

public class BeTrueValidatorTests
{
    private readonly TestValidator _validator;

    public BeTrueValidatorTests()
    {
        _validator = new TestValidator
        {
            v => v.RuleFor(x => x.Enabled).BeTrue()
        };
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    public void BeTrueValidator_ShouldValidate_WhenGivenInput(bool input, bool expectedValidity)
    {
        var result = _validator.Validate(new TestClass
        {
            Enabled = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void BeTrueValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var result = _validator.Validate(new TestClass
        {
            Enabled = false
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Enabled' must be true.");
    }
}