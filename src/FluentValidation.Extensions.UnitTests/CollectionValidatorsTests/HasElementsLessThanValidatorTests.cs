using FluentAssertions;
using FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class HasElementsLessThanValidatorTests
{
    [Theory]
    [ClassData(typeof(HasElementsLessThanData))]
    public void HasElementsLessThanValidator_ShouldValidate_WhenGivenInput(List<int>? items, int count, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasElementsLessThan(count)
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void HasElementsLessThanValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasElementsLessThan(2)
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = new List<int> { 0, 1, 2 }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Int Items' collection must have less than 2 elements.");
    }
}