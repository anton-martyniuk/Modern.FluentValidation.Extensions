using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a string does not contain a specified substring.
/// </summary>
public class DoesNotContainValidator<T> : PropertyValidator<T, string?>
{
    private readonly string _unexpectedSubstring;

    /// <inheritdoc />
    public override string Name => "DoesNotContainValidator";

    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    /// <param name="unexpectedSubstring">The substring that should not be present.</param>
    public DoesNotContainValidator(string unexpectedSubstring)
    {
        _unexpectedSubstring = unexpectedSubstring;
    }

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, string? value)
        => value?.Contains(_unexpectedSubstring) != true;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' must not contain the '{_unexpectedSubstring}' substring.";
}
