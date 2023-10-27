using System.Linq;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a string contains only Latin letters.
/// </summary>
public class BeLatinLettersValidator<T> : PropertyValidator<T, string>
{
    /// <inheritdoc />
    public override string Name => "BeLatinLettersValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, string value)
        => value.All(c => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z');

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must contain only Latin letters.";
}

