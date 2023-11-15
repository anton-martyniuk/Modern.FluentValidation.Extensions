// ReSharper disable CheckNamespace

using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection has at least one element that matches a given predicate.
/// </summary>
public class AnyMatchValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    private readonly Predicate<TElement> _predicate;

    /// <inheritdoc />
    public override string Name => "AnyMatchValidator";

    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="predicate">A predicate to test a collection against</param>
    public AnyMatchValidator(Predicate<TElement> predicate)
    {
        _predicate = predicate;
    }

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
    {
        if (value is null)
        {
            return false;
        }

        var list = value.ToList();
        return list.Count > 0 && list.Any(element => _predicate(element));
    }

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' collection must have at least one element that matches the specified condition.";
}