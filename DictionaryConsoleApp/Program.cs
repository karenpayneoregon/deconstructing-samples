﻿using DictionaryConsoleApp.Models;
using Microsoft.Extensions.Configuration;
using Spectre.Console;

namespace DictionaryConsoleApp;

partial class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        var configuration = builder.Build();

        Recipient[] recipients = configuration.GetSection("Recipients").Get<Recipient[]>();
            
        Dictionary<string, Recipient> dictionary = recipients.ToDictionary(recipient => 
            recipient.Data.ShortName, recipient => recipient);

        // conventional
        AnsiConsole.MarkupLine("[cyan]Conventional[/]");
        foreach (KeyValuePair<string, Recipient> recipient in dictionary)
        {
            Console.WriteLine(recipient.Key);
            foreach (Unit unit in recipient.Value.Data.Units)
            {
                Console.WriteLine($"\t{unit.UnitName,-4}{string.Join(",", unit.Details)}");
            }
        }

        AnsiConsole.WriteLine();
        // deconstruct 
        AnsiConsole.MarkupLine("[cyan]Deconstruct[/]");
        foreach ((string name, Recipient recipient) in dictionary)
        {
            Console.WriteLine(name);
            foreach (Unit unit in recipient.Data.Units)
            {
                Console.WriteLine($"\t{unit.UnitName,-4}{string.Join(",", unit.Details)}");
            }
        }

        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("Press any [b]key[/] to close");
        Console.ReadLine();

    }
}