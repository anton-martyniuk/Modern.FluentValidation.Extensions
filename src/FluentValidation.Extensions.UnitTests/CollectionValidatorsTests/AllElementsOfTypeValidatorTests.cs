using FluentAssertions;
using FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class AllElementsOfTypeValidatorTestsTests
{
    [Theory]
    [ClassData(typeof(AllElementsOfTypeData))]
    public void AllElementsOfTypeValidatorTests_ShouldValidate_WhenGivenInput(List<object?> items, Type expectedType, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.NullableObjectItems)!.AllElementsOfType(expectedType)
        };
        
        var result = validator.Validate(new TestClass
        {
            NullableObjectItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void AllElementsOfTypeValidatorTests_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.NullableObjectItems)!.AllElementsOfType(typeof(string))
        };
        
        var result = validator.Validate(new TestClass
        {
            NullableObjectItems = new List<object?> { 0 }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Nullable Object Items' collection must contain elements of type 'String'.");
    }
}