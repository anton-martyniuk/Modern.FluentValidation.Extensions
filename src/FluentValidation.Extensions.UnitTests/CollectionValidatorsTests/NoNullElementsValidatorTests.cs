using FluentAssertions;
using FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class NoNullElementsValidatorTests
{
    private readonly TestValidator _validator;

    public NoNullElementsValidatorTests()
    {
        _validator = new TestValidator
        {
            v => v.RuleFor(x => x.NullableStringItems)!.NoNullElements()
        };
    }

    [Theory]
    [ClassData(typeof(NoNullElementsData))]
    public void NoNullElementsValidator_ShouldValidate_WhenGivenInput(List<string?> items, bool expectedValidity)
    {
        var result = _validator.Validate(new TestClass
        {
            NullableStringItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void NoNullElementsValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var result = _validator.Validate(new TestClass
        {
            NullableStringItems = new List<string?> { null }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Nullable String Items' must not contain null elements.");
    }
}