using System.Runtime.Serialization;
using Bogus;

namespace ForWritingArticle.LanguageExtensions
{
    public static class ExtensionsForBogus
    {
        public static Faker<T> WithRecord<T>(this Faker<T> faker) where T : class
        {
            faker.CustomInstantiator( _ => FormatterServices.GetUninitializedObject(typeof(T)) as T);
            return faker;
        }

    }
}