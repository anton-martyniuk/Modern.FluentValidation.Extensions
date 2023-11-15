using System.Text.RegularExpressions;
using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a string is a valid relative URL
/// </summary>
public class RelativeUrlValidator<T> : PropertyValidator<T, string>
{
    private static readonly Regex RelativeUrlPattern = new(@"^(?!www\.|(?:http|ftp)s?://|[A-Za-z]:\\|//).*$", RegexOptions.Compiled);
    
    /// <summary>
    /// <inheritdoc />
    /// </summary>
    public override string Name => "RelativeUrlValidator";

    /// <summary>
    /// <inheritdoc />
    /// </summary>
    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        return RelativeUrlPattern.IsMatch(value);
    }

    /// <summary>
    /// <inheritdoc />
    /// </summary>
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must be a relative URL.";
}