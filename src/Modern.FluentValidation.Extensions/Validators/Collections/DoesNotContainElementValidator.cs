using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection does not contain a given value
/// </summary>
public class DoesNotContainElementValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    private readonly TElement _expectedValue;

    /// <inheritdoc />
    public override string Name => "DoesNotContainElementValidator";

    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="expectedValue">A value that should be checked for non existence in the collection</param>
    public DoesNotContainElementValidator(TElement expectedValue)
    {
        _expectedValue = expectedValue;
    }

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
        => value is not null && !value.Contains(_expectedValue);

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' collection must not contain the '{_expectedValue}' value.";
}