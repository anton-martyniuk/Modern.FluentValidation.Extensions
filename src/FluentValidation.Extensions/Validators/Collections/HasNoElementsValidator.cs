using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection doesn't have any elements.
/// </summary>
public class HasNoElementsValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    /// <inheritdoc />
    public override string Name => "NoElementsValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
        => value is null || !value.Any();

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' collection must not have any elements.";
}