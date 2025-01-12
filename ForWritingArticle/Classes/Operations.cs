using System.Collections.ObjectModel;
using Bogus;
using ForWritingArticle.LanguageExtensions;
using static System.DateTime;
using Person = ForWritingArticle.Models.Person;
// ReSharper disable RedundantAssignment

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


            var date = new DateTimeOffset(Now.Year, Now.Month, Now.Day, 0, 0, 0, 0, new TimeSpan(-7, 0, 0));

            var (day, month, year, offset) = date;

            Console.WriteLine($"{month}/{day}/{year} {offset}");

            var test = TimeZoneInfo.ConvertTimeToUtc(date.DateTime, TimeZoneInfo.Local);

            ShowPossibleTimeZones(date);
        }

        private static void ShowPossibleTimeZones(DateTimeOffset offsetTime)
        {
            TimeSpan offset = offsetTime.Offset;
            Console.WriteLine("{0} could belong to the following time zones:", offsetTime.ToString());
            ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
            foreach (TimeZoneInfo timeZone in timeZones)
            {
                if (timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset))
                {
                    Console.WriteLine("   {0}", timeZone.DisplayName);
                }
            }


        }

        public static void DeconstructVersion()
        {
            Version version = new(12, 0, 1, 1);

            var (major, minor, build, revision) = version;
        }
        public static void ConventionalVersion()
        {
            Version version = new(12, 0, 1, 1);

            var major = version.Major;
            var minor = version.Minor;
            var build = version.Build;

        }
        public static void MixingDeclarationAndAssignment()
        {
                string city = "Raleigh";
                int population = 458880;

                (city, population, double area) = QueryCityData("New York City");

                Console.WriteLine();

        }
        private static (string, int, double) QueryCityData(string name) 
            => name == "New York City" ? (name, 8175133, 468.48) : ("", 0, 0);


        public static void ChunkDateTimeOffset()
    {
        var date = new DateTimeOffset(Now.Year, Now.Month, Now.Day, 0, 0, 0, 0, TimeSpan.Zero);
        var (day, month, year) = date.Chunk();
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
