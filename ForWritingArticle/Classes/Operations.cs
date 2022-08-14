﻿using System;
using System.Collections.Generic;
using Bogus;
using ForWritingArticle.LanguageExtensions;
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

        public static void PeopleDeconstruct()
        {
            var list = PeopleList();

            foreach (Person person in list)
            {
                var (id, fullName) = person;
                Console.WriteLine($"{id,-4}{fullName}");
            }

        }
    }
}
