using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a string does not end with a specified substring.
/// </summary>
public class DoesNotEndWithValidator<T> : PropertyValidator<T, string?>
{
    private readonly string _unexpectedEnd;

    /// <inheritdoc />
    public override string Name => "DoesNotEndWithValidator";

    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    /// <param name="unexpectedEnd">The substring that should not be at the end.</param>
    public DoesNotEndWithValidator(string unexpectedEnd)
    {
        _unexpectedEnd = unexpectedEnd;
    }

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, string? value)
        => value?.EndsWith(_unexpectedEnd) != true;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' must not end with the '{_unexpectedEnd}' substring.";
}
