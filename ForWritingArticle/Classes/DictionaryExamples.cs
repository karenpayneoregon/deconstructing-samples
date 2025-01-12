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

            /*
             * Conventional foreach using Key and Value
             */
            foreach (KeyValuePair<string, int> pair in peopleDictionary)
            {
                Console.WriteLine($"{pair.Key} is {pair.Value} years old");
            }
            
            Console.WriteLine();

            /*
             * Here the foreach has been deconstructed using meaningful variable names
             */
            foreach (var (name, age) in peopleDictionary)
            {
                Console.WriteLine($"{name} is {age} years old");
            }

        }
    }
}
