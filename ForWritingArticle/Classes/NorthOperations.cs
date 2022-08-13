using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForWritingArticle.Data;
using ForWritingArticle.Models;
using Microsoft.EntityFrameworkCore;

namespace ForWritingArticle.Classes
{
    public class NorthOperations
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

        public static async Task NorthCustomers()
        {
            var (success, customers, _) = await GetCustomersList();

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
}