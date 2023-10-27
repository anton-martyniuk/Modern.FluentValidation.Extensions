using System;
using System.Collections.Generic;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// A set of registrations for custom validators
/// </summary>
public static class CustomCollectionValidatorRegistrations
{
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
    /// <param name="count">Count of elements.<br/>Collection must have count of elements more than the specified number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasCountOfElements<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int count)
        => ruleBuilder.SetValidator(new HasCountOfElementsValidator<T, TElement>(count));
    
    /// <summary>
    /// Defines a 'has more than N elements' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have more than N elements.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="count">Count of elements.<br/>Collection must have count of elements more than the specified number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasElementsMoreThan<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int count)
        => ruleBuilder.SetValidator(new HasElementsMoreThanValidator<T, TElement>(count));
    
    /// <summary>
    /// Defines a 'has equal or more than N elements' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have equal or more than N elements.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="count">Count of elements.<br/>Collection must have count of elements equal or more than the specified number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasElementsMoreOrEqualThan<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int count)
        => ruleBuilder.SetValidator(new HasElementsMoreOrEqualThanValidator<T, TElement>(count));
    
    /// <summary>
    /// Defines a 'has less than N elements' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have less than N elements.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="count">Count of elements.<br/>Collection must have count of elements less than the specified number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasElementsLessThan<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int count)
        => ruleBuilder.SetValidator(new HasElementsLessThanValidator<T, TElement>(count));
    
    /// <summary>
    /// Defines a 'has equal or less than N elements' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have equal or less than N elements.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="count">Count of elements.<br/>Collection must have count of elements equal or less than the specified number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasElementsLessOrEqualThan<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int count)
        => ruleBuilder.SetValidator(new HasElementsLessOrEqualThanValidator<T, TElement>(count));
    
    /// <summary>
    /// Defines a 'has count of elements between N and M exclusively' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have count of elements between N and M exclusively.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="countFrom">Count of elements.<br/>Collection must have count of elements more than the specified number</param>
    /// <param name="countTo">Count of elements.<br/>Collection must have count of elements less than the specified number</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasElementsBetweenExclusive<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, int countFrom, int countTo)
        => ruleBuilder.SetValidator(new HasElementsBetweenExclusiveValidator<T, TElement>(countFrom, countTo));
    
    /// <summary>
    /// Defines a 'has count of elements between N and M inclusively' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have count of elements between N and M inclusively.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="countFrom">Count of elements.<br/>Collection must have count of elements more than the specified number</param>
    /// <param name="countTo">Count of elements.<br/>Collection must have count of elements less than the specified number</param>
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
    
    /// <summary>
    /// Defines a 'has all unique elements' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have all unique elements.<br/>
    /// NOTE: this method only works on collection that have standard primitive values like int, decimal, char, bool, string, etc.<br/>
    /// This method doesn't work on collections of objects
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> IsUnique<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder)
        => ruleBuilder.SetValidator(new IsUniqueValidator<T,TElement>());
    
    /// <summary>
    /// Defines a 'has any duplicate element' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have at least one duplicate element.<br/>
    /// NOTE: this method only works on collection that have standard primitive values like int, decimal, char, bool, string, etc.<br/>
    /// This method doesn't work on collections of objects
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> HasDuplicate<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder)
        => ruleBuilder.SetValidator(new HasDuplicatesValidator<T, TElement>());
    
    /// <summary>
    /// Defines a 'has no null elements' validator on the current rule builder.
    /// Validation will fail if the collection property has at least one null element.<br/>
    /// NOTE: this method treats default values of objects as null elements, like 0 for numbers and false for boolean
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> NoNullElements<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder)
        => ruleBuilder.SetValidator(new NoNullElementsValidator<T,TElement>());
    
    /// <summary>
    /// Defines a 'has all elements that match condition' validator on the current rule builder.
    /// Validation will fail if the collection property have at least one element that doesn't match the specified condition.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="predicate">A predicate to test a collection against</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> AllMatch<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, Predicate<TElement> predicate)
        => ruleBuilder.SetValidator(new AllMatchValidator<T, TElement>(predicate));
    
    /// <summary>
    /// Defines a 'has any element that matches condition' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have any element that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="predicate">A predicate to test a collection against</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> AnyMatch<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, Predicate<TElement> predicate)
        => ruleBuilder.SetValidator(new AnyMatchValidator<T, TElement>(predicate));

    /// <summary>
    /// Defines a 'contains element' validator on the current rule builder.
    /// Validation will fail if the collection property doesn't have contain the specified element.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="expectedValue">A value that should be checked for existence in the collection</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> Contains<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, TElement expectedValue)
        => ruleBuilder.SetValidator(new ContainsElementValidator<T,TElement>(expectedValue));
    
    /// <summary>
    /// Defines a 'does not contain element' validator on the current rule builder.
    /// Validation will fail if the collection property contains the specified element.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="expectedValue">A value that should be checked for existence in the collection</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> DoesNotContain<T, TElement>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder, TElement expectedValue)
        => ruleBuilder.SetValidator(new DoesNotContainElementValidator<T, TElement>(expectedValue));

    /// <summary>
    /// Defines a 'all elements of type' validator on the current rule builder.
    /// Validation will fail if the collection property elements have different type.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <typeparam name="TElement">Type of collection elements</typeparam>
    /// <typeparam name="TDesiredType">The type of elements that the collection should have</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, IEnumerable<TElement>> AllElementsOfType<T, TElement, TDesiredType>(this IRuleBuilder<T, IEnumerable<TElement>> ruleBuilder)
        => ruleBuilder.SetValidator(new AllElementsOfTypeValidator<T, TElement, TDesiredType>());
}