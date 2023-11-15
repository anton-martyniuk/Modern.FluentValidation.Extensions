using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using Modern.FluentValidation.Extensions.UnitTests.Common;

namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class HasElementsMoreThanValidatorTests
{
    [Theory]
    [ClassData(typeof(HasElementsMoreThanData))]
    public void HasElementsMoreThanValidator_ShouldValidate_WhenGivenInput(List<int>? items, int count, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasElementsMoreThan(count)
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void HasElementsMoreThanValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasElementsMoreThan(2)
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = new List<int> { 0 }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Int Items' collection must have more than 2 elements.");
    }
}