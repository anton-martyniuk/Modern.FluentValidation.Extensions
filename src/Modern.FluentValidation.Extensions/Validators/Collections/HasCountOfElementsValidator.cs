using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection has a specific count of items.
/// </summary>
public class HasCountOfElementsValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    private readonly int _count;
    
    /// <inheritdoc />
    public override string Name => "HasCountOfElementsValidator";
    
    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="count">Count of elements.<br/>Collection must have count of elements equal to the given number</param>
    public HasCountOfElementsValidator(int count)
    {
        _count = count;
    }

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
    {
        var countOfElements = value?.Count() ?? 0;
        return countOfElements == _count;
    }

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' collection must have {_count} elements.";
}