﻿using System;
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
            await Task.Delay(0);

            DictionaryExamples.PeopleOptions();
            await BookOperations.GroupBooks();
            //await NorthOperations.NorthCustomers();
            //OffTheReservation.StarWars();


            Console.ReadLine();
        }

    }
}
