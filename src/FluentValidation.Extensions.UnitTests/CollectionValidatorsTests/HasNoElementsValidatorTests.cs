using FluentAssertions;
using FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class HasNoElementsValidatorTests
{
    private readonly TestValidator _validator;

    public HasNoElementsValidatorTests()
    {
        _validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasNoElements()
        };
    }

    [Theory]
    [ClassData(typeof(HasNoElementsData))]
    public void HasNoElementsValidator_ShouldValidate_WhenGivenInput(List<int>? items, bool expectedValidity)
    {
        var result = _validator.Validate(new TestClass
        {
            IntItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void HasNoElementsValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var result = _validator.Validate(new TestClass
        {
            IntItems = new List<int> { 0 }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Int Items' collection must not have any elements.");
    }
}