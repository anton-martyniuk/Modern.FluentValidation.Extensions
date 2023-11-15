using System;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a date is in the future.
/// </summary>
public class BeInFutureValidator<T> : PropertyValidator<T, DateTime?>
{
    /// <inheritdoc />
    public override string Name => "BeInFutureValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, DateTime? value)
        => value is not null && value > DateTime.Now;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be in the future.";
}

