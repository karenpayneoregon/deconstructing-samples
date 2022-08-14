using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Person = ForWritingArticle.Models.Person;

namespace ForWritingArticle.Classes
{
    public class Operations
    {
        public static List<Person> PeopleList(int count = 5)
        {
            var faker = new Faker<Person>()
                .WithRecord()
                .RuleFor(p => p.Id, f => f.IndexVariable++)
                .RuleFor(p => p.Lastname, f => f.Person.LastName)
                .RuleFor(p => p.Firstname, f => f.Person.FirstName);

            return faker.Generate(count);
        }
    }

    public static class ExtensionsForBogus
    {
        public static Faker<T> WithRecord<T>(this Faker<T> faker) where T : class
        {
            faker.CustomInstantiator(_ => FormatterServices.GetUninitializedObject(typeof(T)) as T);
            return faker;
        }
    }
}
