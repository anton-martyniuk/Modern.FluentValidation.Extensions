using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection has any elements.
/// </summary>
public class HasElementsValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    /// <inheritdoc />
    public override string Name => "HasElementsValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
        => value?.Any() ?? false;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' collection must have at least one element.";
}