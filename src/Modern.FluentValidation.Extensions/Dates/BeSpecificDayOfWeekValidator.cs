using System;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a date falls on a specified day of the week.
/// </summary>
public class BeSpecificDayOfWeekValidator<T> : PropertyValidator<T, DateTime?>
{
    private readonly DayOfWeek _dayOfWeek;

    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="dayOfWeek">The expected day of the week.</param>
    public BeSpecificDayOfWeekValidator(DayOfWeek dayOfWeek)
    {
        _dayOfWeek = dayOfWeek;
    }

    /// <inheritdoc />
    public override string Name => "BeSpecificDayOfWeekValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, DateTime? value)
        => value != DateTime.MinValue && value != DateTime.MaxValue && value?.DayOfWeek == _dayOfWeek;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' must be a {_dayOfWeek} day.";
}
