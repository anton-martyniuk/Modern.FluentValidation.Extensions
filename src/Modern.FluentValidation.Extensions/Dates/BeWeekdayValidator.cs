using System;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a date falls on a weekday.
/// </summary>
public class BeWeekdayValidator<T> : PropertyValidator<T, DateTime?>
{
    /// <inheritdoc />
    public override string Name => "BeWeekdayValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, DateTime? value)
        => value != DateTime.MinValue && value != DateTime.MaxValue && value is not null
           && value.Value.DayOfWeek is not DayOfWeek.Saturday && value.Value.DayOfWeek is not DayOfWeek.Sunday;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be a weekday.";
}

