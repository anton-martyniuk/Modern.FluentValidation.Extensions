// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// A set of registrations for custom validators
/// </summary>
public static class CustomStringValidatorRegistrations
{
    /// <summary>
    /// Defines a 'string starts with' validator on the current rule builder.
    /// Validation will fail if the string property doesn't start with a specified value.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="expectedStart">The expected starting substring.</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> StartsWith<T>(this IRuleBuilder<T, string> ruleBuilder, string expectedStart)
        => ruleBuilder.SetValidator(new StartsWithValidator<T>(expectedStart));
    
    /// <summary>
    /// Defines a 'string ends with' validator on the current rule builder.
    /// Validation will fail if the string property doesn't end with a specified value.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="expectedEnd">The expected ending substring.</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> EndsWith<T>(this IRuleBuilder<T, string> ruleBuilder, string expectedEnd)
        => ruleBuilder.SetValidator(new EndsWithValidator<T>(expectedEnd));
    
    /// <summary>
    /// Defines a 'string doesn't start with' validator on the current rule builder.
    /// Validation will fail if the string property starts with a specified value.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="unexpectedStart">The substring that should not be at the start.</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> DoesNotStartWith<T>(this IRuleBuilder<T, string> ruleBuilder, string unexpectedStart)
        => ruleBuilder.SetValidator(new DoesNotStartWithValidator<T>(unexpectedStart));
    
    /// <summary>
    /// Defines a 'string doesn't end with' validator on the current rule builder.
    /// Validation will fail if the string property ends with a specified value.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="unexpectedEnd">The substring that should not be at the end.</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> DoesNotEndWith<T>(this IRuleBuilder<T, string> ruleBuilder, string unexpectedEnd)
        => ruleBuilder.SetValidator(new DoesNotEndWithValidator<T>(unexpectedEnd));
    
    /// <summary>
    /// Defines a 'string contains' validator on the current rule builder.
    /// Validation will fail if the string property doesn't contain a specified value.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="expectedSubstring">The expected substring that should be present.</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> Contains<T>(this IRuleBuilder<T, string> ruleBuilder, string expectedSubstring)
        => ruleBuilder.SetValidator(new ContainsValidator<T>(expectedSubstring));
    
    /// <summary>
    /// Defines a 'string doesn't contain' validator on the current rule builder.
    /// Validation will fail if the string property contains a specified value.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="unexpectedSubstring">The substring that should not be present.</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> DoesNotContain<T>(this IRuleBuilder<T, string> ruleBuilder, string unexpectedSubstring)
        => ruleBuilder.SetValidator(new DoesNotContainValidator<T>(unexpectedSubstring));
    
    /// <summary>
    /// Defines a 'length between inclusive' validator on the current rule builder.
    /// Validation will fail if the string property's length is not between the specified minimum and maximum lengths.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="minLength">The minimum length</param>
    /// <param name="maxLength">The maximum length</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> LengthBetween<T>(this IRuleBuilder<T, string> ruleBuilder, int minLength, int maxLength)
        => ruleBuilder.SetValidator(new LengthBetweenValidator<T>(minLength, maxLength));
    
    /// <summary>
    /// Defines a 'be numeric' validator on the current rule builder.
    /// Validation will fail if the string property doesn't contain only numbers.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> BeNumeric<T>(this IRuleBuilder<T, string> ruleBuilder)
        => ruleBuilder.SetValidator(new BeNumericValidator<T>());

    /// <summary>
    /// Defines a 'be latin letters' validator on the current rule builder.
    /// Validation will fail if the string property doesn't contain only Latin letters.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> BeLatinLetters<T>(this IRuleBuilder<T, string> ruleBuilder)
        => ruleBuilder.SetValidator(new BeLatinLettersValidator<T>());

    /// <summary>
    /// Defines a 'no special characters' validator on the current rule builder.
    /// Validation will fail if the string property contains any characters that aren't alphanumeric, with an exception for optionally allowed characters.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="allowedChars">Characters that are allowed despite being special characters. Default is none.</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> NoSpecialCharacters<T>(this IRuleBuilder<T, string> ruleBuilder, string allowedChars = "")
        => ruleBuilder.SetValidator(new NoSpecialCharactersValidator<T>(allowedChars));
}