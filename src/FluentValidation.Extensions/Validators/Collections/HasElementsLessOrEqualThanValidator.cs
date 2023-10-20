using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection has equal or less than N elements.
/// </summary>
public class HasElementsLessOrEqualThanValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    private readonly int _count;

    /// <inheritdoc />
    public override string Name => "HasElementsLessOrEqualThanValidator";
    
    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="count">Count of elements.<br/>Collection must have count of elements equal or less than the given number</param>
    public HasElementsLessOrEqualThanValidator(int count)
    {
        _count = count;
    }

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
        => value?.Count() <= _count;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' collection must have equal or less than {_count} elements.";
}