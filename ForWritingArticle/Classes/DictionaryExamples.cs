using System;
using System.Collections.Generic;
using System.Linq;

namespace ForWritingArticle.Classes
{
    public class DictionaryExamples
    {
        public static void PeopleOptions()
        {
            var peopleDictionary = new Dictionary<string, int>
            {
                ["Mary"] = 32, ["Frank"] = 17
            };

            foreach (var (name, age) in peopleDictionary.Select(kvp => (kvp.Key, kvp.Value)))
            {
                Console.WriteLine($"{name} is {age} years old.");
            }

            Console.WriteLine();
            foreach (var pair in peopleDictionary)
            {
                Console.WriteLine($"{pair.Key} is {pair.Value} years old");
            }
            
            Console.WriteLine();
            foreach (var (name, age) in peopleDictionary)
            {
                Console.WriteLine($"{name} is {age} years old");
            }

        }
    }
}
