using System;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a date falls within a leap year.
/// </summary>
public class BeLeapYearValidator<T> : PropertyValidator<T, DateTime?>
{
    /// <inheritdoc />
    public override string Name => "BeLeapYearValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, DateTime? value)
        => value is not null && DateTime.IsLeapYear(value.Value.Year);

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be in a leap year.";
}
