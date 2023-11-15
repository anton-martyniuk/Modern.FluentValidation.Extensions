using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a boolean is false.
/// </summary>
public class BeFalseValidator<T> : PropertyValidator<T, bool>
{
    /// <inheritdoc />
    public override string Name => "BeFalseValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, bool value)
        => !value;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be false.";
}

