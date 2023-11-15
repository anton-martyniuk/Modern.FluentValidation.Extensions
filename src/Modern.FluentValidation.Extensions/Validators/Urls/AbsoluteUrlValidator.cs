using System;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a string is a valid absolute URL
/// </summary>
public class AbsoluteUrlValidator<T> : PropertyValidator<T, string>
{
    /// <summary>
    /// <inheritdoc />
    /// </summary>
    public override string Name => "AbsoluteUrlValidator";

    /// <summary>
    /// <inheritdoc />
    /// </summary>
    public override bool IsValid(ValidationContext<T> context, string value)
        => !string.IsNullOrWhiteSpace(value) && Uri.TryCreate(value, UriKind.Absolute, out _);
    
    /// <summary>
    /// <inheritdoc />
    /// </summary>
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be an absolute URL.";
}