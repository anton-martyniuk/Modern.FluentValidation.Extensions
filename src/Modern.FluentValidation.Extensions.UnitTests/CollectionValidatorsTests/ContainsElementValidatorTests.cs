using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using Modern.FluentValidation.Extensions.UnitTests.Common;

namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class ContainsElementValidatorTests
{
    [Theory]
    [ClassData(typeof(ContainsElementData))]
    public void ContainsElementValidator_ShouldValidate_WhenGivenInput(List<string?> items, string containsValue, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.NullableStringItems)!.Contains(containsValue)
        };
        
        var result = validator.Validate(new TestClass
        {
            NullableStringItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void ContainsElementValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.NullableStringItems)!.Contains("foo")
        };
        
        var result = validator.Validate(new TestClass
        {
            NullableStringItems = new List<string?> { "bar" }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Nullable String Items' collection must contain the 'foo' value.");
    }
}