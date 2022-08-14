using System;
using System.Collections.Generic;
using System.Linq;
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

            /*
             * Group Books by price range, convert to a Dictionary
             */
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

            /*
             * Conventional foreach using Key and Value
             */
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

            /*
             * Here the foreach has been deconstructed using meaningful variable names
             */
            foreach ((string pricingCategory, IGrouping<string, Book> bookGrouping) in results)
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
