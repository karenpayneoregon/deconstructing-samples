using static System.DateTime;

namespace ForWritingArticle.Classes;

    internal class QuestionOfTheDay
    {
        public static void Which()
        {
            Dictionary<string, DateOnly> excelDictionary = new()
                {
                    { "H4", new(2017, 1, 1) }, { "H5", new(2017, 1, 2) },
                    { "H6", new(2017, 1, 3) }, { "H7", new(2017, 1, 4) }
                };


            foreach (var item in excelDictionary)
            {
                Console.WriteLine($"{item.Key,-4}{item.Value.Day,-4}{item.Value.Month,-4}{item.Value.Year}");
                Console.WriteLine($"{item.Key,-4}{item.Value:MM/dd/yyyy}");
                
            }


            foreach (var (cellAddress, (day, month, year)) in excelDictionary)
            {
                Console.WriteLine($"{cellAddress,-4}{day,-4}{month,-4}{year}");
            }

            Console.WriteLine($"Today is {Now:MM/dd/yyyy}");
     
        }
    }

    public static class CommonDeconstruct
    {
        public static void Deconstruct(this DateOnly date, out int day, out int month, out int year) =>
            (day, month, year) = (date.Day, date.Month, date.Year);
    }



