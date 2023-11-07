using System;

// ReSharper disable CheckNamespace
namespace FluentValidation;

/// <summary>
/// A set of registrations for custom validators
/// </summary>
public static class CustomDateValidatorRegistrations
{
    /// <summary>
    /// Defines a 'date is in the future' validator on the current rule builder.
    /// Validation will fail if the date property is not in the future.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, DateTime?> BeInFuture<T>(this IRuleBuilder<T, DateTime?> ruleBuilder)
        => ruleBuilder.SetValidator(new BeInFutureValidator<T>());
    
    /// <summary>
    /// Defines a 'date is in the past' validator on the current rule builder.
    /// Validation will fail if the date property is not in the past.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, DateTime?> BeInPast<T>(this IRuleBuilder<T, DateTime?> ruleBuilder)
        => ruleBuilder.SetValidator(new BeInPastValidator<T>());
    
    /// <summary>
    /// Defines a 'date is in the leap year' validator on the current rule builder.
    /// Validation will fail if the date property is not in the leap year.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, DateTime?> BeLeapYear<T>(this IRuleBuilder<T, DateTime?> ruleBuilder)
        => ruleBuilder.SetValidator(new BeLeapYearValidator<T>());
    
    /// <summary>
    /// Defines a 'date is a weekday' validator on the current rule builder.
    /// Validation will fail if the date property does not fall on a weekday.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, DateTime?> BeWeekday<T>(this IRuleBuilder<T, DateTime?> ruleBuilder)
        => ruleBuilder.SetValidator(new BeWeekdayValidator<T>());

    /// <summary>
    /// Defines a 'date is a weekend day' validator on the current rule builder.
    /// Validation will fail if the date property does not fall on a weekend.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, DateTime?> BeWeekend<T>(this IRuleBuilder<T, DateTime?> ruleBuilder)
        => ruleBuilder.SetValidator(new BeWeekendValidator<T>());
    
    /// <summary>
    /// Defines a 'date is a specific day of the week' validator on the current rule builder.
    /// Validation will fail if the date property does not fall on the specified day of the week.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="dayOfWeek">The expected day of the week.</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, DateTime?> BeSpecificDayOfWeek<T>(this IRuleBuilder<T, DateTime?> ruleBuilder, DayOfWeek dayOfWeek)
        => ruleBuilder.SetValidator(new BeSpecificDayOfWeekValidator<T>(dayOfWeek));

    /// <summary>
    /// Defines a 'date is within a range' validator on the current rule builder.
    /// Validation will fail if the date property does not fall within the specified range of dates.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="startDate">The start date of the range.</param>
    /// <param name="endDate">The end date of the range.</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, DateTime?> BeWithinRange<T>(this IRuleBuilder<T, DateTime?> ruleBuilder, DateTime startDate, DateTime endDate)
        => ruleBuilder.SetValidator(new BeWithinRangeValidator<T>(startDate, endDate));
    
    /// <summary>
    /// Defines a 'date is in a specific month' validator on the current rule builder.
    /// Validation will fail if the date property is not in the specified month.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="month">The expected month.</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, DateTime?> BeSpecificMonth<T>(this IRuleBuilder<T, DateTime?> ruleBuilder, int month)
        => ruleBuilder.SetValidator(new BeSpecificMonthValidator<T>(month));

    /// <summary>
    /// Defines a 'date is on a specific day of the month' validator on the current rule builder.
    /// Validation will fail if the date property is not on the specified day of the month.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="day">The expected day of the month.</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, DateTime?> BeSpecificDay<T>(this IRuleBuilder<T, DateTime?> ruleBuilder, int day)
        => ruleBuilder.SetValidator(new BeSpecificDayValidator<T>(day));
    
    /// <summary>
    /// Defines a 'date has an exact time of day' validator on the current rule builder.
    /// Validation will fail if the date property does not have the specified time of day.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <param name="timeOfDay">The expected time of day.</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, DateTime?> BeExactTimeOfDay<T>(this IRuleBuilder<T, DateTime?> ruleBuilder, TimeSpan timeOfDay)
        => ruleBuilder.SetValidator(new BeExactTimeOfDayValidator<T>(timeOfDay));
    
    /// <summary>
    /// Defines a 'date is UTC' validator on the current rule builder.
    /// Validation will fail if the date property is not in Coordinated Universal Time (UTC).
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns>The rule builder with the 'IsUtc' validator included</returns>
    public static IRuleBuilderOptions<T, DateTime?> IsUtc<T>(this IRuleBuilder<T, DateTime?> ruleBuilder)
        => ruleBuilder.SetValidator(new IsUtcValidator<T>());
    
    /// <summary>
    /// Defines a 'date is local time' validator on the current rule builder.
    /// Validation will fail if the date property is not local time.
    /// </summary>
    /// <typeparam name="T">Type of object being validated</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
    /// <returns>The rule builder with the 'IsLocalTime' validator included</returns>
    public static IRuleBuilderOptions<T, DateTime?> IsLocalTime<T>(this IRuleBuilder<T, DateTime?> ruleBuilder)
        => ruleBuilder.SetValidator(new IsLocalTimeValidator<T>());
}