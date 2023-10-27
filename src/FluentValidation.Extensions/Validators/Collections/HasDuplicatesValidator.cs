// ReSharper disable CheckNamespace

using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection has at least one duplicate element.
/// </summary>
public class HasDuplicatesValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    /// <inheritdoc />
    public override string Name => "HasDuplicatesValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
    {
        if (value is null)
        {
            return false;
        }
        
        return value
            .GroupBy(x => x)
            .Any(g => g.Count() > 1);
    }

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' collection must have at least one duplicate element.";
}