using FluentAssertions;
using FluentValidation;
using Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using Modern.FluentValidation.Extensions.UnitTests.Common;

namespace Modern.FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class HasElementsValidatorTests
{
    private readonly TestValidator _validator;

    public HasElementsValidatorTests()
    {
        _validator = new TestValidator
        {
            v => v.RuleFor(x => x.IntItems)!.HasElements()
        };
    }

    [Theory]
    [ClassData(typeof(HasElementsData))]
    public void HasElementsValidator_ShouldValidate_WhenGivenInput(List<int>? items, bool expectedValidity)
    {
        var result = _validator.Validate(new TestClass
        {
            IntItems = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void HasElementsValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var result = _validator.Validate(new TestClass
        {
            IntItems = new List<int>()
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Int Items' collection must have at least one element.");
    }
}