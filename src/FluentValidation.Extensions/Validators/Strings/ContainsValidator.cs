using FluentValidation.Validators;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// Represents a validator that validates if a string contains a specified substring.
/// </summary>
public class ContainsValidator<T> : PropertyValidator<T, string?>
{
    private readonly string _expectedSubstring;

    /// <inheritdoc />
    public override string Name => "ContainsValidator";

    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    /// <param name="expectedSubstring">The expected substring that should be present.</param>
    public ContainsValidator(string expectedSubstring)
    {
        _expectedSubstring = expectedSubstring;
    }

    /// <inheritdoc />
    public override bool IsValid(ValidationContext<T> context, string? value)
        => value?.Contains(_expectedSubstring) == true;

    /// <inheritdoc />
    protected override string GetDefaultMessageTemplate(string errorCode)
        => "'{PropertyName}' must contain the specified substring.";
}
