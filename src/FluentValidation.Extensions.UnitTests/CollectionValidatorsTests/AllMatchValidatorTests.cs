using FluentAssertions;
using FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests;

public class AllMatchValidatorTestsTests
{
    [Theory]
    [ClassData(typeof(AllMatchData))]
    public void AllMatchValidatorTests_ShouldValidate_WhenGivenInput(List<Person> items, Predicate<Person> predicate, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.Persons)!.AllMatch(predicate)
        };
        
        var result = validator.Validate(new TestClass
        {
            Persons = items
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void AllMatchValidatorTests_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.Persons)!.AllMatch(x => x.Age > 18)
        };
        
        var result = validator.Validate(new TestClass
        {
            Persons = new List<Person>
            {
                new()
                {
                    Name = "Anton",
                    Age = 30
                },
                new()
                {
                    Name = "John",
                    Age = 18
                }
            }
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'Persons' collection must have all elements that match the specified condition.");
    }
}