using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using Modern.FluentValidation.Extensions.UnitTests.Common;

namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class DoesNotContainElementValidatorTests
{
    [Theory]
    [ClassData(typeof(DoesNotContainElementData))]
    public void DoesNotContainElementValidator_ShouldValidate_WhenGivenInput(List<string?> items, string doesntContainValue, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.NullableStringItems)!.DoesNotContain(doesntContainValue)
        };
        
        var result = validator.Validate(new TestClass
        {
            NullableStringItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void DoesNotContainElementValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.NullableStringItems)!.DoesNotContain("foo")
        };
        
        var result = validator.Validate(new TestClass
        {
            NullableStringItems = new List<string?> { "foo" }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Nullable String Items' collection must not contain the 'foo' value.");
    }
}