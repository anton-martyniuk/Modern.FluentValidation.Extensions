using FluentAssertions;
using FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class IsUniqueValidatorTests
{
    private readonly TestValidator _validator;

    public IsUniqueValidatorTests()
    {
        _validator = new TestValidator
        {
            v => v.RuleFor(x => x.NullableStringItems)!.IsUnique()
        };
    }

    [Theory]
    [ClassData(typeof(IsUniqueData))]
    public void IsUniqueValidator_ShouldValidate_WhenGivenInput(List<string?> items, bool expectedValidity)
    {
        var result = _validator.Validate(new TestClass
        {
            NullableStringItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void IsUniqueValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var result = _validator.Validate(new TestClass
        {
            NullableStringItems = new List<string?> { "foo", "foo" }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Nullable String Items' collection must have all unique elements.");
    }
}