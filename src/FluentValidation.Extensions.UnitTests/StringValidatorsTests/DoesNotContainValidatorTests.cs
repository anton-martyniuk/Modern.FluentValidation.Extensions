using FluentAssertions;
using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.StringValidatorsTests;

public class DoesNotContainValidatorTests
{
    [Theory]
    [InlineData(null, "abc", true)]
    [InlineData("", "abc", true)]
    [InlineData(" ", "abc", true)]
    [InlineData("def", "abc", true)]
    [InlineData("abdef", "abc", true)]
    [InlineData("abc", "abc", false)]
    [InlineData("abcdef", "abc", false)]
    [InlineData("defabc", "abc", false)]
    [InlineData("defcba", "abc", true)]
    [InlineData("defabcc", "abc", false)]
    public void DoesNotContainValidator_ShouldValidate_WhenGivenInput(string input, string unexpectedSubstring, bool expectedValidity)
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).DoesNotContain(unexpectedSubstring)
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = input
        });

        result.IsValid.Should().Be(expectedValidity);
    }
    
    [Fact]
    public void DoesNotContainValidator_ShouldReturnCorrectErrorMessage_WhenGivenInvalidInput()
    {
        var validator = new TestValidator
        {
            v => v.RuleFor(x => x.StringValue).DoesNotContain("foo")
        };
        
        var result = validator.Validate(new TestClass
        {
            StringValue = "foobar"
        });

        result.IsValid.Should().BeFalse();
        result.Errors[0].ErrorMessage.Should().Be("'String Value' must not contain the 'foo' substring.");
    }
}