using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForWritingArticle.Classes;
using ForWritingArticle.Data;
using ForWritingArticle.Models;
using Microsoft.EntityFrameworkCore;

namespace ForWritingArticle
{
    partial class Program
    {
        static async Task Main(string[] args)
        {
            //await NorthOperations.NorthCustomers();
            //await BookOperations.GroupBooks();

            await Task.Delay(0);

            var peopleDictionary = new Dictionary<string, int>
            {
                ["Mary"] = 32, 
                ["Frank"] = 17
            };

            foreach (var (name, age) in peopleDictionary.Select(x => (x.Key, x.Value)))
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

            Console.ReadLine();
        }

    }
}
