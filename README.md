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

Extension methods provide deconstruction from 1 to 9 generic parameters, that corresponds to OneOf's count of generic parameters.

## Example of usage

:white_check_mark: **First version of package is scheduled to be released and pushed to Nuget in the early dates of November**

## Acknowledgments

A big shoutout to the original [FluentValidation](https://github.com/FluentValidation/FluentValidation) library and its author for creating such a fantastic library. This package is built upon the foundation laid by the original library, and I am very grateful for the inspiration and the work put into it. Thank you!
