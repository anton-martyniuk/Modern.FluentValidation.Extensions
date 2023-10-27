using System;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a date has an exact specified time of day.
/// </summary>
public class BeExactTimeOfDayValidator<T> : PropertyValidator<T, DateTime>
{
    private readonly TimeSpan _timeOfDay;

    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="timeOfDay">The expected time of day represented as TimeSpan</param>
    public BeExactTimeOfDayValidator(TimeSpan timeOfDay)
    {
        _timeOfDay = timeOfDay;
    }

    /// <inheritdoc />
    public override string Name => "BeExactTimeOfDayValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, DateTime value)
        => value.TimeOfDay == _timeOfDay;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' must have the exact time of {_timeOfDay}.";
}
