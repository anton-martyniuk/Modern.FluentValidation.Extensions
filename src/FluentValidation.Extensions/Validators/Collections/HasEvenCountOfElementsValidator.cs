using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection has an even count of elements.
/// </summary>
public class HasEvenCountOfElementsValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    /// <inheritdoc />
    public override string Name => "HasEvenCountOfElementsValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
    {
        return value?.Count() % 2 == 0;
    }

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must have an even count of elements.";
}