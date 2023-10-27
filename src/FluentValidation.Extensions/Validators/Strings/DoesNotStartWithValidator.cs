using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a string does not start with a specified substring.
/// </summary>
public class DoesNotStartWithValidator<T> : PropertyValidator<T, string?>
{
    private readonly string _unexpectedStart;

    /// <inheritdoc />
    public override string Name => "DoesNotStartWithValidator";

    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    /// <param name="unexpectedStart">The substring that should not be at the start.</param>
    public DoesNotStartWithValidator(string unexpectedStart)
    {
        _unexpectedStart = unexpectedStart;
    }

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, string? value)
        => value?.StartsWith(_unexpectedStart) == false;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must not start with the specified substring.";
}
