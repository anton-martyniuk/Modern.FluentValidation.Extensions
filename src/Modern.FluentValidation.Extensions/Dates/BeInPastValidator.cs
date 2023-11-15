using System;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a date is in the past.
/// </summary>
public class BeInPastValidator<T> : PropertyValidator<T, DateTime?>
{
    /// <inheritdoc />
    public override string Name => "BeInPastValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, DateTime? value)
        => value is not null && value < DateTime.Now;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be in the past.";
}

