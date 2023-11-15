using System;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a date is local time.
/// </summary>
public class IsLocalTimeValidator<T> : PropertyValidator<T, DateTime?>
{
    /// <inheritdoc />
    public override string Name => "IsLocalTimeValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, DateTime? value)
        => value?.Kind == DateTimeKind.Local;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be in local time.";
}

