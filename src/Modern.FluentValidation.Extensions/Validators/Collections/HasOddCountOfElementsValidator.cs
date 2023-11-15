using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection has an odd count of elements.
/// </summary>
public class HasOddCountOfElementsValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    /// <inheritdoc />
    public override string Name => "HasOddCountOfElementsValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
        => value?.Count() % 2 == 1;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' collection must have an odd count of elements.";
}