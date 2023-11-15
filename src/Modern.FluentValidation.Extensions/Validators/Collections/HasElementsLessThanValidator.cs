using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection has less than N elements.
/// </summary>
public class HasElementsLessThanValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    private readonly int _count;

    /// <inheritdoc />
    public override string Name => "HasElementsLessThanValidator";
    
    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="count">Count of elements.<br/>Collection must have count of elements less than the given number</param>
    public HasElementsLessThanValidator(int count)
    {
        _count = count;
    }

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
        => value?.Count() < _count;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' collection must have less than {_count} elements.";
}