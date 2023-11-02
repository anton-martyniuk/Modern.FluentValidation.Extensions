using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a string starts with a specified substring.
/// </summary>
public class StartsWithValidator<T> : PropertyValidator<T, string?>
{
    private readonly string _expectedStart;

    /// <inheritdoc />
    public override string Name => "StartsWithValidator";

    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    /// <param name="expectedStart">The expected starting substring.</param>
    public StartsWithValidator(string expectedStart)
    {
        _expectedStart = expectedStart;
    }

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, string? value)
        => value?.StartsWith(_expectedStart) == true;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' must start with the '{_expectedStart}' substring.";
}
