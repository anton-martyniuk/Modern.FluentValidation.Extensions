

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// A set of registrations for custom validators
/// </summary>
public static class CustomUrlValidatorRegistrations
{
    /// <summary>
    /// Defines a 'is absolute URL' validator on the current rule builder.
    /// Validation will fail if the property is not a valid absolute URL (for example, https://google.com is a valid absolute URL)
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> IsAbsoluteUrl<T>(this IRuleBuilder<T, string> ruleBuilder)
        => ruleBuilder.SetValidator(new AbsoluteUrlValidator<T>());

    /// <summary>
    /// Defines a 'is relative URL' validator on the current rule builder.
    /// Validation will fail if the property is not a valid relative URL (for example, /api/users/1 is a valid relative URL)
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> IsRelativeUrl<T>(this IRuleBuilder<T, string> ruleBuilder)
        => ruleBuilder.SetValidator(new RelativeUrlValidator<T>());
}