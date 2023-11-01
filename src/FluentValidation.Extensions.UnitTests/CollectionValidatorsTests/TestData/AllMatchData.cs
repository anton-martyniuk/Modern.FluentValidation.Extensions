using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class AllMatchData : TheoryData<List<Person>, Predicate<Person>, bool>
{
    public AllMatchData()
    {
        Add(null!, x => x.Age > 18, false);
        Add(new List<Person>(), x => x.Age > 18, false);
        
        Add(new List<Person>
        {
            new()
            {
                Name = "Anton",
                Age = 18
            }
        }, x => x.Age > 18, false);
        
        Add(new List<Person>
        {
            new()
            {
                Name = "Anton",
                Age = 30
            }
        }, x => x.Age > 18, true);
        
        Add(new List<Person>
        {
            new()
            {
                Name = "Anton",
                Age = 30
            },
            new()
            {
                Name = "John",
                Age = 18
            }
        }, x => x.Age > 18, false);
        
        Add(new List<Person>
        {
            new()
            {
                Name = "Anton",
                Age = 30
            },
            new()
            {
                Name = "John",
                Age = 20
            }
        }, x => x.Age > 18, true);
    }
}