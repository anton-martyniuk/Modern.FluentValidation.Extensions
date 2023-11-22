[![Build & Tests](https://github.com/anton-martyniuk/Modern.FluentValidation.Extensions/actions/workflows/tests.yml/badge.svg)](https://github.com/anton-martyniuk/Modern.FluentValidation.Extensions/actions/workflows/tests.yml)


# Modern.FluentValidation.Extensions
A big set of custom validators for popular FluentValidation library for a daily usage

## Installation

[Install a FluentValidation.Extensions nuget package](https://www.nuget.org/packages/Modern.FluentValidation.Extensions)

## Features
A list of validators:
- [String validators](#string-validators)
  - [Contains](#contains)
  - [DoesNotContain](#doesnotcontain)
  - [StartsWith](#startswith)
  - [EndsWith](#endswith)
  - [DoesNotStartWith](#doesnotstartwith)
  - [DoesNotEndWith](#doesnotendwith)
  - [LengthBetween](#lengthbetween)
  - [BeNumeric](#benumeric)
  - [BeLatinLetters](#belatinletters)
  - [NoSpecialCharacters](#nospecialcharacters)
- [Boolean validators](#boolean-validators)
  - [BeTrue](#betrue)
  - [BeFalse](#befalse)
- [Collection validators](#collection-validators)
  - [HasElements](#haselements)
  - [HasNoElements](#hasnoelements)
  - [HasCountOfElements](#hascountofelements)
  - [HasElementsMoreThan](#haselementsmorethan)
  - [HasElementsMoreOrEqualThan](#haselementsmoreorequalthan)
  - [HasElementsLessThan](#haselementslessthan)
  - [HasElementsLessOrEqualThan](#haselementslessorequalthan)
  - [HasElementsBetweenExclusive](#haselementsbetweenexclusive)
  - [HasElementsBetweenInclusive](#haselementsbetweeninclusive)
  - [HasEvenCountOfElements](#hasevencountofelements)
  - [HasOddCountOfElements](#hasoddcountofelements)
  - [IsUnique](#isunique)
  - [HasDuplicates](#hasduplicates)
  - [NoNullElements](#nonullelements)
  - [AllMatch](#allmatch)
  - [AnyMatch](#anymatch)
  - [Contains](#contains-element)
  - [DoesNotContain](#doesnotcontain-element)
  - [AllElementsOfType](#allelementsoftype)
- [DateTime validators](#datetimevalidators)
  - [BeInFuture](#beinfuture)
  - [BeInPast](#beinpast)
  - [BeLeapYear](#beleapyear)
  - [BeWeekday](#beweekday)
  - [BeWeekend](#beweekend)
  - [BeSpecificDayOfWeek](#bespecificdayofweek)
  - [BeWithinRange](#bewithinrange)
  - [BeSpecificMonth](#bespecificmonth)
  - [BeSpecificDay](#bespecificday)
  - [BeExactTimeOfDay](#beexacttimeofday)
  - [IsUtc](#isutc)
  - [IsLocalTime](#islocaltime)
- [URL validators](#url-validators)
  - [IsAbsoluteUrl](#isabsoluteurl)
  - [IsRelativeUrl](#isrelativeurl)

## String validators

#### Contains
Validates that the string contains a specified substring.
```csharp
RuleFor(x => x.StringValue).Contains("foo");
```

#### DoesNotContain
Validates that the string does not contain a specified substring.
```csharp
RuleFor(x => x.StringValue).DoesNotContain("foo");
```

#### StartsWith
Validates that the string starts with a specified substring.
```csharp
RuleFor(x => x.StringValue).StartsWith("foo");
```

#### EndsWith
Validates that the string ends with a specified substring.
```csharp
RuleFor(x => x.StringValue).EndsWith("foo");
```

#### DoesNotStartWith
Validates that the string does not start with a specified substring.
```csharp
RuleFor(x => x.StringValue).DoesNotStartWith("foo");
```

#### DoesNotEndWith
Validates that the string does not end with a specified substring.
```csharp
RuleFor(x => x.StringValue).DoesNotEndWith("foo");
```

#### LengthBetween
Validates that the length of the string is between the specified minimum and maximum.
```csharp
RuleFor(x => x.StringValue).LengthBetween(5, 10);
```

#### BeNumeric
Validates that the string consists only of numeric characters.
```csharp
RuleFor(x => x.StringValue).BeNumeric();
```

#### BeLatinLetters
Validates that the string consists only of Latin letters.
```csharp
RuleFor(x => x.StringValue).BeLatinLetters();
```

#### NoSpecialCharacters
Validates that the string does not contain any special characters.
```csharp
RuleFor(x => x.StringValue).NoSpecialCharacters();
```

If some special characters are allowed they can be passed inside a string parameter without delimeters:
```csharp
RuleFor(x => x.StringValue).NoSpecialCharacters("_.");
```


## Boolean validators

#### BeTrue
Validates that a value equals to true.
```csharp
RuleFor(x => x.BooleanValue).BeTrue();
```

#### BeFalse
Validates that a value equals to false.
```csharp
RuleFor(x => x.BooleanValue).BeFalse();
```


## Collection validators

#### HasElements
Validates that a collection has elements.
```csharp
RuleFor(x => x.CollectionProperty).HasElements();
```

#### HasNoElements
Validates that a collection has no elements.
```csharp
RuleFor(x => x.CollectionProperty).HasNoElements();
```

#### HasCountOfElements
Validates that a collection has a given count of elements.
```csharp
RuleFor(x => x.CollectionProperty).HasCountOfElements(5);
```

#### HasElementsMoreThan
Validates that a collection has more than N elements.
```csharp
RuleFor(x => x.CollectionProperty).HasElementsMoreThan(5);
```

#### HasElementsMoreOrEqualThan
Validates that a collection has equal or more than N elements.
```csharp
RuleFor(x => x.CollectionProperty).HasElementsMoreOrEqualThan(5);
```

#### HasElementsLessThan
Validates that a collection has less than N elements.
```csharp
RuleFor(x => x.CollectionProperty).HasElementsLessThan(5);
```

#### HasElementsLessOrEqualThan
Validates that a collection has equal or less than N elements.
```csharp
RuleFor(x => x.CollectionProperty).HasElementsLessOrEqualThan(5);
```

#### HasElementsBetweenExclusive
Validates that a collection has count of elements between N and M exclusively.
```csharp
RuleFor(x => x.CollectionProperty).HasElementsBetweenExclusive(5, 10);
```

#### HasElementsBetweenInclusive
Validates that a collection has count of elements between N and M inclusively..
```csharp
RuleFor(x => x.CollectionProperty).HasElementsBetweenInclusive(5, 10);
```

#### HasEvenCountOfElements
Validates that a collection has an even count of elements.
```csharp
RuleFor(x => x.CollectionProperty).HasEvenCountOfElements();
```

#### HasOddCountOfElements
Validates that a collection has an odd count of elements.
```csharp
RuleFor(x => x.CollectionProperty).HasOddCountOfElements();
```

#### IsUnique
Validates that a collection has all unique elements.
```csharp
RuleFor(x => x.CollectionProperty).IsUnique();
```

#### HasDuplicates
Validates that a collection has at least one duplicate element.
```csharp
RuleFor(x => x.CollectionProperty).HasDuplicates();
```

#### NoNullElements
Validates that a collection doesn't have null elements.\
NOTE: this method treats default values of objects as null elements, like 0 for numbers and false for boolean
```csharp
RuleFor(x => x.CollectionProperty).NoNullElements(5;
```

#### AllMatch
Validates that all elements of collection match the specified condition.
```csharp
RuleFor(x => x.Persons).AllMatch(x => x.Age > 18);
```

#### AnyMatch
Validates that any element of collection matches the specified condition.
```csharp
RuleFor(x => x.Persons).AnyMatch(x => x.Age > 18);
```

#### Contains element
Validates that a collection contains a specified value.
```csharp
RuleFor(x => x.CollectionProperty).Contains(5);
```

#### DoesNotContain element
Validates that a collection has doesn't contain a specified value.
```csharp
RuleFor(x => x.CollectionProperty).DoesNotContain(5);
```

#### AllElementsOfType
Validates that a collection has all objects of the specified type.
```csharp
public class TestClass
{
  public List<object> ObjectItems { get; set; } = new();
}

RuleFor(x => x.ObjectItems).AllElementsOfType(typeof(string));
```

## DateTime validators

#### BeInFuture
Validates that the date is in the future.
```csharp
RuleFor(x => x.DateValue).BeInFuture();
```

#### BeInPast
Validates that the date is in the past.
```csharp
RuleFor(x => x.DateValue).BeInPast();
```

#### BeLeapYear
Validates that the date is within a leap year.
```csharp
RuleFor(x => x.DateValue).BeLeapYear();
```

#### BeWeekday
Validates that the date falls on a weekday.
```csharp
RuleFor(x => x.DateValue).BeWeekday();
```

#### BeWeekend
Validates that the date falls on a weekend.
```csharp
RuleFor(x => x.DateValue).BeWeekend();
```

#### BeSpecificDayOfWeek
Validates that the date falls on a specified day of the week.
```csharp
RuleFor(x => x.DateValue).BeSpecificDayOfWeek(DayOfWeek.Monday);
```

#### BeWithinRange
Validates that the date is within a specified range.
```csharp
RuleFor(x => x.DateValue).BeWithinRange(startDate, endDate);
```

#### BeSpecificMonth
Validates that the date is in a specific month.
```csharp
RuleFor(x => x.DateValue).BeSpecificMonth(month);
```
#### BeSpecificDay
Validates that the date is on a specific day of the month.
```csharp
RuleFor(x => x.DateValue).BeSpecificDay(day);
```

#### BeExactTimeOfDay
Validates that the date has an exact time of day.
```csharp
RuleFor(x => x.DateValue).BeExactTimeOfDay(new TimeSpan(hour, minute, second));
```

#### IsUtc
Validates that the date is in UTC.
```csharp
RuleFor(x => x.DateValue).IsUtc();
```

#### IsLocalTime
Validates that the date is local time.
```csharp
RuleFor(x => x.DateValue).IsLocalTime();
```

## URL validators

#### IsAbsoluteUrl
Validates that the string is a valid absolute URL.
```csharp
RuleFor(x => x.UrlValue).IsAbsoluteUrl();
```

#### IsRelativeUrl
Validates that the string is a valid relative URL.
```csharp
RuleFor(x => x.UrlValue).IsRelativeUrl();
```

## Acknowledgments

A big shoutout to the original [FluentValidation](https://github.com/FluentValidation/FluentValidation) library and its author for creating such a fantastic library. This package is built upon the foundation laid by the original library, and I am very grateful for the inspiration and the work put into it. Thank you!

## Support My Work :star2:

If you find this package helpful, consider supporting my work by buying me a coffee :coffee:!\
Your support is greatly appreciated and helps me continue developing and maintaining this project.\
You can also give me a :star: on github to make my package more relevant to others.

[![Buy me a coffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/antonmartyniuk)

Thank you for your support!
