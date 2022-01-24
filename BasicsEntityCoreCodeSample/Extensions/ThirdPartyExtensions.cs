using SomeThirdPartyLibrary.Classes;

namespace DeconstructCodeSamples.Extensions
{
    public static class ThirdPartyExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="id">customer key</param>
        /// <param name="companyName">customer's company name</param>
        /// <param name="contactIdentifier">customer's contact identifier</param>
        /// <param name="countryIdentifier">country identifier for customer</param>
        public static void Deconstruct(this Customer customer, out int id, out string companyName, out int? contactIdentifier, out int? countryIdentifier)
        {
            id = customer.CustomerIdentifier;
            companyName = customer.CompanyName;
            contactIdentifier = customer.ContactId;
            countryIdentifier = customer.CountryIdentifier;
        }
    }
}
