using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a string ends with a specified substring.
/// </summary>
public class EndsWithValidator<T> : PropertyValidator<T, string?>
{
    private readonly string _expectedEnd;

    /// <inheritdoc />
    public override string Name => "EndsWithValidator";

    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    /// <param name="expectedEnd">The expected ending substring.</param>
    public EndsWithValidator(string expectedEnd)
    {
        _expectedEnd = expectedEnd;
    }

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, string? value)
        => value?.EndsWith(_expectedEnd) == true;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must end with the specified substring.";
}
