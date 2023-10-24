using System.Collections.Generic;

namespace FluentValidation.Extensions;

/// <summary>
/// A set of registrations for custom validators
/// </summary>
public static class CustomValidatorRegistrator
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
    
    /// <summary>
    /// Defines a 'no elements' validator on the current rule builder.
    /// Validation will fail if the collection property has any elements.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasNoElements<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder)
        => ruleBuilder.SetValidator(new HasNoElementsValidator<T, TElement>());
    
    /// <summary>
    /// Defines a 'has elements' validator on the current rule builder.
    /// Validation will fail if the collection property does not have any elements.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasElements<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder)
        => ruleBuilder.SetValidator(new HasElementsValidator<T, TElement>());
    
    /// <summary>
    /// Defines a 'has count of N elements' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have count of elements equal to N.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="count">Count of elements.<br/>Collection must have count of elements more than the given number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasCountOfElements<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int count)
        => ruleBuilder.SetValidator(new HasCountOfElementsValidator<T, TElement>(count));
    
    /// <summary>
    /// Defines a 'has more than N elements' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have more than N elements.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="count">Count of elements.<br/>Collection must have count of elements more than the given number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasElementsMoreThan<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int count)
        => ruleBuilder.SetValidator(new HasElementsMoreThanValidator<T, TElement>(count));
    
    /// <summary>
    /// Defines a 'has equal or more than N elements' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have equal or more than N elements.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="count">Count of elements.<br/>Collection must have count of elements equal or more than the given number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasElementsMoreOrEqualThan<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int count)
        => ruleBuilder.SetValidator(new HasElementsMoreOrEqualThanValidator<T, TElement>(count));
    
    /// <summary>
    /// Defines a 'has less than N elements' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have less than N elements.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="count">Count of elements.<br/>Collection must have count of elements less than the given number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasElementsLessThan<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int count)
        => ruleBuilder.SetValidator(new HasElementsLessThanValidator<T, TElement>(count));
    
    /// <summary>
    /// Defines a 'has equal or less than N elements' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have equal or less than N elements.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="count">Count of elements.<br/>Collection must have count of elements equal or less than the given number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasElementsLessOrEqualThan<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int count)
        => ruleBuilder.SetValidator(new HasElementsLessOrEqualThanValidator<T, TElement>(count));
    
    /// <summary>
    /// Defines a 'has count of elements between N and M exclusively' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have count of elements between N and M exclusively.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="countFrom">Count of elements.<br/>Collection must have count of elements more than the given number</param>
    /// <param name="countTo">Count of elements.<br/>Collection must have count of elements less than the given number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasElementsBetweenExclusive<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int countFrom, int countTo)
        => ruleBuilder.SetValidator(new HasElementsBetweenExclusiveValidator<T, TElement>(countFrom, countTo));
    
    /// <summary>
    /// Defines a 'has count of elements between N and M inclusively' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have count of elements between N and M inclusively.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="countFrom">Count of elements.<br/>Collection must have count of elements more than the given number</param>
    /// <param name="countTo">Count of elements.<br/>Collection must have count of elements less than the given number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasElementsBetweenInclusive<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int countFrom, int countTo)
        => ruleBuilder.SetValidator(new HasElementsBetweenInclusiveValidator<T, TElement>(countFrom, countTo));
    
    /// <summary>
    /// Defines a 'has even count of elements' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have even count of elements.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasEvenCountOfElements<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder)
        => ruleBuilder.SetValidator(new HasEvenCountOfElementsValidator<T,TElement>());
    
    /// <summary>
    /// Defines a 'has odd count of elements' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have odd count of elements.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasOddCountOfElements<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder)
        => ruleBuilder.SetValidator(new HasOddCountOfElementsValidator<T,TElement>());
    
    // TODO: add string validators: StartWith, EndsWith, etc
    
    // TODO: add other advanced collection validators
}