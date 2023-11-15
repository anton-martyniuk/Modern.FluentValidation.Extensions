using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using Modern.FluentValidation.Extensions.UnitTests.Common;

namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class HasEvenCountOfElementsValidatorTests
{
    [Theory]
    [ClassData(typeof(HasEvenCountOfElementsData))]
    public void HasEvenCountOfElementsValidator_ShouldValidate_WhenGivenInput(List<int>? items, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasEvenCountOfElements()
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void HasEvenCountOfElementsValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasEvenCountOfElements()
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = new List<int> { 0 }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Int Items' collection must have an even count of elements.");
    }
}