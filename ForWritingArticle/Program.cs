using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForWritingArticle.Data;
using ForWritingArticle.Models;
using Microsoft.EntityFrameworkCore;

namespace ForWritingArticle
{
    partial class Program
    {
        static async Task Main(string[] args)
        {
            var (success, customers, _ ) = await DataOperations.GetCustomersList();

            if (success)
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.CompanyName);
                }
            }
            else
            {
                Console.WriteLine("Could not read data");
            }
        }
    }



    public class DataOperations
    {
        public static async Task<(bool success, List<Customers> customers, Exception exception)> GetCustomersList()
        {
            try
            {
                await using NorthContext context = new();
                return 
                    (
                        true,
                        await context.
                            Customers
                            .Include(c => c.ContactTypeIdentifierNavigation)
                            .ToListAsync(), 
                        null
                    );
            }
            catch (Exception ex)
            {
                // write to error log
                return (false,null, ex);
            }
        }
    }

    
}
