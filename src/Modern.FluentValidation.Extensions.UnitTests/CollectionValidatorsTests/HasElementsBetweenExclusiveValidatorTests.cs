using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using Modern.FluentValidation.Extensions.UnitTests.Common;

namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class HasElementsBetweenExclusiveValidatorTests
{
    [Theory]
    [ClassData(typeof(HasElementsBetweenExclusiveData))]
    public void HasElementsBetweenExclusiveValidator_ShouldValidate_WhenGivenInput(List<int>? items, int countFrom, int countTo, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasElementsBetweenExclusive(countFrom, countTo)
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void HasElementsBetweenExclusiveValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasElementsBetweenExclusive(2, 10)
        };
        
        var result = validator.Validate(new TestClass
        {
            IntItems = new List<int> { 0, 1 }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be($"'Int Items' collection must count of elements between 2 and 10 exclusively.");
    }
}