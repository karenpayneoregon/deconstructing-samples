using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForWritingArticle.Data;
using ForWritingArticle.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace ForWritingArticle.Classes
{
    public class BookOperations
    {
        public static async Task GroupBooks()
        {
            await using var context = new BooksContext();

            var books = await context.Book.ToListAsync();

            Dictionary<string, IGrouping<string, Book>> results = books
                .GroupBy(book => book.Price switch
                {
                    <= 10 => "Cheap",
                    > 10 and <= 20 => "Medium",
                    _ => "Expensive"
                })
                .ToDictionary(gb =>
                        gb.Key,
                    g => g);


            AnsiConsole.MarkupLine("[cyan]Conventional foreach[/]");

            foreach (KeyValuePair<string, IGrouping<string, Book>> pair in results)
            {
                Console.WriteLine(pair.Key);
                foreach (var book in pair.Value)
                {
                    Console.WriteLine($"\t{book.Title,-25}{book.Price:C0}");
                }
            }

            Console.WriteLine();
            AnsiConsole.MarkupLine("[yellow]Deconstruct foreach[/]");

            foreach (var (pricingCategory, bookGrouping) in results)
            {
                Console.WriteLine(pricingCategory);
                foreach (var book in bookGrouping)
                {
                    Console.WriteLine($"\t{book.Title, -25}{book.Price:C0}");
                }
            }
        }
    }
}
