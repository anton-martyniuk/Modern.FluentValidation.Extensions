using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a collection has count of elements between N and M inclusively.
/// </summary>
public class HasElementsBetweenInclusiveValidator<T, TElement> : PropertyValidator<T, IEnumerable<TElement>?>
{
    private readonly int _countFrom;
    private readonly int _countTo;

    /// <inheritdoc />
    public override string Name => "HasElementsBetweenValidator";
    
    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="countFrom">Count of elements.<br/>Collection must have count of elements equal or more than the given number</param>
    /// <param name="countTo">Count of elements.<br/>Collection must have count of elements equal or less than the given number</param>
    public HasElementsBetweenInclusiveValidator(int countFrom, int countTo)
    {
        _countFrom = countFrom;
        _countTo = countTo;
    }

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, IEnumerable<TElement>? value)
    {
        var countOfElements = value?.Count() ?? 0;
        return countOfElements >= _countFrom && countOfElements <= _countTo;
    }

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' collection must count of elements between {_countFrom} and {_countTo} inclusively.";
}