using System;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a date falls on a specific day of the month.
/// </summary>
public class BeSpecificDayValidator<T> : PropertyValidator<T, DateTime?>
{
    private readonly int _day;

    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="day">The expected day</param>
    public BeSpecificDayValidator(int day)
    {
        _day = day;
    }

    /// <inheritdoc />
    public override string Name => "HaveDayValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, DateTime? value)
        => value != DateTime.MinValue && value != DateTime.MaxValue && value?.Day == _day;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' must be on the {_day}th day of the month.";
}
