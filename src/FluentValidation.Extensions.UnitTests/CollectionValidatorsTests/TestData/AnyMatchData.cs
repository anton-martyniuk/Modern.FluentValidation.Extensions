using FluentValidation.Extensions.UnitTests.Common;

namespace FluentValidation.Extensions.UnitTests.CollectionValidatorsTests.TestData;

internal class AnyMatchData : TheoryData<List<Person>, Predicate<Person>, bool>
{
    public AnyMatchData()
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
        }, x => x.Age > 18, true);
        
        Add(new List<Person>
        {
            new()
            {
                Name = "Anton",
                Age = 10
            },
            new()
            {
                Name = "John",
                Age = 10
            }
        }, x => x.Age > 18, false);
    }
}