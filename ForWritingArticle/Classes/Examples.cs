namespace ForWritingArticle.Classes;
public partial class DictionaryExamples
{
    public static void DictionaryExample()
    {
        var peopleDictionary = PeopleDictionary();

        foreach (KeyValuePair<string, int> pair in peopleDictionary)
        {
            Console.WriteLine($"{pair.Key} is {pair.Value} years old");
        }

        Console.WriteLine();

        foreach (var (name, age) in peopleDictionary)
        {
            Console.WriteLine($"{name} is {age} years old");
        }
    }

    private static Dictionary<string, int> PeopleDictionary() => new()
    {
        ["Mary"] = 32,
        ["Frank"] = 17,
        ["Karen"] = 66
    };
}
