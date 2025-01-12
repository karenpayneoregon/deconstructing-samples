using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsCodeSamples.Classes
{
    public class DataOperations
    {
        public static readonly string ConnectionStringGood =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2020;" + 
            "Integrated Security=True";

        /// <summary>
        /// Example which attempts to read tables from SQL-Server, setup for failure
        /// as the connection string points to a non-existing database.
        ///
        /// Here if there is an issue the method returns an empty DataTable, the caller
        /// checks to see if there are rows, if not show a generic message.
        ///
        /// This entire method is bad, we can do better with value tuple.
        /// 
        /// </summary>
        /// <param name="ct">Token with time-out set</param>
        /// <returns>DataTable</returns>
        public static async Task<DataTable> ReadCustomersConventional(CancellationToken ct)
        {
            SqlConnection cn = new (
                "Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2020DoesNotExists;" + 
                "Integrated Security=True"
            );

            SqlCommand cmd = new () { Connection = cn };
            DataTable customerDataTable = new ();

            cmd.CommandText = _selectCustomersWithJoinsQuery;

            try
            {

                await cn.OpenAsync(ct);
                customerDataTable.Load(await cmd.ExecuteReaderAsync(ct));

            }
            catch (Exception)
            {
                return new DataTable();
            }

            return customerDataTable;

        }

        /// <summary>
        /// Next level from <see cref="ReadCustomersConventional"/>
        /// 
        /// This method uses named value tuple, DataTable and Exception for return types
        /// rather than simply a DataTable. In this case a developer can determine if
        /// any errors occurred while reading data unlike <see cref="ReadCustomersConventional"/>
        /// which only returns a DataTable.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public static async Task<(DataTable, Exception)> ReadCustomersWithTuple(CancellationToken ct)
        {
            SqlConnection cn = new(ConnectionStringGood);

            SqlCommand cmd = new() { Connection = cn };
            DataTable customerDataTable = new();

            cmd.CommandText = _selectCustomersWithJoinsQuery;

            try
            {

                await cn.OpenAsync(ct);
                customerDataTable.Load(await cmd.ExecuteReaderAsync(ct));

            }
            catch (Exception exception)
            {
                return (null, exception);
            }

            return (customerDataTable, null)!;

        }

        /// <summary>
        /// Gets the SQL query string used to retrieve customer data with joins.
        /// </summary>
        /// <remarks>
        /// This query joins the Customers, ContactType, Countries, and Contacts tables to 
        /// retrieve detailed customer information, including identifiers, company name, 
        /// contact details, address, and country name.
        /// </remarks>
        private static string _selectCustomersWithJoinsQuery =>
            """
            SELECT C.CustomerIdentifier, C.CompanyName, C.ContactId, CT.ContactTitle, CN.FirstName, CN.LastName, C.Street, C.City, C.PostalCode, C.CountryIdentifier, C.Phone, C.ContactTypeIdentifier, CO.Name AS CountryName 
            FROM Customers AS C 
            INNER JOIN ContactType AS CT ON C.ContactTypeIdentifier = CT.ContactTypeIdentifier 
            INNER JOIN Countries   AS CO ON C.CountryIdentifier = CO.CountryIdentifier 
            INNER JOIN Contacts    AS CN ON C.ContactId = CN.ContactId AND CT.ContactTypeIdentifier = CN.ContactTypeIdentifier
            """;
    }
}
