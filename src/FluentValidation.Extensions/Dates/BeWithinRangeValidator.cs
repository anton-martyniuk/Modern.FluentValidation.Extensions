using System;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a date falls within a specified range of dates.
/// </summary>
public class BeWithinRangeValidator<T> : PropertyValidator<T, DateTime>
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;

    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="startDate">The start date of the range.</param>
    /// <param name="endDate">The end date of the range.</param>
    public BeWithinRangeValidator(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
    }

    /// <inheritdoc />
    public override string Name => "BeWithinRangeValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, DateTime value)
        => value >= _startDate && value <= _endDate;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' must be between {_startDate.ToShortDateString()} and {_endDate.ToShortDateString()}.";
}
