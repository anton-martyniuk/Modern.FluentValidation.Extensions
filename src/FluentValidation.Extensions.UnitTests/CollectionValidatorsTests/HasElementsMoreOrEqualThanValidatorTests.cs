using FluentAssertions;
using FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class HasElementsMoreOrEqualThanValidatorTests
{
    [Theory]
    [ClassData(typeof(HasElementsMoreOrEqualThanData))]
    public void HasElementsMoreOrEqualThanValidator_ShouldValidate_WhenGivenInput(List<int>? items, int count, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasElementsMoreOrEqualThan(count)
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void HasElementsMoreOrEqualThanValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasElementsMoreOrEqualThan(2)
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = new List<int> { 0 }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Int Items' collection must have equal or more than 2 elements.");
    }
}