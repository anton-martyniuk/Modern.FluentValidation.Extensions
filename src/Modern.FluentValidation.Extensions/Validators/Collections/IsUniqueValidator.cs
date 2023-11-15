// ReSharper disable CheckNamespace

using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection has all unique elements.
/// </summary>
public class IsUniqueValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    /// <inheritdoc />
    public override string Name => "IsUniqueValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
    {
        if (value is null)
        {
            return false;
        }
        
        var list = value.ToList();
        return list.Count > 0 && list.Distinct().Count() == list.Count;
    }

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' collection must have all unique elements.";
}