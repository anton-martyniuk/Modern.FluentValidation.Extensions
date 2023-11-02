using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a string has a length between two integer values.
/// </summary>
public class LengthBetweenValidator<T> : PropertyValidator<T, string>
{
    private readonly int _minLength;
    private readonly int _maxLength;

    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="minLength">The minimum length</param>
    /// <param name="maxLength">The maximum length</param>
    public LengthBetweenValidator(int minLength, int maxLength)
    {
        _minLength = minLength;
        _maxLength = maxLength;
    }

    /// <inheritdoc />
    public override string Name => "LengthBetweenValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, string? value)
        => value?.Length >= _minLength && value?.Length <= _maxLength;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => $"'{{PropertyName}}' must have a length between {_minLength} and {_maxLength}.";
}

