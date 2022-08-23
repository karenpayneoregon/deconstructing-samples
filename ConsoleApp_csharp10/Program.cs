using ConsoleApp_csharp10.Models;

namespace ConsoleApp_csharp10
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                FirstName = "Karen",
                LastName = "Payne"
            };

            string lastname = "Does not matter :-)";
            (string firstname, lastname) = person;

            AnsiConsole.MarkupLine($"[b]Hello[/] [yellow]{firstname}[/] [cyan]{lastname}[/]");
            Console.ReadLine();
        }
    }
}