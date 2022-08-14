using System;
using System.Collections.Generic;
using Bogus;
using ForWritingArticle.LanguageExtensions;
using static System.DateTime;
using Person = ForWritingArticle.Models.Person;

namespace ForWritingArticle.Classes
{
    public class Operations
    {
        /// <summary>
        /// Uses Bogus NuGet package to create fake records
        /// </summary>
        /// <param name="count">How many records to create, defaults to 5</param>
        /// <returns>List of Person</returns>
        public static List<Person> PeopleList(int count = 5)
        {
            var faker = new Faker<Person>()
                .ForRecord()
                .RuleFor(p => p.Id, f => f.IndexVariable++)
                .RuleFor(p => p.Lastname, f => f.Person.LastName)
                .RuleFor(p => p.Firstname, f => f.Person.FirstName);

            return faker.Generate(count);

        }

        /// <summary>
        /// Deconstruct <see cref="PeopleList"/>
        /// </summary>
        public static void PeopleDeconstruct()
        {
            var list = PeopleList();

            foreach (Person person in list)
            {
                var (id, fullName) = person;
                Console.WriteLine($"{id,-4}{fullName}");
            }

        }

        public static void DeconstructDateTimeOffset()
        {
            var date = new DateTimeOffset(Now.Year, Now.Month, Now.Day, 0, 0, 0, 0, TimeSpan.Zero);

            date.Deconstruct(out int day, out int month, out int year);

            Console.WriteLine($"Year: {year} Month: {month} Day: {day}");
        }

        public static void BreakOutDateParts()
        {
            var date = new DateTimeOffset(Now.Year, Now.Month, Now.Day, 0, 0, 0, 0, TimeSpan.Zero);
            int year = date.Year;
            Console.WriteLine($"Year: {date.Year} Month: {date.Month} Day: {date.Day}");
        }
    }
}
