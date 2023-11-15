using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection has all elements of the given type
/// </summary>
public class AllElementsOfTypeValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    private readonly Type _desiredType;

    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="desiredType">The type of elements that the collection should have</param>
    public AllElementsOfTypeValidator(Type desiredType)
    {
        _desiredType = desiredType;
    }

    /// <inheritdoc />
    public override string Name => "AllElementsOfTypeValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
    {
        if (value is null)
        {
            return false;
        }

        var list = value.ToList();
        return list.Count > 0 && list.All(x => x?.GetType() == _desiredType);
    }

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' collection must contain elements of type '{_desiredType.Name}'.";
}