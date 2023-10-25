using FluentAssertions;
using FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class HasElementsBetweenInclusiveValidatorTests
{
    [Theory]
    [ClassData(typeof(HasElementsBetweenInclusiveData))]
    public void HasElementsBetweenInclusiveValidator_ShouldValidate_WhenGivenInput(List<int>? items, int countFrom, int countTo, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasElementsBetweenInclusive(countFrom, countTo)
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void HasElementsBetweenInclusiveValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasElementsBetweenInclusive(2, 10)
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = new List<int> { 0 }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be($"'Int Items' collection must count of elements between 2 and 10 inclusively.");
    }
}