using System.Runtime.Serialization;
using Bogus;

namespace ForWritingArticle.LanguageExtensions
{
    public static class ExtensionsForBogus
    {
        /// <summary>
        /// Configures a <see cref="Faker{T}"/> instance to create uninitialized objects of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of objects to generate. Must be a reference type.</typeparam>
        /// <param name="faker">The <see cref="Faker{T}"/> instance to configure.</param>
        /// <returns>The configured <see cref="Faker{T}"/> instance.</returns>
        public static Faker<T> ForRecord<T>(this Faker<T> faker) where T : class
        {
            faker.CustomInstantiator( _ => FormatterServices.GetUninitializedObject(typeof(T)) as T);
            return faker;
        }

    }
}