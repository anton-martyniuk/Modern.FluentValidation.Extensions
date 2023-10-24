using FluentAssertions;
using FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class HasCountOfElementsValidatorTests
{
    [Theory]
    [ClassData(typeof(HasCountOfElementsData))]
    public void HasCountOfElementsValidator_ShouldValidate_WhenGivenInput(List<int>? items, int count, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasCountOfElements(count)
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void HasCountOfElementsValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasCountOfElements(2)
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = new List<int>()
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Int Items' collection must have 2 elements.");
    }
}