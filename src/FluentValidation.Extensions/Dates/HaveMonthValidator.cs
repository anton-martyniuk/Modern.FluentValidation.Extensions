using System;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a date falls within a specific month.
/// </summary>
public class HaveMonthValidator<T> : PropertyValidator<T, DateTime>
{
    private readonly int _month;

    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="month">The expected month.</param>
    public HaveMonthValidator(int month)
    {
        _month = month;
    }

    /// <inheritdoc />
    public override string Name => "HaveMonthValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, DateTime value)
        => value.Month == _month;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' must be in month {_month}.";
}
