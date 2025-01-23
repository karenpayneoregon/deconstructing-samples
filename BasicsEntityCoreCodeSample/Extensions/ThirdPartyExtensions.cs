using SomeThirdPartyLibrary.Models;

namespace DeconstructCodeSamples.Extensions;

public static class ThirdPartyExtensions
{
    /// <summary>
    /// Deconstructs a <see cref="Customer"/> object into its individual components.
    /// </summary>
    /// <param name="customer">The <see cref="Customer"/> instance to deconstruct.</param>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <param name="companyName">The name of the company associated with the customer.</param>
    /// <param name="contactIdentifier">The contact identifier of the customer, or <c>null</c> if not available.</param>
    /// <param name="countryIdentifier">The country identifier of the customer, or <c>null</c> if not available.</param>
    public static void Deconstruct(this Customer customer, 
        out int id, out string companyName, out int? contactIdentifier, out int? countryIdentifier)
    {
        id = customer.CustomerIdentifier;
        companyName = customer.CompanyName;
        contactIdentifier = customer.ContactId;
        countryIdentifier = customer.CountryIdentifier;
    }
}