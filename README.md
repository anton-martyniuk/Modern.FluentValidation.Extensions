# FluentValidation.Extensions
A big set of custom validators for popular FluentValidation library for a daily usage

## Installation

[Install a FluentValidation.Extensions nuget package](https://www.nuget.org/packages/FluentValidation.Extensions)

## Features
A list of validators:
- String validators
  - Contains
  - DoesNotContain
  - StartsWith
  - EndsWith
  - DoesNotStartWith
  - DoesNotEndWith
  - LengthBetween
  - BeNumeric
  - BeLatinLetters
  - NoSpecialCharacters
- Boolean validators
  - BeTrue
  - BeFalse
- Collection validators
  - HasElements
  - HasNoElements
  - HasCountOfElements
  - HasElementsMoreThan
  - HasElementsMoreOrEqualThan
  - HasElementsLessThan
  - HasElementsLessOrEqualThan
  - HasElementsBetweenExclusive
  - HasElementsBetweenInclusive
  - HasEvenCountOfElements
  - HasOddCountOfElements
  - IsUnique
  - HasDuplicates
  - NoNullElements
  - AllMatch
  - AnyMatch
  - Contains
  - DoesNotContain
  - AllElementsOfType
- DateTime validators
  - BeInFuture
  - BeInPast
  - BeLeapYear
  - BeWeekday
  - BeWeekend
  - BeSpecificDayOfWeek
  - BeWithinRange
  - BeSpecificMonth
  - BeSpecificDay
  - BeExactTimeOfDay
  - IsUtc
  - IsLocalTime
- URL validators
  - IsAbsoluteUrl
  - IsRelativeUrl

## Example of usage

### String validators

#### Contains
```csharp
RuleFor(x => x.StringValue).Contains("foo");
```

#### DoesNotContain
```csharp
RuleFor(x => x.StringValue).DoesNotContain("foo");
```

#### StartsWith
```csharp
RuleFor(x => x.StringValue).StartsWith("foo");
```

#### EndsWith
```csharp
RuleFor(x => x.StringValue).EndsWith("foo");
```

#### DoesNotStartWith
```csharp
RuleFor(x => x.StringValue).DoesNotStartWith("foo");
```

#### DoesNotEndWith
```csharp
RuleFor(x => x.StringValue).DoesNotEndWith("foo");
```

#### LengthBetween
```csharp
RuleFor(x => x.StringValue).LengthBetween(5, 10);
```

#### BeNumeric
```csharp
RuleFor(x => x.StringValue).BeNumeric();
```

#### BeLatinLetters
```csharp
RuleFor(x => x.StringValue).BeLatinLetters();
```

#### NoSpecialCharacters
```csharp
RuleFor(x => x.StringValue).NoSpecialCharacters();
```

If some special characters are allowed they can be passed inside a string parameter without delimeters:
```csharp
RuleFor(x => x.StringValue).NoSpecialCharacters("_.");
```


### Boolean validators

#### BeTrue
```csharp
RuleFor(x => x.BooleanValue).BeTrue();
```

#### BeFalse
```csharp
RuleFor(x => x.BooleanValue).BeFalse();
```


### Collection validators

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

#### Contains
Validates that a collection contains a specified value.
```csharp
RuleFor(x => x.CollectionProperty).Contains(5);
```

#### DoesNotContain
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

:white_check_mark: **First version of package is scheduled to be released and pushed to Nuget in the early dates of November**

## Acknowledgments

A big shoutout to the original [FluentValidation](https://github.com/FluentValidation/FluentValidation) library and its author for creating such a fantastic library. This package is built upon the foundation laid by the original library, and I am very grateful for the inspiration and the work put into it. Thank you!
