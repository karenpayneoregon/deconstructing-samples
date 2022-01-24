using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeconstructCodeSamples.Models;
using SomeThirdPartyLibrary.Classes;

namespace DeconstructCodeSamples.Classes
{
    class CustomerOperations
    {
        private static string _fileName = "Customers.json";
        private static List<Customer> _customers = new ();
        public static List<Customer> GetCustomers()
        {
            var (customers, _ ) = JsonHelpers.JsonToList<Customer>(_fileName);
            _customers = customers;
            return customers;
        }

        public static List<CustomerItem> CustomerItems()
            => GetCustomers()
                .Select(customer => new CustomerItem()
                {
                    CustomerIdentifier = customer.CustomerIdentifier, 
                    CompanyName = customer.CompanyName
                })
                .ToList();

        public static Customer CustomerByIdentifier(int identifier) 
            => _customers.FirstOrDefault(customer => customer.CustomerIdentifier == identifier);
    }
}
