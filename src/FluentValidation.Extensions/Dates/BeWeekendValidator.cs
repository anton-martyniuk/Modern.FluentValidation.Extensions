using System;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a date falls on a weekend.
/// </summary>
public class BeWeekendValidator<T> : PropertyValidator<T, DateTime>
{
    /// <inheritdoc />
    public override string Name => "BeWeekendValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, DateTime value)
        => value.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be a weekend day.";
}

