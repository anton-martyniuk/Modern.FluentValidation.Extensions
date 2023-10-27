using System.Linq;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a string does not contain special characters.
/// </summary>
public class NoSpecialCharactersValidator<T> : PropertyValidator<T, string>
{
    private readonly string _allowedChars;

    /// <summary>
    /// Initializes a new instance of the class
    /// </summary>
    /// <param name="allowedChars">Characters that are allowed despite being special characters (specify chars without delimeter)</param>
    public NoSpecialCharactersValidator(string allowedChars = "")
    {
        _allowedChars = allowedChars;
    }

    /// <inheritdoc />
    public override string Name => "NoSpecialCharactersValidator";

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, string value)
        => value.All(c => char.IsLetterOrDigit(c) || _allowedChars.Contains(c));

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must not contain special characters.";
}


