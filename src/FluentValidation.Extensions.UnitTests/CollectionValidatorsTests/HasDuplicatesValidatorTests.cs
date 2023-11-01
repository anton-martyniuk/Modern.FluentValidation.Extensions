using FluentAssertions;
using FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class HasDuplicatesValidatorTests
{
    private readonly TestValidator _validator;

    public HasDuplicatesValidatorTests()
    {
        _validator = new TestValidator
        {
            v => v.RuleFor(x => x.NullableStringItems)!.HasDuplicates()
        };
    }

    [Theory]
    [ClassData(typeof(HasDuplicatesData))]
    public void HasDuplicatesValidator_ShouldValidate_WhenGivenInput(List<string?> items, bool expectedValidity)
    {
        var result = _validator.Validate(new TestClass
        {
            NullableStringItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void HasDuplicatesValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var result = _validator.Validate(new TestClass
        {
            NullableStringItems = new List<string?> { "foo", "bar" }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Nullable String Items' collection must have at least one duplicate element.");
    }
}