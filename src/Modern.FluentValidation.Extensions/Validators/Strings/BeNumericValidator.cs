using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a string contains only numbers.
/// </summary>
public class BeNumericValidator<T> : PropertyValidator<T, string>
{
    /// <inheritdoc />
    public override string Name => "BeNumericValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, string? value)
        => int.TryParse(value, out _);

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must contain only numbers.";
}

