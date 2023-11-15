

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// A set of registrations for custom validators
/// </summary>
public static class CustomBooleanValidatorRegistrations
{
    /// <summary>
    /// Defines a 'be true' validator on the current rule builder.
    /// Validation will fail if the boolean property is not true.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, bool> BeTrue<T>(this IRuleBuilder<T, bool> ruleBuilder)
        => ruleBuilder.SetValidator(new BeTrueValidator<T>());
    
    /// <summary>
    /// Defines a 'be false' validator on the current rule builder.
    /// Validation will fail if the boolean property is not false.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, bool> BeFalse<T>(this IRuleBuilder<T, bool> ruleBuilder)
        => ruleBuilder.SetValidator(new BeFalseValidator<T>());
}