using ConsoleApp_csharp10.Classes;
using ConsoleApp_csharp10.Models;

namespace ConsoleApp_csharp10;

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

        var dateTimeOffset = new DateTimeOffset(2022, 9, 2, 0, 0, 0, 0, TimeSpan.Zero);
        
        
        var (day, month, year) = dateTimeOffset;


        DateOnly dateOnly = new DateOnly(2022, 9, 2);


        var (day1, month1, year1) = dateOnly;


        Console.ReadLine();
    }
}