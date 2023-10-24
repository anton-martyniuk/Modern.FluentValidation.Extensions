using FluentAssertions;
using FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class HasOddCountOfElementsValidatorTests
{
    [Theory]
    [ClassData(typeof(HasOddCountOfElementsData))]
    public void HasOddCountOfElementsValidator_ShouldValidate_WhenGivenInput(List<int>? items, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasOddCountOfElements()
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void HasOddCountOfElementsValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasOddCountOfElements()
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = new List<int> { 0, 1 }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Int Items' collection must have an odd count of elements.");
    }
}